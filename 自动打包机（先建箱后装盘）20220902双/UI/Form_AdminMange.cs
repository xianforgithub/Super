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
    public partial class Form_AdminMange : Form
    {
        public Form_AdminMange()
        {
            InitializeComponent();

            
            for (int j = 0; j < 10; j++)
            {
                ListViewItem item = new ListViewItem();
                for (int k = 0; k < 3; k++)
                {
                    item.SubItems.Add("");
                }
                listView1.Items.Add(item);
            }
        }

        private  void bt_Search_Click(object sender, EventArgs e)
        {
            try
            {
                List<AdminMange> list = SqlHelper.SearchAdminMange(tx_UserName.Text, tx_Passdowm.Text, cbx_ManageLevel.Text);
                if (list != null)
                {
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        listView1.Items[i].SubItems[0].Text = "";
                        listView1.Items[i].SubItems[1].Text = "";
                        listView1.Items[i].SubItems[2].Text = "";
                    }
                    for (int i = 0; i < list.Count; i++)
                    {
                        listView1.Items[i].SubItems[0].Text = list[i].UserName;
                        listView1.Items[i].SubItems[1].Text = list[i].Passdowm;
                        listView1.Items[i].SubItems[2].Text = list[i].MangeLevel;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }


        private  void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                int sel = listView1.SelectedIndices[0];
                tx_UserName.Text = listView1.Items[sel].Text;
                tx_Passdowm.Text = listView1.Items[sel].SubItems[1].Text;
                cbx_ManageLevel.Text = listView1.Items[sel].SubItems[2].Text;
            }
        }

        private  void bt_Add_Click(object sender, EventArgs e)
        {
            if (tx_UserName.Text.Trim() != null && tx_Passdowm.Text.Trim() != null && cbx_ManageLevel.Text.Trim() != null)
            {
                if (SqlHelper.AddMange(tx_UserName.Text.Trim(), tx_Passdowm.Text.Trim(), cbx_ManageLevel.Text.Trim()))
                {
                    MessageBox.Show("添加账号成功!");
                    LoadInfo();
                }
                else
                {
                    MessageBox.Show("添加账号失败!");
                }
            }
            else
            {
                MessageBox.Show("账号密码均不能为空!");
            }
        }

        private  void bt_Change_Click(object sender, EventArgs e)
        {
            if (tx_UserName.Text.Trim() != null && tx_Passdowm.Text.Trim() != null && cbx_ManageLevel.Text.Trim() != null)
            {
                if (SqlHelper.ChangeMange(tx_UserName.Text.Trim(), tx_Passdowm.Text.Trim(), cbx_ManageLevel.Text.Trim()))
                {
                    MessageBox.Show("修改成功!");
                    List<AdminMange> list = SqlHelper.SearchAdminMange(tx_UserName.Text, tx_Passdowm.Text, cbx_ManageLevel.Text);
                    if (list != null)
                    {
                        for (int i = 0; i < listView1.Items.Count; i++)
                        {
                            listView1.Items[i].SubItems[0].Text = "";
                            listView1.Items[i].SubItems[1].Text = "";
                            listView1.Items[i].SubItems[2].Text = "";
                        }
                        for (int i = 0; i < list.Count; i++)
                        {
                            listView1.Items[i].SubItems[0].Text = list[i].UserName;
                            listView1.Items[i].SubItems[1].Text = list[i].Passdowm;
                            listView1.Items[i].SubItems[2].Text = list[i].MangeLevel;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("修改失败!");
                }
            }
            else
            {
                MessageBox.Show("账号密码均不能为空!");
            }
        }

        private  void bt_Delete_Click(object sender, EventArgs e)
        {
            if (tx_UserName.Text.Trim() != null)
            {
                DialogResult exitMeg = MessageBox.Show("是否确认删除", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (exitMeg == DialogResult.Yes)
                {
                    if (SqlHelper.DeleteMange(tx_UserName.Text.Trim()))
                    {
                        MessageBox.Show("删除成功!");
                        int sel = listView1.SelectedIndices[0];
                        tx_UserName.Text = listView1.Items[sel].Text = "";
                        tx_Passdowm.Text = listView1.Items[sel].SubItems[1].Text = "";
                        cbx_ManageLevel.Text = listView1.Items[sel].SubItems[2].Text = "";
                    }
                    else
                    {
                        MessageBox.Show("删除失败!");
                    }
                }
            }
            else
            {
                MessageBox.Show("用户名不能为空!");
            }
        }
        private void LoadInfo()
        {
            tx_Passdowm.Text = "";
            tx_UserName.Text = "";
            cbx_ManageLevel.Text = "";
            List<AdminMange> list = SqlHelper.SearchAdminMange(tx_UserName.Text, tx_Passdowm.Text, cbx_ManageLevel.Text);
            if (list != null)
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    listView1.Items[i].SubItems[0].Text = "";
                    listView1.Items[i].SubItems[1].Text = "";
                    listView1.Items[i].SubItems[2].Text = "";
                }

                for (int i = 0; i < list.Count; i++)
                {
                    listView1.Items[i].SubItems[0].Text = list[i].UserName;
                    listView1.Items[i].SubItems[1].Text = list[i].Passdowm;
                    listView1.Items[i].SubItems[2].Text = list[i].MangeLevel;
                }
            }
        }


    }
}
