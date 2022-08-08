namespace LWDBJ
{
    partial class ShowLogForm
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
            this.listviewLog1 = new LWDBJ.ListviewLog();
            this.SuspendLayout();
            // 
            // listviewLog1
            // 
            this.listviewLog1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listviewLog1.Location = new System.Drawing.Point(0, 0);
            this.listviewLog1.Name = "listviewLog1";
            this.listviewLog1.Size = new System.Drawing.Size(800, 450);
            this.listviewLog1.TabIndex = 0;
            // 
            // ShowLgoFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listviewLog1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShowLgoFrom";
            this.Text = "ShowLgoFrom";
            this.ResumeLayout(false);

        }

        #endregion

        private LWDBJ.ListviewLog listviewLog1;
    }
}