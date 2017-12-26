using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using FlowCtlBaseModel;
namespace ProcessCtl
{
    //C1/C2入库前分流
    public class NodeSwitch : CtlNodeBaseModel
    {
        private AsrsInterface.IAsrsManageToCtl asrsResManage = null;
        private List<string> targetPortIDs = new List<string>();
        private List<AsrsControl.AsrsPortalModel> targetPorts = new List<AsrsControl.AsrsPortalModel>();
        public List<AsrsControl.AsrsPortalModel> TargetPorts { get { return targetPorts; } set { targetPorts = value; } }
        public List<string> TargetPortIDs { get { return targetPortIDs; } }
        public AsrsInterface.IAsrsManageToCtl AsrsResManage { get { return asrsResManage; } set { asrsResManage = value; } }
        public override bool BuildCfg(System.Xml.Linq.XElement xe, ref string reStr)
        {
            if (!base.BuildCfg(xe, ref reStr))
            {
                return false;
            }
            XElement selfDataXE = xe.Element("SelfDatainfo");
            if (selfDataXE.Attribute("targetPorts") != null)
            {
                string[] portIDS = selfDataXE.Attribute("targetPorts").Value.ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                if(portIDS != null && portIDS.Count()>0)
                {
                    this.targetPortIDs.Clear();
                    this.targetPortIDs.AddRange(portIDS);
                }
            }
            this.dicCommuDataDB1[1].DataDescription = "0：复位,1：流向C1库,2：流向C2库,3: 等待,4：读卡失败,5: 不可识别的料框托盘号,6：入库申请失败 ";
            this.dicCommuDataDB2[1].DataDescription = "1：无板，2：有板";
            //this.dicCommuDataDB2[1].DataDescription = "1：无请求，2：RFID读取/扫码开始,3：只有一个模组";
            //this.dicCommuDataDB2[2].DataDescription = "1：无请求，2：只有一个模组";
            currentTaskPhase = 0;

            return true;
        }
        
        public override bool ExeBusiness(ref string reStr)
        {

            if (db2Vals[0] == 1)
            {
                currentTaskPhase = 0;
                DevCmdReset();
                db1ValsToSnd[0] = 0;

                rfidUID = string.Empty;
                currentTaskDescribe = "等待新的任务";
                //return true;
            }
            if (db2Vals[0] == 2)
            {
                if (currentTaskPhase == 0)
                {
                    currentTaskPhase = 1;
                }
            }
            switch(this.currentTaskPhase)
            {
                case 1:
                    {
                        currentTaskDescribe = "开始读RFID";
                        this.rfidUID = "";
                        if (SysCfg.SysCfgModel.UnbindMode)
                        {
                            this.rfidUID=System.Guid.NewGuid().ToString();
                
                        }
                        else
                        {
                            if (SysCfg.SysCfgModel.SimMode || SysCfg.SysCfgModel.RfidSimMode)
                            {
                                this.rfidUID = this.SimRfidUID;
                            }
                            else
                            {
                                //this.rfidUID = rfidRW.ReadStrData();// rfidRW.ReadUID();
                                this.rfidUID = barcodeRW.ReadBarcode();
                            }
                        }
                        
                        if (string.IsNullOrWhiteSpace(this.rfidUID))
                        {
                            if (this.db1ValsToSnd[0] != 4)
                            {
                                logRecorder.AddDebugLog(nodeName, "读料框条码失败");
                            }
                            this.db1ValsToSnd[0] = 4;
                            break;
                        }
                        if(this.rfidUID.Length<9)
                        {
                            if (this.db1ValsToSnd[0] != 4)
                            {
                                logRecorder.AddDebugLog(nodeName, "读料框条码错误，长度不足9字符！");
                            }
                            this.db1ValsToSnd[0] = 4;
                            break;
                        }
                        if (this.rfidUID.Length > 9)
                        {
                            this.rfidUID = this.rfidUID.Substring(0, 9);
                        }
                        logRecorder.AddDebugLog(this.nodeName, "读到托盘号:" + this.rfidUID);

                        if (!SysCfg.SysCfgModel.UnbindMode)
                        {
                            List<MesDBAccess.Model.ProductOnlineModel> productList = this.productOnlineBll.GetModelList(string.Format("palletID='{0}' and palletBinded=1 ", this.rfidUID));
                            if (productList == null || productList.Count() < 1)
                            {
                                if (this.db1ValsToSnd[0] != 5)
                                {
                                    logRecorder.AddDebugLog(nodeName, "工装板绑定数据为空,"+rfidUID);
                                }
                                db1ValsToSnd[0] = 5;
                                this.CurrentStat.Status = EnumNodeStatus.设备故障;
                                this.CurrentStat.StatDescribe = "工装板绑定数据为空";
                                this.CurrentTaskDescribe = "工装板绑定数据为空";
                                break;
                            }
                        }

                        this.currentTaskPhase++;
                        break;
                    }
                case 2:
                    {
                        /*
                        if (targetPorts[0].PalletBuffer.Count() == 0 && targetPorts[1].PalletBuffer.Count() == 0)
                        {
                            //查询C1,C2库剩余货位数量
                            string nextMesStepID = targetPorts[0].AsrsCtl.GetNextStepID(this.rfidUID);
                            string currentMesStepID = GetCurrentStepID(this.rfidUID);
                            int curSeq = SysCfg.SysCfgModel.stepSeqs.IndexOf(currentMesStepID);
                            int nextSeq = SysCfg.SysCfgModel.stepSeqs.IndexOf(nextMesStepID);
                            string storeAreaZone = AsrsModel.EnumLogicArea.常温区.ToString();
                            int seq1 = SysCfg.SysCfgModel.stepSeqs.IndexOf("PS-60");
                            //int seq2 = SysCfg.SysCfgModel.stepSeqs.IndexOf("PS-100");
                            if (nextSeq <= seq1)
                            {
                                storeAreaZone = AsrsModel.EnumLogicArea.常温区.ToString();
                            }
                            else
                            {
                                storeAreaZone = AsrsModel.EnumLogicArea.冷却区.ToString();
                            }
                            int cellEmptCounts1 = 0, cellEmptCounts2 = 0;
                            this.asrsResManage.GetHouseAreaLeftGs("C1库房", storeAreaZone, ref cellEmptCounts1, reStr);
                            this.asrsResManage.GetHouseAreaLeftGs("C2库房", storeAreaZone, ref cellEmptCounts2, reStr);
                            if (cellEmptCounts1 >= cellEmptCounts2 && cellEmptCounts1 > 0)
                            {
                                this.db1ValsToSnd[0] = 1;
                                targetPorts[0].PushPalletID(this.rfidUID);

                            }
                            else if (cellEmptCounts1 < cellEmptCounts2 && cellEmptCounts2 > 0)
                            {
                                this.db1ValsToSnd[0] = 2;
                                targetPorts[1].PushPalletID(this.rfidUID);

                            }
                            else
                            {
                                this.db1ValsToSnd[0] = 3;
                                break;
                            }
                        }
                        else
                        {
                            bool switchStat = false;
                            for (int i = 0; i < targetPorts.Count(); i++)
                            {
                                if (targetPorts[i].PalletBuffer.Count()>0 && targetPorts[i].PalletBuffer.Count() < targetPorts[0].PortinBufCapacity)
                                {
                                    string lastPalletID = targetPorts[i].PalletBuffer[targetPorts[i].PalletBuffer.Count() - 1];
                                    string preBatch = productOnlineBll.GetBatchNameofPallet(lastPalletID);
                                    string curBatch = productOnlineBll.GetBatchNameofPallet(this.rfidUID);
                                    if (preBatch == curBatch)
                                    {
                                        this.db1ValsToSnd[0] = (Int16)(i + 1);
                                        targetPorts[i].PushPalletID(this.rfidUID);
                                        switchStat = true;
                                        break;
                                    }
                                }
                            }
                            if(!switchStat)
                            {
                                for (int i = 0; i < targetPorts.Count(); i++)
                                {
                                    if (targetPorts[i].PalletBuffer.Count() == 0)
                                    {
                                        this.db1ValsToSnd[0] = (Int16)(i + 1);
                                        targetPorts[i].PushPalletID(this.rfidUID);
                                        switchStat = true;
                                        break;
                                    }
                                }
                            }
                           
                            if(!switchStat)
                            {
                                this.db1ValsToSnd[0] = 3;
                                this.currentTaskDescribe = "等待分流";
                                break;
                            }
                        }
                        */
                        int switchRe = GetSwitchDecision();
                        this.db1ValsToSnd[0] = (short)switchRe;
                        if (switchRe == 1 || switchRe == 2)
                        {
                             string logStr = string.Format("分流，进入{0}", targetPorts[this.db1ValsToSnd[0] - 1].NodeName);
                             targetPorts[switchRe-1].PushPalletID(this.rfidUID);
                             logRecorder.AddDebugLog(nodeName, logStr);
                             AddProduceRecord(this.rfidUID, logStr);
                             this.currentTaskDescribe = logStr;
                             Console.WriteLine(logStr); 
                             this.rfidUID = "";
                        }
                        else if (this.db1ValsToSnd[0]==3)
                        {
                            this.currentTaskDescribe = "等待分流";
                            break;
                        }
                        this.currentTaskPhase++;
                        break;
                    }
                case 3:
                    {
                        currentTaskDescribe = "分流完成";
                        break;
                    }
                default:
                    break;
            }

            AsrsCheckinRequire();
            
            return true;
        }
        private void AsrsCheckinRequire()
        {
            //foreach(AsrsControl.AsrsPortalModel port in targetPorts)
            for (int i = 0; i < targetPorts.Count();i++ )
            {
                AsrsControl.AsrsPortalModel port = targetPorts[i];
                if(port.AsrsCtl.StackDevice.Db2Vals[0] >0 || port.AsrsCtl.StackDevice.Db2Vals[1]>2)
                {
                    continue;
                }
                if (port.PalletBuffer.Count() < 1)
                {
                    continue;
                }
                if (port.AsrsCtl.StackDevice.Db2Vals[1] > 2) 
                {

                }
                bool checkInRequire = false;
                if (port.PalletBuffer.Count() >= port.PortinBufCapacity)
                {
                    checkInRequire = true;
                }
                else
                {
                    if (db1ValsToSnd[0] == 3 && port.Db2Vals[0] == 2)
                    {
                        checkInRequire = true;
                    }
                }
                for (int j = 0; j < Math.Min(port.PalletBuffer.Count(), port.PortinBufCapacity); j++)
                {
                    if (port.Db2Vals[j] != 2)
                    {
                        checkInRequire = false;
                        break;
                    }
                }
                if(port.Db2Vals[2] == 2) //手动入库按钮请求
                {
                    checkInRequire = true;
                }
                if (!checkInRequire)
                {
                    continue;
                }
                string palletID = port.PalletBuffer[0];
                string nextProcessID = port.AsrsCtl.GetNextStepID(palletID);
                int nextProcessSeq = SysCfg.SysCfgModel.stepSeqs.IndexOf(nextProcessID);
                int curSeq = SysCfg.SysCfgModel.stepSeqs.IndexOf(port.AsrsCtl.MesProcessStepID[0]);
                AsrsModel.EnumLogicArea logicArea = AsrsModel.EnumLogicArea.暂存区;
                if (nextProcessSeq > curSeq)
                {
                    logicArea = AsrsModel.EnumLogicArea.常温区;
                }
                string reStr = "";
                SysCfg.EnumAsrsTaskType taskType = SysCfg.EnumAsrsTaskType.产品入库;
                if (port.AsrsCtl.AsrsCheckinTaskRequire(port, logicArea, taskType, port.PalletBuffer.ToArray(), ref reStr))
                {
                    //port.PalletBuffer.Clear();
                    if (!port.ClearBufPallets(ref reStr))
                    {
                        logRecorder.AddDebugLog(port.NodeName, "清理入口缓存数据失败" + reStr);
                    }
                    
                }
                else
                {
                    string logStr = string.Format("{0}申请失败,因为：{1}", taskType.ToString(), reStr);
                    logRecorder.AddDebugLog(port.NodeName, logStr);
                }
            }
        }
        private int GetSwitchDecision()
        {
            int re = 0;
            string nextMesStepID = targetPorts[0].AsrsCtl.GetNextStepID(this.rfidUID);
            string currentMesStepID = GetCurrentStepID(this.rfidUID);
            int curSeq = SysCfg.SysCfgModel.stepSeqs.IndexOf(currentMesStepID);
            int nextSeq = SysCfg.SysCfgModel.stepSeqs.IndexOf(nextMesStepID);
            string storeAreaZone = AsrsModel.EnumLogicArea.常温区.ToString();
            int seq1 = SysCfg.SysCfgModel.stepSeqs.IndexOf("PS-60");
            //int seq2 = SysCfg.SysCfgModel.stepSeqs.IndexOf("PS-100");
            if (nextSeq <= seq1)
            {
                storeAreaZone = AsrsModel.EnumLogicArea.冷却区.ToString();
            }
            else
            {

                storeAreaZone = AsrsModel.EnumLogicArea.常温区.ToString();
            }

            if (targetPorts[0].PalletBuffer.Count() == 0 && targetPorts[1].PalletBuffer.Count() == 0)
            {
                /*
                if(targetPorts[0].AsrsCtl.StackDevice.Db2Vals[1]>2)
                {
                    if(targetPorts[1].AsrsCtl.StackDevice.Db2Vals[1] == 1 || targetPorts[1].AsrsCtl.StackDevice.Db2Vals[1]==2)
                    {
                        re = 2;
                    }
                    else
                    {
                        re = 3; //C1,C2均故障或非联机状态
                    }
                }
                else if (targetPorts[1].AsrsCtl.StackDevice.Db2Vals[1] > 2)
                {
                    if(targetPorts[0].AsrsCtl.StackDevice.Db2Vals[1] == 1 || targetPorts[0].AsrsCtl.StackDevice.Db2Vals[1]==2)
                    {
                        re = 1;
                    }
                    else
                    {
                        re = 3;
                    }
                }
                else*/
                
                //查询C1,C2库剩余货位数量
                    
                int cellEmptCounts1 = 0, cellEmptCounts2 = 0;
                string reStr = "";
                this.asrsResManage.GetHouseAreaLeftGs("C1库房", storeAreaZone, ref cellEmptCounts1, reStr);
                this.asrsResManage.GetHouseAreaLeftGs("C2库房", storeAreaZone, ref cellEmptCounts2, reStr);
                if (cellEmptCounts1 >= cellEmptCounts2 && cellEmptCounts1 > 0 && targetPorts[0].Db2Vals[0] != 2 && targetPorts[0].Db2Vals[1]!=2)
                {
                    re = 1;//流向C1,  this.db1ValsToSnd[0] = 1;
                    //  targetPorts[0].PushPalletID(this.rfidUID);

                }
                else if (cellEmptCounts1 < cellEmptCounts2 && cellEmptCounts2 > 0 && targetPorts[1].Db2Vals[0] != 2 && targetPorts[1].Db2Vals[1] != 2)
                {
                    re = 2;//流向C2,  this.db1ValsToSnd[0] = 2;
                    //   targetPorts[1].PushPalletID(this.rfidUID);

                }
                else
                {
                    re = 3;//等待 this.db1ValsToSnd[0] = 3;

                }
                
               
            }
            else
            {
                bool switchStat = false;
                for (int i = 0; i < targetPorts.Count(); i++)
                {
                    //if(targetPorts[i].AsrsCtl.StackDevice.Db2Vals[1] >2)
                    //{
                    //    continue;
                    //}
                  
                    if (targetPorts[i].PalletBuffer.Count() > 0 && targetPorts[i].PalletBuffer.Count() < targetPorts[i].PortinBufCapacity)
                    {
                        string lastPalletID = targetPorts[i].PalletBuffer[targetPorts[i].PalletBuffer.Count() - 1];
                        string preBatch = productOnlineBll.GetBatchNameofPallet(lastPalletID);
                        string curBatch = productOnlineBll.GetBatchNameofPallet(this.rfidUID);

                        string nextMesStepIDLast = targetPorts[0].AsrsCtl.GetNextStepID(lastPalletID);
                        string currentMesStepIDLast = GetCurrentStepID(lastPalletID);
                        int curSeqLast = SysCfg.SysCfgModel.stepSeqs.IndexOf(currentMesStepIDLast);
                        int nextSeqLast = SysCfg.SysCfgModel.stepSeqs.IndexOf(nextMesStepIDLast);
                        string storeAreaZoneLast = AsrsModel.EnumLogicArea.冷却区.ToString();
                        int seq1Last = SysCfg.SysCfgModel.stepSeqs.IndexOf("PS-60");
                        //int seq2 = SysCfg.SysCfgModel.stepSeqs.IndexOf("PS-100");
                        if (nextSeqLast <= seq1Last)
                        {
                            storeAreaZoneLast = AsrsModel.EnumLogicArea.冷却区.ToString();
                        }
                        else
                        {

                            storeAreaZoneLast = AsrsModel.EnumLogicArea.常温区.ToString();
                        }

                        if (preBatch == curBatch && (storeAreaZone == storeAreaZoneLast))
                        {
                            re = (Int16)(i + 1);//this.db1ValsToSnd[0] = 
                            //targetPorts[i].PushPalletID(this.rfidUID);
                            switchStat = true;
                            break;
                        }
                    }
                  

                }
                if (!switchStat)
                {
                    for (int i = 0; i < targetPorts.Count(); i++)
                    {
                        if (targetPorts[i].PalletBuffer.Count() == 0 && ((targetPorts[i].AsrsCtl.StackDevice.Db2Vals[1]<3) ||(targetPorts[i].AsrsCtl.StackDevice.Db2Vals[0] >0)))
                        {
                            int cellEmptCounts = 0;
                            string reStr = "";
                            if(!this.asrsResManage.GetHouseAreaLeftGs(targetPorts[i].AsrsCtl.HouseName, storeAreaZone, ref cellEmptCounts, reStr))
                            {
                                continue;
                            }
                            if(cellEmptCounts<=0)
                            {
                                continue;
                            }
                            re = (Int16)(i + 1);//this.db1ValsToSnd[0] =
                           // targetPorts[i].PushPalletID(this.rfidUID);
                            switchStat = true;
                            break;
                        }
                    }
                }

                if (!switchStat)
                {
                    re = 3;// this.db1ValsToSnd[0] = 3;
                    //this.currentTaskDescribe = "等待分流";
                    //break;
                }
            }
            return re;
        }
    }
}
