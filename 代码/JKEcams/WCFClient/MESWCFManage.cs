using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Runtime.Serialization;
using System.ServiceModel;
using Logger;

namespace WCFClient
{
    public class MESWCFManage
    {
        private IlikuClient proxy = null;
        private string Success = "OK";
        private string Fail = "NG";
        private static MESWCFManage __meswcfmange = null;
        private bool isConnect = false;

        public static MESWCFManage Inst()
        {
            if (__meswcfmange == null)
            {
                __meswcfmange = new MESWCFManage();
            }
            return __meswcfmange;
        }

        public MESWCFManage()
        {
            proxy = new IlikuClient();
            if (proxy.Connect() == Success)
            {
                isConnect = true;
            }
            else
            {
                isConnect = false;
            }
        }

        // 连接MES接口
        private bool Connect()
        {
            if (proxy.Connect() == Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // 上传工装板RFID
        public bool UpLoadRID(string rfid)
        {
            Logger.LoggerClass.Inst().WriteFile("UpLoadRID", LogType.INFO, "Begin : rfid " + rfid);
            try
            {
                if (!isConnect)
                {
                    if (!Connect())
                    {
                        return false;
                    }
                }

                if (proxy.UpLoadRID(rfid) == Success)
                {
                    Logger.LoggerClass.Inst().WriteFile("UpLoadRID", LogType.INFO, "End : rfid " + rfid);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Logger.LoggerClass.Inst().WriteExceptionLog(ex, string.Empty);
            }
            return false;
        }

        // 工装板RFID退回
        public bool ReturnRFIDA(string rfid)
        {
            Logger.LoggerClass.Inst().WriteFile("ReturnRFIDA", LogType.INFO, "Begin : rfid " + rfid);
            try
            {
                if (!isConnect)
                {
                    if (!Connect())
                    {
                        return false;
                    }
                }
                if (proxy.returnRID(rfid) == Success)
                {
                    Logger.LoggerClass.Inst().WriteFile("ReturnRFIDA", LogType.INFO, "End : rfid " + rfid);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Logger.LoggerClass.Inst().WriteExceptionLog(ex, string.Empty);
            }
            return false;
        }

        public string GetSNByRFID(string rfid)
        {
            string str = string.Empty;
            Logger.LoggerClass.Inst().WriteFile("GetSNByRFID", LogType.INFO, "Begin : rfid " + rfid);
            try
            {
                if (!isConnect)
                {
                    if (!Connect())
                    {
                        return string.Empty;
                    }
                }
                str = proxy.getSNByRID(rfid);
                Logger.LoggerClass.Inst().WriteFile("GetSNByRFID", LogType.INFO, "End:" + str);
            }
            catch (Exception ex)
            {
                Logger.LoggerClass.Inst().WriteExceptionLog(ex, string.Empty);
            }
            return str;
        }

        public bool UpLoadHWA(string rfid, string hw, int type)
        {
            Logger.LoggerClass.Inst().WriteFile("UpLoadHWA", LogType.INFO, "Begin : rfid " + rfid + " hw " + hw + " type " + type.ToString());
            try
            {
                if (!isConnect)
                {
                    if (!Connect())
                    {
                        return false;
                    }
                }
                if (proxy.UpLoadHWA(rfid, hw, type) == Success)
                {
                    Logger.LoggerClass.Inst().WriteFile("UpLoadHWA", LogType.INFO, "End : rfid " + rfid + " hw " + hw + " type " + type.ToString());
                    return true;
                }
            }
            catch (Exception ex)
            {
                Logger.LoggerClass.Inst().WriteExceptionLog(ex, string.Empty);
            }
            return false;
        }

        public bool UpLoadHWB(string rfid, string hw, int type)
        {
            Logger.LoggerClass.Inst().WriteFile("UpLoadHWB", LogType.INFO, "Begin : rfid " + rfid + " hw " + hw + " type " + type.ToString());
            try
            {
                if (!isConnect)
                {
                    if (!Connect())
                    {
                        return false;
                    }
                }

                if (proxy.UpLoadHWB(rfid, hw, type) == Success)
                {
                    Logger.LoggerClass.Inst().WriteFile("UpLoadHWB", LogType.INFO, "End : rfid " + rfid + " hw " + hw + " type " + type.ToString());
                    return true;
                }
            }
            catch (Exception ex)
            {
                Logger.LoggerClass.Inst().WriteExceptionLog(ex, string.Empty);
            }
            return false;
        }

        public bool UpLoadTestDataA(string str)
        {
            Logger.LoggerClass.Inst().WriteFile("UpLoadTestDataA", LogType.INFO, "Begin : str " + str);
            try
            {
                if (!isConnect)
                {
                    if (!Connect())
                    {
                        return false;
                    }
                }

                if (proxy.UpLoadTestDataA(str) == Success)
                {
                    Logger.LoggerClass.Inst().WriteFile("UpLoadTestDataA", LogType.INFO, "End : str " + str);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Logger.LoggerClass.Inst().WriteExceptionLog(ex, string.Empty);
            }
            return false;
        }

        public bool UpLoadTestDataB(string str)
        {
            Logger.LoggerClass.Inst().WriteFile("UpLoadTestDataB", LogType.INFO, "Begin : str " + str);
            try
            {
                if (!isConnect)
                {
                    if (!Connect())
                    {
                        return false;
                    }
                }

                if (proxy.UpLoadTestDataB(str) == Success)
                {
                    Logger.LoggerClass.Inst().WriteFile("UpLoadTestDataB", LogType.INFO, "End : str " + str);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Logger.LoggerClass.Inst().WriteExceptionLog(ex, string.Empty);
            }
            return false;
        }

        public bool ScanBind10(string str)
        {
            Logger.LoggerClass.Inst().WriteFile("ScanBind10", LogType.INFO, "Begin : str " + str);
            try
            {
                if (!isConnect)
                {
                    if (!Connect())
                    {
                        return false;
                    }
                }

                if (proxy.ScanBind10(str) == Success)
                {
                    Logger.LoggerClass.Inst().WriteFile("ScanBind10", LogType.INFO, "End : str " + str);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Logger.LoggerClass.Inst().WriteExceptionLog(ex, string.Empty);
            }
            return false;
        }

        public bool ScanBind20(string sn)
        {
            Logger.LoggerClass.Inst().WriteFile("ScanBind20", LogType.INFO, "Begin : str " + sn);
            try
            {
                if (!isConnect)
                {
                    if (!Connect())
                    {
                        return false;
                    }
                }

                if (proxy.ScanBind20(sn) == Success)
                {
                    Logger.LoggerClass.Inst().WriteFile("ScanBind20", LogType.INFO, "End : str " + sn);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Logger.LoggerClass.Inst().WriteExceptionLog(ex, string.Empty);
            }
            return false;
        }

        public void Close()
        {
            try
            {
                proxy.Close();
            }
            catch
            {
                proxy.Abort();
            }
        }


    }
}
