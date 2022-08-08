namespace LWDBJ
{
    partial class Form_SystemParam
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
        private  void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgv_SystemParam = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.bt_SaveSystemParam = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SystemParam)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgv_SystemParam);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Panel2.Controls.Add(this.bt_SaveSystemParam);
            this.splitContainer1.Size = new System.Drawing.Size(1924, 952);
            this.splitContainer1.SplitterDistance = 845;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // dgv_SystemParam
            // 
            this.dgv_SystemParam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_SystemParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_SystemParam.Enabled = false;
            this.dgv_SystemParam.Location = new System.Drawing.Point(0, 0);
            this.dgv_SystemParam.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgv_SystemParam.Name = "dgv_SystemParam";
            this.dgv_SystemParam.RowHeadersVisible = false;
            this.dgv_SystemParam.RowTemplate.Height = 23;
            this.dgv_SystemParam.Size = new System.Drawing.Size(1924, 845);
            this.dgv_SystemParam.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(4, 69);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(164, 29);
            this.button1.TabIndex = 1;
            this.button1.Text = "授权验证";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bt_SaveSystemParam
            // 
            this.bt_SaveSystemParam.Enabled = false;
            this.bt_SaveSystemParam.Location = new System.Drawing.Point(699, 16);
            this.bt_SaveSystemParam.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bt_SaveSystemParam.Name = "bt_SaveSystemParam";
            this.bt_SaveSystemParam.Size = new System.Drawing.Size(451, 58);
            this.bt_SaveSystemParam.TabIndex = 0;
            this.bt_SaveSystemParam.Text = "保存";
            this.bt_SaveSystemParam.UseVisualStyleBackColor = true;
            this.bt_SaveSystemParam.Click += new System.EventHandler(this.Bt_SaveSystemParam_Click);
            // 
            // Form_SystemParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 952);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form_SystemParam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统参数";
            this.Load += new System.EventHandler(this.Form_SystemParam_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SystemParam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgv_SystemParam;
        private System.Windows.Forms.Button bt_SaveSystemParam;
        private System.Windows.Forms.Button button1;
    }
}