namespace LWDBJ
{
    partial class Form_DevStatus
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
            this.bt_UpdataDevStatus = new System.Windows.Forms.Button();
            this.cbx_DeviceStatus = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTime_End = new System.Windows.Forms.DateTimePicker();
            this.dateTime_Star = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bt_UpdataDevStatus
            // 
            this.bt_UpdataDevStatus.Location = new System.Drawing.Point(136, 157);
            this.bt_UpdataDevStatus.Name = "bt_UpdataDevStatus";
            this.bt_UpdataDevStatus.Size = new System.Drawing.Size(79, 38);
            this.bt_UpdataDevStatus.TabIndex = 0;
            this.bt_UpdataDevStatus.Text = "确认上传";
            this.bt_UpdataDevStatus.UseVisualStyleBackColor = true;
            this.bt_UpdataDevStatus.Click += new System.EventHandler(this.bt_UpdataDevStatus_Click);
            // 
            // cbx_DeviceStatus
            // 
            this.cbx_DeviceStatus.FormattingEnabled = true;
            this.cbx_DeviceStatus.Location = new System.Drawing.Point(119, 22);
            this.cbx_DeviceStatus.Name = "cbx_DeviceStatus";
            this.cbx_DeviceStatus.Size = new System.Drawing.Size(200, 23);
            this.cbx_DeviceStatus.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "开始时间";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "结束时间";
            // 
            // dateTime_End
            // 
            this.dateTime_End.Location = new System.Drawing.Point(119, 102);
            this.dateTime_End.Name = "dateTime_End";
            this.dateTime_End.Size = new System.Drawing.Size(200, 25);
            this.dateTime_End.TabIndex = 4;
            // 
            // dateTime_Star
            // 
            this.dateTime_Star.Location = new System.Drawing.Point(119, 61);
            this.dateTime_Star.Name = "dateTime_Star";
            this.dateTime_Star.Size = new System.Drawing.Size(200, 25);
            this.dateTime_Star.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "状态选择";
            // 
            // Form_DevStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 231);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTime_Star);
            this.Controls.Add(this.dateTime_End);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbx_DeviceStatus);
            this.Controls.Add(this.bt_UpdataDevStatus);
            this.Name = "Form_DevStatus";
            this.Text = "设备状态上传";
            this.Load += new System.EventHandler(this.Form_DveStatus_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_UpdataDevStatus;
        private System.Windows.Forms.ComboBox cbx_DeviceStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTime_End;
        private System.Windows.Forms.DateTimePicker dateTime_Star;
        private System.Windows.Forms.Label label3;
    }
}