using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ModuleCrossPnP;
using MesDBAccess.BLL;
using MesDBAccess.Model;
using LogInterface;
namespace ProductRecordView
{
    public partial class XWEHistroyView : BaseChildView
    {
        #region 数据
        private XWEHistroyBLL modRecordBll = new XWEHistroyBLL();

        #endregion
        public XWEHistroyView(string captionText)
            : base(captionText)
        {
            InitializeComponent();
            this.Text = captionText;
        }
        #region UI事件
        private void ProduceReccordView_Load(object sender, EventArgs e)
        {
            //过滤参数绑定
            //this.comboBox1.Items.AddRange(new string[] { "所有", "电芯", "工装板", "模组" });
            //this.comboBox1.SelectedIndex = 0;
            this.dateTimePicker1.Value = DateTime.Now.AddMonths(-1);
        }

        private void buttonTrace_Click(object sender, EventArgs e)
        {
            OnRecordQuery();
        }
        private void OnRecordQuery()
        {

            string strWhere = " 1=1 ";
            this.dataGridView1.DataSource = null;

            //if (comboBox1.Text != "所有")
            //{
            //    strWhere += "and productCata like '%" + comboBox1.Text.Trim() + "%'";

            //    if(textBoxBarcode.Text.Trim().Length > 0)
            //    {
            //        strWhere += "and productID like '%" + textBoxBarcode.Text.Trim() + "%'";
            //    }
            //}

            strWhere += "and TestTime between '" + dateTimePicker1.Value.ToString("yyyy-MM-dd 0:00:00") + "' And '" + dateTimePicker2.Value.ToString("yyyy-MM-dd 0:00:00") + "'";


            strWhere += " order by TestTime desc";

            DataSet ds = modRecordBll.GetList(strWhere);

            if (ds.Tables.Count <= 0)
            {
                return;
            }
            DataTable dt = ds.Tables[0];

            this.dataGridView1.DataSource = dt;

            this.dataGridView1.Columns["BatteryCodeID"].Visible = false;
            this.dataGridView1.Columns["tag1"].Visible = false;
            this.dataGridView1.Columns["tag2"].Visible = false;
            this.dataGridView1.Columns["tag3"].Visible = false;
            this.dataGridView1.Columns["tag4"].Visible = false;
            this.dataGridView1.Columns["tag5"].Visible = false;
            this.dataGridView1.Columns["TestStatus"].Visible = false;


            this.dataGridView1.Columns["Code"].HeaderText = "条码";
            this.dataGridView1.Columns["Code"].Width = 120;
            this.dataGridView1.Columns["Channel"].HeaderText = "测试通道";
            this.dataGridView1.Columns["Pressure"].HeaderText = "电压";
            this.dataGridView1.Columns["InnerRC"].HeaderText = "电阻";
            this.dataGridView1.Columns["Power"].HeaderText = "功率";
            this.dataGridView1.Columns["Capcity"].HeaderText = "容量";

            this.dataGridView1.Columns["TestResult"].HeaderText = "测试结果";
            this.dataGridView1.Columns["TestTime"].HeaderText = "测试时间";

            this.dataGridView1.Columns["HouseName"].HeaderText = "库房名称";
            this.dataGridView1.Columns["GoodsSiteName"].HeaderText = "货位名称";

            this.dataGridView1.Columns["TestType"].HeaderText = "测试类型";
            this.dataGridView1.Columns["PalletID"].HeaderText = "工装板码";
        }
        #endregion

        #region 私有方法
       
      
        #endregion


    }
}
