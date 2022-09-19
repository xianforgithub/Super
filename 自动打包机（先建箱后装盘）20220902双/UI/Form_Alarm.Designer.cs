namespace LWDBJ_自建_.UI
{
    partial class Form_Alarm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_Day = new System.Windows.Forms.DataGridView();
            this.alarmdata = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnSelectDay = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Day)).BeginInit();
            this.alarmdata.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_Day
            // 
            this.dgv_Day.AllowUserToAddRows = false;
            this.dgv_Day.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Day.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Day.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Day.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Day.Location = new System.Drawing.Point(2, 16);
            this.dgv_Day.Name = "dgv_Day";
            this.dgv_Day.RowHeadersVisible = false;
            this.dgv_Day.RowHeadersWidth = 30;
            this.dgv_Day.RowTemplate.Height = 23;
            this.dgv_Day.Size = new System.Drawing.Size(1049, 558);
            this.dgv_Day.TabIndex = 12;
            // 
            // alarmdata
            // 
            this.alarmdata.Controls.Add(this.dgv_Day);
            this.alarmdata.Location = new System.Drawing.Point(9, 74);
            this.alarmdata.Margin = new System.Windows.Forms.Padding(2);
            this.alarmdata.Name = "alarmdata";
            this.alarmdata.Padding = new System.Windows.Forms.Padding(2);
            this.alarmdata.Size = new System.Drawing.Size(1053, 576);
            this.alarmdata.TabIndex = 13;
            this.alarmdata.TabStop = false;
            this.alarmdata.Text = "报警数据";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.btnSelectDay);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(11, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1049, 57);
            this.panel1.TabIndex = 14;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyyMMdd";
            this.dateTimePicker1.Location = new System.Drawing.Point(426, 16);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(116, 21);
            this.dateTimePicker1.TabIndex = 5;
            this.dateTimePicker1.Value = new System.DateTime(2022, 3, 23, 0, 0, 0, 0);
            // 
            // btnSelectDay
            // 
            this.btnSelectDay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnSelectDay.Location = new System.Drawing.Point(558, 12);
            this.btnSelectDay.Name = "btnSelectDay";
            this.btnSelectDay.Size = new System.Drawing.Size(116, 32);
            this.btnSelectDay.TabIndex = 6;
            this.btnSelectDay.Text = "查询";
            this.btnSelectDay.UseVisualStyleBackColor = false;
            this.btnSelectDay.Click += new System.EventHandler(this.btnSelectDay_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(374, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "时间:";
            // 
            // Form_Alarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 652);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.alarmdata);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form_Alarm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "报警信息";
            this.Load += new System.EventHandler(this.Form_Alarm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Day)).EndInit();
            this.alarmdata.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgv_Day;
        private System.Windows.Forms.GroupBox alarmdata;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnSelectDay;
        private System.Windows.Forms.Label label1;
    }
}