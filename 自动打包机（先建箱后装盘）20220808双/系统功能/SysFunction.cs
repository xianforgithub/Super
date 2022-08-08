using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LWDBJ
{
    public static class SysFunction
    {
        static object lock_SaveLog = new object();
        public static void SaveLog(string filename, string title, string json)
        {
            lock (lock_SaveLog)
            {
                if (!Directory.Exists(GloVar.path_savelog)) Directory.CreateDirectory(GloVar.path_savelog);
                string path = GloVar.path_savelog + filename;
                //if (!File.Exists(path)) File.Create(path);

                using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("日期:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n");
                    sb.Append("标题:" + title + "\r\n");
                    sb.Append(json + "\r\n");
                    sb.Append("____________________________________" + "\r\n");

                    StreamWriter sw = new StreamWriter(fs, Encoding.Default);
                    sw.WriteLine(sb);
                    sw.Close();

                    fs.Close();
                }
            }
        }

        /// <summary>
        /// 网口初始化
        /// </summary>
        /// <param name="client">socket对象</param>
        /// <param name="ipAddress">ip地址</param>
        /// <param name="port">端口号</param>
        /// <param name="res">返回参数</param>
        /// <returns></returns>
        public static bool InitSocketClient(ref Socket client, string ipAddress, int port)
        {
            try
            {
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress ip = IPAddress.Parse(ipAddress);
                IPEndPoint ipPort = new IPEndPoint(ip, port);
                //client.ReceiveTimeout = 1000;
                client.Connect(ipPort);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 初始化串口对象
        /// </summary>
        /// <param name="Serial">串口对象</param>
        /// <param name="PortName">串口名</param>
        /// <param name="BaudRate">波特率</param>
        /// <param name="DataBits">数据位</param>
        /// <param name="Parity">奇偶校验位</param>
        /// <param name="StopBits">停止位</param>
        /// <returns></returns>
        public static bool InitCom(ref SerialPort Serial, string PortName, int BaudRate, int DataBits = 8, Parity Parity = System.IO.Ports.Parity.None, StopBits StopBits = System.IO.Ports.StopBits.One)
        {
            if (Serial == null)
            {
                Serial = new SerialPort();
                Serial.PortName = PortName;
                Serial.BaudRate = BaudRate;
                Serial.DataBits = DataBits;
                Serial.Parity = Parity;
                Serial.StopBits = StopBits;
            }
            else if (Serial.IsOpen)
            {
                return true;
            }

            try
            {
                Serial.ReadTimeout = 1000;
                Serial.WriteTimeout = 500;
                Serial.Open();
                Serial.DtrEnable = true;
                Serial.RtsEnable = false;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        /// <summary>
        /// 读取csv到DataTable中
        /// </summary>
        /// <param name="strPath">csv路径</param>
        /// <param name="table">要填充的表</param>
        /// <param name="isDeleteHead">是否读取首行(true为不读取，但前提是传入的表已经添加有列)</param>
        /// <returns></returns>
        public static DataTable ReadCsvToTable(string strPath,  bool isDeleteHead)
        {
            DataTable table = new DataTable();

            string strLine = "";
            if (!File.Exists(strPath))
            {
                MessageBox.Show("CSV文件不存在");
                return null;
            }
            else
            {
                using (StreamReader sr = new StreamReader(strPath, Encoding.Default))
                {
                    if (isDeleteHead == true)
                    {
                        sr.ReadLine();
                    }
                    else
                    {
                        strLine = sr.ReadLine();
                        string[] columns = strLine.Split(',');
                        for (int i = 0; i < columns.Length; i++)
                        {
                            table.Columns.Add(columns[i]);
                        }
                    }

                    while (true)
                    {
                        strLine = sr.ReadLine();
                        if (strLine==null|| strLine.Split(',').Length != table.Columns.Count)
                        {
                            break;
                        }
                        else
                        {
                            string[] arrCol = strLine.Split(',');
                            DataRow row = table.NewRow();
                            for (int i = 0; i < arrCol.Length; i++)
                            {
                                if (arrCol[i] != "")
                                {
                                    row[i] = arrCol[i];
                                }
                            }
                            table.Rows.Add(row);
                        }
                    }
                }
                return table;
            }
        }

        /// <summary>
        /// 加载系统参数
        /// </summary>
        /// <param name="strPath">系统参数路径</param>
        public static void LoadSystemParam(string strPath)
        {
            //string[] arrColName = { "索引", "参数名", "参数值", "备注" };
            //for (int i = 0; i < arrColName.Length; i++)
            //{
            //    GloVar.systemParamTable.Columns.Add(arrColName[i], Type.GetType("System.String"));
            //}
            GloVar.systemParamTable = ReadCsvToTable(strPath, false);
        }

        /// <summary>
        /// 核对参数名
        /// </summary>
        public static void CheckParamName()
        {
            for (int i = 0; i < GloVar.systemParamTable.Rows.Count; i++)
            {
                if (GloVar.systemParamTable.Rows[i]["参数名"].ToString() != Enum.GetName(typeof(GloVar.enSystemParam), i))
                {
                    MessageBox.Show("参数名： " + GloVar.systemParamTable.Rows[i]["参数名"] + " 与枚举： " + Enum.GetName(typeof(GloVar.enSystemParam), i) + " 不对应，请检查");
                }
            }
        }

        //获取系统参数信息
        public static string get_Param(int ParamID)
        {
            string rc = GloVar.systemParamTable.Rows[ParamID]["参数值"].ToString();
            return rc;

        }

        public static string get_Param(string ParamName)
        {
            for (int i = 0; i < GloVar.systemParamTable.Rows.Count; i++)
            {
                if (GloVar.systemParamTable.Rows[i]["参数名"].ToString()==ParamName)
                {

                    string str1 = GloVar.systemParamTable.Rows[i]["参数值"].ToString();
                    return str1;
                }
            }
            return string.Empty;

        }

        //设置系统参数信息
        public static void set_Param(int ParamID, string value)
        {
            GloVar.systemParamTable.Rows[ParamID]["参数值"] = value;
        }


        public static bool SaveSystemParam(string filePath)
        {
            int FileNum = FileSystem.FreeFile();
            try
            {
                if (!File.Exists(filePath))
                {
                    return false;
                }

                FileSystem.FileOpen(FileNum, filePath, OpenMode.Output, OpenAccess.Write, (OpenShare)(-1), -1);

                string strHeader = string.Empty;
                foreach (DataColumn col in GloVar.systemParamTable.Columns)
                {
                    strHeader += col.ColumnName + ",";
                }
                FileSystem.PrintLine(FileNum, strHeader.Substring(0, strHeader.Length - 1));


                foreach (DataRow row in GloVar.systemParamTable.Rows)
                {
                    string strLine = string.Empty;
                    for (int col = 0; col <= GloVar.systemParamTable.Columns.Count - 1; col++)
                    {
                        strLine += row[col] + ",";
                    }
                    FileSystem.PrintLine(FileNum, strLine.Substring(0, strLine.Length - 1));
                }

                FileSystem.FileClose(FileNum);
                return true;
            }
            catch (Exception)
            {
                FileSystem.FileClose(FileNum);
                return false;
            }
        }

        #region 读写txt
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);
        //文件根节点值/节点下标记值/默认标记值/读取的标记值/读取最大容量/文件的全路径
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string mpAppName, string mpKeyName, string mpDefault, string mpFileName);
        //文件节点值/节点下标记值/写入或者修改的标记值/文件的全路径
        [DllImport("Kernel32.dll")]
        private static extern int GetPrivateProfileSection(string lpAppName, byte[] lpReturnedString, int nSize, string lpFileName);
        //获取指定Section的key和value

        public static string ConnectINIReader(string address, string area, string key, string def)
        {

            StringBuilder stringBuilder = new StringBuilder(1024); 				//定义一个最大长度为1024的可变字符串
            GetPrivateProfileString(area, key, def, stringBuilder, 1024, address); 			//读取INI文件
            return stringBuilder.ToString();								//返回INI文件的内容
        }

        public static void ConnectINIWriter(string area, string Key, string contentValue, string configfilepath)
        {
            WritePrivateProfileString(area, Key, contentValue, configfilepath);
        }
        #endregion

        /// <summary>
        /// 读取xlsx->dataset文件
        /// </summary>
        /// <param name="FileFullPath">文件路径</param>
        /// <param name="SheetName">表格名称</param>
        /// <returns></returns>
        public static DataSet ReadxlsxTodataset(string FileFullPath, string SheetName)
        {
            try
            {
                //string SheetName = "Sheet1$";
                //string FileFullPath = @"D:\users\S2110250138\桌面\102.xlsx";
                //string strConn = "Provider=Microsoft.Jet.OleDb.4.0;" + "data source=" + FileFullPath + ";Extended Properties='Excel 8.0; HDR=NO; IMEX=1'"; //此连接只能操作Excel2007之前(.xls)文件
                string strConn = "Provider=Microsoft.Ace.OleDb.12.0;" + "data source=" + FileFullPath + ";Extended Properties='Excel 12.0; HDR=NO; IMEX=1'";  //此连接可以操作.xls与.xlsx文件
     
                OleDbConnection conn = new OleDbConnection(strConn);
                conn.Open();
                OleDbDataAdapter odda = new OleDbDataAdapter(string.Format("SELECT * FROM [{0}]", SheetName), conn);            //("select * from [Sheet1$]", conn);
                OleDbCommandBuilder dfb = new OleDbCommandBuilder(odda);
                DataSet ds = new DataSet();
                odda.Fill(ds, SheetName);
                conn.Close();
                return ds;
            }
            catch(Exception ex)
            {
                return null;
            }
           
        }

       

        /// <summary>
        /// 从数据库读取指定数据到dataset
        /// </summary>
        /// <param name="sqlcommand">sql读取命令</param>
        /// <returns></returns>
        public static DataSet ReadmMysqlTodataset(string sqlcommand)
        {
            try
            {
                MySqlConnection con = new MySqlConnection(GloVar.SqlConn);
                //     MySqlConnection con = new MySqlConnection("server = 127.0.0.1"
                //+ "; database = test"
                //+ "; user id =root"
                //+ "; password = superstar"
                //+ ";pooling=true;CharSet=utf8;port=3306;SslMode = none;");
                MySqlDataAdapter mda = new MySqlDataAdapter(sqlcommand, con);
                MySqlCommandBuilder mcb = new MySqlCommandBuilder(mda);
                DataSet ds = new DataSet();
                mda.Fill(ds);
                return ds;
            }
           catch(Exception ex)
            {
                return null;
            }
        }
    }
}
