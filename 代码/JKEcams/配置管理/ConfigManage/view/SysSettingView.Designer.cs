namespace ConfigManage
{
    partial class SysSettingView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SysSettingView));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDispProcessParams = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxHouseC2 = new System.Windows.Forms.CheckBox();
            this.checkBoxUnbind = new System.Windows.Forms.CheckBox();
            this.checkBoxHouseB = new System.Windows.Forms.CheckBox();
            this.checkBoxHouseC1 = new System.Windows.Forms.CheckBox();
            this.checkBoxHouseA = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxA1BurninTime = new System.Windows.Forms.TextBox();
            this.buttonCfgApply = new System.Windows.Forms.Button();
            this.buttonCancelSet = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonCancelBatch = new System.Windows.Forms.Button();
            this.buttonAddBatch = new System.Windows.Forms.Button();
            this.richTextBoxMark = new System.Windows.Forms.RichTextBox();
            this.textBoxBatch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnDelBatchCfg = new System.Windows.Forms.ToolStripButton();
            this.btnRefresBatchCfg = new System.Windows.Forms.ToolStripButton();
            this.btnModifyBatch = new System.Windows.Forms.ToolStripButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonSaveCfg = new System.Windows.Forms.Button();
            this.buttonDispCfg = new System.Windows.Forms.Button();
            this.btnExportCfg = new System.Windows.Forms.Button();
            this.buttonImportCfg = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1013, 414);
            this.panel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1013, 414);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.buttonCfgApply);
            this.tabPage1.Controls.Add(this.buttonCancelSet);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1005, 388);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "系统设置";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDispProcessParams);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(8, 131);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(587, 211);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "老化时间设置";
            // 
            // btnDispProcessParams
            // 
            this.btnDispProcessParams.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.btnDispProcessParams.Font = new System.Drawing.Font("宋体", 13F);
            this.btnDispProcessParams.Location = new System.Drawing.Point(23, 20);
            this.btnDispProcessParams.Name = "btnDispProcessParams";
            this.btnDispProcessParams.Size = new System.Drawing.Size(156, 36);
            this.btnDispProcessParams.TabIndex = 1;
            this.btnDispProcessParams.Text = "刷新";
            this.btnDispProcessParams.UseVisualStyleBackColor = false;
            this.btnDispProcessParams.Click += new System.EventHandler(this.btnDispProcessParams_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 62);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(578, 143);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxHouseC2);
            this.groupBox1.Controls.Add(this.checkBoxUnbind);
            this.groupBox1.Controls.Add(this.checkBoxHouseB);
            this.groupBox1.Controls.Add(this.checkBoxHouseC1);
            this.groupBox1.Controls.Add(this.checkBoxHouseA);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxA1BurninTime);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 13F);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(589, 109);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "通用设置";
            // 
            // checkBoxHouseC2
            // 
            this.checkBoxHouseC2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxHouseC2.AutoSize = true;
            this.checkBoxHouseC2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBoxHouseC2.Location = new System.Drawing.Point(495, 46);
            this.checkBoxHouseC2.Name = "checkBoxHouseC2";
            this.checkBoxHouseC2.Size = new System.Drawing.Size(91, 20);
            this.checkBoxHouseC2.TabIndex = 4;
            this.checkBoxHouseC2.Text = "C2库启用";
            this.checkBoxHouseC2.UseVisualStyleBackColor = true;
            this.checkBoxHouseC2.Visible = false;
            // 
            // checkBoxUnbind
            // 
            this.checkBoxUnbind.AutoSize = true;
            this.checkBoxUnbind.Font = new System.Drawing.Font("宋体", 13F);
            this.checkBoxUnbind.Location = new System.Drawing.Point(12, 30);
            this.checkBoxUnbind.Name = "checkBoxUnbind";
            this.checkBoxUnbind.Size = new System.Drawing.Size(153, 22);
            this.checkBoxUnbind.TabIndex = 4;
            this.checkBoxUnbind.Text = "无RFID绑定模式";
            this.checkBoxUnbind.UseVisualStyleBackColor = true;
            // 
            // checkBoxHouseB
            // 
            this.checkBoxHouseB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxHouseB.AutoSize = true;
            this.checkBoxHouseB.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBoxHouseB.Location = new System.Drawing.Point(374, 46);
            this.checkBoxHouseB.Name = "checkBoxHouseB";
            this.checkBoxHouseB.Size = new System.Drawing.Size(91, 20);
            this.checkBoxHouseB.TabIndex = 4;
            this.checkBoxHouseB.Text = "B1库启用";
            this.checkBoxHouseB.UseVisualStyleBackColor = true;
            this.checkBoxHouseB.Visible = false;
            // 
            // checkBoxHouseC1
            // 
            this.checkBoxHouseC1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxHouseC1.AutoSize = true;
            this.checkBoxHouseC1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBoxHouseC1.Location = new System.Drawing.Point(495, 20);
            this.checkBoxHouseC1.Name = "checkBoxHouseC1";
            this.checkBoxHouseC1.Size = new System.Drawing.Size(91, 20);
            this.checkBoxHouseC1.TabIndex = 4;
            this.checkBoxHouseC1.Text = "C1库启用";
            this.checkBoxHouseC1.UseVisualStyleBackColor = true;
            this.checkBoxHouseC1.Visible = false;
            // 
            // checkBoxHouseA
            // 
            this.checkBoxHouseA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxHouseA.AutoSize = true;
            this.checkBoxHouseA.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBoxHouseA.Location = new System.Drawing.Point(374, 20);
            this.checkBoxHouseA.Name = "checkBoxHouseA";
            this.checkBoxHouseA.Size = new System.Drawing.Size(91, 20);
            this.checkBoxHouseA.TabIndex = 4;
            this.checkBoxHouseA.Text = "A1库启用";
            this.checkBoxHouseA.UseVisualStyleBackColor = true;
            this.checkBoxHouseA.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 13F);
            this.label1.Location = new System.Drawing.Point(7, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 36);
            this.label1.TabIndex = 3;
            this.label1.Text = "默认老化时间\r\n（单位：小时）";
            this.label1.Visible = false;
            // 
            // textBoxA1BurninTime
            // 
            this.textBoxA1BurninTime.Location = new System.Drawing.Point(152, 70);
            this.textBoxA1BurninTime.Name = "textBoxA1BurninTime";
            this.textBoxA1BurninTime.Size = new System.Drawing.Size(135, 27);
            this.textBoxA1BurninTime.TabIndex = 2;
            this.textBoxA1BurninTime.Visible = false;
            // 
            // buttonCfgApply
            // 
            this.buttonCfgApply.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonCfgApply.Location = new System.Drawing.Point(18, 348);
            this.buttonCfgApply.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCfgApply.Name = "buttonCfgApply";
            this.buttonCfgApply.Size = new System.Drawing.Size(124, 38);
            this.buttonCfgApply.TabIndex = 1;
            this.buttonCfgApply.Text = "应用";
            this.buttonCfgApply.UseVisualStyleBackColor = true;
            this.buttonCfgApply.Click += new System.EventHandler(this.buttonCfgApply_Click);
            // 
            // buttonCancelSet
            // 
            this.buttonCancelSet.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonCancelSet.Location = new System.Drawing.Point(160, 347);
            this.buttonCancelSet.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCancelSet.Name = "buttonCancelSet";
            this.buttonCancelSet.Size = new System.Drawing.Size(124, 38);
            this.buttonCancelSet.TabIndex = 1;
            this.buttonCancelSet.Text = "取消";
            this.buttonCancelSet.UseVisualStyleBackColor = true;
            this.buttonCancelSet.Click += new System.EventHandler(this.buttonCancelSet_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.toolStrip2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1005, 388);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "产品批次管理";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(-1, 111);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(1006, 277);
            this.dataGridView2.TabIndex = 5;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.buttonCancelBatch);
            this.panel2.Controls.Add(this.buttonAddBatch);
            this.panel2.Controls.Add(this.richTextBoxMark);
            this.panel2.Controls.Add(this.textBoxBatch);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Location = new System.Drawing.Point(3, 31);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(994, 74);
            this.panel2.TabIndex = 4;
            // 
            // buttonCancelBatch
            // 
            this.buttonCancelBatch.Location = new System.Drawing.Point(139, 33);
            this.buttonCancelBatch.Name = "buttonCancelBatch";
            this.buttonCancelBatch.Size = new System.Drawing.Size(107, 31);
            this.buttonCancelBatch.TabIndex = 4;
            this.buttonCancelBatch.Text = "取消";
            this.buttonCancelBatch.UseVisualStyleBackColor = true;
            this.buttonCancelBatch.Click += new System.EventHandler(this.buttonCancelBatch_Click);
            // 
            // buttonAddBatch
            // 
            this.buttonAddBatch.Location = new System.Drawing.Point(17, 33);
            this.buttonAddBatch.Name = "buttonAddBatch";
            this.buttonAddBatch.Size = new System.Drawing.Size(106, 31);
            this.buttonAddBatch.TabIndex = 4;
            this.buttonAddBatch.Text = "添加";
            this.buttonAddBatch.UseVisualStyleBackColor = true;
            this.buttonAddBatch.Click += new System.EventHandler(this.buttonAddBatch_Click);
            // 
            // richTextBoxMark
            // 
            this.richTextBoxMark.Location = new System.Drawing.Point(337, 3);
            this.richTextBoxMark.Name = "richTextBoxMark";
            this.richTextBoxMark.Size = new System.Drawing.Size(421, 61);
            this.richTextBoxMark.TabIndex = 2;
            this.richTextBoxMark.Text = "";
            // 
            // textBoxBatch
            // 
            this.textBoxBatch.Location = new System.Drawing.Point(63, 3);
            this.textBoxBatch.Name = "textBoxBatch";
            this.textBoxBatch.Size = new System.Drawing.Size(183, 21);
            this.textBoxBatch.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(285, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "备注";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "批次号";
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDelBatchCfg,
            this.btnRefresBatchCfg,
            this.btnModifyBatch});
            this.toolStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip2.Location = new System.Drawing.Point(3, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(999, 25);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnDelBatchCfg
            // 
            this.btnDelBatchCfg.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDelBatchCfg.Image = ((System.Drawing.Image)(resources.GetObject("btnDelBatchCfg.Image")));
            this.btnDelBatchCfg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelBatchCfg.Name = "btnDelBatchCfg";
            this.btnDelBatchCfg.Size = new System.Drawing.Size(36, 22);
            this.btnDelBatchCfg.Text = "删除";
            this.btnDelBatchCfg.Click += new System.EventHandler(this.btnDelBatchCfg_Click);
            // 
            // btnRefresBatchCfg
            // 
            this.btnRefresBatchCfg.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnRefresBatchCfg.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresBatchCfg.Image")));
            this.btnRefresBatchCfg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresBatchCfg.Name = "btnRefresBatchCfg";
            this.btnRefresBatchCfg.Size = new System.Drawing.Size(36, 22);
            this.btnRefresBatchCfg.Text = "刷新";
            this.btnRefresBatchCfg.ToolTipText = "显示所有";
            this.btnRefresBatchCfg.Click += new System.EventHandler(this.btnRefresBatchCfg_Click);
            // 
            // btnModifyBatch
            // 
            this.btnModifyBatch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnModifyBatch.Image = ((System.Drawing.Image)(resources.GetObject("btnModifyBatch.Image")));
            this.btnModifyBatch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnModifyBatch.Name = "btnModifyBatch";
            this.btnModifyBatch.Size = new System.Drawing.Size(36, 22);
            this.btnModifyBatch.Text = "修改";
            this.btnModifyBatch.Click += new System.EventHandler(this.btnModifyBatch_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tableLayoutPanel1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1005, 388);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "系统配置文件";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.richTextBox1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(999, 382);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel3.Controls.Add(this.buttonSaveCfg);
            this.panel3.Controls.Add(this.buttonDispCfg);
            this.panel3.Controls.Add(this.btnExportCfg);
            this.panel3.Controls.Add(this.buttonImportCfg);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(993, 49);
            this.panel3.TabIndex = 0;
            // 
            // buttonSaveCfg
            // 
            this.buttonSaveCfg.Location = new System.Drawing.Point(396, 3);
            this.buttonSaveCfg.Name = "buttonSaveCfg";
            this.buttonSaveCfg.Size = new System.Drawing.Size(121, 43);
            this.buttonSaveCfg.TabIndex = 0;
            this.buttonSaveCfg.Text = "保存";
            this.buttonSaveCfg.UseVisualStyleBackColor = true;
            this.buttonSaveCfg.Click += new System.EventHandler(this.buttonSaveCfg_Click);
            // 
            // buttonDispCfg
            // 
            this.buttonDispCfg.Location = new System.Drawing.Point(150, 3);
            this.buttonDispCfg.Name = "buttonDispCfg";
            this.buttonDispCfg.Size = new System.Drawing.Size(117, 43);
            this.buttonDispCfg.TabIndex = 0;
            this.buttonDispCfg.Text = "查看配置文件";
            this.buttonDispCfg.UseVisualStyleBackColor = true;
            this.buttonDispCfg.Click += new System.EventHandler(this.buttonDispCfg_Click);
            // 
            // btnExportCfg
            // 
            this.btnExportCfg.Location = new System.Drawing.Point(273, 3);
            this.btnExportCfg.Name = "btnExportCfg";
            this.btnExportCfg.Size = new System.Drawing.Size(117, 43);
            this.btnExportCfg.TabIndex = 0;
            this.btnExportCfg.Text = "导出配置文件";
            this.btnExportCfg.UseVisualStyleBackColor = true;
            this.btnExportCfg.Click += new System.EventHandler(this.btnExportCfg_Click);
            // 
            // buttonImportCfg
            // 
            this.buttonImportCfg.Location = new System.Drawing.Point(27, 3);
            this.buttonImportCfg.Name = "buttonImportCfg";
            this.buttonImportCfg.Size = new System.Drawing.Size(117, 43);
            this.buttonImportCfg.TabIndex = 0;
            this.buttonImportCfg.Text = "导入配置文件";
            this.buttonImportCfg.UseVisualStyleBackColor = true;
            this.buttonImportCfg.Click += new System.EventHandler(this.buttonImportCfg_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox1.Location = new System.Drawing.Point(3, 58);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(993, 321);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // SysSettingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 414);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SysSettingView";
            this.Text = "系统设置";
            this.Load += new System.EventHandler(this.SysSettingView_Load);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonCfgApply;
        private System.Windows.Forms.Button buttonCancelSet;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxA1BurninTime;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnDelBatchCfg;
        private System.Windows.Forms.ToolStripButton btnRefresBatchCfg;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonCancelBatch;
        private System.Windows.Forms.Button buttonAddBatch;
        private System.Windows.Forms.RichTextBox richTextBoxMark;
        private System.Windows.Forms.TextBox textBoxBatch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.ToolStripButton btnModifyBatch;
        private System.Windows.Forms.CheckBox checkBoxHouseB;
        private System.Windows.Forms.CheckBox checkBoxHouseA;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button buttonSaveCfg;
        private System.Windows.Forms.Button buttonImportCfg;
        private System.Windows.Forms.Button buttonDispCfg;
        private System.Windows.Forms.Button btnExportCfg;
        private System.Windows.Forms.CheckBox checkBoxHouseC2;
        private System.Windows.Forms.CheckBox checkBoxHouseC1;
        private System.Windows.Forms.CheckBox checkBoxUnbind;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnDispProcessParams;
    }
}