namespace LWDBJ_自建_.UI
{
    partial class Form_production
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnSelectDay = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.gb_data = new System.Windows.Forms.GroupBox();
            this.dgv_Day = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.gb_data.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Day)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.btnSelectDay);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1665, 75);
            this.panel1.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyyMMdd";
            this.dateTimePicker1.Location = new System.Drawing.Point(505, 23);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(153, 25);
            this.dateTimePicker1.TabIndex = 2;
            this.dateTimePicker1.Value = new System.DateTime(2022, 3, 23, 0, 0, 0, 0);
            // 
            // btnSelectDay
            // 
            this.btnSelectDay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnSelectDay.Location = new System.Drawing.Point(681, 17);
            this.btnSelectDay.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelectDay.Name = "btnSelectDay";
            this.btnSelectDay.Size = new System.Drawing.Size(155, 40);
            this.btnSelectDay.TabIndex = 3;
            this.btnSelectDay.Text = "查询";
            this.btnSelectDay.UseVisualStyleBackColor = false;
            this.btnSelectDay.Click += new System.EventHandler(this.btnSelectDay_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(437, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "时间:";
            // 
            // gb_data
            // 
            this.gb_data.Controls.Add(this.dgv_Day);
            this.gb_data.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gb_data.Location = new System.Drawing.Point(8, 98);
            this.gb_data.Name = "gb_data";
            this.gb_data.Size = new System.Drawing.Size(1413, 719);
            this.gb_data.TabIndex = 2;
            this.gb_data.TabStop = false;
            this.gb_data.Text = "电芯数据";
            // 
            // dgv_Day
            // 
            this.dgv_Day.AllowUserToAddRows = false;
            this.dgv_Day.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Day.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Day.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Day.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Day.Location = new System.Drawing.Point(3, 24);
            this.dgv_Day.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_Day.Name = "dgv_Day";
            this.dgv_Day.RowHeadersVisible = false;
            this.dgv_Day.RowHeadersWidth = 30;
            this.dgv_Day.RowTemplate.Height = 23;
            this.dgv_Day.Size = new System.Drawing.Size(1407, 692);
            this.dgv_Day.TabIndex = 12;
            // 
            // Form_production
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1421, 815);
            this.Controls.Add(this.gb_data);
            this.Controls.Add(this.panel1);
            this.Name = "Form_production";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "电芯生产数据";
            this.Load += new System.EventHandler(this.Form_production_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gb_data.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Day)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnSelectDay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gb_data;
        private System.Windows.Forms.DataGridView dgv_Day;
    }
}