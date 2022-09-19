using LWDBJ;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LWDBJ_自建_.UI
{
    public partial class Form_Alarm : Form
    {
        public Form_Alarm()
        {
            InitializeComponent();
        }

        private void btnSelectDay_Click(object sender, EventArgs e)
        {
           
        }

        private void Form_Alarm_Load(object sender, EventArgs e)
        {
            
            dateTimePicker1.Value = DateTime.Now;
            GetAlarmtoShow();
            
        }
        private void GetAlarmtoShow()
        {
            try
            {
                string dtt = dateTimePicker1.Text;
                string date = dtt.Remove(dtt.IndexOf('年'));  //20220225
                dtt = dtt.Remove(0, dtt.IndexOf('年') + 1);
                date += dtt.Remove(dtt.IndexOf('月')).PadLeft(2, '0');
                dtt = dtt.Remove(0, dtt.IndexOf('月') + 1);
                date += dtt.Remove(dtt.IndexOf('日')).PadLeft(2, '0');
                string sheet = date;
                date += ".xlsx";
                date = GloVar.path_Alarm + date;
                if (File.Exists(date))
                {
                    DataSet ds = SysFunction.ReadxlsxTodataset(date, sheet + "$");
                    if (ds != null)
                        dgv_Day.DataSource = ds.Tables[0];
                }
                else
                {
                    //MessageBox.Show(dateTimePicker1.Text + " 无报警记录");
                }
            }
            catch(Exception ec)
            {

            }
                
        }

        private void btnSelectDay_Click_1(object sender, EventArgs e)
        {
            btnSelectDay.Enabled = false;
            btnSelectDay.Text = "查询中...";
            GetAlarmtoShow();
            btnSelectDay.Enabled = true;
            btnSelectDay.Text = "查询";
        }
    }
}
