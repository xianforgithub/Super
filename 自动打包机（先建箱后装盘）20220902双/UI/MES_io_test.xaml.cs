using LWDBJ;
using LWDBJ_自建_.项目相关;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LWDBJ_自建_.UI
{
    /// <summary>
    /// MES_io_test.xaml 的交互逻辑
    /// </summary>
    public partial class MES_io_test : Window
    {
        public MES_io_test()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tx_lname.Text = SysFunction.get_Param ((int)GloVar .enSystemParam.扫码人); //GloVar.mes_UserName;  用户名
            tx_lmi.Text = GloVar.mes_MI;
            tx_lpas.Text = GloVar.mes_PassWord;
        }
        MES mes = new MES(3000);
        string msg = "";
        string weightup = "";
        string weightdown = "";
        string isgruop = "";
        string group = "";
        string qty = "";
        private void bt_login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mes.LoginDevice(GloVar.M_MACHINENO, tx_lname.Text, tx_lmi.Text, tx_lpas.Text, ref msg);
                lsmessage.Items.Clear();
                lsmessage.Items.Add(msg);
            }
            catch(Exception ex)
            {
                lsmessage.Items.Add(ex);
            }
         

        }

        private void bt_mi_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mes.GetMI(ref msg);
                lsmessage.Items.Clear();
                lsmessage.Items.Add(msg);
            }
            catch (Exception ex)
            {
                lsmessage.Items.Add(ex);
            }

        }

        private void bt_special_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                tx_special.Text = SysFunction.get_Param((int)GloVar.enSystemParam.MI);
                mes.GetPackSpecifications(ref qty, ref weightup, ref weightdown, ref isgruop, ref group, ref msg);
                lsmessage.Items.Clear();
                lsmessage.Items.Add(msg);
            }
            catch (Exception ex)
            {
                lsmessage.Items.Add(ex);
            }

        }

        private void bt_newbox_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mes.CreateBoxSn(ref msg);
                lsmessage.Items.Clear();
                lsmessage.Items.Add(msg);
            }
            catch (Exception ex)
            {
                lsmessage.Items.Add(ex);
            }

        }

        private void bt_group_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mes.GetGroup(tx_group.Text, ref msg);
                lsmessage.Items.Clear();
                lsmessage.Items.Add(msg);
            }
            catch (Exception ex)
            {
                lsmessage.Items.Add(ex);
            }

        }

        private void bt_pack_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PackCell2Box2_push pack_push = new PackCell2Box2_push();
                pack_push.BoxSn = tx_pbox.Text;
                pack_push.ProductSn = tx_psn.Text;
                pack_push.Seq = tx_ploca.Text;
                pack_push.Qty = "1";
                pack_push.OperatorId = GloVar.OperatorId;
                pack_push.TimeStamp = DateTime.Now.ToString();

                string json = "[" + JsonHandler.SerializeObject(pack_push) + "]";
                mes.PackCell2Box2(json, ref msg);
                lsmessage.Items.Clear();
                lsmessage.Items.Add(msg);
            }
            catch (Exception ex)
            {
                lsmessage.Items.Add(ex);
            }

        }

        private void bt_update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mes.UpdatePackStatus(tx_usn.Text, ref msg);
                lsmessage.Items.Clear();
                lsmessage.Items.Add(msg);
            }
            catch (Exception ex)
            {
                lsmessage.Items.Add(ex);
            }

        }

        private void bt_fpack_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mes.FinishPackBox(tx_fweight.Text, tx_fsn.Text, ref msg);
                lsmessage.Items.Clear();
                lsmessage.Items.Add(msg);
            }
            catch (Exception ex)
            {
                lsmessage.Items.Add(ex);
            }

        }

        private void bt_recode_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mes.RecordPrintTimes(tx_rsn.Text, ref msg);
                lsmessage.Items.Clear();
                lsmessage.Items.Add(msg);
            }
            catch (Exception ex)
            {
                lsmessage.Items.Add(ex);
            }

        }

        private void bt_print_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mes.printProductSn(tx_printsn.Text, ref msg);
                lsmessage.Items.Clear();
                lsmessage.Items.Add(msg);
            }
            catch (Exception ex)
            {
                lsmessage.Items.Add(ex);
            }

        }

        private void bt_fit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mes.allFitting(tx_fboxn.Text, ref msg);
                lsmessage.Items.Clear();
                lsmessage.Items.Add(msg);
            }
            catch (Exception ex)
            {
                lsmessage.Items.Add(ex);
            }
        }

        private void bt_gpackno_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string mi = "";
                mes.GetPackageByPackNo(tx_gboxn.Text, ref mi, ref msg);
                lsmessage.Items.Clear();
                lsmessage.Items.Add(msg);
            }
            catch (Exception ex)
            {
                lsmessage.Items.Add(ex);
            }
        }
    }
}
