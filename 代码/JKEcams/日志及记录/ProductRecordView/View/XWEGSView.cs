using LogInterface;
using ModuleCrossPnP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
 
namespace ProductRecordView
{
    public partial class XWEGSView : BaseChildView
    {
        private XWEDBAccess.BLL.BatteryCodeBLL bllBattery = new XWEDBAccess.BLL.BatteryCodeBLL();
        private XWEDBAccess.BLL.GoodsSiteBLL bllGs = new XWEDBAccess.BLL.GoodsSiteBLL();
       
        public XWEGSView(string captionText)
            : base(captionText)
        {
        
            InitializeComponent();
            this.cb_HouseName.SelectedIndex = 0;
        }
     
        public void SetLogInterface(ILogRecorder ilog)
        {
            this.logRecorder = ilog;
        }

        private void bt_QueryGs_Click(object sender, EventArgs e)
        {
            DataTable gsData = bllGs.GetGsData(this.cb_HouseName.Text.Trim(), this.tb_GsName.Text.Trim());
            this.dgv_GS.DataSource = gsData;
            this.dgv_TestDetail.DataSource = null;
        }

       
        private void bt_Save_Click(object sender, EventArgs e)
        {
            if (this.parentPNP.RoleID > 2)
            {
                MessageBox.Show("当前用户没有此功能的操作权限！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.dgv_GS.CurrentRow == null)
            {
                return;
            }
            int rowIndex = this.dgv_GS.CurrentRow.Index;
            int goodsSiteID = int.Parse(this.dgv_GS.CurrentRow.Cells["GoodsSiteID"].Value.ToString());
            string testType = this.dgv_GS.CurrentRow.Cells["TestType"].Value.ToString();
            string testStatus = this.dgv_GS.CurrentRow.Cells["TestStatus"].Value.ToString();
            string gsName = this.dgv_GS.CurrentRow.Cells["GoodsSiteName"].Value.ToString();
            string operateStatus = this.dgv_GS.CurrentRow.Cells["OperateStatus"].Value.ToString();
            bllGs.UpdateGs(this.cb_HouseName.Text.Trim(), gsName,operateStatus, testStatus, testType);

            for(int i=0;i<this.dgv_TestDetail.Rows.Count;i++)
            {
                DataGridViewRow row = this.dgv_TestDetail.Rows[i];

                XWEDBAccess.Model.BatteryCodeModel batteryModel = new XWEDBAccess.Model.BatteryCodeModel();
                int btteryCodeID = int.Parse(row.Cells["BatteryCodeID"].Value.ToString());
                string code = row.Cells["Code"].Value.ToString();
                string channel = row.Cells["Channel"].Value.ToString();
                string pressure = row.Cells["Pressure"].Value.ToString();
                string innerRc = row.Cells["InnerRC"].Value.ToString();
                string power = row.Cells["Power"].Value.ToString();
                string capcity = row.Cells["Capcity"].Value.ToString();
                string testResult = row.Cells["TestResult"].Value.ToString();
                string testTime = row.Cells["TestTime"].Value.ToString();
                batteryModel.BatteryCodeID = btteryCodeID;
                batteryModel.Capcity = capcity;
                batteryModel.GoodsSiteID = goodsSiteID;
                batteryModel.Channel = channel;
                batteryModel.Code = code;
                batteryModel.InnerRC = innerRc;
                batteryModel.Power = power;
                batteryModel.Pressure = pressure;
                batteryModel.TestResult = testResult;
              
                bllBattery.Update(batteryModel);
            }
        }

        private void dgv_GS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dgv_TestDetail.DataSource = null;
            if (this.dgv_GS.CurrentRow == null)
            {
                return;
            }
            int rowIndex = this.dgv_GS.CurrentRow.Index;
            object gsObj = this.dgv_GS.CurrentRow.Cells["GoodsSiteID"].Value;
            if(gsObj==null)
            {
                return;
            }
            int goodsSiteID = 0;
            bool isInt = int.TryParse(gsObj.ToString(), out goodsSiteID); ;
            if(isInt == false)
            {
                return;
            }
        
            DataTable batterydata = bllBattery.GetBatteryData(goodsSiteID);
            this.dgv_TestDetail.DataSource = batterydata;
        }

        private void bt_PowerCmd_Click(object sender, EventArgs e)
        {
            if (this.parentPNP.RoleID > 2)
            {
                MessageBox.Show("当前用户没有此功能的操作权限！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                if (this.dgv_GS.CurrentRow == null)
                {
                    return;
                }
                int rowIndex = this.dgv_GS.CurrentRow.Index;
                int goodsSiteID = int.Parse(this.dgv_GS.CurrentRow.Cells["GoodsSiteID"].Value.ToString());

                string gsName = this.dgv_GS.CurrentRow.Cells["GoodsSiteName"].Value.ToString();

                bllGs.UpdateGs(this.cb_HouseName.Text.Trim() ,gsName ,SysCfg.EnumOperateStatus.空闲.ToString(),SysCfg.EnumTestStatus.成功.ToString(), SysCfg.EnumTestType.充放电测试.ToString());

                for (int i = 0; i < this.dgv_TestDetail.Rows.Count; i++)
                {
                    DataGridViewRow row = this.dgv_TestDetail.Rows[i];

                    XWEDBAccess.Model.BatteryCodeModel batteryModel = new XWEDBAccess.Model.BatteryCodeModel();
                    int btteryCodeID = int.Parse(row.Cells["BatteryCodeID"].Value.ToString());
                    string code = row.Cells["Code"].Value.ToString();
                    //string channel = row.Cells["Channel"].Value.ToString();
                    //string pressure = row.Cells["Pressure"].Value.ToString();
                    //string innerRc = row.Cells["InnerRC"].Value.ToString();
                    //string power = row.Cells["Power"].Value.ToString();
                    //string capcity = row.Cells["Capcity"].Value.ToString();
                    //string testResult = row.Cells["TestResult"].Value.ToString();
                    //string testTime = row.Cells["TestTime"].Value.ToString();
                    batteryModel.BatteryCodeID = btteryCodeID;
                    batteryModel.Capcity = "12";
                    batteryModel.GoodsSiteID = goodsSiteID;
                    batteryModel.Channel = (i + 1).ToString();
                    batteryModel.Code = code;
                    batteryModel.InnerRC = "13";
                    batteryModel.Power = "34";
                    batteryModel.Pressure = "1.5";
                    batteryModel.TestResult = "OK";

                    bllBattery.Update(batteryModel);
                }
                bt_QueryGs_Click(null, null);
                MessageBox.Show("充放电模拟完成！");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bt_PowerExcept_Click(object sender, EventArgs e)
        {
            if (this.parentPNP.RoleID > 2)
            {
                MessageBox.Show("当前用户没有此功能的操作权限！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.dgv_GS.CurrentRow == null)
            {
                return;
            }
            int rowIndex = this.dgv_GS.CurrentRow.Index;
            int goodsSiteID = int.Parse(this.dgv_GS.CurrentRow.Cells["GoodsSiteID"].Value.ToString());

            string gsName = this.dgv_GS.CurrentRow.Cells["GoodsSiteName"].Value.ToString();

            bllGs.UpdateGs(this.cb_HouseName.Text.Trim(), gsName, SysCfg.EnumOperateStatus.空闲.ToString(), SysCfg.EnumTestStatus.报警.ToString(), SysCfg.EnumTestType.充放电测试.ToString());
            bt_QueryGs_Click(null, null);
        }

        private void bt_DcrTestError_Click(object sender, EventArgs e)
        {
            if (this.parentPNP.RoleID > 2)
            {
                MessageBox.Show("当前用户没有此功能的操作权限！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.dgv_GS.CurrentRow == null)
            {
                return;
            }
            int rowIndex = this.dgv_GS.CurrentRow.Index;
            int goodsSiteID = int.Parse(this.dgv_GS.CurrentRow.Cells["GoodsSiteID"].Value.ToString());

            string gsName = this.dgv_GS.CurrentRow.Cells["GoodsSiteName"].Value.ToString();

          
            if (this.cb_HouseName.Text.Trim() == "A1库房")
            {
                if (gsName != "1-14-1")
                {
                    MessageBox.Show("请选择1-14-1货位DCR测试！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                if (gsName != "1-1-1")
                {
                    MessageBox.Show("请选择1-1-1货位DCR测试！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            bllGs.UpdateGs(this.cb_HouseName.Text.Trim(), gsName, SysCfg.EnumOperateStatus.空闲.ToString(), SysCfg.EnumTestStatus.报警.ToString(), SysCfg.EnumTestType.DCR测试.ToString());
            bt_QueryGs_Click(null, null);
        }

        private void bt_DcrTest_Click(object sender, EventArgs e)
        {
            if (this.parentPNP.RoleID > 2)
            {
                MessageBox.Show("当前用户没有此功能的操作权限！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.dgv_GS.CurrentRow == null)
            {
                return;
            }
            int rowIndex = this.dgv_GS.CurrentRow.Index;
            int goodsSiteID = int.Parse(this.dgv_GS.CurrentRow.Cells["GoodsSiteID"].Value.ToString());

            string gsName = this.dgv_GS.CurrentRow.Cells["GoodsSiteName"].Value.ToString();
            if (this.cb_HouseName.Text.Trim() == "A1库房")
            {
                if (gsName != "1-14-1")
                {
                    MessageBox.Show("请选择1-14-1货位DCR测试！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                if (gsName != "1-1-1")
                {
                    MessageBox.Show("请选择1-1-1货位DCR测试！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            bllGs.UpdateGs(this.cb_HouseName.Text.Trim(), gsName, SysCfg.EnumOperateStatus.空闲.ToString(), SysCfg.EnumTestStatus.成功.ToString(), SysCfg.EnumTestType.DCR测试.ToString());
            bt_QueryGs_Click(null, null);
        }
    }
}
