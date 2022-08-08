using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;//[DllImport("kernel32")]
using System.IO.Ports;//SerialPort
using System.IO;//File
using System.Windows;
namespace LWDBJ
{
    class ConfigINI
    {
        #region 变量声明区
        public static string adressComINI = System.Environment.CurrentDirectory + "\\ComParam.ini";//该变量保存INI文件所在的具体物理位置，Connect接口
        public static string adressCountINI = System.Environment.CurrentDirectory + "\\ProCount.ini";
        public static string adressParamINI = System.Environment.CurrentDirectory + "\\myParam.ini";
        public static string adressMesIuPutINI = System.Environment.CurrentDirectory + "\\MESInput.ini";

        public static string adressProductsINI = System.Environment.CurrentDirectory + "\\Products.ini";//产品配方
        public static string adressProductParamINI = System.Environment.CurrentDirectory + "\\ProductParam.ini";//产品配方
        public static readonly string adressErrorLog = System.Environment.CurrentDirectory + "\\Errorlog.txt";
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);
        //文件根节点值/节点下标记值/默认标记值/读取的标记值/读取最大容量/文件的全路径
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string mpAppName, string mpKeyName, string mpDefault, string mpFileName);
        //文件节点值/节点下标记值/写入或者修改的标记值/文件的全路径
        [DllImport("Kernel32.dll")]
        private static extern int GetPrivateProfileSection(string lpAppName, byte[] lpReturnedString, int nSize, string lpFileName);
        //获取指定Section的key和value
        //读取串口信息从INI文件中
        public static void ReadSerialPortFromINI(ref string whichArea, out SerialPort sp)
        {
            sp = new SerialPort();
            try
            {
                if (File.Exists(adressComINI))
                {
                    sp.PortName = ConnectINIReader(adressComINI, whichArea, "PortName", "");
                    sp.BaudRate = Convert.ToInt32(ConnectINIReader(adressComINI, whichArea, "BaudRate", ""));
                    sp.Parity = (Parity)Enum.Parse(typeof(Parity), ConnectINIReader(adressComINI, whichArea, "Parity", ""));
                    sp.DataBits = Convert.ToInt16(ConnectINIReader(adressComINI, whichArea, "DataBits", ""));
                    sp.StopBits = (StopBits)Enum.Parse(typeof(StopBits), ConnectINIReader(adressComINI, whichArea, "StopBits", ""));
                }
                else
                {
                    MessageBoxResult rust = MessageBox.Show("配置文件不存在，你是否想要自动创建原始文件？", "程序创建原始配置文件", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (rust == MessageBoxResult.Yes)
                    {
                        File.Create(adressComINI).Close();
                        createINI();
                    }
                }
            }
            catch(Exception ex)
            {
                sp.PortName = "COM1";
                MessageBox.Show(ex.Message );
            }
        }
        /// <summary>
        /// 读取INI文件内容
        /// </summary>
        /// <param name="area">节点值</param>
        /// <param name="key">节点下标记值</param>
        /// <param name="def">默认标记值</param>
        /// <returns>返回读取标记值</returns>
        public static string ConnectINIReader(string address,string area, string key, string def)
        {
            StringBuilder stringBuilder = new StringBuilder(1024); 				//定义一个最大长度为1024的可变字符串
            GetPrivateProfileString(area, key, def, stringBuilder, 1024, address); 			//读取INI文件
            return stringBuilder.ToString();								//返回INI文件的内容
        }
        public static void ConnectINIWriter(string address, string area, string Key, string contentValue)
        {
            WritePrivateProfileString(area, Key, contentValue, address);
        }
        /// <summary>
        /// 记录错误信息
        /// </summary>
        /// <param name="errTitle">错误标题</param>
        /// <param name="str">错误信息</param>
        public static void WriteErrLog(string errTitle, string errContent)
        {
            try
            {
                if (!File.Exists(adressErrorLog)) File.Create(adressErrorLog).Close();
                FileInfo f = new FileInfo(adressErrorLog);
                if (f.Length > (1048578 * 10))//超过10M 重新生成
                {
                    File.Delete(adressErrorLog);
                    File.Create(adressErrorLog).Close();
                }
                StringBuilder strBuilderErrorMessage = new StringBuilder();
                //strBuilderErrorMessage.Append("__________________________________________________\r\n");
                strBuilderErrorMessage.Append("日期:" + System.DateTime.Now.ToString() + "\r\n");
                strBuilderErrorMessage.Append("错误标题:" + errTitle + "\r\n");
                strBuilderErrorMessage.Append(errContent + "\r\n");
                //strBuilderErrorMessage.Append("___________________________________________________\r\n");
                if (!IsFileInUse(adressErrorLog))
                {
                    using (FileStream fs = new FileStream(adressErrorLog, FileMode.Append, FileAccess.Write))
                    {
                        StreamWriter sw = new StreamWriter(fs, Encoding.Default);
                        sw.WriteLine(strBuilderErrorMessage);
                        sw.Close();
                        fs.Close();
                    }
                }
            }
            catch (Exception ex ) 
            {
                MessageBox.Show(ex.Message);
            }
        }
        //判断程序有没有被占用啊
        public static bool IsFileInUse(string fileName)
        {
            bool inUse = true;
            FileStream fs = null;
            try
            {
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.None);
                inUse = false;
            }
            catch
            {
            }
            finally
            {
                if (fs != null)

                    fs.Close();
            }
            return inUse;//true表示正在使用,false没有使用  
        }  
        //创建Connect.ini文件
        public static void createINI()
        {
            //扫码枪
            WritePrivateProfileString("Scanner", "PortName", "COM1", adressComINI);//串口名
            WritePrivateProfileString("Scanner", "BaudRate", "9600", adressComINI);//波特率
            WritePrivateProfileString("Scanner", "Parity", "None", adressComINI);//奇偶性
            WritePrivateProfileString("Scanner", "DataBits", "8", adressComINI);//数据位
            WritePrivateProfileString("Scanner", "StopBits", "One\r\n", adressComINI);//结束位

            MessageBox.Show("创建成功！", "提示信息", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        #endregion
    }
}
