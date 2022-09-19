using LWDBJ_自建_.UI_Wpf;
using LWDBJ_自建_.项目相关;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LWDBJ
{
    static class Program
    {
        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
           
            new Form_Logion ().ShowDialog ();  //登录
            bool createdNew;
            string appName;
            appName = System.Reflection.Assembly.GetExecutingAssembly().Location;
            appName = appName.Replace(System.IO.Path.DirectorySeparatorChar, '_');

            using (Mutex mutex = new Mutex(true, appName, out createdNew))
            {
                if (createdNew)
                {
                    mutex.ReleaseMutex();
                    Application.EnableVisualStyles();
                    //Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form_Main());
                }
                else
                {
                    Process current = Process.GetCurrentProcess();
                    foreach (var process in Process.GetProcessesByName(current.ProcessName))
                    {
                        if (process.Id != current.Id)
                        {
                            MessageBox.Show("程序已经打开");
                            SetForegroundWindow(process.MainWindowHandle);
                            break;
                        }
                    }
                }
            }
        }
       
    }
}
