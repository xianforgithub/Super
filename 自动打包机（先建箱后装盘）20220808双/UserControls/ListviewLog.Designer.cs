namespace LWDBJ
{
    partial class ListviewLog
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lv_log = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lv_log
            // 
            this.lv_log.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6});
            this.lv_log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_log.GridLines = true;
            this.lv_log.HideSelection = false;
            this.lv_log.Location = new System.Drawing.Point(0, 0);
            this.lv_log.Name = "lv_log";
            this.lv_log.Size = new System.Drawing.Size(253, 265);
            this.lv_log.TabIndex = 1;
            this.lv_log.UseCompatibleStateImageBehavior = false;
            this.lv_log.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "时间";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "内容";
            this.columnHeader6.Width = 366;
            // 
            // ListviewLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lv_log);
            this.Name = "ListviewLog";
            this.Size = new System.Drawing.Size(253, 265);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lv_log;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}
