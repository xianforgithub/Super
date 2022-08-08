using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LWDBJ
{
    public partial class ListviewLog : UserControl
    {
        private  object lock_Log = new object();
        public ListviewLog()
        {
            InitializeComponent();
        }


        public void ShowLog(string text)
        {
            try
            {
                lock (lock_Log)
                {
                    string filename = DateTime.Now.ToString("yyyyMMdd") + "_auto.txt";
                    SysFunction.SaveLog(filename, "自动程序", text);

                    //防止条目过多引起卡顿
                    if (this.lv_log.Items.Count >= 30)
                    {
                        this.lv_log.Items.RemoveAt(0);
                    }
                    ListViewItem item = new ListViewItem();
                    item.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    if (text == null) text = "";
                    item.SubItems.Add(text);
                    this.lv_log.Items.Add(item);

                    if (this.lv_log.Items.Count >= 30)
                    {
                        int index = this.lv_log.Items.Count - 1;
                        this.lv_log.EnsureVisible(index);
                    }
                }
            }
            catch (Exception ex)
            {
                string faileName = DateTime.Now.ToString("yyyy-MM-dd") + "_other.txt";
                SysFunction.SaveLog(faileName, "显示日志异常", ex.ToString());
            }

        }

        public void ClearLog()
        {
            lv_log.Items.Clear();
        }

    }
}
