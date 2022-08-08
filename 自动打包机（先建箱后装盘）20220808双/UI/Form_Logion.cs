using HFrfid;
using LWDBJ_自建_.项目相关;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LWDBJ
{
    public partial class Form_Logion : Form
    {
        public Form_Logion()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void Bt_Logion_Click(object sender, EventArgs e)
        {
            string psword = this.tx_Password.Text;
            System.Diagnostics.Process[] myProcesses = System.Diagnostics.Process.GetProcessesByName("自动打包机");//获取指定的进程名   
            if (myProcesses.Length > 1) //如果可以获取到知道的进程名则说明已经启动
            {
                MessageBox.Show("程序已启动！", "提示");
                Environment.Exit(Environment.ExitCode); //彻底的退出程序方式
            }
            if (radioButton1.Checked)
            {
                if (tx_Password .Text ==DateTime .Now .ToString ("yyMMdd"))
                {
                    Read = false;
                    GloVar.MangeLevel = "工程师";
                    SysFunction.set_Param((int)GloVar.enSystemParam.是否上传MES, "FALSE");
                    this.Hide();
                }
               
            }
            else
            {

                string err = "";
                bool b = GloVar.mes.LoginDevice(tx_Station.Text, tx_Username.Text, com_mi.Text ,tx_Password.Text , ref err);
                if (b)
                {
                    
                    Read = false;
                    GloVar.dcmi = GloVar.mes.GetMI(ref err);        //获取MI
                    SysFunction.set_Param((int)GloVar.enSystemParam.是否上传MES, "TRUE");
                    SysFunction.set_Param((int)GloVar.enSystemParam.扫码人, tx_Username.Text);
                    SysFunction.set_Param((int)GloVar.enSystemParam.设备号, tx_Station.Text);
                    SysFunction.set_Param((int)GloVar.enSystemParam.密码, tx_Password.Text);
                    SysFunction.set_Param((int)GloVar.enSystemParam.MI, com_mi.Text);

                    GloVar.mes_UserName = tx_Username.Text;
                    GloVar.M_MACHINENO = tx_Station.Text;
                    GloVar.mes_PassWord = tx_Password.Text ;
                    GloVar.mes_MI = com_mi.Text;
                    GloVar.ItemCode = GloVar.dcmi[com_mi.Text];
                    GloVar.isset = true;
                    MessageBox.Show("MES登录成功");
                  
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("mes登录失败");
                }
            }
            SysFunction.SaveSystemParam(Environment.CurrentDirectory + "\\SysConfig.csv");
        }

        private void Bt_Exit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            //System.Environment.Exit(0);
            this.Close();
        }

        private void Form_Logion_Load(object sender, EventArgs e)
        {
            //加载系统参数
            //SysFunction.LoadSystemParam(Environment.CurrentDirectory + "\\SysConfig.csv");
            GloStruct gls = new GloStruct();
            gls.Initial();
            tx_Station.Text = SysFunction.get_Param((int)GloVar.enSystemParam.设备号);
            tx_Username .Text = SysFunction.get_Param((int)GloVar.enSystemParam.扫码人);
            tx_Password .Text = SysFunction.get_Param((int)GloVar.enSystemParam.密码);
            com_mi.Text = SysFunction.get_Param((int)GloVar.enSystemParam.MI);
            
            bool flg = Reader.Connect(SysFunction.get_Param((int)GloVar.enSystemParam.读卡器), 9600);
            timer1.Enabled = true;
        }
        
        RfidReader Reader = new RfidReader();
        private bool Read = true;
        private void timer1_Tick(object sender, EventArgs e)
        {
            GetCard();
        }
        //读卡方法
        public void GetCard()
        {
            try
            {
                int status;
                byte[] type = new byte[2];
                byte[] id = new byte[4];

                Reader.Cmd = Cmd.M1_ReadId;//读卡号命令
                Reader.Addr = Convert.ToByte("20", 16);//读写器地址,设备号
                Reader.Beep = Beep.On;

                status = Reader.M1_Operation();
                if (status == 0)//读卡成功
                {
                    for (int i = 0; i < 2; i++)//获取2字节卡类型
                    {
                        type[i] = Reader.RxBuffer[i];
                    }
                    for (int i = 0; i < 04; i++)//获取4字节卡号
                    {
                        id[i] = Reader.RxBuffer[i + 2];
                    }
                    string ss = byteToHexStr(type, 2);
                    ss = byteToHexStr(id, 4);            // CC620EF0    
                    ss = To16Convert10(ss).ToString();   // 3428978416      
                    tx_Username.Text = ss;
                }
            }
            catch (Exception ex)
            {

            }
        }
        //数组转十六进制字符    
        public string byteToHexStr(byte[] bytes, int len)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < len; i++)
                {
                    returnStr += bytes[i].ToString("X2");
                }
            }
            return returnStr;
        }

        #region 十六进制字符串转十进制
        static double To16Convert10(string str)
        {
            int res = 0;
            double d = 0;
            StringBuilder sb = new StringBuilder();
            try
            {
                //str = str.Trim().Replace(" ", "");//移除空字符
                for (int i = 0; i < str.Length; i++)
                {
                    int r3 = Convert.ToInt32(str[i].ToString(), 16);
                    d += r3 * Math.Pow(16, str.Length - i - 1);
                }

            }
            catch (Exception e)
            {
                res = 0;
            }

            return d;

        }
        #endregion
        private void Form_Logion_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (Read)
            //{
            //    System.Environment.Exit(0);
            //}

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            tx_Station.Enabled = false ;
            tx_Username.Enabled = false;
            com_mi.Enabled = false;
            tx_Password.Text = "";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            tx_Station.Enabled = true;
            tx_Username.Enabled = true;
            tx_Password.Enabled = true;
            com_mi.Enabled = true;

       
        }

        private void com_mi_Click(object sender, EventArgs e)
        {
            if(radioButton2.Checked ==true)
            {
                try
                {
                    string msg = "";
                    GloVar.dcmi = GloVar.mes.GetMI(ref msg);        //获取MI          
                    if(GloVar .dcmi==null)
                    {
                        MessageBox.Show("获取MI接口失败");
                    } 
                    else
                    {
                        foreach (KeyValuePair  <string ,string > item in GloVar .dcmi )
                        {
                            com_mi.Items.Add(item.Key);
                        }
                    }                       
                }
                catch (Exception ex)
                {
                    MessageBox.Show("获取MI接口失败");
                }
            }
        }

        private void com_mi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
