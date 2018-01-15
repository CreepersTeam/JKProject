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
    public partial class ProduceTraceView : BaseChildView
    {
        #region 数据
        private ProduceRecordBll modRecordBll = new ProduceRecordBll();

        private View_ProduceRecordBLL productViewBll = new View_ProduceRecordBLL();

        #endregion
        public ProduceTraceView(string captionText)
            : base(captionText)
        {
            InitializeComponent();
            this.Text = captionText;
        }
        #region UI事件
        private void ProduceReccordView_Load(object sender, EventArgs e)
        {
            //过滤参数绑定
            this.comboBox1.Items.AddRange(new string[] { "所有", "电芯", "工装板", "模组" });
            this.comboBox1.SelectedIndex = 0;
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

            if (comboBox1.Text != "所有")
            {
                strWhere += "and productCata like '%" + comboBox1.Text.Trim() + "%'";

                if(textBoxBarcode.Text.Trim().Length > 0)
                {
                    strWhere += "and productID like '%" + textBoxBarcode.Text.Trim() + "%'";
                }
            }

            strWhere += "and recordTime between '" + dateTimePicker1.Value.ToString("yyyy-MM-dd 0:00:00") + "' And '" + dateTimePicker2.Value.ToString("yyyy-MM-dd 0:00:00") + "'";


            strWhere += " order by recordTime desc";

            DataSet ds = productViewBll.GetList(strWhere);

            if (ds.Tables.Count <= 0)
            {
                return;
            }
            DataTable dt = ds.Tables[0];

            this.dataGridView1.DataSource = dt;

            this.dataGridView1.Columns["recordID"].Visible = false;
            this.dataGridView1.Columns["stationID"].Visible = false;
            this.dataGridView1.Columns["recordCata"].Visible = false;
            this.dataGridView1.Columns["tag1"].Visible = false;
            //this.dataGridView1.Columns["tag2"].Visible = false;
            //this.dataGridView1.Columns["tag3"].Visible = false;
            this.dataGridView1.Columns["tag4"].Visible = false;
            this.dataGridView1.Columns["tag5"].Visible = false;
            this.dataGridView1.Columns["checkResult"].Visible = false;

            //this.dataGridView1.Columns["checkResult"].HeaderText = "检测结果";
            this.dataGridView1.Columns["processStepName"].HeaderText = "当前工艺";
            this.dataGridView1.Columns["productID"].HeaderText = "条码";
            this.dataGridView1.Columns["productID"].Width = 200;
            this.dataGridView1.Columns["productCata"].HeaderText = "物料类别";
            //this.dataGridView1.Columns["tag1"].HeaderText = "工艺流程";
            ////this.dataGridView1.Columns["tag1"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //this.dataGridView1.Columns["tag1"].Width = 150;
            this.dataGridView1.Columns["tag2"].HeaderText = "工装板码";
            this.dataGridView1.Columns["tag3"].HeaderText = "位置";
            this.dataGridView1.Columns["recordTime"].HeaderText = "记录时间";
            this.dataGridView1.Columns["recordTime"].Width = 200;
        }
        #endregion

        #region 私有方法
       
      
        #endregion


    }
}
