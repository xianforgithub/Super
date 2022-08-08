using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LWDBJ
{
    public partial class Form_DevStatus : Form
    {
        public Form_DevStatus()
        {
            InitializeComponent();
        }

        private void Form_DveStatus_Load(object sender, EventArgs e)
        {
            //获取csv信息
            GloVar.DevStatusTable = new DataTable();
            GloVar.DevStatusTable = SysFunction.ReadCsvToTable(Environment.CurrentDirectory + "设备状态表.csv", false);
           
            //填充到cbx_DeviceStatus中
            for (int i = 0; i < GloVar.DevStatusTable.Rows.Count; i++)
            {
                cbx_DeviceStatus.Items.Add(GloVar.DevStatusTable.Rows[i][1]);
            }
        }

        private void bt_UpdataDevStatus_Click(object sender, EventArgs e)
        {
            string resCatch = "";
            MES mes = GloVar.mes;
            //mes.UpdataDevStatus(cbx_DeviceStatus.Text, ref resCatch);
        }




    }
}
