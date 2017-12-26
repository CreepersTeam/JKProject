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

using SysCfg;
using WCFClient;

namespace ProcessCtl
{
    /// <summary>
    /// 人工模组绑定
    /// </summary>
    public class NodeManualBind : CtlNodeBaseModel
    {
        private int snSize = 10; // 人工绑定电池码的个数
        private string StartBarcode = "START"; //扫码时必须要扫的第一个码

        public int SNSize { get { return snSize; } }


        public NodeManualBind()
        {

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
            }
            this.dicCommuDataDB1[1].DataDescription = "第一组模组 1：复位,2：装载合格,3：异常";
            this.dicCommuDataDB1[2].DataDescription = "第二组模组 1：复位,2：装载合格,3：异常";

            this.dicCommuDataDB2[1].DataDescription = "第一组模组 1：复位,2：装载完成完成";
            this.dicCommuDataDB2[2].DataDescription = "第二组模组 1：复位,2：装载完成完成";
            currentTaskPhase = 0;

            return true;
        }

        EnumAsrsTaskType GetTaskTypeByNodeName(string nodeName)
        {
            if (nodeName == "扫码工位1")
            {
                return EnumAsrsTaskType.扫码工位1;
            }
            else if (nodeName == "扫码工位2")
            {
                return EnumAsrsTaskType.扫码工位2;
            }
            else if (nodeName == "扫码工位3")
            {
                return EnumAsrsTaskType.扫码工位3;
            }
            else
            {
                return EnumAsrsTaskType.空;
            }
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
                        currentTaskDescribe = "开始执行扫描任务";
                        this.db1ValsToSnd[0] = 2;
                        this.currentTaskPhase++;
                        this.currentTask.TaskPhase = this.currentTaskPhase;
                        this.ctlTaskBll.Update(this.currentTask);
                        logRecorder.AddDebugLog(nodeName, string.Format("等待第一组模组开始扫描完成"));
                        break;
                    }
                case 2:
                    {
                        if (db2Vals[0] != 2)
                        {
                            break;
                        }

                        if (db1ValsToSnd[0] != 4)
                        {
                            logRecorder.AddDebugLog(this.nodeName, "第一组模组开始验证");
                        }
                        List<string> barcodes = new List<string>();
                        // 获取读取到的BarCode列表
                        if (SysCfg.SysCfgModel.SimMode)
                        {
                            GenerateSimBarCode(ref barcodes);
                        }
                        else
                        {
                            barcodes = barcodeRW.GetBarcodesBuf();//
                            //验证BarCode的格式START
                            if (!VerifyBarcode(ref barcodes))
                            {
                                if (db1ValsToSnd[0] != 4)
                                {
                                    logRecorder.AddDebugLog(this.nodeName, "第一组模组验证失败");
                                }
                                db1ValsToSnd[0] = 4;
                                return false;
                            }
                            logRecorder.AddDebugLog(this.nodeName, "第一组模组验证成功");
                            //验证BarCode的格式END
                        }

                        // TODO:上传到MES系统START

                        // 上传到MES系统END

                        logRecorder.AddDebugLog(this.nodeName, "第一组模组验证成功");

                        this.db1ValsToSnd[0] = 3;
                        this.currentTaskPhase++;
                        this.currentTask.TaskPhase = this.currentTaskPhase;
                        this.ctlTaskBll.Update(this.currentTask);
                        logRecorder.AddDebugLog(nodeName, "等待第二组模组扫码.......");
                        break;
                    }
                case 3:
                    {
                        currentTaskDescribe = "等待第二组模组扫码.......";
                        if (db2Vals[1] != 2)
                        {
                            break;
                        }
                        if (db1ValsToSnd[1] != 4)
                        {
                            logRecorder.AddDebugLog(this.nodeName, "第二组模组开始验证");
                        }
                        List<string> barcodes = new List<string>();
                        // 获取读取到的BarCode列表
                        if (SysCfg.SysCfgModel.SimMode)
                        {
                            GenerateSimBarCode(ref barcodes);
                        }
                        else
                        {
                            barcodes = barcodeRW.GetBarcodesBuf();//
                            //验证BarCode的格式START
                            if (!VerifyBarcode(ref barcodes))
                            {
                                if (db1ValsToSnd[1] != 4)
                                {
                                    logRecorder.AddDebugLog(this.nodeName, "第二组模组验证失败");
                                }
                                db1ValsToSnd[1] = 4;
                                return false;
                            }
                            //验证BarCode的格式END
                        }
                        
                      
                        // TODO:上传到MES系统START

                        // 上传到MES系统END

                        logRecorder.AddDebugLog(this.nodeName, "第二组模组验证成功");

                        this.currentTaskPhase++;
                        this.currentTask.TaskPhase = this.currentTaskPhase;
                        this.ctlTaskBll.Update(this.currentTask);
                        this.db1ValsToSnd[1] = 2;
                        break;
                    }
                case 4:
                    {

                        if ((this.db1ValsToSnd[0] != 1) || (this.db1ValsToSnd[1] != 1))
                        {
                            break;
                        }

                        //TODO: 更新OnLine数据库 START
                        //AddProduceRecord(this.rfidUID, string.Format("卸载:{0}", nodeName));
                        // 更新OnLine数据库 END 

                        logRecorder.AddDebugLog(nodeName, "更新数据库成功,扫描完成");
                        this.currentTask.FinishTime = System.DateTime.Now;
                        this.currentTask.TaskStatus = SysCfg.EnumTaskStatus.已完成.ToString();
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

       void  GenerateSimBarCode(ref List<string> barcodes)
       {
           barcodes.Add(StartBarcode);
           for (int i = 0; i < snSize + 2; i++)
           {
               string barcodeID = string.Format("BarCode-{0}-{1}", (i + 1).ToString().PadLeft(6, '0'),System.DateTime.Now.ToLongTimeString());
               barcodes.Add(barcodeID);
           }
       }


         // TODO:查找工位号码的 字符串
       public bool ListFind1(string name)
       {
           return true;
       }

       // TODO:查找工位号码的 字符串
       public bool ListFind2(string name)
       {
           return true;
       }

       // TODO:查找工位号码的 字符串
       public bool ListFind3(string name)
       {
           return true;
       }
        bool VerifyBarcode(ref List<string> barcodes)
        {
            //// 找到最后一个StartBarcode 
            //int index = 0;
            //int startIndex = 0;
            //foreach(string singleBarcode in barcodes)
            //{
            //    if(singleBarcode.ToUpper() == StartBarcode)
            //    {
            //        startIndex = index;
            //    }
            //    else
            //    {
            //        index++;
            //    }
            //}

            //// 将在查找到的Barcode之前的都删除 
            //barcodes.RemoveRange(0, (startIndex + 1));

            // 判断个数是否正确
            if(barcodes.Count != this.snSize + 2 )
            {
                return false;
            }

            // 判断是否含有工位工号
            List<string> subList = barcodes.FindAll(ListFind1); 
            if(subList.Count != 1)
            {
                return false;
            }

            // 
            subList = barcodes.FindAll(ListFind2);
            if (subList.Count != 1)
            {
                return false;
            }

            subList = barcodes.FindAll(ListFind3);
            if (subList.Count != snSize)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 任务申请
        /// </summary>
        private bool FillTaskRequire(ref string reStr)
        {
            string getBarcode = string.Empty;
            if (SysCfg.SysCfgModel.SimMode)
            {
                getBarcode = StartBarcode;
            }
            else
            {
                getBarcode = barcodeRW.ReadBarcode();// 
            }

            if (string.IsNullOrWhiteSpace(getBarcode))
            {
                return false;
            }

            // 如果读取到的的Barcode 不是开始
            if (getBarcode != StartBarcode)
            {
                return false;
            }

            EnumAsrsTaskType taskType = GetTaskTypeByNodeName(this.nodeName);
            if (taskType != EnumAsrsTaskType.空)
            {
                if (ExistUnCompletedTask((int)taskType))
                {
                    return true;
                }
            }

            //生成新任务
            this.currentTaskPhase = 1;
            ControlTaskModel task = new ControlTaskModel();
            task.DeviceID = this.nodeID;
            task.CreateMode = "自动";
            task.CreateTime = System.DateTime.Now;
            task.TaskParam = this.nodeID;
            task.TaskID = System.Guid.NewGuid().ToString("N");
            task.TaskType = (int)taskType;
            task.TaskPhase = this.currentTaskPhase;
            task.TaskStatus = SysCfg.EnumTaskStatus.执行中.ToString();
            task.Remark = taskType.ToString();
            this.ctlTaskBll.Add(task);
            this.currentTask = task;
            currentTaskDescribe = "扫码任务生成";

            return true;

        }

 

    }
}

