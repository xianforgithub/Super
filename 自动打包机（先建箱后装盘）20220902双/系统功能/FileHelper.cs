using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace LWDBJ
{
    public class FileHelper
    {
        /// <summary>
        /// 保存电池上传记录
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="txt">要保存的记录</param>
        public void SaveUpdataCellCSV(string path, string titleName, string txt)
        {
            try
            {
                string strPath = "";
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                strPath = path + titleName + DateTime.Now.ToString("yyyy-MM-dd") + ".csv";

                if (!File.Exists(strPath))
                {
                    using (FileStream fs = new FileStream(strPath, FileMode.Append, FileAccess.Write))
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("时间" + ",");
                        sb.Append("条码" + ",");
                        sb.Append("箱号" + ",");
                        sb.Append("操作员" + ",");
                        sb.Append("检查员" + ",");
                        sb.Append("电芯型号" + ",");
                        sb.Append("MI号" + ",");
                        sb.Append("电压类型" + ",");
                        sb.Append("工单号" + ",");
                        sb.Append("批次号" + ",");
                        sb.Append("设备编号" + ",");
                        StreamWriter sw = new StreamWriter(fs, Encoding.Default);
                        sw.WriteLine(sb);

                        sw.Close();
                        fs.Close();
                    }
                }

                using (FileStream fs = new FileStream(strPath, FileMode.Append, FileAccess.Write))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ",");
                    sb.Append(txt + ",");
                    StreamWriter sw = new StreamWriter(fs, Encoding.Default);
                    sw.WriteLine(sb);

                    sw.Close();
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                string faileName = DateTime.Now.ToString("yyyy-MM-dd") + "_other.txt";
                SysFunction.SaveLog(faileName, "保存电芯记录异常", ex.ToString());
            }

        }


        /// <summary>
        /// 保存重量上传记录
        /// </summary>
        /// <param name=""></param>
        /// <param name="titleName"></param>
        /// <param name="txt"></param>
        public void SaveUpdataBoxWeight(string path, string titleName, string txt)
        {
            try
            {
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                path += titleName + DateTime.Now.ToString("yyyy-MM-dd") + ".csv";

                if (!File.Exists(path))
                {
                    using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write))
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("时间" + ",");
                        sb.Append("箱号" + ",");
                        sb.Append("总重量" + ",");
                        sb.Append("净重" + ",");
                        sb.Append("扫码人" + ",");
                        sb.Append("检查人" + ",");
                        sb.Append("NG信息" + ",");

                        StreamWriter sw = new StreamWriter(fs, Encoding.Default);
                        sw.WriteLine(sb);

                        sw.Close();
                        fs.Close();

                    }
                }

                using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ",");
                    sb.Append(txt + ",");

                    StreamWriter sw = new StreamWriter(fs, Encoding.Default);
                    sw.WriteLine(sb);

                    sw.Close();
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                string faileName = DateTime.Now.ToString("yyyy-MM-dd") + "_other.txt";
                SysFunction.SaveLog(faileName, "保存称重记录异常", ex.ToString());
            }
        }

        /// <summary>保存拆箱记录
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="boxSN"></param>
        /// <param name="OKorNG"></param>
        public void SaveDeletBoxLog(string path, string titleName, string boxSN, string OKorNG)
        {
            try
            {
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                path += titleName + DateTime.Now.ToString("yyyy-MM-dd") + ".csv";

                if (!File.Exists(path))
                {
                    using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write))
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("时间" + ",");
                        sb.Append("箱号" + ",");
                        sb.Append("是否成功" + ",");
                        sb.Append("扫码人" + ",");
                        sb.Append("检查人" + ",");


                        StreamWriter sw = new StreamWriter(fs, Encoding.Default);
                        sw.WriteLine(sb);

                        sw.Close();
                        fs.Close();

                    }
                }

                using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write))
                {
                    StringBuilder sb = new StringBuilder();

                    sb.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ",");  //时间
                    sb.Append(boxSN + ",");     //箱号
                    sb.Append(OKorNG + ",");    //拆箱不否成功
                    sb.Append(SysFunction.get_Param((int)GloVar.enSystemParam.扫码人) + ",");  //扫码人
                    sb.Append(SysFunction.get_Param((int)GloVar.enSystemParam.检查人) + ",");  //检查人

                    StreamWriter sw = new StreamWriter(fs, Encoding.Default);
                    sw.WriteLine(sb);

                    sw.Close();
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                string faileName = DateTime.Now.ToString("yyyy-MM-dd") + "_other.txt";
                SysFunction.SaveLog(faileName, "保存拆箱记录异常", ex.ToString());
            }
        }

        //保存停机记录
        public void SaveStop(string mes)
        {
            try
            {
                if (!Directory.Exists(GloVar.path_Stop))
                {
                    Directory.CreateDirectory(GloVar.path_Stop);
                }
                string path = GloVar.path_Stop + DateTime.Now.ToString("yyyyMMdd") + ".csv";
                if (!File.Exists(path))
                {
                    using (File.Create(path)) {; }
                    string content = "设备编号,停机原因,开始时间,结束时间";
                    CSV.CSVHelper.SaveCSV(path, content);
                }
                CSV.CSVHelper.SaveCSV(path, mes);
            }
            catch (Exception ex)
            {

            }

        }
        private bool b_save = false;//触发记录开始停机
        private string startime = "";
        private string stop_cause = "";
        public void SaveStop()
        {
            try
            {
                if (GloVar.PLC_Rread[11] == 0 && b_save == false)//plc触发停机
                {
                    startime = DateTime.Now.ToString();
                    b_save = true;
                }
                else if (GloVar.PLC_Rread[11] > 0 && b_save)
                {
                    switch (GloVar.PLC_Rread[11])
                    {
                        case 1: stop_cause = "待料"; break;
                        case 2: stop_cause = "品质异常"; break;
                        case 3: stop_cause = "离岗"; break;
                        case 4: stop_cause = "首检点检"; break;
                        case 5: stop_cause = "清洁"; break;
                        case 6: stop_cause = "设备故障"; break;
                        case 7: stop_cause = "网络异常"; break;
                        case 8: stop_cause = "厂房电器类异常"; break;
                        case 9: stop_cause = "无生产计划"; break;
                        case 10: stop_cause = "未知原因"; break;
                    }
                    SaveStop(SysFunction.get_Param((int)GloVar.enSystemParam.设备号) + "," + stop_cause + "," + startime + "," + DateTime.Now.ToString());
                    b_save = false;
                }
            }
            catch (Exception ex)
            {

            }

        }

        //删除超过一年的文件
        public  void Delectfile(string path, string xlsxorevt)
        {
            try
            {
                path = path + DateTime.Now.AddYears(-1).ToString("yyyyMMdd") + xlsxorevt;
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
