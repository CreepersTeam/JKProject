using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlowCtlBaseModel;
using System.Xml;
using System.Xml.Linq;
using XWEDBAccess;
using XWEDBAccess.BLL;

namespace ProcessCtl
{
    //RCR
    public class NodeRCR : CtlNodeBaseModel
    {
        private string houseName = ""; //库房名称
        private string goodsSiteName = "";//货位名称

        private GoodsSiteBLL goodsitebll = null;
        public string HouseName { get { return houseName; } }
        public string GoodsSiteName { get { return goodsSiteName; } }

        public NodeRCR()
        {
            goodsitebll = new GoodsSiteBLL();
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
                if (selfDataXE.Attribute("houseName") != null)
                {
                    this.houseName = selfDataXE.Attribute("houseName").Value.ToString();
                }

                if (selfDataXE.Attribute("snSize") != null)
                {
                    this.goodsSiteName = selfDataXE.Attribute("goodsSiteName").Value.ToString();
                }
            }
            currentTaskPhase = 0;

            return true;
        }

        public override bool DevStatusRestore()
        {
            devStatusRestore = true;
            string strWhere = string.Format("(TaskStatus='执行中' or TaskStatus='超时') and DeviceID='{0}' order by CreateTime ", this.nodeID);
            this.currentTask = ctlTaskBll.GetFirstRequiredTask(strWhere);
            if (this.currentTask != null)
            {
                this.currentTaskPhase = this.currentTask.TaskPhase;
            }
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

            //goodsitebll.GetModel

            return true;
        }
    }
}
