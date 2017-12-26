namespace ASRSStorManage.View
{
    partial class StockManaView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockManaView));
            this.cms_StockMana = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_StockStaModify = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_OutputManual = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_deleteStock = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_StockList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_delete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_addStockList = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_StockListPro = new System.Windows.Forms.ToolStripMenuItem();
            this.cb_GSTaskType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cb_GSStatus = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cb_HouseArea = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.bt_RefreshBatch = new System.Windows.Forms.Button();
            this.cb_ProductBatch = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cb_StockLayer = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cb_StockColumn = new System.Windows.Forms.ComboBox();
            this.cb_StockRow = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_StoreHouse = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsb_QueryStock = new System.Windows.Forms.ToolStripButton();
            this.tsb_OutputManual = new System.Windows.Forms.ToolStripButton();
            this.tsb_GsStatusModify = new System.Windows.Forms.ToolStripButton();
            this.tsb_deleteStock = new System.Windows.Forms.ToolStripButton();
            this.tsb_returnOutFac = new System.Windows.Forms.ToolStripButton();
            this.tsb_UseGS = new System.Windows.Forms.ToolStripButton();
            this.tsb_UnuseGs = new System.Windows.Forms.ToolStripButton();
            this.tsb_ProductNum = new System.Windows.Forms.ToolStripButton();
            this.lb_GSNum = new System.Windows.Forms.Label();
            this.lb_PalletNum = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gb_Model = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.pl_ExterProParent = new System.Windows.Forms.Panel();
            this.bt_CloseExpandView = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lb_ProductNum = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_StockInfor = new System.Windows.Forms.DataGridView();
            this.StockID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_HouseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_HouseArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductBatch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GoodsSiteName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rowth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.layerth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gs_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gs_TaskStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_StartStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_InHousetime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.cms_StockMana.SuspendLayout();
            this.cms_StockList.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.gb_Model.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_StockInfor)).BeginInit();
            this.SuspendLayout();
            // 
            // cms_StockMana
            // 
            this.cms_StockMana.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_StockStaModify,
            this.tsmi_OutputManual,
            this.tsmi_deleteStock});
            this.cms_StockMana.Name = "cms_StockMana";
            this.cms_StockMana.Size = new System.Drawing.Size(149, 70);
            // 
            // tsmi_StockStaModify
            // 
            this.tsmi_StockStaModify.Name = "tsmi_StockStaModify";
            this.tsmi_StockStaModify.Size = new System.Drawing.Size(148, 22);
            this.tsmi_StockStaModify.Text = "库存状态修改";
            this.tsmi_StockStaModify.Click += new System.EventHandler(this.tsmi_StockStaModify_Click);
            // 
            // tsmi_OutputManual
            // 
            this.tsmi_OutputManual.Name = "tsmi_OutputManual";
            this.tsmi_OutputManual.Size = new System.Drawing.Size(148, 22);
            this.tsmi_OutputManual.Text = "手  动  出  库";
            this.tsmi_OutputManual.Click += new System.EventHandler(this.tsmi_OutputManual_Click);
            // 
            // tsmi_deleteStock
            // 
            this.tsmi_deleteStock.Name = "tsmi_deleteStock";
            this.tsmi_deleteStock.Size = new System.Drawing.Size(148, 22);
            this.tsmi_deleteStock.Text = "删  除  库  存";
            this.tsmi_deleteStock.Click += new System.EventHandler(this.tsmi_deleteStock_Click);
            // 
            // cms_StockList
            // 
            this.cms_StockList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_delete,
            this.tsmi_addStockList,
            this.tsmi_StockListPro});
            this.cms_StockList.Name = "cms_StockMana";
            this.cms_StockList.Size = new System.Drawing.Size(101, 70);
            // 
            // tsmi_delete
            // 
            this.tsmi_delete.Name = "tsmi_delete";
            this.tsmi_delete.Size = new System.Drawing.Size(100, 22);
            this.tsmi_delete.Text = "删除";
            this.tsmi_delete.Visible = false;
            this.tsmi_delete.Click += new System.EventHandler(this.tsmi_delete_Click);
            // 
            // tsmi_addStockList
            // 
            this.tsmi_addStockList.Name = "tsmi_addStockList";
            this.tsmi_addStockList.Size = new System.Drawing.Size(100, 22);
            this.tsmi_addStockList.Text = "添加";
            this.tsmi_addStockList.Visible = false;
            this.tsmi_addStockList.Click += new System.EventHandler(this.tsmi_addStockList_Click);
            // 
            // tsmi_StockListPro
            // 
            this.tsmi_StockListPro.Name = "tsmi_StockListPro";
            this.tsmi_StockListPro.Size = new System.Drawing.Size(100, 22);
            this.tsmi_StockListPro.Text = "属性";
            this.tsmi_StockListPro.Click += new System.EventHandler(this.tsmi_StockListPro_Click);
            // 
            // cb_GSTaskType
            // 
            this.cb_GSTaskType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_GSTaskType.FormattingEnabled = true;
            this.cb_GSTaskType.Location = new System.Drawing.Point(273, 46);
            this.cb_GSTaskType.Name = "cb_GSTaskType";
            this.cb_GSTaskType.Size = new System.Drawing.Size(90, 20);
            this.cb_GSTaskType.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(179, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 18;
            this.label7.Text = "货位任务状态：";
            // 
            // cb_GSStatus
            // 
            this.cb_GSStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_GSStatus.FormattingEnabled = true;
            this.cb_GSStatus.Location = new System.Drawing.Point(437, 46);
            this.cb_GSStatus.Name = "cb_GSStatus";
            this.cb_GSStatus.Size = new System.Drawing.Size(90, 20);
            this.cb_GSStatus.TabIndex = 17;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.cb_HouseArea);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.bt_RefreshBatch);
            this.groupBox2.Controls.Add(this.cb_ProductBatch);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cb_GSTaskType);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cb_GSStatus);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cb_StockLayer);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cb_StockColumn);
            this.groupBox2.Controls.Add(this.cb_StockRow);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cb_StoreHouse);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(6, 34);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(980, 71);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "货位筛选条件";
            // 
            // cb_HouseArea
            // 
            this.cb_HouseArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_HouseArea.FormattingEnabled = true;
            this.cb_HouseArea.Items.AddRange(new object[] {
            " "});
            this.cb_HouseArea.Location = new System.Drawing.Point(273, 17);
            this.cb_HouseArea.Name = "cb_HouseArea";
            this.cb_HouseArea.Size = new System.Drawing.Size(90, 20);
            this.cb_HouseArea.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(179, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 12);
            this.label10.TabIndex = 24;
            this.label10.Text = "库        区：";
            // 
            // bt_RefreshBatch
            // 
            this.bt_RefreshBatch.Location = new System.Drawing.Point(717, 37);
            this.bt_RefreshBatch.Name = "bt_RefreshBatch";
            this.bt_RefreshBatch.Size = new System.Drawing.Size(95, 31);
            this.bt_RefreshBatch.TabIndex = 23;
            this.bt_RefreshBatch.Text = "刷新批次信息";
            this.bt_RefreshBatch.UseVisualStyleBackColor = true;
            this.bt_RefreshBatch.Click += new System.EventHandler(this.bt_RefreshBatch_Click);
            // 
            // cb_ProductBatch
            // 
            this.cb_ProductBatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ProductBatch.FormattingEnabled = true;
            this.cb_ProductBatch.Location = new System.Drawing.Point(608, 45);
            this.cb_ProductBatch.Name = "cb_ProductBatch";
            this.cb_ProductBatch.Size = new System.Drawing.Size(97, 20);
            this.cb_ProductBatch.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(539, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 20;
            this.label4.Text = "产品批次：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(368, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "货位状态：";
            // 
            // cb_StockLayer
            // 
            this.cb_StockLayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_StockLayer.FormattingEnabled = true;
            this.cb_StockLayer.Location = new System.Drawing.Point(84, 46);
            this.cb_StockLayer.Name = "cb_StockLayer";
            this.cb_StockLayer.Size = new System.Drawing.Size(90, 20);
            this.cb_StockLayer.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "层    数：";
            // 
            // cb_StockColumn
            // 
            this.cb_StockColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_StockColumn.FormattingEnabled = true;
            this.cb_StockColumn.Location = new System.Drawing.Point(608, 17);
            this.cb_StockColumn.Name = "cb_StockColumn";
            this.cb_StockColumn.Size = new System.Drawing.Size(97, 20);
            this.cb_StockColumn.TabIndex = 8;
            this.cb_StockColumn.SelectedIndexChanged += new System.EventHandler(this.cb_StockColumn_SelectedIndexChanged);
            // 
            // cb_StockRow
            // 
            this.cb_StockRow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_StockRow.FormattingEnabled = true;
            this.cb_StockRow.Location = new System.Drawing.Point(437, 17);
            this.cb_StockRow.Name = "cb_StockRow";
            this.cb_StockRow.Size = new System.Drawing.Size(90, 20);
            this.cb_StockRow.TabIndex = 7;
            this.cb_StockRow.SelectedIndexChanged += new System.EventHandler(this.cb_StockRow_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(539, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "列    数：";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(368, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "排    数：";
            // 
            // cb_StoreHouse
            // 
            this.cb_StoreHouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_StoreHouse.FormattingEnabled = true;
            this.cb_StoreHouse.Items.AddRange(new object[] {
            " "});
            this.cb_StoreHouse.Location = new System.Drawing.Point(84, 17);
            this.cb_StoreHouse.Name = "cb_StoreHouse";
            this.cb_StoreHouse.Size = new System.Drawing.Size(90, 20);
            this.cb_StoreHouse.TabIndex = 1;
            this.cb_StoreHouse.SelectedIndexChanged += new System.EventHandler(this.cb_StoreHouse_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "存储仓库：";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_QueryStock,
            this.tsb_OutputManual,
            this.tsb_GsStatusModify,
            this.tsb_deleteStock,
            this.tsb_returnOutFac,
            this.tsb_UseGS,
            this.tsb_UnuseGs,
            this.tsb_ProductNum});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(986, 31);
            this.toolStrip1.TabIndex = 33;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsb_QueryStock
            // 
            this.tsb_QueryStock.Image = ((System.Drawing.Image)(resources.GetObject("tsb_QueryStock.Image")));
            this.tsb_QueryStock.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsb_QueryStock.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_QueryStock.Name = "tsb_QueryStock";
            this.tsb_QueryStock.Size = new System.Drawing.Size(58, 28);
            this.tsb_QueryStock.Text = "查询";
            this.tsb_QueryStock.Click += new System.EventHandler(this.tsb_QueryStock_Click);
            // 
            // tsb_OutputManual
            // 
            this.tsb_OutputManual.Image = ((System.Drawing.Image)(resources.GetObject("tsb_OutputManual.Image")));
            this.tsb_OutputManual.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsb_OutputManual.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_OutputManual.Name = "tsb_OutputManual";
            this.tsb_OutputManual.Size = new System.Drawing.Size(82, 28);
            this.tsb_OutputManual.Text = "手动出库";
            this.tsb_OutputManual.Click += new System.EventHandler(this.tsb_OutputManual_Click);
            // 
            // tsb_GsStatusModify
            // 
            this.tsb_GsStatusModify.Image = ((System.Drawing.Image)(resources.GetObject("tsb_GsStatusModify.Image")));
            this.tsb_GsStatusModify.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsb_GsStatusModify.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_GsStatusModify.Name = "tsb_GsStatusModify";
            this.tsb_GsStatusModify.Size = new System.Drawing.Size(106, 28);
            this.tsb_GsStatusModify.Text = "库存状态修改";
            this.tsb_GsStatusModify.Click += new System.EventHandler(this.tsb_GsStaModify_Click);
            // 
            // tsb_deleteStock
            // 
            this.tsb_deleteStock.Image = ((System.Drawing.Image)(resources.GetObject("tsb_deleteStock.Image")));
            this.tsb_deleteStock.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsb_deleteStock.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_deleteStock.Name = "tsb_deleteStock";
            this.tsb_deleteStock.Size = new System.Drawing.Size(82, 28);
            this.tsb_deleteStock.Text = "删除库存";
            this.tsb_deleteStock.Click += new System.EventHandler(this.tsb_deleteStock_Click);
            // 
            // tsb_returnOutFac
            // 
            this.tsb_returnOutFac.Image = ((System.Drawing.Image)(resources.GetObject("tsb_returnOutFac.Image")));
            this.tsb_returnOutFac.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsb_returnOutFac.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_returnOutFac.Name = "tsb_returnOutFac";
            this.tsb_returnOutFac.Size = new System.Drawing.Size(108, 28);
            this.tsb_returnOutFac.Text = "恢复出厂设置";
            this.tsb_returnOutFac.Visible = false;
            this.tsb_returnOutFac.Click += new System.EventHandler(this.tsb_returnOutFac_Click);
            // 
            // tsb_UseGS
            // 
            this.tsb_UseGS.Image = ((System.Drawing.Image)(resources.GetObject("tsb_UseGS.Image")));
            this.tsb_UseGS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_UseGS.Name = "tsb_UseGS";
            this.tsb_UseGS.Size = new System.Drawing.Size(76, 28);
            this.tsb_UseGS.Text = "货位启用";
            this.tsb_UseGS.Click += new System.EventHandler(this.tsb_UseGS_Click);
            // 
            // tsb_UnuseGs
            // 
            this.tsb_UnuseGs.Image = ((System.Drawing.Image)(resources.GetObject("tsb_UnuseGs.Image")));
            this.tsb_UnuseGs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_UnuseGs.Name = "tsb_UnuseGs";
            this.tsb_UnuseGs.Size = new System.Drawing.Size(76, 28);
            this.tsb_UnuseGs.Text = "货位禁用";
            this.tsb_UnuseGs.Click += new System.EventHandler(this.tsb_UnuseGs_Click);
            // 
            // tsb_ProductNum
            // 
            this.tsb_ProductNum.Image = ((System.Drawing.Image)(resources.GetObject("tsb_ProductNum.Image")));
            this.tsb_ProductNum.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_ProductNum.Name = "tsb_ProductNum";
            this.tsb_ProductNum.Size = new System.Drawing.Size(100, 28);
            this.tsb_ProductNum.Text = "产品数量查询";
            this.tsb_ProductNum.Click += new System.EventHandler(this.tsb_ProductNum_Click);
            // 
            // lb_GSNum
            // 
            this.lb_GSNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lb_GSNum.AutoSize = true;
            this.lb_GSNum.Location = new System.Drawing.Point(83, 345);
            this.lb_GSNum.Name = "lb_GSNum";
            this.lb_GSNum.Size = new System.Drawing.Size(23, 12);
            this.lb_GSNum.TabIndex = 41;
            this.lb_GSNum.Text = "---";
            // 
            // lb_PalletNum
            // 
            this.lb_PalletNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lb_PalletNum.AutoSize = true;
            this.lb_PalletNum.Location = new System.Drawing.Point(219, 345);
            this.lb_PalletNum.Name = "lb_PalletNum";
            this.lb_PalletNum.Size = new System.Drawing.Size(23, 12);
            this.lb_PalletNum.TabIndex = 40;
            this.lb_PalletNum.Text = "---";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(148, 345);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 39;
            this.label9.Text = "料框数量：";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 345);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 38;
            this.label5.Text = "货位数量：";
            // 
            // gb_Model
            // 
            this.gb_Model.Controls.Add(this.tableLayoutPanel3);
            this.gb_Model.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_Model.Location = new System.Drawing.Point(0, 0);
            this.gb_Model.Name = "gb_Model";
            this.gb_Model.Size = new System.Drawing.Size(96, 100);
            this.gb_Model.TabIndex = 3;
            this.gb_Model.TabStop = false;
            this.gb_Model.Text = "模块";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.pl_ExterProParent, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.bt_CloseExpandView, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(90, 80);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // pl_ExterProParent
            // 
            this.pl_ExterProParent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pl_ExterProParent.Location = new System.Drawing.Point(3, 33);
            this.pl_ExterProParent.Name = "pl_ExterProParent";
            this.pl_ExterProParent.Size = new System.Drawing.Size(84, 44);
            this.pl_ExterProParent.TabIndex = 1;
            // 
            // bt_CloseExpandView
            // 
            this.bt_CloseExpandView.Location = new System.Drawing.Point(3, 3);
            this.bt_CloseExpandView.Name = "bt_CloseExpandView";
            this.bt_CloseExpandView.Size = new System.Drawing.Size(84, 23);
            this.bt_CloseExpandView.TabIndex = 0;
            this.bt_CloseExpandView.Text = " 关  闭";
            this.bt_CloseExpandView.UseVisualStyleBackColor = true;
            this.bt_CloseExpandView.Click += new System.EventHandler(this.bt_CloseExpandView_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(6, 106);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lb_ProductNum);
            this.splitContainer1.Panel1.Controls.Add(this.label11);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.lb_GSNum);
            this.splitContainer1.Panel1.Controls.Add(this.lb_PalletNum);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gb_Model);
            this.splitContainer1.Panel2Collapsed = true;
            this.splitContainer1.Size = new System.Drawing.Size(980, 362);
            this.splitContainer1.SplitterDistance = 657;
            this.splitContainer1.TabIndex = 34;
            // 
            // lb_ProductNum
            // 
            this.lb_ProductNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lb_ProductNum.AutoSize = true;
            this.lb_ProductNum.Location = new System.Drawing.Point(359, 345);
            this.lb_ProductNum.Name = "lb_ProductNum";
            this.lb_ProductNum.Size = new System.Drawing.Size(23, 12);
            this.lb_ProductNum.TabIndex = 44;
            this.lb_ProductNum.Text = "---";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(288, 344);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 43;
            this.label11.Text = "产品数量：";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgv_StockInfor);
            this.groupBox1.Location = new System.Drawing.Point(0, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(976, 334);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "库存信息";
            // 
            // dgv_StockInfor
            // 
            this.dgv_StockInfor.AllowUserToAddRows = false;
            this.dgv_StockInfor.AllowUserToDeleteRows = false;
            this.dgv_StockInfor.AllowUserToResizeRows = false;
            this.dgv_StockInfor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_StockInfor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StockID,
            this.col_HouseName,
            this.col_HouseArea,
            this.ProductBatch,
            this.GoodsSiteName,
            this.rowth,
            this.colth,
            this.layerth,
            this.gs_Status,
            this.gs_TaskStatus,
            this.col_ProductCode,
            this.col_StartStatus,
            this.col_InHousetime});
            this.dgv_StockInfor.ContextMenuStrip = this.cms_StockMana;
            this.dgv_StockInfor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_StockInfor.Location = new System.Drawing.Point(3, 17);
            this.dgv_StockInfor.Name = "dgv_StockInfor";
            this.dgv_StockInfor.RowHeadersVisible = false;
            this.dgv_StockInfor.RowTemplate.Height = 23;
            this.dgv_StockInfor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_StockInfor.Size = new System.Drawing.Size(970, 314);
            this.dgv_StockInfor.TabIndex = 0;
            // 
            // StockID
            // 
            this.StockID.HeaderText = "库存ID";
            this.StockID.Name = "StockID";
            this.StockID.Width = 96;
            // 
            // col_HouseName
            // 
            this.col_HouseName.HeaderText = "库房";
            this.col_HouseName.Name = "col_HouseName";
            // 
            // col_HouseArea
            // 
            this.col_HouseArea.HeaderText = "库区";
            this.col_HouseArea.Name = "col_HouseArea";
            // 
            // ProductBatch
            // 
            this.ProductBatch.HeaderText = "产品批次";
            this.ProductBatch.Name = "ProductBatch";
            this.ProductBatch.Width = 96;
            // 
            // GoodsSiteName
            // 
            this.GoodsSiteName.HeaderText = "货位名称";
            this.GoodsSiteName.Name = "GoodsSiteName";
            this.GoodsSiteName.Width = 97;
            // 
            // rowth
            // 
            this.rowth.HeaderText = "排";
            this.rowth.Name = "rowth";
            this.rowth.Width = 50;
            // 
            // colth
            // 
            this.colth.HeaderText = "列";
            this.colth.Name = "colth";
            this.colth.Width = 50;
            // 
            // layerth
            // 
            this.layerth.HeaderText = "层";
            this.layerth.Name = "layerth";
            this.layerth.Width = 50;
            // 
            // gs_Status
            // 
            this.gs_Status.HeaderText = "货位状态";
            this.gs_Status.Name = "gs_Status";
            this.gs_Status.Width = 96;
            // 
            // gs_TaskStatus
            // 
            this.gs_TaskStatus.HeaderText = "货位任务状态";
            this.gs_TaskStatus.Name = "gs_TaskStatus";
            this.gs_TaskStatus.Width = 97;
            // 
            // col_ProductCode
            // 
            this.col_ProductCode.HeaderText = "料框条码";
            this.col_ProductCode.Name = "col_ProductCode";
            this.col_ProductCode.Width = 200;
            // 
            // col_StartStatus
            // 
            this.col_StartStatus.HeaderText = "启用状态";
            this.col_StartStatus.Name = "col_StartStatus";
            // 
            // col_InHousetime
            // 
            this.col_InHousetime.HeaderText = "入库时间";
            this.col_InHousetime.Name = "col_InHousetime";
            this.col_InHousetime.Width = 96;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // StockManaView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 473);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox2);
            this.Name = "StockManaView";
            this.Text = "库存管理";
            this.Load += new System.EventHandler(this.StackManaView_Load);
            this.cms_StockMana.ResumeLayout(false);
            this.cms_StockList.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.gb_Model.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_StockInfor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cms_StockMana;
        private System.Windows.Forms.ToolStripMenuItem tsmi_StockStaModify;
        private System.Windows.Forms.ToolStripMenuItem tsmi_OutputManual;
        private System.Windows.Forms.ToolStripMenuItem tsmi_deleteStock;
        private System.Windows.Forms.ComboBox cb_GSTaskType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cb_GSStatus;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cb_StockLayer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cb_StockColumn;
        private System.Windows.Forms.ComboBox cb_StockRow;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_StoreHouse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsb_QueryStock;
        private System.Windows.Forms.ToolStripButton tsb_OutputManual;
        private System.Windows.Forms.ToolStripButton tsb_returnOutFac;
        private System.Windows.Forms.ToolStripButton tsb_deleteStock;
        private System.Windows.Forms.ToolStripButton tsb_GsStatusModify;
        private System.Windows.Forms.ContextMenuStrip cms_StockList;
        private System.Windows.Forms.ToolStripMenuItem tsmi_delete;
        private System.Windows.Forms.ToolStripMenuItem tsmi_addStockList;
        private System.Windows.Forms.ComboBox cb_ProductBatch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem tsmi_StockListPro;
        private System.Windows.Forms.ToolStripButton tsb_UseGS;
        private System.Windows.Forms.ToolStripButton tsb_UnuseGs;
        private System.Windows.Forms.Label lb_GSNum;
        private System.Windows.Forms.Label lb_PalletNum;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bt_RefreshBatch;
        private System.Windows.Forms.GroupBox gb_Model;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel pl_ExterProParent;
        private System.Windows.Forms.Button bt_CloseExpandView;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv_StockInfor;
        private System.Windows.Forms.Label lb_ProductNum;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripButton tsb_ProductNum;
        private System.Windows.Forms.ComboBox cb_HouseArea;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockID;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_HouseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_HouseArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductBatch;
        private System.Windows.Forms.DataGridViewTextBoxColumn GoodsSiteName;
        private System.Windows.Forms.DataGridViewTextBoxColumn rowth;
        private System.Windows.Forms.DataGridViewTextBoxColumn colth;
        private System.Windows.Forms.DataGridViewTextBoxColumn layerth;
        private System.Windows.Forms.DataGridViewTextBoxColumn gs_Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn gs_TaskStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_StartStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_InHousetime;
    }
}