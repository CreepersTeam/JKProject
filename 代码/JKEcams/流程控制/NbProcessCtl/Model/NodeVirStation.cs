using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using FlowCtlBaseModel;
namespace ProcessCtl
{
    public class NodeVirStation : CtlNodeBaseModel
    {
        public NodeVirStation()
        {
            this.currentTaskPhase = 0;
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
                return true;
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
                            }
                            this.db1ValsToSnd[0] = 3;
                            currentTaskDescribe = "读RFID失败";
                            break;
                        }
                        if (this.rfidUID.Length < 9)
                        {
                            if (this.db1ValsToSnd[0] != 3)
                            {
                                logRecorder.AddDebugLog(nodeName, "读料框RFID错误，长度不足9字符！");
                            }
                            this.db1ValsToSnd[0] = 3;
                            break;
                        }

                        if (this.rfidUID.Length > 9)
                        {
                            this.rfidUID = this.rfidUID.Substring(0, 9);
                        }
                        logRecorder.AddDebugLog(this.nodeName, "读到托盘号:" + this.rfidUID);
                        currentTaskDescribe = "开始执行分流";
                        string logStr = "";
                        if(this.nodeID== "4003")
                        {
                            string curMesProcessID = this.productOnlineBll.GetProcessIDOfPallet(this.rfidUID);
                            if (string.IsNullOrWhiteSpace(curMesProcessID))
                            {
                                currentTaskDescribe = "OCV2";
                                this.db1ValsToSnd[0] = 1; //OCV2
                                logStr = "分流信息：OCV2分拣后料框";
                            }
                            else
                            {
                                int curSeq = SysCfg.SysCfgModel.stepSeqs.IndexOf(curMesProcessID);
                                int ocv2Seq = SysCfg.SysCfgModel.stepSeqs.IndexOf("PS-70");
                                if (curSeq <= ocv2Seq)
                                {
                                    currentTaskDescribe = "OCV2";
                                    this.db1ValsToSnd[0] = 1; //OCV2
                                    logStr = "分流信息：OCV2分拣后料框";
                                }
                                else
                                {
                                    currentTaskDescribe = "OCV4";
                                    this.db1ValsToSnd[0] = 2; //OCV4
                                    logStr = "分流信息：OCV2分拣后料框";
                                }
                            }
                            logRecorder.AddDebugLog(nodeName, logStr);
                        }
                        else
                        {
                            List<MesDBAccess.Model.ProductOnlineModel> productList = this.productOnlineBll.GetModelList(string.Format("palletID='{0}' and palletBinded=1 ", this.rfidUID));
                            if (productList == null || productList.Count() < 1)
                            {
                                this.db1ValsToSnd[0] = 1; //空框
                                currentTaskDescribe = "这是空框";
                                logStr = "分流信息：这是空框";
                            }
                            else
                            {
                                this.db1ValsToSnd[0] = 2;// 满框
                                currentTaskDescribe = "这是满框";
                                logStr = "分流信息：这是满框";
                            }
                            logRecorder.AddDebugLog(nodeName, logStr);
                        }
                        this.currentTaskPhase++;
                        break;
                    }
                case 2:
                    {
                        currentTaskDescribe = "流程完成";
                        break;
                    }
            }
            return true;
        }
    }
}
