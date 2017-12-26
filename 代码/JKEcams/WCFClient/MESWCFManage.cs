using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFClient.Proxys;

namespace WCFClient
{
    public class MESWCFManage
    {
        //private MESInterfaceProxy mesProxy = null;
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
            //mesProxy = new MESInterfaceProxy();
            //mesProxy.Open();
            //isConnect = Connect();
        }

        // 连接MES接口
        private bool Connect()
        {
           // if(mesProxy.Connect() == Success)
            {
                return true;
            }
            //else
            {
                return false;
            }
        }

        // 上传工装板RFID
        public bool UpLoadRID(string rfid)
        {
            return true;
            if (!isConnect)
            {
                if (!Connect())
                {
                    return false;
                }
            }

            //if(mesProxy.UpLoadRID(rfid) == Success)
            {
                return true;
            }
            return false;
        }

        // 工装板RFID退回
        public bool ReturnRFIDA(string rfid)
        {
            return true;
            if (!isConnect)
            {
                if (!Connect())
                {
                    return false;
                }
            }

            //if (mesProxy.ReturnRFIDA(rfid) == Success)
            {
                return true;
            }
            return false;
        }


        public string GetSNByRFID(string rfid)
        {
            string snStr = string.Empty;
            for (int i = 0; i < 12;i++ )
            {
                snStr = (i + 1).ToString() + ",";
            }
            snStr = snStr.Substring(0,snStr.Length -1);
            return snStr;

            if (!isConnect)
            {
                if (!Connect())
                {
                    return string.Empty;
                }
            }
            //return mesProxy.GetSNByRFID(rfid);
        }


        public bool UpLoadHWA(string rfid, string hw, int type)
        {
            if (!isConnect)
            {
                if (!Connect())
                {
                    return false;
                }
            }

           // if (mesProxy.UpLoadHWA( rfid, hw, type) == Success)
            {
                return true;
            }
            return false;
        }


        public bool UpLoadHWB(string rfid, string hw, int type)
        {
            if (!isConnect)
            {
                if (!Connect())
                {
                    return false;
                }
            }

            //if (mesProxy.UpLoadHWB(rfid, hw, type) == Success)
            {
                return true;
            }
            return false;
        }


        public bool UpLoadTestDataA(string str)
        {
            if (!isConnect)
            {
                if (!Connect())
                {
                    return false;
                }
            }

            //if (mesProxy.UpLoadTestDataA(str) == Success)
            {
                return true;
            }
            return false;
        }


        public bool UpLoadTestDataB(string str)
        {
            if (!isConnect)
            {
                if (!Connect())
                {
                    return false;
                }
            }

            //if (mesProxy.UpLoadTestDataB(str) == Success)
            {
                return true;
            }
            return false;
        }

        public bool ScanBind10(string str)
        {
            if (!isConnect)
            {
                if (!Connect())
                {
                    return false;
                }
            }

            //if (mesProxy.ScanBind10(str) == Success)
            {
                return true;
            }
            return false;
        }

        public bool ScanBind2(string sn, string sn1, string sn2)
        {
            if (!isConnect)
            {
                if (!Connect())
                {
                    return false;
                }
            }

            //if (mesProxy.ScanBind2( sn, sn1, sn2) == Success)
            {
                return true;
            }
            return false;
        }

        public void Close()
        {
            try
            {
               // mesProxy.Close();
            }
            catch
            {
             //   mesProxy.Abort();
            }
        }


    }
}
