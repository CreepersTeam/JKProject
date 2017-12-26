using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevAccess;
using FlowCtlBaseModel;
using CtlDBAccess.Model;
using CtlDBAccess.BLL;
namespace ProcessCtl
{
    //OCV测试后分拣
    public class NodeGrasp : CtlNodeBaseModel
    {
     
        private OcvAccess ocvAccess = null;
        public OcvAccess OcvAccess { get { return ocvAccess; } set { ocvAccess = value; } }
        public NodeGrasp()
        {
            ctlTaskBll = new ControlTaskBll();
            
        }
        public override bool BuildCfg(System.Xml.Linq.XElement xe, ref string reStr)
        {
            if (!base.BuildCfg(xe, ref reStr))
            {
                return false;
            }
            this.dicCommuDataDB1[1].DataDescription = "1:未完成，2：写入完成，3：读RFID失败，4:托盘信息不存在";
            this.dicCommuDataDB1[2].DataDescription = "1:未处理完成，2：处理完成,3:任务撤销";
            if(this.nodeID=="6002")
            {
                this.dicCommuDataDB1[3].DataDescription = "OCV标识，1:OCV2,2:OCV4";
                for (int i = 0; i < 36; i++)
                {
                    this.dicCommuDataDB1[4 + i].DataDescription = string.Format("通道:{0}状态，1:合格，2：NG，3：该位置无电芯，4：需要补电", i + 1);
                }
            }
            else
            {
                for (int i = 0; i < 36; i++)
                {
                    this.dicCommuDataDB1[3 + i].DataDescription = string.Format("通道:{0}状态，1:合格，2：NG，3：该位置无电芯，4：需要补电", i + 1);
                }
            }
            this.dicCommuDataDB2[1].DataDescription = "1：无板，2：有板";
            this.dicCommuDataDB2[2].DataDescription = "1：分拣未完成，2：分拣完成，3: 撤销处理完成";
          
               
            currentTaskPhase = 0;

            return true;
        }
        public override bool ExeBusiness(ref string reStr)
        {
            if (!nodeEnabled)
            {
                return true;
            }
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
            }

            //任务撤销
            if (db2Vals[1] == 3 && db1ValsToSnd[1] != 3)
            {
                if (this.currentTask != null && this.currentTaskPhase > 0)
                {
                    this.currentTask.TaskStatus = SysCfg.EnumTaskStatus.任务撤销.ToString();
                    this.currentTask.FinishTime = System.DateTime.Now;
                    ctlTaskBll.Update(this.currentTask);

                    logRecorder.AddDebugLog(this.nodeName, string.Format("分拣任务{0}撤销",this.currentTask.TaskID));
                    currentTaskDescribe = "分拣任务撤销，等待任务撤销信号复位";
                    this.currentTask = null;
                    this.currentTaskPhase = 0;
                }
                Array.Clear(this.db1ValsToSnd, 0, this.db1ValsToSnd.Count());
                db1ValsToSnd[1] = 3;//

                return true;
            }
            if (db1ValsToSnd[1] == 3 && db2Vals[1] !=2)
            {
                //任务撤销命令复位，应答也复位
                db1ValsToSnd[1] = 1;
            }

            if(!GraspTaskRequire(ref reStr))
            {
                return false;
            }
            if (this.currentTask == null)
            {
                return true;
            }
            switch(this.currentTaskPhase)
            {
                case 1:
                    {
                        currentTaskDescribe = "开始执行分拣任务";
                       // int ocvProcessID = 1;//zwx,临时
                        List<int> ocvTestSeqIDS = new List<int>();
                        int testValStIndex = 2;
                       if(this.nodeID=="6002")
                       {
                           testValStIndex = 3;
                           string curMesProcessID = this.productOnlineBll.GetProcessIDOfPallet(this.rfidUID);
                           if (string.IsNullOrWhiteSpace(curMesProcessID))
                           {

                               this.db1ValsToSnd[2] = 1; //OCV2
                           }
                           else
                           {
                               int curSeq = SysCfg.SysCfgModel.stepSeqs.IndexOf(curMesProcessID);
                               int ocv2Seq = SysCfg.SysCfgModel.stepSeqs.IndexOf("PS-70");
                               if (curSeq <= ocv2Seq)
                               {

                                   this.db1ValsToSnd[2] = 1; //OCV2
                               }
                               else
                               {

                                   this.db1ValsToSnd[2] = 2; //OCV4
                               }
                           }
                       }
                        
                        if (this.nodeID == "6001")
                        {
                            //检测OCV1数据
                            ocvTestSeqIDS.Add(1);
                        }
                        else if (this.nodeID == "6002")
                        {
                             if(this.db1ValsToSnd[2] ==1)
                             {
                                 ocvTestSeqIDS.Add(2); //检测OCV2数据
                             }
                             else
                             {
                                 ocvTestSeqIDS.Add(5);//检测OCV4数据
                             }
                        }
                        else
                        {
                            //检测分容，OCV3数据
                            ocvTestSeqIDS.Add(3);
                            ocvTestSeqIDS.Add(4);
                        }
                        //查询测试结果
                       
                        List<int> vals = new List<int>();
                        if(SysCfg.SysCfgModel.SimMode)
                        {
                            for(int i=0;i<36;i++)
                            {
                                vals.Add(1);
                            }
                        }
                        else
                        {
                            //List<int> ocvTestSeqIDS = new List<int>();
                           
                            if (!ocvAccess.GetCheckResult(this.rfidUID, ocvTestSeqIDS, ref vals, ref reStr))
                            {
                                if(db1ValsToSnd[0] != 4)
                                {
                                    logRecorder.AddDebugLog(nodeName,string.Format("查询OCV测试结果失败,{0},{1}",this.rfidUID,reStr));
                                }
                                db1ValsToSnd[0] = 4;
                                break;
                            }
                        }

                        //发送分拣参数
                        for (int i = 0; i < Math.Max(36, vals.Count()); i++)
                        {
                            Int16 re =(short)vals[i];
                            db1ValsToSnd[testValStIndex + i] = re;
                        }
                        db1ValsToSnd[0] = 2;
                        currentTaskDescribe = "分拣参数发送完成";
                        this.currentTaskPhase++;
                        this.currentTask.TaskPhase = this.currentTaskPhase;
                        this.ctlTaskBll.Update(this.currentTask);
                        break;
                    }
              
                case 2:
                    {
                        //等待任务完成
                        currentTaskDescribe = "等待分拣完成";
                        if (db2Vals[1] != 2)
                        {
                            break; 
                        }
                       
                        UpdateOnlineProductInfo(this.rfidUID);
                        AddProduceRecord(this.rfidUID, string.Format("分拣:{0}", nodeName));
                        this.currentTaskPhase++;
                      
                        this.currentTask.TaskPhase = this.currentTaskPhase;
                        this.ctlTaskBll.Update(this.currentTask);
                        db1ValsToSnd[1] = 2;
                        break;
                    }
                case 3:
                    {
                        currentTaskDescribe = "分拣流程完成，等待分拣完成信号复位";
                        if (this.db2Vals[1] != 1)
                        {
                            break;
                        }
                        DevCmdReset();
                        this.currentTask.TaskStatus = SysCfg.EnumTaskStatus.已完成.ToString();
                        this.ctlTaskBll.Update(this.currentTask);

                        this.currentTask = null;
                        currentTaskPhase = 0;
                        currentTaskDescribe = "等待执行下一个任务";
                        break;
                    }
                default:
                    break;
            }
            return true;
        }
       
        /// <summary>
        /// 分拣任务申请
        /// </summary>
        private bool GraspTaskRequire(ref string reStr)
        {

            //if (db2Vals[0] == 1)
            //{
            //    currentTaskPhase = 0;
            //    db1ValsToSnd[0] = 1;

            //    rfidUID = string.Empty;
            //    currentTaskDescribe = "等待新的任务";
            //    return;
            //}
            if (db2Vals[0] == 2 && db1ValsToSnd[1] != 2)
            {
                if (ExistUnCompletedTask((int)SysCfg.EnumAsrsTaskType.OCV测试分拣))
                {
                    return true;
                }
                //先读RFID卡
                currentTaskDescribe = "开始读RFID";
                this.rfidUID = "";
                if (SysCfg.SysCfgModel.SimMode || SysCfg.SysCfgModel.RfidSimMode)
                {
                    this.rfidUID = this.SimRfidUID;
                }
                else
                {
                    this.rfidUID = rfidRW.ReadStrData();// rfidRW.ReadUID();
                   
                }
                if (string.IsNullOrWhiteSpace(this.rfidUID))
                {
                    if (this.db1ValsToSnd[0] != 3)
                    {
                        logRecorder.AddDebugLog(nodeName, "读RFID失败");
                        this.currentTaskDescribe = "读RFID失败";
                    }
                    this.db1ValsToSnd[0] = 3;
                    return true;
                }
                if (this.rfidUID.Length < 9)
                {
                    if (this.db1ValsToSnd[0] != 3)
                    {
                        logRecorder.AddDebugLog(nodeName, "读料框RFID错误，长度不足9字符！");
                    }
                    this.db1ValsToSnd[0] = 3;
                    return true;
                }

                if (this.rfidUID.Length > 9)
                {
                    this.rfidUID = this.rfidUID.Substring(0, 9);
                }
                if(db1ValsToSnd[0] == 1 || db1ValsToSnd[0] == 3)
                {
                    logRecorder.AddDebugLog(this.nodeName, "读到托盘号:" + this.rfidUID);
                    this.currentTaskDescribe = "读到托盘号:" + this.rfidUID;
                }
               
                List<MesDBAccess.Model.ProductOnlineModel> bindedProducts = productOnlineBll.GetProductsInPallet(this.rfidUID);
                if(bindedProducts == null || bindedProducts.Count()<1)
                {
                    this.db1ValsToSnd[0] = 4;
                    this.currentTaskDescribe = string.Format("{0}无绑定数据",this.rfidUID);
                    return true;
                }
                //生成新任务
                this.currentTaskPhase = 1;
                ControlTaskModel task = new ControlTaskModel();
                task.DeviceID = this.nodeID;
                task.CreateMode = "自动";
                task.CreateTime = System.DateTime.Now;
                task.TaskID = System.Guid.NewGuid().ToString("N");
                task.TaskStatus = SysCfg.EnumTaskStatus.待执行.ToString();
                task.TaskType = (int)SysCfg.EnumAsrsTaskType.OCV测试分拣;
                task.TaskParam = this.rfidUID;
                task.TaskPhase = this.currentTaskPhase;
                task.TaskStatus = SysCfg.EnumTaskStatus.执行中.ToString();
                this.ctlTaskBll.Add(task);
                this.currentTask = task;
                currentTaskDescribe = "分拣任务生成";
                return true;
            }
            if (db2Vals[0] == 1 && this.currentTask == null)
            {
                this.db1ValsToSnd[0] = 1;
            }
            return true;
        }
       
    }
}
