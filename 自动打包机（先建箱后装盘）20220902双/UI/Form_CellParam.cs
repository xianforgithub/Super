using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LWDBJ
{
    public partial class Form_CellParam : Form
    {
        public Form_CellParam()
        {
            InitializeComponent();
        }

        private void Bt_Add_Click(object sender, EventArgs e)
        {
            try
            {
                int index = 0;
                if (tx_AddCellModel.Text != "" && tx_WeightUp.Text != "" && tx_WeightDowm.Text != "" && tx_ZWeightDowm.Text != "" && tx_ZWeightUp.Text != "" && tx_BoxWeight.Text != "")
                {
                    string cmd = string.Format("insert into cell values('{0}','{1}','{2}','{3}','{4}','{5}')"
                        , tx_AddCellModel.Text.Trim(), tx_WeightUp.Text, tx_WeightDowm.Text, tx_ZWeightUp.Text, tx_ZWeightDowm.Text, tx_BoxWeight.Text);
                    SqlHelper.InsertSQLData(cmd, out index);
                    if (index > 0)
                    {
                        MessageBox.Show("添加成功");
                        cbx_CellModel.Items.Add(tx_AddCellModel.Text.Trim());
                    }

                }
                else
                {
                    MessageBox.Show("输入参数不能为空!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Bt_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                int index = SqlHelper.DeleteCellParam(cbx_CellModel.Text.Trim());
                if (index > 0)
                {
                    MessageBox.Show("删除成功");
                    cbx_CellModel.Items.Remove(tx_AddCellModel.Text.Trim());
                }
                else
                {
                    MessageBox.Show("删除失败");
                }

                Form_CellParam_Load(null, null);
            }
            catch (Exception ex)
            {

            }
        }

        private void Bt_Change_Click(object sender, EventArgs e)
        {
            try
            {
                string str = string.Format("UPDATE cell SET WeightUp='{0}',WeightDowm='{1}',ZWeightUp='{2}',ZWeightDowm='{3}',BoxWeight='{4}' WHERE CellModel='{5}' "
                    , tx_WeightUp.Text, tx_WeightDowm.Text, tx_ZWeightUp.Text, tx_ZWeightDowm.Text, tx_BoxWeight.Text, cbx_CellModel.Text);
                int index = SqlHelper.UpdateSQLData(str);
                if (index > 0)
                {
                    MessageBox.Show("修改成功");
                }
                else
                {
                    MessageBox.Show("修改失败");
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void UpdataCellParam(CellParam cellParam)
        {
            tx_NowProductCellModel.Text = cellParam.CellModel;
            //tx_WeightUp.Text = cellParam.werightUp.ToString();
            //tx_WeightDowm.Text = cellParam.werightDowm.ToString();
            //tx_ZWeightDowm.Text = cellParam.ZwerightDowm.ToString();
            //tx_ZWeightUp.Text = cellParam.ZwerightUp.ToString();
            //tx_BoxWeight.Text = cellParam.BoxWeight.ToString();
        }

        private void Form_CellParam_Load(object sender, EventArgs e)
        {
            try
            {
                cbx_CellModel.Items.Clear();
                DataTable readParam;
                int count1;
                readParam = SqlHelper.GetAllSQLDataAsDataTable("select * from cell ", out count1);
                for (int i = 0; i < readParam.Rows.Count; i++)
                {
                    cbx_CellModel.Items.Add(readParam.Rows[i][0].ToString());
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void Cbx_CellModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string str = cbx_CellModel.Text;
                int qCount;
                DataTable mDataTB = SqlHelper.GetSQLDataAsDataTable("select *from cell where  CellModel='" + str + "'", out qCount);
                if (mDataTB.Rows.Count ==1)
                {
                    int i = 0;
                    tx_WeightUp.Text = mDataTB.Rows[i][1].ToString();//净重上限
                    tx_WeightDowm.Text = mDataTB.Rows[i][2].ToString();
                    tx_ZWeightUp.Text = mDataTB.Rows[i][3].ToString();
                    tx_ZWeightDowm.Text = mDataTB.Rows[i][4].ToString();
                    tx_BoxWeight.Text = mDataTB.Rows[i][5].ToString();
                }
                else
                {
                    MessageBox.Show("找不到型号对应的参数或找到多个相同的型号");
                }

                //for (int i = 0; i < mDataTB.Rows.Count; i++)
                //{
                //    tx_WeightUp.Text = mDataTB.Rows[i][1].ToString();//净重上限
                //    tx_WeightDowm.Text = mDataTB.Rows[i][2].ToString();
                //    tx_ZWeightUp.Text = mDataTB.Rows[i][3].ToString();
                //    tx_ZWeightDowm.Text = mDataTB.Rows[i][4].ToString();
                //    tx_BoxWeight.Text = mDataTB.Rows[i][5].ToString();
                //}
            }
            catch (Exception ex)
            {

            }
        }



    }

}
