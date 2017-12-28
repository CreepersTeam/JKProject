namespace ProductRecordView
{
    partial class XWEGSView
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
            this.bt_QueryGs = new System.Windows.Forms.Button();
            this.dgv_GS = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_HouseName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bt_DcrTestError = new System.Windows.Forms.Button();
            this.bt_DcrTest = new System.Windows.Forms.Button();
            this.bt_PowerExcept = new System.Windows.Forms.Button();
            this.bt_PowerCmd = new System.Windows.Forms.Button();
            this.bt_Save = new System.Windows.Forms.Button();
            this.tb_GsName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgv_TestDetail = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_GS)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TestDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_QueryGs
            // 
            this.bt_QueryGs.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_QueryGs.Location = new System.Drawing.Point(493, 18);
            this.bt_QueryGs.Name = "bt_QueryGs";
            this.bt_QueryGs.Size = new System.Drawing.Size(80, 34);
            this.bt_QueryGs.TabIndex = 4;
            this.bt_QueryGs.Text = "查询";
            this.bt_QueryGs.UseVisualStyleBackColor = true;
            this.bt_QueryGs.Click += new System.EventHandler(this.bt_QueryGs_Click);
            // 
            // dgv_GS
            // 
            this.dgv_GS.AllowUserToAddRows = false;
            this.dgv_GS.AllowUserToDeleteRows = false;
            this.dgv_GS.AllowUserToResizeRows = false;
            this.dgv_GS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_GS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_GS.Location = new System.Drawing.Point(3, 17);
            this.dgv_GS.Name = "dgv_GS";
            this.dgv_GS.RowTemplate.Height = 23;
            this.dgv_GS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_GS.Size = new System.Drawing.Size(1040, 281);
            this.dgv_GS.TabIndex = 5;
            this.dgv_GS.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_GS_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "库房";
            // 
            // cb_HouseName
            // 
            this.cb_HouseName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_HouseName.FormattingEnabled = true;
            this.cb_HouseName.Items.AddRange(new object[] {
            "A1库房",
            "B1库房"});
            this.cb_HouseName.Location = new System.Drawing.Point(58, 26);
            this.cb_HouseName.Name = "cb_HouseName";
            this.cb_HouseName.Size = new System.Drawing.Size(147, 20);
            this.cb_HouseName.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(222, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "货位名称";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.bt_DcrTestError);
            this.groupBox1.Controls.Add(this.bt_DcrTest);
            this.groupBox1.Controls.Add(this.bt_PowerExcept);
            this.groupBox1.Controls.Add(this.bt_PowerCmd);
            this.groupBox1.Controls.Add(this.bt_Save);
            this.groupBox1.Controls.Add(this.bt_QueryGs);
            this.groupBox1.Controls.Add(this.tb_GsName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cb_HouseName);
            this.groupBox1.Location = new System.Drawing.Point(5, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1043, 71);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "操作";
            // 
            // bt_DcrTestError
            // 
            this.bt_DcrTestError.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_DcrTestError.Location = new System.Drawing.Point(893, 18);
            this.bt_DcrTestError.Name = "bt_DcrTestError";
            this.bt_DcrTestError.Size = new System.Drawing.Size(80, 34);
            this.bt_DcrTestError.TabIndex = 15;
            this.bt_DcrTestError.Text = "DCR测试报警";
            this.bt_DcrTestError.UseVisualStyleBackColor = true;
            this.bt_DcrTestError.Click += new System.EventHandler(this.bt_DcrTestError_Click);
            // 
            // bt_DcrTest
            // 
            this.bt_DcrTest.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_DcrTest.Location = new System.Drawing.Point(813, 18);
            this.bt_DcrTest.Name = "bt_DcrTest";
            this.bt_DcrTest.Size = new System.Drawing.Size(80, 34);
            this.bt_DcrTest.TabIndex = 14;
            this.bt_DcrTest.Text = "DCR测试成功";
            this.bt_DcrTest.UseVisualStyleBackColor = true;
            this.bt_DcrTest.Click += new System.EventHandler(this.bt_DcrTest_Click);
            // 
            // bt_PowerExcept
            // 
            this.bt_PowerExcept.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_PowerExcept.Location = new System.Drawing.Point(733, 18);
            this.bt_PowerExcept.Name = "bt_PowerExcept";
            this.bt_PowerExcept.Size = new System.Drawing.Size(80, 34);
            this.bt_PowerExcept.TabIndex = 13;
            this.bt_PowerExcept.Text = "冲放电异常";
            this.bt_PowerExcept.UseVisualStyleBackColor = true;
            this.bt_PowerExcept.Click += new System.EventHandler(this.bt_PowerExcept_Click);
            // 
            // bt_PowerCmd
            // 
            this.bt_PowerCmd.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_PowerCmd.Location = new System.Drawing.Point(653, 18);
            this.bt_PowerCmd.Name = "bt_PowerCmd";
            this.bt_PowerCmd.Size = new System.Drawing.Size(80, 34);
            this.bt_PowerCmd.TabIndex = 12;
            this.bt_PowerCmd.Tag = "";
            this.bt_PowerCmd.Text = "冲放电完成";
            this.bt_PowerCmd.UseVisualStyleBackColor = true;
            this.bt_PowerCmd.Click += new System.EventHandler(this.bt_PowerCmd_Click);
            // 
            // bt_Save
            // 
            this.bt_Save.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_Save.Location = new System.Drawing.Point(573, 18);
            this.bt_Save.Name = "bt_Save";
            this.bt_Save.Size = new System.Drawing.Size(80, 34);
            this.bt_Save.TabIndex = 11;
            this.bt_Save.Text = "保存";
            this.bt_Save.UseVisualStyleBackColor = true;
            this.bt_Save.Click += new System.EventHandler(this.bt_Save_Click);
            // 
            // tb_GsName
            // 
            this.tb_GsName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_GsName.Location = new System.Drawing.Point(292, 26);
            this.tb_GsName.Name = "tb_GsName";
            this.tb_GsName.Size = new System.Drawing.Size(182, 21);
            this.tb_GsName.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgv_GS);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1046, 301);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "电池测试货位";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgv_TestDetail);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1046, 120);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "测试详细";
            // 
            // dgv_TestDetail
            // 
            this.dgv_TestDetail.AllowUserToAddRows = false;
            this.dgv_TestDetail.AllowUserToDeleteRows = false;
            this.dgv_TestDetail.AllowUserToResizeRows = false;
            this.dgv_TestDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_TestDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_TestDetail.Location = new System.Drawing.Point(3, 17);
            this.dgv_TestDetail.Name = "dgv_TestDetail";
            this.dgv_TestDetail.RowTemplate.Height = 23;
            this.dgv_TestDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_TestDetail.Size = new System.Drawing.Size(1040, 100);
            this.dgv_TestDetail.TabIndex = 5;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(5, 84);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Size = new System.Drawing.Size(1046, 425);
            this.splitContainer1.SplitterDistance = 301;
            this.splitContainer1.TabIndex = 14;
            // 
            // XWEGSView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 509);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.groupBox1);
            this.Name = "XWEGSView";
            this.Text = "新威尔测试";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_GS)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TestDetail)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_QueryGs;
        private System.Windows.Forms.DataGridView dgv_GS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_HouseName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgv_TestDetail;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button bt_Save;
        private System.Windows.Forms.TextBox tb_GsName;
        private System.Windows.Forms.Button bt_PowerCmd;
        private System.Windows.Forms.Button bt_PowerExcept;
        private System.Windows.Forms.Button bt_DcrTestError;
        private System.Windows.Forms.Button bt_DcrTest;

    }
}