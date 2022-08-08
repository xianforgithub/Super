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
    public partial class Form_AdminLgion : Form
    {
        public Form_AdminLgion()
        {
            InitializeComponent();
        }

        private  void bt_Logion_Click(object sender, EventArgs e)
        {
            if (tx_UserName.Text.Trim()!=null&&tx_Passdowm.Text.Trim()!=null)
            {
                List<AdminMange> list_admin = SqlHelper.SearchAdminMange(tx_UserName.Text.Trim(), tx_Passdowm.Text.Trim(), "");
                if (list_admin!=null)
                {
                    if (list_admin[0].Passdowm==tx_Passdowm.Text.Trim())
                    {
                        GloVar.MangeLevel = list_admin[0].MangeLevel;
                        MessageBox.Show("登录成功!" + "权限等级为" + list_admin[0].MangeLevel);
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("登录失败，用户名不存在");
                }
            }
            else
            {
                MessageBox.Show("用户名和密码不能为空!");
            }
        }

        private  void bt_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}
