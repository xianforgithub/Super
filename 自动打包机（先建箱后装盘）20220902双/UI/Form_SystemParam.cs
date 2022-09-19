using Microsoft.VisualBasic;
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
    public partial class Form_SystemParam : Form
    {
        public Form_SystemParam()
        {
            InitializeComponent();
        }

        private  void Form_SystemParam_Load(object sender, EventArgs e)
        {

            dgv_SystemParam.DataSource = GloVar.systemParamTable;

            dgv_SystemParam.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv_SystemParam.Columns[0].ReadOnly = true;
            dgv_SystemParam.Columns[0].Width = 60;

            dgv_SystemParam.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv_SystemParam.Columns[1].ReadOnly = true;
            dgv_SystemParam.Columns[1].Width = 150;

            dgv_SystemParam.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv_SystemParam.Columns[2].ReadOnly = false;
            dgv_SystemParam.Columns[2].Width = 600;

            dgv_SystemParam.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv_SystemParam.Columns[3].ReadOnly = true;
            dgv_SystemParam.Columns[3].Width = 1000;



            ////设置不可排序和只读属性
            //for (int i = 0; i < dgv_SystemParam.Columns.Count; i++)
            //{
            //    dgv_SystemParam.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable; //列值不可排序
            //    if (i != 2)
            //    {
            //        dgv_SystemParam.Columns[i].ReadOnly = true;
            //    }
            //}
            ////设置列宽
            //int width = 0;
            //dgv_SystemParam.Columns[1].Width = 150;
            //dgv_SystemParam.Columns[2].Width = 400;

            //for (int i = 0; i < dgv_SystemParam.Columns.Count - 1; i++)
            //{
            //    width += dgv_SystemParam.Columns[i].Width;
            //}
            //dgv_SystemParam.Columns[dgv_SystemParam.ColumnCount - 1].Width = Screen.PrimaryScreen.WorkingArea.Width - width;
            SysFunction.CheckParamName();
        }

        private void Bt_SaveSystemParam_Click(object sender, EventArgs e)
        {
            SysFunction.SaveSystemParam(Environment.CurrentDirectory + "\\SysConfig.csv");

            dgv_SystemParam.Enabled = false;
            bt_SaveSystemParam.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String PM = Interaction.InputBox("请输入密码", "输入密码", "", Screen.PrimaryScreen.Bounds.Width / 3, Screen.PrimaryScreen.Bounds.Height / 4);
            if (PM == "asdf")
            {
                dgv_SystemParam.Enabled = true;
                bt_SaveSystemParam.Enabled = true;
            }
        }
    }
}
