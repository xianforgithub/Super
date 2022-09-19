//using DevExpress.Charts.Model;
using LWDBJ;
using MySql.Data.MySqlClient;
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
using System.Windows;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace LWDBJ_自建_.UI
{
    public partial class Form_production : Form
    {
        public Form_production()
        {
            InitializeComponent();
        }

        private void btnSelectDay_Click(object sender, EventArgs e)
        {
            btnSelectDay.Text = "查询中···";
            btnSelectDay.Enabled = false;
            Readsqltoshow();
         
            btnSelectDay.Text = "查询";
            btnSelectDay.Enabled = true ;


        }
        
        private void Form_production_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            Readsqltoshow();
        }
        private void Readsqltoshow()
        {
            try
            {
                string datecurrent = dateTimePicker1.Value.ToString();//2022/03/23 0:00:00
                string[] sr = datecurrent.Split(' ');
                datecurrent = sr[0] + " 00:00:00";
                string datetomorow = sr[0] + " 23:59:59";
                string sql = "select *from scancz02 where Time between '" + datecurrent + "' and '" + datetomorow + "'";
                DataSet ds = SysFunction.ReadmMysqlTodataset(sql);
                if (ds != null)
                    dgv_Day.DataSource = ds.Tables[0];
            }
            catch(Exception ec)
            {

            }
            
        }


       
    }
}
