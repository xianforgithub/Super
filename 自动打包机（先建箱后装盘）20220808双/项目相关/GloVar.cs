using HslCommunication.Profinet.Omron;
using LWDBJ_自建_.项目相关;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LWDBJ
{
    public static class GloVar
    {
        //public static string Url_Logion = "http://172.60.6.40:8080/ifactory/j_spring_security_check?";//登录
        //public static string Url_Param = "http://172.60.6.40:8080/ifactory/lw/client/clientAPI!getDcGroupStandard.action?";//获取电芯上下限参数（保液量，放电容量，O1电压内阻,O2电压K值
        //public static string Url_Model = "http://172.60.6.40:8080/ifactory/lw/client/clientAPI!getResultList.action?";//获取MI号，电压型号
        //public static string Url_Weight = "http://172.60.6.40:8080/ifactory/lw/client/clientAPI!uploadBoxWeight.action?";//上传重量
        //public static string Url_Packing = "http://172.60.6.22:82/api/packing/packing?";//上传电芯绑盘
        //public static string Url_Search = "http://172.60.6.40:8080/ifactory/lw/client/clientAPI!searchBox.action";//查询箱号里的电芯
        //public static string Url_DeleteBox = "http://172.60.6.40:8080/ifactory/lw/client/clientAPI!deleteBox.action?";//拆箱
        //public static string Url_DevStatus = "";//上传设备状态

        public static string Url_Logion = "http://lxmes.liwinon.com/mesapi/LoginDevice?"; //登录接口
        /// <summary>用户权限级别："","技术员","工程师"
        /// 
        /// </summary>
        public static string MangeLevel = "";

        public static string SqlConn = "Database='test';Data Source='127.0.0.1';Port='3306';User Id='root';Password='123456';charset='utf8';pooling=true";

        public static string Ftp = @"ftp://192.168.250.2/eventlog/EL_";//触摸屏地址
        public static string userName = "uploadhis";//账号
        public static string password = "111111";//密码

        public static string path_productcount = Environment.CurrentDirectory + "\\product.txt";            //统计
        public static string path_mainconfig = Environment.CurrentDirectory + "\\Connect.ini";              //系统参数配置
        public static string path_devdescription = Environment.CurrentDirectory + "\\设备状态描述.csv";     //设备状态描述
        public static string path_cellParam = Environment.CurrentDirectory + "\\cellParam.txt";             //本地参数
        public static string path_savelog = @"D:\日志输出\";
        public static string path_Alarm = @"D:\报警记录\";
        public static string path_Stop = @"D:\停机记录\";

        public static string dic_productOK = @"D:\电芯上传OK记录\";
        public static string dic_productNG = @"D:\电芯上传NG记录\";
        public static string dic_delbox = @"D:\拆箱记录\";
        public static string dic_weight = @"D:\称重记录\";


        public static ProductCount ProductCount = new ProductCount();//生产统计
        public static DataTable DevStatusTable;//设备状态表
        public static FileHelper filehelper = new FileHelper();
        public static CellParam cellParam = new CellParam();
        public static DataTable systemParamTable = new DataTable();//系统参数表
        public static Recipe recipe = new Recipe();
        public static MES mes = new LWDBJ.MES(3000);

        public static string M_MACHINENO= "LSDB01";//设备号
        public static string mes_UserName = "123465465";
        public static string mes_MI = "H74";        //MI名称
        public static string ItemCode = "";      //MI对应的料号
        public static Dictionary<string, string> dcmi = new Dictionary<string, string>();  //MI号集合<工艺名称，物料号>
        public static string mes_PassWord = "123456";
        public static string OperatorId = "";   //操作员工号，登陆时返回的sessionid
        public static string dcroom = "";    //车间号
        public static string WorkShop = "";  //车间ID
        public static string  makecode = "";                             //喷码规则
        public static string StepNo = "";       //分容类型
        public static string MO = "";           //工单号
        public static string Lot = "";           //批次号
        public static string BoxSN = "";        //(最新)MES返回的箱号
        public static string Region = "LX";    //出货地区
        public static  bool isset = false;  //fase:不允许操作员设置MES相关项
        public static string mes_Station = "LW";

        public static Scaner scaner_cell;//电芯扫码枪
        public static Scaner scaner_box;//箱体扫码枪
        public static Socket PLC_Fine;//PLC
        public static OmronFinsUdp omPLC;
        public static short[] PLC_Rread = new short[20];
        public static short[] PLC_Write = new short[20];
        public static MF1_IC_Card ICcard;

        public static SerialPort serialPort_weight;//称重
        public static string weight_port;//称重串口号
        public static int weight_baudrate;//称重波特率

        /// <summary>一盘的电芯数，从PLC获取
        /// 
        /// </summary>
        public static int CellCountOnePlate;//一盘电芯的数量
        public static int NeedMovePlate;//需要搬移的盘数，用来判断是否搬移够数量再上传
        public static int NeedUpdataCellCount;//需要上传的电芯数

        /// <summary>是否需要申请新箱号
        /// 
        /// </summary>
        public static bool isBuilderNewBoxSnFlag = true;//第一次开机上传

        public static Dictionary<string, string> voltageTypeDic = new Dictionary<string, string>();

        /// <summary>当前箱号已上传的电池数量，从MES获取
        /// 
        /// </summary>
        public static int NowUpdataCellCount = 0;//当前上传电池数量

        /// <summary>当前箱已搬移盘数
        /// 
        /// </summary>
        public static int NowMovePlateCount = 0;//当前电芯搬移盘数
        //public static int NowMoveCellCoune = 0;//当前电池搬移数
        //public static int DeleteCellCount = 0;//需要拆箱的电芯数量

        /// <summary>当前正在装箱的箱号，从MES获取
        /// 
        /// </summary>
        public static string NowUpdataBoxSN = "";//当前装箱的箱号


        /// <summary>待称重箱号LIST缓存
        /// 
        /// </summary>
        public static List<string> NeedWeightBoxSnList = new List<string>();//当前上传重量的箱号集合,防止有一箱要重复称重，另一箱在等待导致条码覆盖
        //public static bool IsUpadataBox = false;//是否可以上传整箱给MES
        //public static bool IsPrintBoxSN = false;//是否可以进行打印

        //public static List<string> HistoryBoxSN = new List<string>();

        public static double WeightUp;//净重上限（不用）
        public static double WeightDowm;//净重下限（不用）
        public static double ZweightUp;//毛重上限
        public static double ZweightDowm;//毛重下限
        public static double BoxWeight;//纸箱重量（不用）
        public static bool isLimit;    //是否限制重量和分组 (true为限制)
        public static bool isGroup;    //是否分组 (true为限制)
        public static int groupCount = 0;  //分组最大数量

        public static bool PLCStatus = false;
        public static bool login_mes = false; //MES登录
       


        public static string BYL;//保液量
        public static string Capacity;//放电容量
        public static string VoltageO1L;//O1低压电压
        public static string ResO1L;//O1低压内阻
        public static string VoltageO2L;//O2低压电压
        public static string KO2L;//O2低压内阻
        public static string VoltageO1H;//O1高压电压
        public static string ResO1H;//O1高压内阻
        public static string VoltageO2H;//O2高压电压
        public static string KO2H;//O2高压K值

       
        public static string boxWeight;//箱子重量
        public static string voltageType;//所选的高电压还是低电压
        public static string cellParam_Name = "";//配方名

        public static int Boxid = 101;//自定义第N箱
        public static Dictionary<int, List<string>> dt_boxbarcode = new Dictionary<int, List<string>>();//每箱含有的编码集合

        #region 窗体静态变量
        //public static ShowLogForm showlogForm;
        //public static Form_Logion form_logion = new Form_Logion();
        //public static Form_SystemParam form_systemParam = new Form_SystemParam();
        public static Form_CellParam form_cellParam = new Form_CellParam();
        #endregion



        public static void LoadConnect()
        {
            try
            {
                cellParam_Name = SysFunction.ConnectINIReader(path_mainconfig, "Recipe", "pfname", "");//默认加载选一个配方名字

                ProductCount.LoadCount(GloVar.path_productcount);//加载生产统计
                if (!Directory.Exists(GloVar.dic_delbox)) Directory.CreateDirectory(GloVar.dic_delbox);
                if (!Directory.Exists(GloVar.dic_productNG)) Directory.CreateDirectory(GloVar.dic_productNG);
                if (!Directory.Exists(GloVar.dic_productOK)) Directory.CreateDirectory(GloVar.dic_productOK);
                if (!Directory.Exists(GloVar.dic_weight)) Directory.CreateDirectory(GloVar.dic_weight);
            }
            catch (Exception ex)
            {

            }

        }

        #region  运行步骤
        public enum enScanStep
        {
            准备扫码,
            开始扫码1,
            获取条码1,
            扫码1NG处理,
            扫码1完成,
            准备扫码2,
            开始扫码2,
            获取条码2,
            扫码2NG处理,
            扫码2完成,
            上传条码,
            扫码上传流程结束,
        }
        public static enScanStep 扫码流程 = enScanStep.准备扫码;
        public static int 扫码流程1 = 0;
        public static int 扫码流程2 = 0;
        public static int 电芯上传流程 = 0;

        public enum enBarRead
        {
            准备整箱记录,
            开始整箱记录,
            记录结束
        }
        public static enBarRead 整箱读取 = enBarRead.准备整箱记录;



        public enum enWeightStep
        {
            准备称重,
            开始称重,
            记录称重数据接口,
            记录打印信息接口,
            打印箱号标签接口,
            称重结束,
        }
        public static enWeightStep 称重流程 = enWeightStep.准备称重;

        public enum enInit
        {
            准备初始化,
            开始初始化,
            初始化完成,
        }
        public static enInit 初始化流程 = enInit.准备初始化;

        public enum enSysStatus
        {
            运行,
            暂停,
            未知,
        }
        public static enSysStatus 运行状态 = enSysStatus.暂停;

        public enum enMoveStep
        {
            准备搬移,
            开始搬移,
            判断搬移状态,
            搬移完成,
        }
        public static enMoveStep 搬移流程 = enMoveStep.准备搬移;

        public enum enScanBoxStep
        {
            准备扫码,
            开始扫码,
            获取条码,
            上传条码获取分流档位,
            箱体扫码结束,
        }
        public static enScanBoxStep 箱体扫码流程 = enScanBoxStep.准备扫码;




        #endregion

        #region 系统参数枚举
        public enum enSystemParam
        {
            PLCIP地址,
            PLC端口号,
            电池扫码枪IP地址,
            箱体扫码枪IP地址,
            触摸屏地址,
            扫码枪端口号,
            电子秤串口号,
            电子秤波特率,
            是否上传MES,
            是否分档位,
            登录接口,
            打包参数接口,
            类型接口,
            生成新箱号接口,
            电芯分组接口,
            电芯绑箱接口,
            箱子状态更新接口,
            称重上传接口,
            记录打印信息接口,
            打印箱号标签接口,
            箱子解绑接口,
            分档接口,
            电芯型号,
            MI,
            密码,
            电压类型,
            工单号,
            批次号,
            扫码人,
            检查人,
            设备号,
            扫码超时,
            档位1批次号,
            档位2批次号,
            档位3批次号,
            读卡器,
            车间号,
            喷码规则,
            出货地区
        }

        #endregion

        #region PLC与PC交互参数枚举

        public enum enReadPLC2900
        {
            通讯维持信号触发 = 0,//【11】    
            PLC初始化触发 = 1,//【10：清零 11：启动  12 完成】
            整箱开始触发 = 2,
            扫码1触发 = 3,
            扫码2触发=4,
            称重触发 =5,//【10：清零 11：净重称重  12：毛重称重
            分档扫码触发 = 6,//【10：清零 11：触发  】
            盘数 = 7,
            行数 = 8,
            列数 = 9,
            扫码次数=10,

 
            整箱结束触发 = 4,
            PLC启动触发,//【10：暂停 11：启动】                                                     //无
            //扫码1触发,//【10：清零 11：位置1扫码  12：位置2扫码】
            扫码上传触发,

            //PLC称重次数,//【11：称重一次  12：称重两次】
            搬移触发,//【10：清零 11：单盘搬移完成  12：一叠料搬移完成   13：PLC单盘更换】
            

        }

        public enum enWritePLC3000
        {
            通讯维持信号响应 = 0,//【11】
            上位机初始化响应 = 1,//【10：清零 11：触发】
            整箱开始响应 = 2,
            扫码1响应 = 3,
            扫码2响应=4,
            //整箱结束响应 = 3,
            称重响应 = 5,//【10:清零 11：称重OK 12：称重NG //NG由MES判断
            分档结果响应 = 6,//【10：清零 11:一档 12：二挡 13：三挡 14：NG】

           
            上位机启动信号触发 = 12,//【10：暂停 11：启动】
            //扫码1响应,//【10:清零 11：扫码OK 12：扫码NG】
            //扫码2响应,//【10:清零 11：扫码OK 12：扫码NG】
            扫码上传响应,//【10：清零 11：OK 12:NG】
            搬移响应,//【10:清零 11：搬移完成

            称重NG缓存清除响应 = 12,
            备用相应 = 13,
            上位机初始化触发 = 14
        }

        #endregion
        public static void WritePLCtest(int addressStart, int data)
        {
            byte[] buffer_Write = new byte[34 + 100 * 2];
            buffer_Write[0] = 0X46; //F
            buffer_Write[1] = 0X49; //I
            buffer_Write[2] = 0X4e; //N
            buffer_Write[3] = 0X53; //S

            buffer_Write[4] = 0X00;
            buffer_Write[5] = 0X00;
            buffer_Write[6] = 0X00;
            buffer_Write[7] = Convert.ToByte(26 + 100 * 2); //指令从这里开始后面的字数和，26是默认[8]-[33]一共26个地址

            buffer_Write[8] = 0X00;
            buffer_Write[9] = 0X00;
            buffer_Write[10] = 0X00;
            buffer_Write[11] = 0X02;

            buffer_Write[12] = 0X00;
            buffer_Write[13] = 0X00;
            buffer_Write[14] = 0X00;
            buffer_Write[15] = 0X00;

            buffer_Write[16] = 0X80;
            buffer_Write[17] = 0X00;
            buffer_Write[18] = 0X02;
            buffer_Write[19] = 0X00;

            buffer_Write[20] = 1;//PLC地址
            buffer_Write[21] = 0X00;
            buffer_Write[22] = 0X00;
            buffer_Write[23] = 3; //本机IP地址最后一个数

            buffer_Write[24] = 0X00;
            buffer_Write[25] = 0X00;
            //0102代表写指令
            buffer_Write[26] = 0X01;
            buffer_Write[27] = 0X02;
            //B1表示WR区按字，B0表示CIO按字，30表示CIO按位
            buffer_Write[28] = 0XB0;
            //地址
            buffer_Write[29] = Convert.ToByte((addressStart) / (int)(Math.Pow(2, 8)));
            buffer_Write[30] = Convert.ToByte((addressStart) % (int)(Math.Pow(2, 8)));
            //起始地址
            buffer_Write[31] = 0X00;
            //写入的个数
            buffer_Write[32] = Convert.ToByte(1 / (int)(Math.Pow(2, 8)));
            buffer_Write[33] = Convert.ToByte(1 % (int)(Math.Pow(2, 8)));//写入的地址个数，100个地址
            //写入的数据
            int index1 = 34;

            buffer_Write[index1] = Convert.ToByte(data / (int)(Math.Pow(2, 8)));//high
            buffer_Write[index1 + 1] = Convert.ToByte(data % (int)(Math.Pow(2, 8)));//low

            GloVar.PLC_Fine.Send(buffer_Write);
            Thread.Sleep(10);
            byte[] writeBuffer = new byte[50];
            int writeBufferLength = GloVar.PLC_Fine.Receive(writeBuffer);
        }


    }
}
