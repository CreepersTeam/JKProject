﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Linq;
namespace SysCfg
{
    public static class SysCfgModel
    {
        
        private static string CfgFile = "";
        public const string SysCfgFileName = "SysCfgFile";
        public static bool PlcCommSynMode = true;//同步通信模式
        public static bool UnbindMode = true;//ASRS动作调试模式，没有数据绑定
        public static bool RfidSimMode = false;
        //工艺参数配置字典，从数据库获取
        public static IDictionary<string, MesDBAccess.Model.ProcessStepModel> stepParamDic = new Dictionary<string, MesDBAccess.Model.ProcessStepModel>();
        public static List<string> stepSeqs = new List<string>();
        public static bool SimMode { get; set; }
       // public static bool TestMode = true;
        public static float AsrsStoreTime { get; set; } //默认统一静置时间
        //public static string CheckoutBatchHouseA { get; set; } //A库出库批次
        //public static string CheckinBatchHouseA { get; set; }//A库入库批次
        //public static string CheckoutBatchHouseB { get; set; }//B库出库批次
        //public static string CheckinBatchHouseB { get; set; } //B库入库批次
        //public static Dictionary<string, string> CheckoutBatchDic { get; set; }

        public static Dictionary<string, string> CheckoutBatchDic = new Dictionary<string, string>();
      
        public static Dictionary<string, string> CheckinBatchDic = new Dictionary<string, string>();
        
     //   public static bool HouseEnabledA { get; set; }
     //   public static bool HouseEnabledB { get; set; }
        public static bool SaveCfgDB(ref string reStr)
        {
            try
            {
                CtlDBAccess.BLL.SysCfgBll sysCfgBll = new CtlDBAccess.BLL.SysCfgBll();
                CtlDBAccess.Model.SysCfgDBModel cfgModel = sysCfgBll.GetModel(SysCfg.SysCfgModel.SysCfgFileName);
                XElement root = null;
              //  string xmlCfgFile = SysCfgModel.CfgFile;// System.AppDomain.CurrentDomain.BaseDirectory + @"data/NBssCfg.xml";
                if (cfgModel == null)
                {
                    reStr = "系统配置不存在!";
                    return false;
                }
                root = XElement.Parse(cfgModel.cfgFile);
                if (root == null)
                {
                    reStr = "系统配置不存在!";
                    return false;
                }
                XElement runModeXE = root.Element("sysSet").Element("RunMode");
                if(runModeXE.Attribute("UnBindedMode") != null)
                {
                    runModeXE.Attribute("UnBindedMode").Value =  SysCfg.SysCfgModel.UnbindMode.ToString();
                 
                }
                
                //XElement root = XElement.Load(xmlCfgFile);
                XElement asrsStoreCfgXE = root.Element("sysSet").Element("AsrsStoreCfg");
                asrsStoreCfgXE.Attribute("StoreTime").Value = AsrsStoreTime.ToString();
                XElement asrsBatchCfgXE = root.Element("sysSet").Element("AsrsBatchCfg");
                asrsBatchCfgXE.Attribute("HouseACheckin").Value = CheckinBatchDic["A1库房"];
                asrsBatchCfgXE.Attribute("HouseACheckout").Value = CheckoutBatchDic["A1库房"];
                asrsBatchCfgXE.Attribute("HouseBCheckin").Value = CheckinBatchDic["B1库房"];
                asrsBatchCfgXE.Attribute("HouseBCheckout").Value = CheckoutBatchDic["B1库房"];
                //asrsBatchCfgXE.Attribute("HouseC1Checkout").Value = CheckoutBatchDic["C1库房"];
                //asrsBatchCfgXE.Attribute("HouseC2Checkout").Value = CheckoutBatchDic["C2库房"];
                XElement asrsEnableXE = root.Element("sysSet").Element("AsrsEnableSet");
               // asrsEnableXE.Attribute("HouseEnabledA").Value = HouseEnabledA.ToString();
             //   asrsEnableXE.Attribute("HouseEnabledB").Value = HouseEnabledB.ToString();
               // root.Save(xmlCfgFile);
                if(cfgModel != null)
                {
                    cfgModel.cfgFile = root.ToString();
                    sysCfgBll.Update(cfgModel);
                }
                
                return true;
            }
            catch (Exception ex)
            {
                reStr = ex.ToString();
                return false;
            }
        }
        public static bool LoadCfgDB(ref XElement root,ref string reStr)
        {
            try
            {
                CheckinBatchDic = new Dictionary<string, string>();
                CheckoutBatchDic = new Dictionary<string, string>();
                stepSeqs.Clear();
                //投产绑定，一次高温，OCV1，二次绑定，二次高温，冷却，OCV2,OCV3,常温老化，OCV4,下线入库
                stepSeqs.AddRange(new string[] {"PS-1","PS-2","PS-3","PS-4","PS-5","PS-6","PS-7","PS-8","PS-9","PS-10","PS-11" });

                CtlDBAccess.BLL.SysCfgBll sysCfgBll = new CtlDBAccess.BLL.SysCfgBll();
                CtlDBAccess.Model.SysCfgDBModel cfgModel = sysCfgBll.GetModel(SysCfg.SysCfgModel.SysCfgFileName);
              
                //SysCfgModel.CfgFile = cfgFile;


                if (cfgModel == null)
                {
                    reStr = "系统配置不存在";
                    return false;
                }
                root = XElement.Parse(cfgModel.cfgFile);
                if(root == null)
                {
                    reStr = "系统配置不存在!";
                    return false;
                }
                
                
                XElement asrsStoreCfgXE = root.Element("sysSet").Element("AsrsStoreCfg");
                AsrsStoreTime=float.Parse(asrsStoreCfgXE.Attribute("StoreTime").Value);

                XElement runModeXE = root.Element("sysSet").Element("RunMode");
                string simStr = runModeXE.Attribute("sim").Value.ToString().ToUpper();
                if (simStr == "TRUE")
                {
                    SimMode = true;
                }
                else
                {
                    SimMode = false;
                }
                if (runModeXE.Attribute("RfidSimMode") != null)
                {
                    string strRfidSim = runModeXE.Attribute("RfidSimMode").Value.ToString().ToUpper();
                    if(strRfidSim == "TRUE")
                    {
                        RfidSimMode = true;
                    }
                    else
                    {
                        RfidSimMode = false;
                    }
                }
                if(runModeXE.Attribute("UnBindedMode")!= null)
                {
                    string unbindedStr = runModeXE.Attribute("UnBindedMode").Value.ToString().ToUpper();
                    if (unbindedStr == "TRUE")
                    {
                        UnbindMode = true;
                    }
                    else
                    {
                        UnbindMode = false;
                    }
                }
               //if(root.Element("sysSet").Element("AsrsBatchSet") != null && 
               //    root.Element("sysSet").Element("AsrsBatchSet").Element("CheckInBatch") != null)
               //{
                   
               //}
                XElement asrsBatchCfgXE = root.Element("sysSet").Element("AsrsBatchCfg");
                CheckinBatchDic["A1库房"] = asrsBatchCfgXE.Attribute("HouseACheckin").Value.ToString();
                CheckinBatchDic["B1库房"] = asrsBatchCfgXE.Attribute("HouseBCheckin").Value.ToString();
                //CheckinBatchDic["C1库房"] = asrsBatchCfgXE.Attribute("HouseC1Checkin").Value.ToString();
                //CheckinBatchDic["C2库房"] = asrsBatchCfgXE.Attribute("HouseC2Checkin").Value.ToString(); ;

                CheckoutBatchDic["A1库房"] = asrsBatchCfgXE.Attribute("HouseACheckout").Value.ToString();
                CheckoutBatchDic["B1库房"] = asrsBatchCfgXE.Attribute("HouseBCheckout").Value.ToString();
                //CheckoutBatchDic["C1库房"] = asrsBatchCfgXE.Attribute("HouseC1Checkout").Value.ToString();
                //CheckoutBatchDic["C2库房"] = asrsBatchCfgXE.Attribute("HouseC2Checkout").Value.ToString();
                //CheckinBatchHouseA = asrsBatchCfgXE.Attribute("HouseACheckin").Value.ToString();
                //CheckoutBatchHouseA = asrsBatchCfgXE.Attribute("HouseACheckout").Value.ToString();
                //CheckinBatchHouseB = asrsBatchCfgXE.Attribute("HouseBCheckin").Value.ToString();
                //CheckoutBatchHouseB = asrsBatchCfgXE.Attribute("HouseBCheckout").Value.ToString();

                //XElement asrsEnableXE = root.Element("sysSet").Element("AsrsEnableSet");
                //string str= asrsEnableXE.Attribute("HouseEnabledA").Value.ToString().ToUpper();
                //if(str == "TRUE")
                //{
                //    HouseEnabledA = true;
                //}
                //else
                //{
                //    HouseEnabledA = false;
                //}
                //str = asrsEnableXE.Attribute("HouseEnabledB").Value.ToString().ToUpper();
                //if (str == "TRUE")
                //{
                //    HouseEnabledB = true;
                //}
                //else
                //{
                //    HouseEnabledB = false;
                //}
                return true;
            }
            catch (Exception ex)
            {
                reStr = ex.ToString();
                return false;
            }
           
        }


        public static bool SaveCfg(ref string reStr)
        {
            try
            {
                string xmlCfgFile = SysCfgModel.CfgFile;// System.AppDomain.CurrentDomain.BaseDirectory + @"data/NBssCfg.xml";
                if (!File.Exists(xmlCfgFile))
                {
                    reStr = "系统配置文件：" + xmlCfgFile + " 不存在!";
                    return false;
                }
                XElement root = XElement.Load(xmlCfgFile);

                root = XElement.Parse(SysCfgModel.CfgFile);
                if (root == null)
                {
                    reStr = "系统配置不存在!";
                    return false;
                }
                XElement runModeXE = root.Element("sysSet").Element("RunMode");
                if (runModeXE.Attribute("UnBindedMode") != null)
                {
                    runModeXE.Attribute("UnBindedMode").Value = SysCfg.SysCfgModel.UnbindMode.ToString();

                }

                //XElement root = XElement.Load(xmlCfgFile);
                XElement asrsStoreCfgXE = root.Element("sysSet").Element("AsrsStoreCfg");
                asrsStoreCfgXE.Attribute("StoreTime").Value = AsrsStoreTime.ToString();
                XElement asrsBatchCfgXE = root.Element("sysSet").Element("AsrsBatchCfg");
                asrsBatchCfgXE.Attribute("HouseACheckin").Value = CheckinBatchDic["A1库房"];
                asrsBatchCfgXE.Attribute("HouseACheckout").Value = CheckoutBatchDic["A1库房"];
                asrsBatchCfgXE.Attribute("HouseBCheckin").Value = CheckinBatchDic["B1库房"];
                asrsBatchCfgXE.Attribute("HouseBCheckout").Value = CheckoutBatchDic["B1库房"];
                //asrsBatchCfgXE.Attribute("HouseC1Checkout").Value = CheckoutBatchDic["C1库房"];
                //asrsBatchCfgXE.Attribute("HouseC2Checkout").Value = CheckoutBatchDic["C2库房"];
                XElement asrsEnableXE = root.Element("sysSet").Element("AsrsEnableSet");
                // asrsEnableXE.Attribute("HouseEnabledA").Value = HouseEnabledA.ToString();
                //   asrsEnableXE.Attribute("HouseEnabledB").Value = HouseEnabledB.ToString();
                // root.Save(xmlCfgFile);
                root.Save(xmlCfgFile);
                return true;
            }
            catch (Exception ex)
            {
                reStr = ex.ToString();
                return false;
            }
        }
        public static bool LoadCfg(string cfgFile, ref string reStr)
        {
            try
            {
                SysCfgModel.CfgFile = cfgFile;
                string xmlCfgFile = SysCfgModel.CfgFile;// System.AppDomain.CurrentDomain.BaseDirectory + @"data/NBssCfg.xml";
                if (!File.Exists(xmlCfgFile))
                {
                    reStr = "系统配置文件：" + xmlCfgFile + " 不存在!";
                    return false;
                }
                XElement root = XElement.Load(xmlCfgFile);
                
                if (root == null)
                {
                    reStr = "系统配置不存在!";
                    return false;
                }


                XElement asrsStoreCfgXE = root.Element("sysSet").Element("AsrsStoreCfg");
                AsrsStoreTime = float.Parse(asrsStoreCfgXE.Attribute("StoreTime").Value);

                XElement runModeXE = root.Element("sysSet").Element("RunMode");
                string simStr = runModeXE.Attribute("sim").Value.ToString().ToUpper();
                if (simStr == "TRUE")
                {
                    SimMode = true;
                }
                else
                {
                    SimMode = false;
                }
                if (runModeXE.Attribute("RfidSimMode") != null)
                {
                    string strRfidSim = runModeXE.Attribute("RfidSimMode").Value.ToString().ToUpper();
                    if (strRfidSim == "TRUE")
                    {
                        RfidSimMode = true;
                    }
                    else
                    {
                        RfidSimMode = false;
                    }
                }
                if (runModeXE.Attribute("UnBindedMode") != null)
                {
                    string unbindedStr = runModeXE.Attribute("UnBindedMode").Value.ToString().ToUpper();
                    if (unbindedStr == "TRUE")
                    {
                        UnbindMode = true;
                    }
                    else
                    {
                        UnbindMode = false;
                    }
                }

                XElement asrsBatchCfgXE = root.Element("sysSet").Element("AsrsBatchCfg");
                CheckinBatchDic["A1库房"] = asrsBatchCfgXE.Attribute("HouseACheckin").Value.ToString();
                CheckinBatchDic["B1库房"] = asrsBatchCfgXE.Attribute("HouseBCheckin").Value.ToString();

                CheckoutBatchDic["A1库房"] = asrsBatchCfgXE.Attribute("HouseACheckout").Value.ToString();
                CheckoutBatchDic["B1库房"] = asrsBatchCfgXE.Attribute("HouseBCheckout").Value.ToString();


                stepSeqs.Clear();
                //投产绑定，一次高温，OCV1，二次绑定，二次高温，冷却，OCV2,OCV3,常温老化，OCV4,下线入库
                stepSeqs.AddRange(new string[] { "PS-1", "PS-2", "PS-3", "PS-4", "PS-5", "PS-6", "PS-7", "PS-8", "PS-9", "PS-10", "PS-11" });


                return true;
            }
            catch (Exception ex)
            {
                reStr = ex.ToString();
                return false;
            }

        }

    }
    public enum EnumTestStatus
    {
        成功=1,
        报警=2,
        待测试=3,
        测试中=4
    }
    public enum EnumOperateStatus
    {
        锁定,
        空闲
    }
    public enum EnumTestType
    {
        充放电测试=1,
        DCR测试=2,
        无
    }
    public enum EnumProductCata
    {
        电芯,
        模组,
        PACK,
        工装板,
        其它
    }
    /// <summary>
    /// 任务执行状态（控制任务、管理任务）
    /// </summary>
    public enum EnumTaskStatus
    {
        待执行,
        执行中,
        已完成,
        超时, //任务在规定时间内未完成
        错误, //任务发生错误，不可能再继续执行了，必须人工清理掉
        任务撤销
    }
    //模组工艺过程枚举
    public enum EnumModProcessStage
    {
        模组装配上盖,
        模组装配下盖,
        模组工装板绑定,
        模组入A库,
        模组出A库,
        模组焊接上盖,
        模组焊接下盖,
        模组入B库,
        模组充电完成出B库,
        模组装配到PACK
    }
    public enum EnumAsrsTaskType
    {
        无,
        产品入库 = 1,
        //DCR测试 = 2,
        DCR出库 = 3,
        DCR测试 = 4,
        移库 = 5,
        点胶入库=6,
        紧急出库=7,
        空框出库,
        空框入库,
        OCV测试分拣,
        托盘装载,
        卸载读卡,
        扫码工位 ,
    }
}
