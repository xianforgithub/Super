namespace LWDBJ
{
    partial class Form_DevSetting
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tx_ScanBoxPort = new System.Windows.Forms.TextBox();
            this.tx_ScanBoxIP = new System.Windows.Forms.TextBox();
            this.bt_SaveBox = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tx_ScanCellPort = new System.Windows.Forms.TextBox();
            this.tx_ScanCellIP = new System.Windows.Forms.TextBox();
            this.bt_SaveCell = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tx_WeightPort = new System.Windows.Forms.TextBox();
            this.tx_WeightCOM = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.bt_SaveWeight = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(776, 276);
            this.splitContainer1.SplitterDistance = 501;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer2.Size = new System.Drawing.Size(501, 276);
            this.splitContainer2.SplitterDistance = 228;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tx_ScanBoxPort);
            this.groupBox3.Controls.Add(this.tx_ScanBoxIP);
            this.groupBox3.Controls.Add(this.bt_SaveBox);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(228, 276);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "电池扫码枪";
            // 
            // tx_ScanBoxPort
            // 
            this.tx_ScanBoxPort.Location = new System.Drawing.Point(16, 161);
            this.tx_ScanBoxPort.Name = "tx_ScanBoxPort";
            this.tx_ScanBoxPort.Size = new System.Drawing.Size(130, 25);
            this.tx_ScanBoxPort.TabIndex = 4;
            // 
            // tx_ScanBoxIP
            // 
            this.tx_ScanBoxIP.Location = new System.Drawing.Point(16, 73);
            this.tx_ScanBoxIP.Name = "tx_ScanBoxIP";
            this.tx_ScanBoxIP.Size = new System.Drawing.Size(130, 25);
            this.tx_ScanBoxIP.TabIndex = 3;
            // 
            // bt_SaveBox
            // 
            this.bt_SaveBox.Location = new System.Drawing.Point(39, 223);
            this.bt_SaveBox.Name = "bt_SaveBox";
            this.bt_SaveBox.Size = new System.Drawing.Size(71, 29);
            this.bt_SaveBox.TabIndex = 2;
            this.bt_SaveBox.Text = "保存";
            this.bt_SaveBox.UseVisualStyleBackColor = true;
            this.bt_SaveBox.Click += new System.EventHandler(this.bt_SaveBox_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "扫码枪波特率";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "扫码枪IP地址";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tx_ScanCellPort);
            this.groupBox1.Controls.Add(this.tx_ScanCellIP);
            this.groupBox1.Controls.Add(this.bt_SaveCell);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(269, 276);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "电池扫码枪";
            // 
            // tx_ScanCellPort
            // 
            this.tx_ScanCellPort.Location = new System.Drawing.Point(15, 161);
            this.tx_ScanCellPort.Name = "tx_ScanCellPort";
            this.tx_ScanCellPort.Size = new System.Drawing.Size(136, 25);
            this.tx_ScanCellPort.TabIndex = 4;
            // 
            // tx_ScanCellIP
            // 
            this.tx_ScanCellIP.Location = new System.Drawing.Point(15, 73);
            this.tx_ScanCellIP.Name = "tx_ScanCellIP";
            this.tx_ScanCellIP.Size = new System.Drawing.Size(136, 25);
            this.tx_ScanCellIP.TabIndex = 3;
            // 
            // bt_SaveCell
            // 
            this.bt_SaveCell.Location = new System.Drawing.Point(39, 223);
            this.bt_SaveCell.Name = "bt_SaveCell";
            this.bt_SaveCell.Size = new System.Drawing.Size(71, 29);
            this.bt_SaveCell.TabIndex = 2;
            this.bt_SaveCell.Text = "保存";
            this.bt_SaveCell.UseVisualStyleBackColor = true;
            this.bt_SaveCell.Click += new System.EventHandler(this.bt_SaveCell_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "扫码枪波特率";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "扫码枪IP地址";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tx_WeightPort);
            this.groupBox2.Controls.Add(this.tx_WeightCOM);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.bt_SaveWeight);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(271, 276);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "电子秤";
            // 
            // tx_WeightPort
            // 
            this.tx_WeightPort.Location = new System.Drawing.Point(14, 161);
            this.tx_WeightPort.Name = "tx_WeightPort";
            this.tx_WeightPort.Size = new System.Drawing.Size(125, 25);
            this.tx_WeightPort.TabIndex = 9;
            // 
            // tx_WeightCOM
            // 
            this.tx_WeightCOM.Location = new System.Drawing.Point(14, 71);
            this.tx_WeightCOM.Name = "tx_WeightCOM";
            this.tx_WeightCOM.Size = new System.Drawing.Size(125, 25);
            this.tx_WeightCOM.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "电子秤COM口";
            // 
            // bt_SaveWeight
            // 
            this.bt_SaveWeight.Location = new System.Drawing.Point(38, 223);
            this.bt_SaveWeight.Name = "bt_SaveWeight";
            this.bt_SaveWeight.Size = new System.Drawing.Size(71, 29);
            this.bt_SaveWeight.TabIndex = 7;
            this.bt_SaveWeight.Text = "保存";
            this.bt_SaveWeight.UseVisualStyleBackColor = true;
            this.bt_SaveWeight.Click += new System.EventHandler(this.bt_SaveWeight_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "电子秤波特率";
            // 
            // Form_DevSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 276);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form_DevSetting";
            this.Text = "扫码枪、电子秤设定";
            this.Load += new System.EventHandler(this.Form_DevSetting_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox tx_ScanCellPort;
        private System.Windows.Forms.TextBox tx_ScanCellIP;
        private System.Windows.Forms.Button bt_SaveCell;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tx_ScanBoxPort;
        private System.Windows.Forms.TextBox tx_ScanBoxIP;
        private System.Windows.Forms.Button bt_SaveBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tx_WeightPort;
        private System.Windows.Forms.TextBox tx_WeightCOM;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bt_SaveWeight;
        private System.Windows.Forms.Label label5;
    }
}