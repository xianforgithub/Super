namespace LWDBJ
{
    partial class Form_AdminLgion
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tx_UserName = new System.Windows.Forms.TextBox();
            this.tx_Passdowm = new System.Windows.Forms.TextBox();
            this.bt_Logion = new System.Windows.Forms.Button();
            this.bt_Exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "密码";
            // 
            // tx_UserName
            // 
            this.tx_UserName.Location = new System.Drawing.Point(142, 56);
            this.tx_UserName.Name = "tx_UserName";
            this.tx_UserName.Size = new System.Drawing.Size(194, 25);
            this.tx_UserName.TabIndex = 2;
            // 
            // tx_Passdowm
            // 
            this.tx_Passdowm.Location = new System.Drawing.Point(142, 109);
            this.tx_Passdowm.Name = "tx_Passdowm";
            this.tx_Passdowm.Size = new System.Drawing.Size(194, 25);
            this.tx_Passdowm.TabIndex = 3;
            // 
            // bt_Logion
            // 
            this.bt_Logion.Location = new System.Drawing.Point(78, 178);
            this.bt_Logion.Name = "bt_Logion";
            this.bt_Logion.Size = new System.Drawing.Size(92, 41);
            this.bt_Logion.TabIndex = 4;
            this.bt_Logion.Text = "确认";
            this.bt_Logion.UseVisualStyleBackColor = true;
            this.bt_Logion.Click += new System.EventHandler(this.bt_Logion_Click);
            // 
            // bt_Exit
            // 
            this.bt_Exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_Exit.Location = new System.Drawing.Point(247, 178);
            this.bt_Exit.Name = "bt_Exit";
            this.bt_Exit.Size = new System.Drawing.Size(92, 41);
            this.bt_Exit.TabIndex = 5;
            this.bt_Exit.Text = "取消";
            this.bt_Exit.UseVisualStyleBackColor = true;
            this.bt_Exit.Click += new System.EventHandler(this.bt_Exit_Click);
            // 
            // Form_AdminLgion
            // 
            this.AcceptButton = this.bt_Logion;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bt_Exit;
            this.ClientSize = new System.Drawing.Size(444, 297);
            this.Controls.Add(this.bt_Exit);
            this.Controls.Add(this.bt_Logion);
            this.Controls.Add(this.tx_Passdowm);
            this.Controls.Add(this.tx_UserName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form_AdminLgion";
            this.Text = "权限登录";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tx_UserName;
        private System.Windows.Forms.TextBox tx_Passdowm;
        private System.Windows.Forms.Button bt_Logion;
        private System.Windows.Forms.Button bt_Exit;
    }
}