using LWDBJ;
using LWDBJ_自建_.项目相关;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace LWDBJ_自建_.UI_Wpf
{
    /// <summary>
    /// US_Login.xaml 的交互逻辑
    /// </summary>
    public partial class US_Login : Window
    {
        public US_Login()
        {
            InitializeComponent();
            GloVar.M_MACHINENO = SysFunction.get_Param((int)GloVar.enSystemParam.设备号);
            //th_read = new Thread(GetCarNumber);
            //th_read.IsBackground = true;
            //th_read.Start();
            this.TextNo.Text = GloVar.M_MACHINENO;
            Dispatcher.Invoke(GetCarNumber);
        }
        Thread th_read;
        private bool Read = true;
        string user = "";
        
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string psword = this.passwordBox1.Password;
            System.Diagnostics.Process[] myProcesses = System.Diagnostics.Process.GetProcessesByName("自动打包机");//获取指定的进程名   
            if (myProcesses.Length > 1) //如果可以获取到知道的进程名则说明已经启动
            {
                MessageBox.Show("程序已启动！", "提示");
                Environment.Exit(Environment.ExitCode); //彻底的退出程序方式
            }
            if (this.passwordBox1.Password == DateTime.Now.ToString("yyMMdd"))
            {
                MES mes = new MES(3000);
                string err = "";
                bool b= mes.LoginDevice(TextNo.Text, cUserNo.Text,"","", ref  err);
                if(b)
                {
                    Read = false;
                    ConfigINI.ConnectINIWriter(ConfigINI.adressCountINI, "User", "M_USERNO", this.cUserNo.Text);
                    ConfigINI.ConnectINIWriter(ConfigINI.adressCountINI, "User", "M_MACHINENO", this.TextNo.Text);
                    GloVar.mes_UserName = ConfigINI.ConnectINIReader(ConfigINI.adressCountINI, "User", "M_USERNO", "");
                    GloVar.M_MACHINENO = ConfigINI.ConnectINIReader(ConfigINI.adressCountINI, "User", "M_MACHINENO", "");
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(err);
                }
            }
            else { MessageBox.Show("密码输入错误！"); }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(Environment.ExitCode);
        }
        private void GetCarNumber()
        {
            while (Read)
            {
                Thread.Sleep(300);
                //GloVar.mes_UserName = MF1_IC_Card.GetCar();
                user = GloVar.mes_UserName;
                this.cUserNo.Text = user;
            }
        }
    }
}
