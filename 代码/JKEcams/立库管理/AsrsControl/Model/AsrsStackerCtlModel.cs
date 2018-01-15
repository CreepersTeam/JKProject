using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlowCtlBaseModel;
using DevInterface;
using AsrsModel;
using CtlDBAccess.Model;
using CtlDBAccess.BLL;
using AsrsInterface;
namespace AsrsControl
{
    /// <summary>
    /// 堆垛机控制模型
    /// </summary>
    public class AsrsStackerCtlModel:CtlNodeBaseModel
    {
        public delegate bool DlgtTaskCompleted(AsrsTaskParamModel taskParamModel, ControlTaskModel ctlTask);
        #region 数据
        private bool devStatusRestore = false;//是否已经恢复下电前状态
        private string houseName = "";
       // protected short devRunningStatus = 0; //设备工作状态
        private IrfidRW rfidReader = null;
       // protected ControlTaskModel currentTask = null;
        protected AsrsTaskParamModel taskParamModel = null;
        protected IAsrsManageToCtl asrsResManage = null; //立库管理层接口对象
        protected IDictionary<int, string> errcodeMap = null;
        /// <summary>
        /// 管理层任务下发数据表的业务接口
        /// </summary>
       // protected ControlTaskBll ctlTaskBll = null;
       // public short DevRunningStatus { get { return devRunningStatus; } }
        public DlgtTaskCompleted dlgtTaskCompleted = null;
        public IrfidRW RfidReader { get { return rfidReader; } set { rfidReader = value; } }
      
        public string HouseName { get { return houseName; } set { houseName = value; } }
        public IAsrsManageToCtl AsrsResManage { get { return asrsResManage; } set { asrsResManage = value; } }
        #endregion
        #region 公有
        public AsrsStackerCtlModel()
        {
            this.currentStat = new CtlNodeStatus(nodeName);
            this.currentStat.Status = EnumNodeStatus.设备空闲;
            this.currentStat.StatDescribe = "空闲状态";
            this.ctlTaskBll = new ControlTaskBll();
            this.currentTaskPhase = 0;
            errcodeMap = new Dictionary<int, string>();
            #region 故障码定义
            errcodeMap[1] = "接收任务错";
            errcodeMap[2] = "货叉不在原点位";
            errcodeMap[3] = "激光测距范围超限/被档";
            errcodeMap[4] = "钢丝绳松故障";
            errcodeMap[5] = "货叉内有货";
            errcodeMap[6] = "感应到后限位故障";
            errcodeMap[7] = "感应到前限位故障";
            errcodeMap[8] = "升降高度超最高值或上限位保护";
            errcodeMap[9] = "升降速度超高或超低";
            errcodeMap[10] = "行走变频器故障";
            errcodeMap[11] = "升降变频器故障";
            errcodeMap[12] = "放货货叉带货出";
            errcodeMap[13] = "取货货叉上为空";
            errcodeMap[14] = "取货货叉上为空";
            errcodeMap[15] = "上位机与下位机时序错";
            errcodeMap[16] = "货叉超时保护";
            errcodeMap[17] = "行走时货物偏左故障";
            errcodeMap[18] = "行走时货物偏右故障";
            errcodeMap[19] = "急停按下";
            errcodeMap[20] = "门被打开";
            errcodeMap[21] = "通讯故障";
            errcodeMap[22] = "工板放斜故障";
            errcodeMap[23] = "其他故障";
            errcodeMap[24] ="其它故障6";
            errcodeMap[25] ="其它故障7";
            errcodeMap[26] ="其它故障8";
            errcodeMap[27] ="其它故障9";
            errcodeMap[28] ="其它故障10";
            errcodeMap[29] ="其它故障11";
            errcodeMap[30] ="急停被按下12";
	        #endregion
        }
        /// <summary>
        /// 给安排任务
        /// </summary>
        /// <param name="task"></param>
        /// <param name="reStr"></param>
        /// <returns></returns>
        public bool FillTask(ControlTaskModel task, ref string reStr)
        {
            if(this.currentTask != null )
            {
                reStr = "当前任务未执行完，不能接受新的任务";
                return false;
            }
            this.currentTask = task;
            return true;
        }
        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="reStr"></param>
        /// <returns></returns>
        public override bool ExeBusiness(ref string reStr)
        {
            //if(this.currentStat.Status == EnumNodeStatus.设备故障)
            //{
            //    return false;
            //}
            if (!nodeEnabled)
            {
                return true;
            }
            if(!devStatusRestore)
            {
                devStatusRestore = DevStatusRestore();

            }
            if(!devStatusRestore)
            {
                return false;
            }
           //任务撤销
            if (db2Vals[2] == 3 && db1ValsToSnd[1] != 3)
            {
                TaskReback();
                return true;
            }
            if (db1ValsToSnd[1] == 3 && db2Vals[2] == 1)
            {
                //任务撤销命令复位，应答也复位
                db1ValsToSnd[1] = 1;
            }
            if(currentTask != null)
            {  
               this.currentStat.Status = EnumNodeStatus.设备使用中;
                
            }
            else
            {
                this.currentStat.Status = EnumNodeStatus.设备空闲;
            }
            if(this.db2Vals[0]!=0)
            {
                this.db1ValsToSnd[11] = 1;
                currentTaskDescribe = "设备故障";
                return true;
            }
            switch (currentTaskPhase)
            {
                case 0:
                    {
                        currentTaskDescribe = "等待新的任务";
                        if(currentTask == null)
                        {
                            break;
                        }
                        
                        currentTaskDescribe = "即将开始任务通信";
                        this.taskParamModel = new AsrsTaskParamModel();
                        if (!taskParamModel.ParseParam((SysCfg.EnumAsrsTaskType)this.CurrentTask.TaskType, this.CurrentTask.TaskParam, houseName ,ref reStr))
                        {
                            ThrowErrorStat(reStr, EnumNodeStatus.设备故障);
                            taskParamModel = null;
                            //logRecorder.AddDebugLog(nodeName, reStr);
                            return false;
                        }
                        currentTaskDescribe = "等待设备空闲状态";
                        if(this.db2Vals[1]==1) //设备处于空闲状态，可以 接受新的任务
                        {
                            string logInfo = "";
                            //写入参数
                            if(currentTask.TaskType ==5 )//移库
                            {
                                logInfo = string.Format("开始执行任务:{0},{1}-{2}-{3}至{4}-{5}-{6}", ((SysCfg.EnumAsrsTaskType)currentTask.TaskType).ToString() 
                                    , taskParamModel.CellPos1.Row, taskParamModel.CellPos1.Col, taskParamModel.CellPos1.Layer, taskParamModel.CellPos2.Row,
                                    taskParamModel.CellPos2.Col, taskParamModel.CellPos2.Layer);
                           
                            }
                            else
                            {
                               logInfo= string.Format("开始执行任务:{0},{1}-{2}-{3}", ((SysCfg.EnumAsrsTaskType)currentTask.TaskType).ToString(), taskParamModel.CellPos1.Row, taskParamModel.CellPos1.Col, taskParamModel.CellPos1.Layer);
                           
                            }
                             logRecorder.AddDebugLog(nodeName, logInfo);
                            //  logRecorder.AddDebugLog(nodeName, "开始执行任务：" + ((EnumAsrsTaskType)currentTask.TaskType).ToString());
                            if(WriteTaskParam(this.currentTask))
                            {
                                this.currentTaskPhase++;
                                this.currentTask.TaskStatus = SysCfg.EnumTaskStatus.执行中.ToString();
                                this.currentTask.TaskPhase = currentTaskPhase;
                                ctlTaskBll.Update(currentTask);
                            }
                               
                        }
                      
                        break;
                    }
                case 1:
                    {
                        //参数写入完成
                        currentTaskDescribe = "开始发送参数";
                        this.db1ValsToSnd[0] = 2;
                        if(!NodeCmdCommit(true, ref reStr))
                        {
                            Console.WriteLine("发送参数失败");
                            break;
                        }
                        currentTask.TaskPhase = currentTaskPhase;
                        logRecorder.AddDebugLog(nodeName, "参数发送完成");
                        this.currentTaskPhase++;
                        this.currentTask.TaskPhase = currentTaskPhase;
                        ctlTaskBll.Update(currentTask);
                        break;
                    }
                case 2:
                    {
                        //等待任务完成
                        currentTaskDescribe = "等待设备进入工作状态";
                        if(db2Vals[1] != 2)
                        {
                            //必须进入工作状态
                            break;
                        }
                        db1ValsToSnd[0] = 1;
                        currentTaskDescribe = "等待任务完成";
                        if (db2Vals[2] == 2)
                        {

                            for (int i = 3; i < db1ValsToSnd.Count(); i++)
                            {
                                db1ValsToSnd[i] = 0;
                            }
                            //处理任务
                            if (dlgtTaskCompleted != null)
                            {
                                if (!dlgtTaskCompleted(this.taskParamModel, this.currentTask))
                                {
                                    logRecorder.AddDebugLog(nodeName, "任务完成后处理失败!");
                                    break;
                                }
                            }
                            //if (!TaskCompletedProcess(this.taskParamModel, this.currentTask))
                            //{
                            //    logRecorder.AddDebugLog(nodeName, "任务完成后处理失败!");
                            //    break;
                            //}
                            db1ValsToSnd[1] = 2;
                            if (!NodeCmdCommit(true, ref reStr))
                            {
                                Console.WriteLine("发送任务处理完成状态失败");
                                break;
                            }
                            // string debugLog = string.Format("任务ID：{0}，{1}完成！", currentTask.TaskID, currentTask.Remark);
                            string debugLog = "";
                            if (currentTask.TaskType == 5) //移库
                            {
                                debugLog = string.Format("任务:{0},{1}-{2}-{3}至{4}-{5}-{6}完成", ((SysCfg.EnumAsrsTaskType)currentTask.TaskType).ToString(),
                                    taskParamModel.CellPos1.Row, taskParamModel.CellPos1.Col, taskParamModel.CellPos1.Layer
                                    , taskParamModel.CellPos2.Row, taskParamModel.CellPos2.Col, taskParamModel.CellPos2.Layer);

                            }
                            else
                            {
                                debugLog = string.Format("任务:{0},{1}-{2}-{3}完成", ((SysCfg.EnumAsrsTaskType)currentTask.TaskType).ToString(), taskParamModel.CellPos1.Row, taskParamModel.CellPos1.Col, taskParamModel.CellPos1.Layer);

                            }
                            logRecorder.AddDebugLog(nodeName, debugLog);
                            currentTaskDescribe = "任务完成";
                            this.currentTaskPhase++;
                        }
                       
                        currentTask.TaskPhase = currentTaskPhase;
                        ctlTaskBll.Update(currentTask);
                        break;
                    }
                case 3:
                    {
                        currentTaskDescribe = "等待任务完成信号复位";
                        if(db2Vals[2] != 1)
                        {
                            break;
                        }

                        DevCmdReset();
                        currentTask = null;
                        currentTaskPhase = 0;
                        currentTaskDescribe = "等待执行下一个任务";
                       
                        logRecorder.AddDebugLog(nodeName, currentTaskDescribe);
                        break;
                    }
                default:
                    break;
            }
            return true;
        }
        public override bool BuildCfg(System.Xml.Linq.XElement xe, ref string reStr)
        {
            if (!base.BuildCfg(xe, ref reStr))
            {
                return false;
            }
            this.dicCommuDataDB1[1].DataDescription = "参数写入标志，1：未完成，2：写入完成";
            this.dicCommuDataDB1[2].DataDescription = "任务处理完成标志，1：未完成，2：处理完成,3:撤销处理完成";
            this.dicCommuDataDB1[3].DataDescription = "任务类型标志，1：产品入库;2：备用;3:DCR出库;4：DCR测试 A库：1-15-1 B库：1-1-1;5：移库;6:点胶入库（预留）;7：紧急出库（A库西侧预留的紧急出口）;";
            this.dicCommuDataDB1[4].DataDescription = "入口编号（从1开始）";
            this.dicCommuDataDB1[5].DataDescription = "出口编号（从1开始）";
            this.dicCommuDataDB1[6].DataDescription = "货位编号 ：排（从1开始）";
            this.dicCommuDataDB1[7].DataDescription = "货位编号 ：列（从1开始）";
            this.dicCommuDataDB1[8].DataDescription = "货位编号 ：层（从1开始）";

            this.dicCommuDataDB1[9].DataDescription = "货位编号2（移库时用） ：排（从1开始）";
            this.dicCommuDataDB1[10].DataDescription = "货位编号2 （移库时用）：列（从1开始）";
            this.dicCommuDataDB1[11].DataDescription = "位编号2（移库时用） ：层（从1开始）";
            this.dicCommuDataDB1[12].DataDescription = "1:故障处理未完成,2：故障处理完成";

            this.dicCommuDataDB2[1].DataDescription = "故障码";
            this.dicCommuDataDB2[2].DataDescription = "设备状态：1空闲，2：工作中，3：故障,4:非联机状态";
            this.dicCommuDataDB2[3].DataDescription = "任务完成状态：1：未完成，2：完成，3：任务取消，设备将复位";
            return true;
        }
        /// <summary>
        /// 系统启动后，先回复设备运行状态
        /// </summary>
        /// <param name="errStr"></param>
        /// <returns></returns>
        public override bool DevStatusRestore()
        {
            if(!base.DevStatusRestore())
            {
                return false;
            }
         
            string strWhere = string.Format("(TaskStatus='执行中' or TaskStatus='超时') and DeviceID='{0}' order by CreateTime ", this.nodeID);
            this.currentTask = ctlTaskBll.GetFirstRequiredTask(strWhere);
            if (this.currentTask != null)
            {
                this.currentTaskPhase = this.currentTask.TaskPhase;
                this.taskParamModel = new AsrsTaskParamModel();
                string reStr = "";
                if (!taskParamModel.ParseParam((SysCfg.EnumAsrsTaskType)this.CurrentTask.TaskType, this.CurrentTask.TaskParam,houseName, ref reStr))
                {
                    ThrowErrorStat(reStr, EnumNodeStatus.设备故障);
                    taskParamModel = null;
                    //logRecorder.AddDebugLog(nodeName, reStr);
                    return false;
                }
            }
            devStatusRestore = true;
            return true;

        }
        public bool GetRunningStatus(ref int errCode,ref string[] status)
        {
            errCode = db2Vals[0];
            status = new string[3];
            string errInfo = "工作正常";
            if(errCode != 0)
            {
                if(errcodeMap.Keys.Contains(errCode))
                {
                    errInfo = string.Format("故障发生：{0},{1}", errCode, errcodeMap[errCode]);
                }
                else
                {
                    errInfo = string.Format("故障发生：无定义的故障码{0}", errCode);
                }
            }
            status[0] = errInfo;// string.Format("故障码:{0}", db2Vals[0]);
            if(this.currentTask != null && taskParamModel != null)
            {
                status[1] = string.Format("当前任务:{0},{1}-{2}-{3}", ((SysCfg.EnumAsrsTaskType)currentTask.TaskType).ToString(), taskParamModel.CellPos1.Row, taskParamModel.CellPos1.Col, taskParamModel.CellPos1.Layer);
            }
            else
            {
                status[1]="当前任务：无";
              
            }
            status[2] = "状态：" + currentTaskDescribe;
            return true;
        }
        public bool ErrorReset(ref string reStr)
        {
            if(!plcRW.IsConnect)
            {
                reStr = string.Format("{0}PLC未连接,复位失败",nodeName);
                return false;
            }
            this.db1ValsToSnd[11] = 2;
            if(!NodeCmdCommit(false,ref reStr))
            {
                return false;
            }
            return true;
        }
        #endregion
        #region 私有
        private bool WriteTaskParam(ControlTaskModel ctlTask)
        {
            if(taskParamModel == null)
            {
                return false;
            }
           
            //1 任务类型码
             this.db1ValsToSnd[2] = (short)this.currentTask.TaskType; 
             
             this.db1ValsToSnd[3] = (short)taskParamModel.InputPort;
             this.db1ValsToSnd[4] = (short)taskParamModel.OutputPort;
             if (this.CurrentTask.TaskType == 4)//DCR测试
             {

                 //this.db1ValsToSnd[5] = (short)taskParamModel.CellPos2.Row;
                 //this.db1ValsToSnd[6] = (short)taskParamModel.CellPos2.Col;
                 //this.db1ValsToSnd[7] = (short)taskParamModel.CellPos2.Layer;

                 this.db1ValsToSnd[5] = (short)taskParamModel.CellPos1.Row;
                 this.db1ValsToSnd[6] = (short)taskParamModel.CellPos1.Col;
                 this.db1ValsToSnd[7] = (short)taskParamModel.CellPos1.Layer;

             }
             else
             {
                 this.db1ValsToSnd[5] = (short)taskParamModel.CellPos1.Row;
                 this.db1ValsToSnd[6] = (short)taskParamModel.CellPos1.Col;
                 this.db1ValsToSnd[7] = (short)taskParamModel.CellPos1.Layer;
             }
            
             
             if(this.CurrentTask.TaskType == 5)//移库
             {
                 this.db1ValsToSnd[8] = (short)taskParamModel.CellPos2.Row;
                 this.db1ValsToSnd[9] = (short)taskParamModel.CellPos2.Col;
                 this.db1ValsToSnd[10] = (short)taskParamModel.CellPos2.Layer;
             }
             return true;
        }
       
        /// <summary>
        /// 当前任务撤销处理
        /// </summary>
        private void TaskReback()
        {
            if(this.currentTask != null && this.currentTaskPhase>0)
            {
                //先更新货位状态
                string reStr = "";
                this.asrsResManage.UpdateGsTaskStatus(this.houseName, taskParamModel.CellPos1,EnumGSTaskStatus.完成,ref reStr);
                this.currentTask.TaskStatus = SysCfg.EnumTaskStatus.任务撤销.ToString();
                this.currentTask.FinishTime = System.DateTime.Now;
                ctlTaskBll.Update(this.currentTask);
                string debugLog = string.Format("任务:{0},{1}-{2}-{3}撤销", ((SysCfg.EnumAsrsTaskType)currentTask.TaskType).ToString(), taskParamModel.CellPos1.Row, taskParamModel.CellPos1.Col, taskParamModel.CellPos1.Layer);
                logRecorder.AddDebugLog(this.nodeName, debugLog);
                this.currentTask = null;
                this.currentTaskPhase = 0;
            }
            if(db1ValsToSnd[1] != 3)
            {
                ///DevCmdReset();
                Array.Clear(this.db1ValsToSnd, 0, this.db1ValsToSnd.Count());
                db1ValsToSnd[1] = 3;//
            }
           
            currentTaskDescribe = "任务撤销，等待'撤销信号'复位";
           
        }
        #endregion
    }
}
