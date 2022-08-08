namespace LWDBJ
{
    partial class Form_AdminMange
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
            this.bt_Search = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbx_ManageLevel = new System.Windows.Forms.ComboBox();
            this.bt_Add = new System.Windows.Forms.Button();
            this.bt_Change = new System.Windows.Forms.Button();
            this.bt_Delete = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tx_UserName = new System.Windows.Forms.TextBox();
            this.tx_Passdowm = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // bt_Search
            // 
            this.bt_Search.Location = new System.Drawing.Point(320, 36);
            this.bt_Search.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bt_Search.Name = "bt_Search";
            this.bt_Search.Size = new System.Drawing.Size(50, 34);
            this.bt_Search.TabIndex = 0;
            this.bt_Search.Text = "查询";
            this.bt_Search.UseVisualStyleBackColor = true;
            this.bt_Search.Click += new System.EventHandler(this.bt_Search_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 47);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "权限等级";
            // 
            // cbx_ManageLevel
            // 
            this.cbx_ManageLevel.FormattingEnabled = true;
            this.cbx_ManageLevel.Items.AddRange(new object[] {
            "操作员",
            "技术员",
            "管理员"});
            this.cbx_ManageLevel.Location = new System.Drawing.Point(123, 47);
            this.cbx_ManageLevel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbx_ManageLevel.Name = "cbx_ManageLevel";
            this.cbx_ManageLevel.Size = new System.Drawing.Size(133, 20);
            this.cbx_ManageLevel.TabIndex = 2;
            // 
            // bt_Add
            // 
            this.bt_Add.Location = new System.Drawing.Point(400, 36);
            this.bt_Add.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bt_Add.Name = "bt_Add";
            this.bt_Add.Size = new System.Drawing.Size(50, 34);
            this.bt_Add.TabIndex = 3;
            this.bt_Add.Text = "添加";
            this.bt_Add.UseVisualStyleBackColor = true;
            this.bt_Add.Click += new System.EventHandler(this.bt_Add_Click);
            // 
            // bt_Change
            // 
            this.bt_Change.Location = new System.Drawing.Point(481, 36);
            this.bt_Change.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bt_Change.Name = "bt_Change";
            this.bt_Change.Size = new System.Drawing.Size(50, 34);
            this.bt_Change.TabIndex = 4;
            this.bt_Change.Text = "修改";
            this.bt_Change.UseVisualStyleBackColor = true;
            this.bt_Change.Click += new System.EventHandler(this.bt_Change_Click);
            // 
            // bt_Delete
            // 
            this.bt_Delete.Location = new System.Drawing.Point(562, 36);
            this.bt_Delete.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bt_Delete.Name = "bt_Delete";
            this.bt_Delete.Size = new System.Drawing.Size(50, 34);
            this.bt_Delete.TabIndex = 5;
            this.bt_Delete.Text = "删除";
            this.bt_Delete.UseVisualStyleBackColor = true;
            this.bt_Delete.Click += new System.EventHandler(this.bt_Delete_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 82);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "用户名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 114);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "密码";
            // 
            // tx_UserName
            // 
            this.tx_UserName.Location = new System.Drawing.Point(123, 79);
            this.tx_UserName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tx_UserName.Name = "tx_UserName";
            this.tx_UserName.Size = new System.Drawing.Size(133, 21);
            this.tx_UserName.TabIndex = 8;
            // 
            // tx_Passdowm
            // 
            this.tx_Passdowm.Location = new System.Drawing.Point(123, 111);
            this.tx_Passdowm.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tx_Passdowm.Name = "tx_Passdowm";
            this.tx_Passdowm.Size = new System.Drawing.Size(133, 21);
            this.tx_Passdowm.TabIndex = 9;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(112, 143);
            this.listView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(384, 198);
            this.listView1.TabIndex = 10;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "用户名";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "密码";
            this.columnHeader2.Width = 89;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "权限等级";
            // 
            // Form_AdminMange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 369);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.tx_Passdowm);
            this.Controls.Add(this.tx_UserName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bt_Delete);
            this.Controls.Add(this.bt_Change);
            this.Controls.Add(this.bt_Add);
            this.Controls.Add(this.cbx_ManageLevel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bt_Search);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form_AdminMange";
            this.Text = "权限管理";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_Search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbx_ManageLevel;
        private System.Windows.Forms.Button bt_Add;
        private System.Windows.Forms.Button bt_Change;
        private System.Windows.Forms.Button bt_Delete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tx_UserName;
        private System.Windows.Forms.TextBox tx_Passdowm;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}