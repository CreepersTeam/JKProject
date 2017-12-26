using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace WCFClient.Proxys
{
    public class MESInterfaceProxy : ClientBase<IMESInterface>, IMESInterface
    {
        public MESInterfaceProxy(): base()
        {
        }

        public string Connect()
        {
            return base.Channel.Connect();
        }
       
        public string UpLoadRID(string rfid)
        {
            return base.Channel.UpLoadRID(rfid);
        }

        public string ReturnRFIDA(string rfid)
        {
            return base.Channel.ReturnRFIDA(rfid);
        }
       
        public string GetSNByRFID(string rfid)
        {
            return base.Channel.GetSNByRFID(rfid);
        }
       
        public string UpLoadHWA(string rfid, string hw, int type)
        {
            return base.Channel.UpLoadHWA(rfid,hw,type);
        }
       
        public string UpLoadHWB(string rfid, string hw, int type)
        {
            return base.Channel.UpLoadHWB(rfid, hw, type);
        }
       
        public string UpLoadTestDataA(string str)
        {
            return base.Channel.UpLoadTestDataA(str);
        }
       
        public string UpLoadTestDataB(string str)
        {
            return base.Channel.UpLoadTestDataB(str);
        }
       
        public string ScanBind10(string str)
        {
            return base.Channel.ScanBind10(str);
        }

        public string ScanBind2(string sn, string sn1, string sn2)
        {
           return base.Channel.ScanBind2(sn, sn1, sn2);
        }

    }
}
