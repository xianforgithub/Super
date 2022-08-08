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
    public partial class Form_权限登陆 : Form
    {
        public Form_权限登陆()
        {
            InitializeComponent();
        }

        private void Form_权限登陆_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void Form_权限登陆_Shown(object sender, EventArgs e)
        {
            tx_Passdowm.Focus();
        }

        private void bt_Logion_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text =="技术员")
            {
                if (tx_Passdowm.Text=="123")
                {
                    GloVar.MangeLevel = "技术员";

                    MessageBox.Show("技术员登陆成功");
                    this.Close();
                    return;
                }
                else
                {
                    MessageBox.Show("密码错误");
                    return;
                }
            }

            if (comboBox1.Text == "工程师")
            {
                if (tx_Passdowm.Text == "123456")
                {
                    GloVar.MangeLevel = "工程师";

                    MessageBox.Show("工程师登陆成功");
                    this.Close();
                    return;
                }
                else
                {
                    MessageBox.Show("密码错误");
                    return;
                }
            }
        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
