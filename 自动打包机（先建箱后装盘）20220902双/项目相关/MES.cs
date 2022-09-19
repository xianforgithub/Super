using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ActionContext;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using LWDBJ_自建_.项目相关;

namespace LWDBJ
{
    public class MES
    {
        static string strCookie = string.Empty;

        static int Timeout = 3000;
        public MES(int timeout)
        {
            Timeout = timeout;
        }
        Login_push login_push = new Login_push();                             //登录输入
        PackSpecifications_push pack_push = new PackSpecifications_push();    //打包输入
        CreateBoxSn_push creat_push = new CreateBoxSn_push();                 //生成箱号输入
        GetGroup_push group_push = new GetGroup_push();                       //分组输入
        UpdatePackStatus_push update_push = new UpdatePackStatus_push();      //箱子状态更新输入
        FinishPackBox_push finish_push = new FinishPackBox_push();            //称重上传输入
        RecordPrintTimes_push record_push = new RecordPrintTimes_push();      //记录打印输入
        printProductSn_push print_push = new printProductSn_push();           //打印箱号输入
        allFitting_push fit_push = new allFitting_push();                     //解绑输入
        GetPackageByPackNo_push packno_push = new GetPackageByPackNo_push();  //分档输入
        public string HttpPost(string postUrl, string paramData)
        {
            string responseContent = string.Empty;
            try
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(paramData); //转化
                HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(new Uri(postUrl));
                webReq.Method = "POST";
                webReq.ContentType = "application/x-www-form-urlencoded";
                webReq.ContentLength = byteArray.Length;
                webReq.Headers.Add("Cookie", strCookie);
                //webReq.Timeout = Timeout;
                using (Stream reqStream = webReq.GetRequestStream())
                {
                    reqStream.Write(byteArray, 0, byteArray.Length);//写入参数
                                                                    //reqStream.Close();

                }
                using (HttpWebResponse response = (HttpWebResponse)webReq.GetResponse())
                {
                    //在这里对接收到的页面内容进行处理
                    using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                    {
                        responseContent = sr.ReadToEnd();
                        if (responseContent.Contains("sessionId"))
                        {
                            strCookie = "JSESSIONID=" + responseContent.Substring(45, 32);
                        }
                        //File.WriteAllText("D:\\a.txt", responseContent);
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return responseContent;
        }

        #region 新登录接口
        #region 设备登录
        public bool LoginDevice(string machine, string user, string mi, string password, ref string resMes)
        {
            string filename = DateTime.Now.ToString("yyyy-MM-dd") + "_MES.txt";
            try
            {
                //http://lxmes.liwinon.com/mesapi/LoginDevice jsonData{"MachineId": "LJR01A","CardNumber": "00013244646546"};
                //string json = "jsonData={\"MachineId\":\"{0}\",\"CardNumber\":\"{1}\"}";
                //json = json.Replace("{0}", machine);
                //json = json.Replace("{1}", user);
                login_push.Clear();
                login_push.MachineId = machine;
                login_push.UserNumber = user;
                login_push.Mi = mi;
                login_push.PassWord = password;
                string json = "jsonData=" + JsonHandler.SerializeObject(login_push);
                SysFunction.SaveLog(filename, "MES登录请求  "+ GloVar.Url_Logion, json);

                string res = HttpPost(GloVar.Url_Logion , json);
                resMes = res;
                Dictionary<string, object> dic = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(res);
                SysFunction.SaveLog(filename, "MES登录返回  " + GloVar.Url_Logion, res);
                if (dic["status"].ToString().ToUpper() == "TRUE")
                {
                    GloVar.OperatorId = dic["result"].ToString();  
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                SysFunction.SaveLog(filename, "MES登录请求异常", ex.ToString());
                resMes += "登录异常error" + ex.ToString();
                return false;
            }
        }

        #endregion  设备登录
        
        #region 获取MI

        public Dictionary<string, string> GetMI(ref string resCatch)
        {
            string filename = DateTime.Now.ToString("yyyy-MM-dd") + "_MES.txt";
            try
            {
                Dictionary<string, string> dcMi = new Dictionary<string, string>();
                string jsonData = "jsonData={}";
                SysFunction.SaveLog(filename, "MESMI号请求  "+ SysFunction.get_Param((int)GloVar.enSystemParam.类型接口), jsonData);

                string res = HttpPost(SysFunction.get_Param((int)GloVar.enSystemParam.类型接口), jsonData);
                SysFunction.SaveLog(filename, "MESMI号返回  "+ SysFunction.get_Param((int)GloVar.enSystemParam.类型接口), res);
                resCatch = res;
                MIObject mi = JsonConvert.DeserializeObject<MIObject>(res);
                if (mi.status == "true")
                {
                    foreach (MItestResultDetails item in mi.testResultDetails)
                    {
                        dcMi.Add(item.technicsName, item.modelCode);//工艺名称，物料料号
                    }
                }
                else
                {
                    //MessageBox.Show(res);
                }

                return dcMi;
            }
            catch (Exception ex)
            {
                SysFunction.SaveLog(filename, "获取MI号异常", ex.ToString());
                resCatch = "获取MI号异常" + ex.ToString();
                return null;
            }
        }
        #endregion  获取MI

        #region 打包参数

        //拿到箱子重量上下限，分组情况
        public bool GetPackSpecifications(ref string qty, ref string weightup,ref string weightdown,ref  string isgroup, ref string groupcount, ref string resCatch)
        {

            string filename = DateTime.Now.ToString("yyyy-MM-dd") + "_MES.txt";
            pack_push.TechnicsName = GloVar.mes_MI;
            try
            {
                
                string jsonData = "jsonData="+JsonHandler .SerializeObject (pack_push);
                SysFunction.SaveLog(filename, "打包参数请求  " + SysFunction.get_Param((int)GloVar.enSystemParam.打包参数接口), jsonData);

                string res = HttpPost(SysFunction.get_Param((int)GloVar.enSystemParam.打包参数接口), jsonData);
                SysFunction.SaveLog(filename, "打包参数返回  "+ SysFunction.get_Param((int)GloVar.enSystemParam.打包参数接口), res);
                resCatch = res;

                PackSpecifications mi = JsonConvert.DeserializeObject<PackSpecifications>(res);
                if (mi.status == "true")
                {
                    if (mi.testResultDetails == null)
                    {
                        GloVar.isLimit = false;
                        isgroup = "1";
                    }
                    else
                    {
                        GloVar.isLimit = true;
                        isgroup = mi.testResultDetails[0].isGroup;
                        PackDetails pdt = mi.testResultDetails[0];
                        qty = pdt.qty;
                        GloVar.ZweightDowm = Convert.ToDouble(pdt.boxWeightMin);   //每箱最小值
                        GloVar.ZweightUp = Convert.ToDouble(pdt.boxWeightMax);
                        weightdown = pdt.boxWeightMin;
                        weightup = pdt.boxWeightMax;
                        if (pdt.isGroup == "0")   //需要分组
                        {
                            GloVar.isGroup = true;
                            GloVar.groupCount = Convert.ToInt16(pdt.groupCount);
                            groupcount = pdt.groupCount;
                        }
                        else
                        {
                            GloVar.isGroup = false;
                        }
                    }
                    return true;
                }
                else
                {
                    
                    //MessageBox.Show(res);
                    return false;
                }
            }
            catch (Exception ex)
            {
                SysFunction.SaveLog(filename, "获取打包参数异常", ex.ToString());
                resCatch = "获取打包参数异常" + ex.ToString();
            }
            return false;
        }
        #endregion  打包参数

        #region 生成新箱号

        public string  CreateBoxSn(ref string resCatch)
        {
             
            string filename = DateTime.Now.ToString("yyyy-MM-dd") + "_MES.txt";
            creat_push .Mi  = GloVar.mes_MI;
            creat_push.StepNo = GloVar.StepNo;
            creat_push.Mo = GloVar.MO;
            creat_push.Lot = GloVar.Lot;
            creat_push.GroupCode = "1163";
            creat_push.MachineId = GloVar.M_MACHINENO;
            creat_push.WorkShop = GloVar.WorkShop;
            creat_push.Type = "1";
            creat_push.OperatorId = GloVar.OperatorId;
            creat_push.TimeStamp = DateTime.Now.ToString();
            creat_push.ItemCode = GloVar.ItemCode;
            try
            {

                string jsonData = "jsonData=" + JsonHandler.SerializeObject(creat_push);
                SysFunction.SaveLog(filename, "生成箱号请求  "+SysFunction.get_Param((int)GloVar.enSystemParam.生成新箱号接口), jsonData);

                string res = HttpPost(SysFunction.get_Param((int)GloVar.enSystemParam.生成新箱号接口), jsonData);
                SysFunction.SaveLog(filename, "生成箱号返回  "+ SysFunction.get_Param((int)GloVar.enSystemParam.生成新箱号接口), res);
                resCatch = res;
                CreateBoxSn_back mi = JsonConvert.DeserializeObject<CreateBoxSn_back>(res);
                if (mi.status == "true")
                {
                    GloVar.BoxSN = mi.result;

                    return mi.result;
                }
                else
                {
                    //MessageBox.Show("生成箱号失败，请按提示操作并重新初始化： " + res);
                }
            }
            catch (Exception ex)
            {
                SysFunction.SaveLog(filename, "获取新箱号异常", ex.ToString());
                resCatch = "获取新箱号异常" + ex.ToString();
            }
            return "";
        }
        #endregion  生成新箱号

        #region 电芯分组

        //上传二维码编号，返回分组字符串
        public string  GetGroup(string sn, ref string resCatch)
        {

            string filename = DateTime.Now.ToString("yyyy-MM-dd") + "_MES.txt";
            group_push.Sn = sn;
            try
            {
                string jsonData = "jsonData=" + JsonHandler.SerializeObject(group_push);
                SysFunction.SaveLog(filename, "电芯分组请求  "+SysFunction.get_Param((int)GloVar.enSystemParam.电芯分组接口), jsonData);

                string res = HttpPost(SysFunction.get_Param((int)GloVar.enSystemParam.电芯分组接口), jsonData);
                SysFunction.SaveLog(filename, "电芯分组返回  "+ SysFunction.get_Param((int)GloVar.enSystemParam.电芯分组接口), res);
                resCatch = res;
                GetGroup_back mi = JsonConvert.DeserializeObject<GetGroup_back>(res);
                if (mi.status == "true")
                {
                    return  mi.testResult;//C,D,D
                   
                }
                else
                {

                    //MessageBox.Show(res);
                }
            }
            catch (Exception ex)
            {
                SysFunction.SaveLog(filename, "获取电芯分组异常", ex.ToString());
                resCatch = "获取电芯分组异常" + ex.ToString();
            }
            return "";
        }
        #endregion  电芯分组

        #region 电芯绑箱

        
        public bool  PackCell2Box2(object json, ref string resCatch)
        {

            string filename = DateTime.Now.ToString("yyyy-MM-dd") + "_MES.txt";
            
            try
            {
                string jsonData = "jsonData=[" +json+"]";
                SysFunction.SaveLog(filename, "电芯绑箱请求  "+SysFunction.get_Param((int)GloVar.enSystemParam.电芯绑箱接口), jsonData);

                string res = HttpPost(SysFunction.get_Param((int)GloVar.enSystemParam.电芯绑箱接口), jsonData);
                SysFunction.SaveLog(filename, "电芯绑箱返回  "+ SysFunction.get_Param((int)GloVar.enSystemParam.电芯绑箱接口), res);
                resCatch = res;
                PackCell2Box2_back  mi = JsonConvert.DeserializeObject<PackCell2Box2_back>(res);
                if (mi.status == "true")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                SysFunction.SaveLog(filename, "电芯绑箱异常", ex.ToString());
                resCatch = "电芯绑箱异常" + ex.ToString();
            }
            return false;
        }
        #endregion  电芯绑箱

        #region 箱子状态更新
        
        public bool UpdatePackStatus( string boxsn, ref string resCatch)
        {

            string filename = DateTime.Now.ToString("yyyy-MM-dd") + "_MES.txt";
            update_push.boxSn = boxsn;
            try
            {
                string jsonData = "jsonData="+JsonHandler .SerializeObject (update_push );
                SysFunction.SaveLog(filename, "箱子状态更新请求  "+ SysFunction.get_Param((int)GloVar.enSystemParam.箱子状态更新接口), jsonData);

                string res = HttpPost(SysFunction.get_Param((int)GloVar.enSystemParam.箱子状态更新接口), jsonData);
                SysFunction.SaveLog(filename, "箱子状态更新返回  "+ SysFunction.get_Param((int)GloVar.enSystemParam.箱子状态更新接口), res);
                resCatch = res;
                UpdatePackStatus_back mi = JsonConvert.DeserializeObject<UpdatePackStatus_back>(res);
                if (mi.status == "true")
                {
                    return true;
                }
                else
                {
                    //MessageBox.Show(res);
                    return false;
                }
            }
            catch (Exception ex)
            {
                SysFunction.SaveLog(filename, "箱子状态更新异常", ex.ToString());
                resCatch = "箱子状态更新异常" + ex.ToString();
                
            }
            return false;
        }
        #endregion  箱子状态更新

        #region 称重上传

        //输入参数重量单位是kg
        public bool FinishPackBox(string weight,string boxsn, ref string resCatch)
        {

            string filename = DateTime.Now.ToString("yyyy-MM-dd") + "_MES.txt";
            finish_push.BoxSn = boxsn;
            finish_push.Weight = weight;
            finish_push.Unit = "Kg";
            finish_push.MachineId = GloVar.M_MACHINENO;
            finish_push.TimeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            finish_push.GroupCode = "1163";
            try
            {
                string jsonData = "jsonData=" + JsonHandler.SerializeObject(finish_push);
                SysFunction.SaveLog(filename, "称重上传请求  "+ SysFunction.get_Param((int)GloVar.enSystemParam.称重上传接口), jsonData);

                string res = HttpPost(SysFunction.get_Param((int)GloVar.enSystemParam.称重上传接口), jsonData);
                SysFunction.SaveLog(filename, "称重上传返回  "+ SysFunction.get_Param((int)GloVar.enSystemParam.称重上传接口), res);
                resCatch = res;
                FinishPackBox_back mi = JsonConvert.DeserializeObject<FinishPackBox_back>(res);
                if (mi.status == "true")
                {
                    return true;
                }
                else
                {
                    //MessageBox.Show(res);
                    return false;
                }
            }
            catch (Exception ex)
            {
                SysFunction.SaveLog(filename, "称重上传异常", ex.ToString());
                resCatch = "称重上传异常" + ex.ToString();
            }
            return false;
        }
        #endregion  称重上传

        #region 记录打印信息
        
        public bool RecordPrintTimes(string boxsn, ref string resCatch)
        {

            string filename = DateTime.Now.ToString("yyyy-MM-dd") + "_MES.txt";
            record_push.Sn = boxsn;
            record_push.SnType = "0";
            record_push.MachineId = GloVar.M_MACHINENO;
            record_push.OperatorId = GloVar.OperatorId;
            record_push.TimeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            try
            {
                string jsonData = "jsonData=" + JsonHandler.SerializeObject(record_push);
                SysFunction.SaveLog(filename, "记录打印信息请求  "+ SysFunction.get_Param((int)GloVar.enSystemParam.记录打印信息接口), jsonData);

                string res = HttpPost(SysFunction.get_Param((int)GloVar.enSystemParam.记录打印信息接口), jsonData);
                SysFunction.SaveLog(filename, "记录打印信息返回  "+ SysFunction.get_Param((int)GloVar.enSystemParam.记录打印信息接口), res);
                resCatch = res;
                RecordPrintTimes_back mi = JsonConvert.DeserializeObject<RecordPrintTimes_back>(res);
                if (mi.status == "true")
                {
                    return true;
                }
                else
                {
                    //MessageBox.Show(res);
                    return false;
                }
            }
            catch (Exception ex)
            {
                SysFunction.SaveLog(filename, "记录打印信息上传异常", ex.ToString());
                resCatch = "记录打印信息上传异常" + ex.ToString();
            }
            return false;
        }
        #endregion  记录打印信息

        #region 打印箱号标签

        public bool printProductSn(string boxsn, ref string resCatch)
        {

            string filename = DateTime.Now.ToString("yyyy-MM-dd") + "_MES.txt";
            print_push.BoxSn = boxsn;
            print_push.SnType = GloVar .Region;
            print_push.MachineId = GloVar.M_MACHINENO;
            try
            {
                string jsonData = "jsonData=" + JsonHandler.SerializeObject(print_push);
                SysFunction.SaveLog(filename, "打印箱号标签请求  "+ SysFunction.get_Param((int)GloVar.enSystemParam.打印箱号标签接口), jsonData);

                string res = HttpPost(SysFunction.get_Param((int)GloVar.enSystemParam.打印箱号标签接口), jsonData);
                SysFunction.SaveLog(filename, "打印箱号标签返回  "+ SysFunction.get_Param((int)GloVar.enSystemParam.打印箱号标签接口), res);
                resCatch = res;
                printProductSn_back mi = JsonConvert.DeserializeObject<printProductSn_back>(res);
                if (mi.status == "true")
                {
                    return true;
                }
                else
                {
                    //MessageBox.Show(res);
                    return false;
                }
            }
            catch (Exception ex)
            {
                SysFunction.SaveLog(filename, "打印箱号标签上传异常", ex.ToString());
                resCatch = "打印箱号标签上传异常" + ex.ToString();
            }
            return false;
        }
        #endregion  打印箱号标签

        #region 箱子解绑

        public bool allFitting(string boxsn, ref string resCatch)
        {

            string filename = DateTime.Now.ToString("yyyy-MM-dd") + "_MES.txt";
            fit_push.BoxSn = boxsn;
            fit_push .OperatorId  = GloVar.OperatorId ;
            fit_push.TimeStamp = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            try
            {
                string jsonData = "jsonData=" + JsonHandler.SerializeObject(fit_push);
                SysFunction.SaveLog(filename, "箱子解绑请求  "+ SysFunction.get_Param((int)GloVar.enSystemParam.箱子解绑接口), jsonData);

                string res = HttpPost(SysFunction.get_Param((int)GloVar.enSystemParam.箱子解绑接口), jsonData);
                SysFunction.SaveLog(filename, "箱子解绑返回  "+ SysFunction.get_Param((int)GloVar.enSystemParam.箱子解绑接口), res);
                resCatch = res;
                FinishPackBox_back mi = JsonConvert.DeserializeObject<FinishPackBox_back>(res);
                if (mi.status == "true")
                {
                    return true;
                }
                else
                {
                    //MessageBox.Show(res);
                    return false;
                }
            }
            catch (Exception ex)
            {
                SysFunction.SaveLog(filename, "箱子解绑上传异常", ex.ToString());
                resCatch = "箱子解绑上传异常" + ex.ToString();
            }
            return false;
        }
        #endregion  箱子解绑

        #region 分档

        public bool GetPackageByPackNo(string boxsn,ref string miNo, ref string resCatch)
        {

            string filename = DateTime.Now.ToString("yyyy-MM-dd") + "_MES.txt";
            packno_push.BoxSn = boxsn;
            try
            {
                string jsonData = "jsonData=" + JsonHandler.SerializeObject(packno_push);
                SysFunction.SaveLog(filename, "分档请求  "+ SysFunction.get_Param((int)GloVar.enSystemParam.分档接口), jsonData);

                string res = HttpPost(SysFunction.get_Param((int)GloVar.enSystemParam.分档接口), jsonData);
                SysFunction.SaveLog(filename, "分档返回  "+ SysFunction.get_Param((int)GloVar.enSystemParam.分档接口), res);
                resCatch = res;
                GetPackageByPackNo_back mi = JsonConvert.DeserializeObject<GetPackageByPackNo_back>(res);
                if (mi.status == "true")
                {
                    GetPackageByPackNoDetails_back packdet = mi.testResultDetails[0];
                    miNo = packdet.miNo;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                SysFunction.SaveLog(filename, "分档上传异常", ex.ToString());
                resCatch = "分档上传异常" + ex.ToString();
            }
            return false;
        }
        #endregion  分档

        #endregion 新登录接口


    }


}
