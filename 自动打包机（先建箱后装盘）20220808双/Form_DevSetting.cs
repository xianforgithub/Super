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
    public partial class Form_DevSetting : Form
    {
        public Form_DevSetting()
        {
            InitializeComponent();
        }

        private void bt_SaveBox_Click(object sender, EventArgs e)
        {
            SysFunction.ConnectINIWriter("Scan", "scan_boxID", tx_ScanBoxIP.Text.Trim(), GloVar.path_mainconfig);
            SysFunction.ConnectINIWriter("Scan", "scan_boxID", tx_ScanBoxPort.Text.Trim(), GloVar.path_mainconfig);
            MessageBox.Show("保存成功，重启后生效");
        }

        private void bt_SaveCell_Click(object sender, EventArgs e)
        {
            SysFunction.ConnectINIWriter("Scan", "scan_cellID", tx_ScanCellIP.Text.Trim(), GloVar.path_mainconfig);
            SysFunction.ConnectINIWriter("Scan", "scan_cellPort", tx_ScanCellPort.Text.Trim(), GloVar.path_mainconfig);
            MessageBox.Show("保存成功，重启后生效");
        }

        private void bt_SaveWeight_Click(object sender, EventArgs e)
        {
            SysFunction.ConnectINIWriter("Scan", "weight_port", tx_WeightCOM.Text.Trim(), GloVar.path_mainconfig);
            SysFunction.ConnectINIWriter("Scan", "weight_baudrate", tx_WeightPort.Text.Trim(), GloVar.path_mainconfig);
            MessageBox.Show("保存成功，重启后生效");
        }

        private void Form_DevSetting_Load(object sender, EventArgs e)
        {
            tx_ScanBoxIP.Text = GloVar.scan_boxID;
            tx_ScanBoxPort.Text = GloVar.scan_boxPort;

            tx_ScanCellIP.Text = GloVar.scan_cellID;
            tx_ScanCellPort.Text = GloVar.scan_cellPort;

            tx_WeightCOM.Text = GloVar.weight_port;
            tx_WeightPort.Text = GloVar.weight_baudrate.ToString();
        }


    }
}
