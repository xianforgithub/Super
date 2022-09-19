using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LWDBJ
{
    public partial class Form_IO : Form
    {
        public Form_IO()
        {
            InitializeComponent();
        }

        private void Form_IO_Load(object sender, EventArgs e)
        {
            int plcin = 0, plcout = 0;
            FileStream fs = new FileStream("io.csv", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs, Encoding.Default);
            string readString;
            string[] strs;
           
            while (true)
            {
                readString = sr.ReadLine();
                if (readString == null)
                {
                    break;
                }
                strs = readString.Split(',');
                if (strs.Length == 4)
                {
                    if (strs[0] == "in")
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = plcin.ToString();//索引
                        item.SubItems.Add(strs[1]);//地址
                        item.SubItems.Add("");//状态
                        item.SubItems.Add(strs[2]);//描述
                        listview_In.LabelWrap = true;
                        listview_In.Items.Add(item);
                        plcin++;
                    }
                    if (strs[0] == "out")
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = plcout.ToString();//索引
                        item.SubItems.Add(strs[1]);//地址
                        item.SubItems.Add("");//状态
                        item.SubItems.Add(strs[2]);//描述
                        listview_Out.Items.Add(item);
                        plcout++;
                    }
                }
            }
            sr.Close();
            fs.Close();
            timer_PLCIO.Enabled = true;
        }

        private void Form_IO_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer_PLCIO.Enabled = false;
        }

        private void timer_PLCIO_Tick(object sender, EventArgs e)
        {

            //输入
            for (int i = 0; i < listview_In.Items.Count; i++)
            {
                if (listview_In.Items[i].SubItems[2].Text != GloVar.PLC_Rread[i].ToString())
                {
                    listview_In.Items[i].SubItems[2].Text = GloVar.PLC_Rread[i].ToString();
                }

            }

            //输出
            for (int i = 0; i < listview_Out.Items.Count; i++)
            {
                if (listview_Out.Items[i].SubItems[2].Text != GloVar.PLC_Write[i].ToString())
                {
                    listview_Out.Items[i].SubItems[2].Text = GloVar.PLC_Write[i].ToString();
                }

            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
