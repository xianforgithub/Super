namespace LWDBJ
{
    partial class Form_权限登陆
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
            this.bt_Exit = new System.Windows.Forms.Button();
            this.bt_Logion = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tx_Passdowm = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bt_Exit
            // 
            this.bt_Exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_Exit.Location = new System.Drawing.Point(428, 222);
            this.bt_Exit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bt_Exit.Name = "bt_Exit";
            this.bt_Exit.Size = new System.Drawing.Size(92, 41);
            this.bt_Exit.TabIndex = 9;
            this.bt_Exit.Text = "取消";
            this.bt_Exit.UseVisualStyleBackColor = true;
            this.bt_Exit.Click += new System.EventHandler(this.bt_Exit_Click);
            // 
            // bt_Logion
            // 
            this.bt_Logion.Location = new System.Drawing.Point(268, 222);
            this.bt_Logion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bt_Logion.Name = "bt_Logion";
            this.bt_Logion.Size = new System.Drawing.Size(92, 41);
            this.bt_Logion.TabIndex = 8;
            this.bt_Logion.Text = "确认";
            this.bt_Logion.UseVisualStyleBackColor = true;
            this.bt_Logion.Click += new System.EventHandler(this.bt_Logion_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(281, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "密码";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(265, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "用户名";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "技术员",
            "工程师"});
            this.comboBox1.Location = new System.Drawing.Point(326, 126);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(192, 23);
            this.comboBox1.TabIndex = 10;
            // 
            // tx_Passdowm
            // 
            this.tx_Passdowm.Location = new System.Drawing.Point(326, 163);
            this.tx_Passdowm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tx_Passdowm.Name = "tx_Passdowm";
            this.tx_Passdowm.PasswordChar = '*';
            this.tx_Passdowm.Size = new System.Drawing.Size(193, 25);
            this.tx_Passdowm.TabIndex = 11;
            // 
            // Form_权限登陆
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(804, 442);
            this.Controls.Add(this.tx_Passdowm);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.bt_Exit);
            this.Controls.Add(this.bt_Logion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form_权限登陆";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户登陆";
            this.Load += new System.EventHandler(this.Form_权限登陆_Load);
            this.Shown += new System.EventHandler(this.Form_权限登陆_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_Exit;
        private System.Windows.Forms.Button bt_Logion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox tx_Passdowm;
    }
}