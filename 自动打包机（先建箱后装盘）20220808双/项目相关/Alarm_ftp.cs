using LWDBJ;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LWDBJ_自建_.项目相关
{
    class Alarm_ftp
    {
        public static Byte[] ToByteArray(Stream stream)
        {
            MemoryStream ms = new MemoryStream();
            byte[] chunk = new byte[1024 * 10];
            int bytesRead;
            while ((bytesRead = stream.Read(chunk, 0, chunk.Length)) > 0)
            {
                ms.Write(chunk, 0, bytesRead);
            }
            return ms.ToArray();
        }
        static string evt_path = GloVar.path_Alarm + "EVT文件\\";    //‪D:\报警记录\EVT文件\
        object o = "";
        Thread th1,th2;

        public void ReadAlarm()
        {

            Directory.CreateDirectory(evt_path);
            th1 = new Thread(Readevt);
            th1.IsBackground = true;
            th1.Start();
        }
        private void Readevt()
        {
            while (true)
            {
                Thread.Sleep(2000);
                lock (o)
                {
                    Delectfile(".evt");
                    string fileName = GloVar.Ftp + DateTime.Now.ToString("yyyyMMdd") + ".evt";//文件夹名+文件名=复制文件全路径   "ftp://192.168.250.2/ eventlog/EL_20220729.evt"
                    string newFileName = evt_path + DateTime.Now.ToString("yyyyMMdd") + ".evt";//粘贴路径
                    try
                    {
                        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(fileName);
                        request.Method = WebRequestMethods.Ftp.DownloadFile;

                        request.Credentials = new NetworkCredential(GloVar.userName, GloVar.password);
                        FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                        Stream responseStream = response.GetResponseStream();

                        // 把 byte[] 写入文件

                        FileStream fs = new FileStream(newFileName, FileMode.Create);

                        BinaryWriter bw = new BinaryWriter(fs);

                        bw.Write(ToByteArray(responseStream));

                        bw.Close();

                        fs.Close();

                        //Upload("ftp://ftp.mysite.net/" + FileToCopy, ToByteArray(responseStream), userName, password);
                        responseStream.Close();
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
        }
        

        //解压当天最新evt文件
        public void Toexcel()
        {
            th2 = new Thread(Exexcel);
            th2.IsBackground = true;
            th2.Start();
        }
        private void Exexcel()
        {
            while (true)
            {
                Thread.Sleep(2000);
                {
                    lock (o)
                    {
                        try
                        {
                            Delectfile(".xlsx");
                            string path_sour = evt_path + DateTime.Now.ToString("yyyyMMdd");
                            string fileold = GloVar.path_Alarm + DateTime.Now.ToString("yyyyMMdd") + ".xlsx";
                            if (File.Exists(path_sour + ".evt"))
                            {
                                ProcessStartInfo prs = new ProcessStartInfo(path_sour + ".evt");
                                Process pr = new Process();
                                pr.StartInfo = prs;
                                pr.Start();

                                if (File.Exists(fileold))
                                {
                                    File.Delete(fileold);
                                }
                                File.Move(path_sour + ".xlsx", fileold);
                            }
                        }
                        catch
                        {

                        }
                    }
                }
            }
        }
        //删除超过一年的文件
        private  void Delectfile(string xlsxorevt)
        {
            string path = evt_path +DateTime .Now .AddYears (-1).ToString ("yyyyMMdd")+xlsxorevt;
            if (xlsxorevt ==".xlsx")
            {
                path = GloVar.path_Alarm +DateTime .Now .AddYears (-1).ToString ("yyyyMMdd") + xlsxorevt;
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
            else
            {
               if(File.Exists (path  ))
                {
                    File.Delete(path);
                }
                path = evt_path + DateTime.Now.AddDays (-1).ToString("yyyyMMdd") + ".xlsx";
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
            
        }
    }
}
