using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Data;
using DevAccess;
using FlowCtlBaseModel;
using DevInterface;
using CtlDBAccess.Model;
using CtlDBAccess.BLL;
using XWEDBAccess.BLL;
using MesDBAccess.Model;
using XWEDBAccess.Model;
using WCFClient;
using SysCfg;

namespace ProcessCtl
{
    /// <summary>
    /// 电芯-托盘卸载
    /// </summary>
    public class NodePalletUnBind : CtlNodeBaseModel
    {
        private int snSize = 12;
        private string stockName = "";
        private int stepid = 1;
        
        private string testOK = "TRUE";
        private string testNG = "FALSE";

        public int SNSize { get { return snSize; } }
        private BatteryCodeBLL batteryBll = null; 

        public NodePalletUnBind()
        {
            batteryBll = new BatteryCodeBLL();
        }
        public override bool BuildCfg(System.Xml.Linq.XElement xe, ref string reStr)
        {
            if (!base.BuildCfg(xe, ref reStr))
            {
                return false;
            }
            XElement selfDataXE = xe.Element("SelfDatainfo");
            if (selfDataXE != null)
            {
                if (selfDataXE.Attribute("snSize") != null)
                {
                    this.snSize = int.Parse(selfDataXE.Attribute("snSize").Value.ToString());
                }
                if (selfDataXE.Attribute("storename") != null)
                {
                    this.stockName = selfDataXE.Attribute("storename").Value.ToString();
                }
                if (selfDataXE.Attribute("stepid") != null)
                {
                    this.stepid = int.Parse(selfDataXE.Attribute("stepid").Value.ToString());
                }
            }
            this.dicCommuDataDB1[1].DataDescription = "1：复位,2：读卡完成，放行空板到装载位置,3：读RFID失败";
            this.dicCommuDataDB1[2].DataDescription = "1：复位,2：参数写入完成，放行空板到装载位置,3：读RFID失败";

            for (int i = 0; i < snSize;i++ )
            {
                this.dicCommuDataDB1[2 + i + 1].DataDescription = "1:合格，2：不合格,3:该位置电芯为空";

            }

            this.dicCommuDataDB2[1].DataDescription = "1：无板，2：有板";
            this.dicCommuDataDB2[2].DataDescription = "1：未完成,2：卸载完成,3：撤销";
            currentTaskPhase = 0;

            return true;
        }
        public override bool ExeBusiness(ref string reStr)
        {
            if (!nodeEnabled)
            {
                return true;
            }
            // 查看此节点是否有任务在执行或排队
            if (!devStatusRestore)
            {
                devStatusRestore = DevStatusRestore();
            }
            if (!devStatusRestore)
            {
                return false;
            }

            if (db2Vals[0] != 2)
            {
                db1ValsToSnd[0] = 1;
                db1ValsToSnd[1] = 1;
            }
            //任务撤销
            if (db2Vals[1] == 3)
            {
                if (this.currentTask != null && this.currentTaskPhase > 0)
                {
                    this.currentTask.TaskStatus = SysCfg.EnumTaskStatus.任务撤销.ToString();
                    this.currentTask.FinishTime = System.DateTime.Now;
                    ctlTaskBll.Update(this.currentTask);

                    logRecorder.AddDebugLog(this.nodeName, "卸载任务撤销");
                    currentTaskDescribe = "卸载任务撤销";
                    this.currentTask = null;
                    this.currentTaskPhase = 0;
                }

                Array.Clear(this.db1ValsToSnd, 0, this.db1ValsToSnd.Count());
                db1ValsToSnd[0] = 1;
                db1ValsToSnd[1] = 1;
                return true;
            }

            if (!FillTaskRequire(ref reStr))
            {
                return false;
            }

            if (this.currentTask == null)
            {
                return true;
            }

            switch (this.currentTaskPhase)
            {
                case 1:
                    {
                        currentTaskDescribe = "开始执行卸载任务,RFID上报MES系统";
                        //将RFID上报MES系统
                        if (!SysCfg.SysCfgModel.SimMode)
                        {
                            if (!MESWCFManage.Inst().ReturnRFIDA(this.rfidUID))
                            {
                                logRecorder.AddDebugLog(nodeName, string.Format("{0} 读到托盘号后，RFID上报MES系统失败！", this.rfidUID));
                                break;
                            }
                        }

                        this.db1ValsToSnd[0] = 2;

                        this.currentTaskPhase++;
                        this.currentTask.TaskPhase = this.currentTaskPhase;
                        this.ctlTaskBll.Update(this.currentTask);
                        logRecorder.AddDebugLog(nodeName, string.Format("{0} 卸载,等待参数写入....", this.rfidUID));
                        break;
                    }
                case 2:                    
                    {
                        currentTaskDescribe = "卸载等待参数写入";
                        // ADD 
                        if ( !SysCfg.SysCfgModel.SimMode)
                        {
                            //将参数写入到PLC中 START
                            if(!WriteDataToPLC(this.rfidUID))
                            {
                                return false;
                            }
                            // 将参数写入到PLC中 END
                        }
                        logRecorder.AddDebugLog(nodeName, string.Format("{0} 参数写入完成，等待卸载完成...",this.rfidUID));
                      
                        currentTaskDescribe = "参数写入完成";

                        // 参数写入完成后 就需将读卡请求复位START
                        this.db1ValsToSnd[0] = 2;
                        // 参数写入完成后 就需将读卡请求复位END

                        this.currentTaskPhase++;
                        this.currentTask.TaskPhase = this.currentTaskPhase;
                        this.ctlTaskBll.Update(this.currentTask);

                        break;
                    }
                case 3:
                    {
                        currentTaskDescribe = "卸载中，等待完成....";
                        // 等待卸载完成
                        if (this.db2Vals[1] != 2)
                        {
                            break;
                        }

                        //更新OnLine数据库 START
                        // 完成卸载 ，从OnLine 数据库中 解绑
                        if (!productOnlineBll.UnbindPallet(this.rfidUID, ref reStr))
                        {
                            logRecorder.AddDebugLog(nodeName, reStr);
                            return false;
                        }
                        // 更新OnLine数据库 END 

                        // 卸载完成置2，其他所有数据复位 START
                        Array.Clear(db1ValsToSnd, 0, db1ValsToSnd.Count());
                        db1ValsToSnd[1] = 2;
                        db1ValsToSnd[0] = 1;
                        // 卸载完成置2，其他所有数据复位 END
                        this.currentTaskPhase++;
                        this.currentTask.TaskPhase = this.currentTaskPhase;
                        this.ctlTaskBll.Update(this.currentTask);

                        logRecorder.AddDebugLog(nodeName, string.Format("{0} 更新数据库成功,等待卸载完成信号复位", rfidUID));

                        break;
                    }
                case 4:
                    {
                        currentTaskDescribe = "等待卸载完成信号复位";
                        // 等待卸载完成
                        if (this.db2Vals[1] != 1)
                        {
                            break;
                        }

                        //收到卸载完成信号复位时，把卸载处理完成信号复位START
                        db1ValsToSnd[1] = 1;
                        //收到卸载完成信号复位时，把卸载处理完成信号复位END

                        this.currentTask.TaskStatus = SysCfg.EnumTaskStatus.已完成.ToString();
                        this.currentTask.FinishTime = System.DateTime.Now;                      
                        this.ctlTaskBll.Update(this.currentTask);
                        this.currentTask = null;
                        currentTaskPhase = 0;

                        logRecorder.AddDebugLog(nodeName, "等待执行下一个任务");
                        currentTaskDescribe = "等待执行下一个任务";
                        break;
                    }
                default:
                    break;
            }
            return true;
        }

        bool VerifyRFID(string readrfid)
        {
            if (SysCfg.SysCfgModel.SimMode || SysCfg.SysCfgModel.RfidSimMode)
            {
                return true;
            }
            return true;
        }


        EnumAsrsTaskType GetTaskTypeByNodeName(string nodeName)
        {
            if (nodeName == "卸载读卡A")
            {
                return EnumAsrsTaskType.卸载读卡A;
            }
            else if (nodeName == "卸载读卡B")
            {
                return EnumAsrsTaskType.卸载读卡B;
            }
            else
            {
                return EnumAsrsTaskType.空;
            }
        }

        /// <summary>
        /// 装载任务申请
        /// </summary>
        private bool FillTaskRequire(ref string reStr)
        {

            if (db2Vals[0] == 2 && db1ValsToSnd[0] != 2)
            {
                EnumAsrsTaskType taskType = GetTaskTypeByNodeName(this.nodeName);

                if (ExistUnCompletedTask((int)taskType))
                {
                    return true;
                }
                //先读RFID卡
                currentTaskDescribe = "开始读RFID";
                this.rfidUID = "";
                if (SysCfg.SysCfgModel.SimMode)
                {
                    this.rfidUID = this.SimRfidUID;
                }
                else
                {
                    this.rfidUID = rfidRW.ReadStrData();//
                }

                if (string.IsNullOrWhiteSpace(this.rfidUID))
                {
                    if (this.db1ValsToSnd[0] != 3)
                    {
                        logRecorder.AddDebugLog(nodeName, "读RFID失败");
                    }
                    this.db1ValsToSnd[0] = 3;
                    return true;
                }

                //验证RFID的格式START
                if (!VerifyRFID(this.rfidUID))
                {
                    if (this.db1ValsToSnd[0] != 3)
                    {
                        logRecorder.AddDebugLog(nodeName, string.Format("{0} RFID验证失败", this.rfidUID));
                    }
                    this.db1ValsToSnd[0] = 3;
                    return true;
                }

                logRecorder.AddDebugLog(this.nodeName, "读到托盘号:" + this.rfidUID);
                //验证RFID的格式END
                // 
                //生成新任务
                this.currentTaskPhase = 1;
                ControlTaskModel task = new ControlTaskModel();
                task.DeviceID = this.nodeID;
                task.CreateMode = "自动";
                task.CreateTime = System.DateTime.Now;
                task.TaskID = System.Guid.NewGuid().ToString("N");
                task.TaskType = (int)taskType;
                task.TaskParam = this.rfidUID;
                task.TaskPhase = this.currentTaskPhase;
                task.TaskStatus = SysCfg.EnumTaskStatus.执行中.ToString();
                task.Remark = taskType.ToString();
                task.tag1 = stockName;
                this.ctlTaskBll.Add(task);
                this.currentTask = task;
                currentTaskDescribe = "卸载任务生成";
                return true;
            }
            if (db2Vals[0] == 1 && this.currentTask == null)
            {
                this.db1ValsToSnd[0] = 1;
                this.db1ValsToSnd[1] = 1;
            }
            return true;
        }

        //将参数写入到PLC中 START
        bool  WriteDataToPLC(string rfid)
        {
            // 根据RFID获取 OnLine Product
            List<ProductOnlineModel>  products = productOnlineBll.GetProductsInPallet(rfid);
            //if(products.Count != snSize)
            //{
            //    logRecorder.AddDebugLog(nodeName, this.rfidUID + " 将参数写入PLC时，获取到的Product个数不正确:" + products.Count);
            //    return false;
            //}

            for (int i = 0; i < snSize; i++)
            {
                //
                ProductOnlineModel singleProduct = products.Find(item => item.tag1 == (i + 1).ToString());
                if (singleProduct != null)
                {
                    BatteryCodeModel batteryInfo = batteryBll.GetModelByCode(singleProduct.productID);
                    if (singleProduct != null)
                    {
                        if (batteryInfo.TestResult.ToUpper() == testOK)
                        {
                            // 如果测试结果OK，将PLC相应的位置1
                            this.db1ValsToSnd[i + 2] = 1;
                        }
                        else if (batteryInfo.TestResult.ToUpper() == testNG)
                        {
                            // 如果测试结果NG，将PLC相应的位置2
                            this.db1ValsToSnd[i + 2] = 2;
                        }
                    }
                    else
                    {
                        // 如果没找到此条数据，将PLC相应的位置3
                        this.db1ValsToSnd[i + 2] = 3;
                    }
                }
                else
                {
                    // 如果没找到此条数据，将PLC相应的位置3
                    this.db1ValsToSnd[i + 2] = 3;
                }
            }

            return true;
        }
        //将参数写入到PLC中 END

    }
}

