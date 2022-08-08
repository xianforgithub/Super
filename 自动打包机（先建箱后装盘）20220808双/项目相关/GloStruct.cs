using HslCommunication.Profinet.Omron;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LWDBJ
{
    //生产统计
    public class ProductCount
    {
        public int 总投入 = 0;//总投入

        public int marking拦截 = 0;//marking拦截 

        public int 扫码不良 = 0;//扫码不良

        public int 性能不良 = 0;//性能不良

        public int 已入箱 = 0;//已入箱
        public int 拆箱数量 = 0;//拆箱电芯数量


        //载入统计数据
        public void LoadCount(string fileAddress)
        {
            try
            {
                if (File.Exists(fileAddress))
                {
                    using (StreamReader sr = new StreamReader(fileAddress))
                    {
                        string txt = sr.ReadToEnd();
                        ProductCount product = JsonConvert.DeserializeObject<ProductCount>(txt);
                        marking拦截 = product.marking拦截;
                        性能不良 = product.性能不良;
                        扫码不良 = product.扫码不良;
                        已入箱 = product.已入箱;
                        拆箱数量 = product.拆箱数量;
                        总投入 = product.总投入;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        //保存
        public void SaveCount(string filepath)
        {
            try
            {
                string txt = JsonConvert.SerializeObject(this);

                StreamWriter sw = new StreamWriter(filepath);
                sw.Write(txt);
                sw.Close();
            }
            catch (Exception e)
            {

            }
        }

        public void ClearCount()
        {
            marking拦截 = 0;
            性能不良 = 0;
            扫码不良 = 0;
            已入箱 = 0;
            拆箱数量 = 0;
            总投入 = 0;
        }


    }

    public class GloStruct
    {
        //初始化
        public void Initial()
        {
            //初始化过程先初始化内存再初始化硬件
            #region 内存初始化

            SysFunction.LoadSystemParam(Environment.CurrentDirectory + "\\SysConfig.csv");                                                            //加载配置文件
            GloVar.M_MACHINENO = SysFunction.get_Param((int)GloVar.enSystemParam.设备号);                                                             //读取设备号
            GloVar.Url_Logion = SysFunction.get_Param((int)GloVar.enSystemParam.登录接口);                                                            //获取MES地址
            GloVar . Ftp = "ftp://"+ SysFunction.get_Param((int)GloVar.enSystemParam.触摸屏地址 ) +"/eventlog/EL_";                                  //触摸屏地址 @"ftp://192.168.250.2/eventlog/EL_"
            GloVar.ProductCount.LoadCount(GloVar.path_productcount);                                                                                  //生产统计
            SqlHelper.CreatMysqltable();                                                                                                              //创建数据表
            GloVar.CellCountOnePlate = GloVar.PLC_Rread[(int)GloVar.enReadPLC2900.行数] * GloVar.PLC_Rread[(int)GloVar.enReadPLC2900.列数];           //一盘的电芯数量
            GloVar.NeedMovePlate = Convert.ToInt32(GloVar.PLC_Rread[(int)GloVar.enReadPLC2900.盘数]);                                                 //需要搬移盘数（MES接口确认下来可以考虑删除）
            GloVar.NeedUpdataCellCount = GloVar.CellCountOnePlate * GloVar.NeedMovePlate;                                                             //要上传的电芯数量（MES接口确认下来可以考虑删除）
            GloVar.扫码流程1 = 0;
            GloVar.扫码流程2 = 0;
            GloVar.电芯上传流程 = 0;
            GloVar.搬移流程 = GloVar.enMoveStep.准备搬移;
            GloVar.称重流程 = GloVar.enWeightStep.准备称重;
            GloVar.Boxid = 101;
            for (int i = 0; i < 15; i++)                                                                 //初始化plc写存储区
            {
                GloVar.PLC_Write[i] = 10;
            }

            GloVar.NeedWeightBoxSnList.Clear();                                                         //待称重箱号

            //mes相关
            string msg = "";
            GloVar.dcroom = SysFunction.get_Param((int)GloVar.enSystemParam.车间号);                     //获取车间
            //GloVar.dcmi = GloVar.mes.GetMI(ref msg);                                                   //获取MI
            GloVar.makecode = SysFunction.get_Param((int)GloVar.enSystemParam.喷码规则);                 //喷码规则
            GloVar.StepNo = SysFunction.get_Param((int)GloVar.enSystemParam.电压类型).Split(' ')[1];     //分容
            GloVar .Region= SysFunction.get_Param((int)GloVar.enSystemParam.出货地区).Split(' ')[1];     //出货地区
            GloVar.MO = SysFunction.get_Param((int)GloVar.enSystemParam.工单号);                         //工单号
            GloVar.Lot = SysFunction.get_Param((int)GloVar.enSystemParam.批次号);                        //当前批次
            GloVar.mes_UserName = SysFunction.get_Param((int)GloVar.enSystemParam.扫码人);               //扫码人
            GloVar.M_MACHINENO = SysFunction.get_Param((int)GloVar.enSystemParam.设备号);                //设备名
            GloVar.mes_PassWord = SysFunction.get_Param((int)GloVar.enSystemParam.密码);                 //密码
            GloVar.NowUpdataCellCount = 0;                                                               //（初始化）电芯已上传数量MES
            GloVar.NowUpdataBoxSN = "";                                                                  //正在装箱箱号MES

            #endregion 内存初始化

            #region 读取config文件，初始化硬件

            //GloVar.LoadConnect();

            //初始化IC卡
            GloVar.ICcard = new LWDBJ_自建_.项目相关.MF1_IC_Card(SysFunction.get_Param((int)GloVar.enSystemParam.读卡器), 9600);

            //初始化plc
            GloVar.omPLC = new OmronFinsUdp(SysFunction.get_Param((int)GloVar.enSystemParam.PLCIP地址), int.Parse(SysFunction.get_Param((int)GloVar.enSystemParam.PLC端口号)));
            GloVar.omPLC.ReceiveTimeout = 2000;

           
            //初始化扫码枪
            GloVar.scaner_cell = new Scaner(SysFunction.get_Param((int)GloVar.enSystemParam.电池扫码枪IP地址), int.Parse(SysFunction.get_Param((int)GloVar.enSystemParam.扫码枪端口号)));
            if (SysFunction.get_Param((int)GloVar.enSystemParam.是否分档位) == "TRUE")
            {
                GloVar.scaner_box = new Scaner(SysFunction.get_Param((int)GloVar.enSystemParam.箱体扫码枪IP地址), int.Parse(SysFunction.get_Param((int)GloVar.enSystemParam.扫码枪端口号)));
            }

            //初始化电子秤串口
            SysFunction.InitCom(ref GloVar.serialPort_weight, SysFunction.get_Param((int)GloVar.enSystemParam.电子秤串口号), int.Parse(SysFunction.get_Param((int)GloVar.enSystemParam.电子秤波特率)));

            #endregion 读取config文件，初始化硬件


        }
    }


    //一箱电芯
    public class Box
    {
        public string Mes_id = "";  //箱号
        public string weightup = "";
        public string weightdown = "";
        public string isgroup = "";
        public string groupcount = "";
        public List<string> lsgroup = new List<string>();  //已经包含的组别
        public Dictionary<int, Dish> dcbox = new Dictionary<int, Dish>();
    }
    //一盘电芯
    public class Dish
    {
        public int dishcellcount = 0;
        public Dictionary<int, Cell> dcdish = new Dictionary<int, Cell>();
    }
    //一个电芯
    public class Cell
    {
        public string barcode = "";
    }

}
