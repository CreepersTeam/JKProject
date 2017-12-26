using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;


namespace WCFClient.Proxys
{
    [ServiceContract]
    public interface IMESInterface
    {
        [OperationContract]
        string Connect();

        [OperationContract]
        string UpLoadRID(string rfid);

        [OperationContract]
        string ReturnRFIDA(string rfid);

        [OperationContract]
        string GetSNByRFID(string rfid);

        [OperationContract]
        string UpLoadHWA(string rfid, string hw, int type);

        [OperationContract]
        string UpLoadHWB(string rfid, string hw, int type);

        [OperationContract]
        string UpLoadTestDataA(string str);

        [OperationContract]
        string UpLoadTestDataB(string str);

        [OperationContract]
        string ScanBind10(string str);

        [OperationContract]
        string ScanBind2(string sn,string sn1, string sn2);

    }
}
