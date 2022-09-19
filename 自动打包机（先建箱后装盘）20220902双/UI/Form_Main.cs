
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Threading;
using LWDBJ_自建_.项目相关;
using LWDBJ_自建_.UI;
using HslCommunication.Profinet.Omron;
using System.Diagnostics;
using LWDBJ_自建_.UI_Wpf;

namespace LWDBJ
{
    public partial class Form_Main : Form
    {
        #region 全局变量
        MES mes = GloVar.mes;
        private GloStruct gls = new GloStruct();
        private Thread thread_PLC;//PLC刷新线程;
        private Thread thread_Boxread;//整箱触发;
        private Thread thread_BoxEndread;//整箱结束触发
        private Thread thread_ScanCell1;//扫码1线程;
        private Thread thread_ScanCell2;//扫码2线程;
        private Thread thread_UpdateCells;//扫码完上传线程;
        private Thread thread_Move;//搬移线程
        private Thread thread_Weight;//称重线程;
        private Thread thread_Init;//初始化线程;
        private Thread thread_BoxScan;//箱体扫码线程;
        private Alarm_ftp Alarm = new Alarm_ftp();//报警信息读取对象

        private Dictionary<int, Box> dc_Allbox = new Dictionary<int, Box>();//《ID，箱》
        private int communID = 100;//与plc整箱交互ID判断条件
        private bool updata = false; //绑箱与更新箱子状态标志位
        private int index = 1;//准备绑箱的下一个位置

        #endregion
        public Form_Main()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            gls.Initial();         //配置初始化
            Init_Thread();         //线程初始化
            ShowInitial();         //界面初始化
            
        }

        #region 初始化

        /// <summary>
        /// 初始化线程
        /// </summary>
        private void Init_Thread()
        {
            //PLC刷新线程（通信维持）
            thread_PLC = new Thread(new ThreadStart(Task_PLC1));
            thread_PLC.IsBackground = true;
            thread_PLC.Start();

            //初始化线程
            thread_Init = new Thread(new ThreadStart(Task_Init));
            thread_Init.IsBackground = true;
            thread_Init.Start();

            //整箱触发线程
            thread_Boxread = new Thread(new ThreadStart(Task_BoxRead));//新增20220328 
            thread_Boxread.IsBackground = true;
            thread_Boxread.Start();

            ////整箱结束触发
            ////thread_BoxEndread = new Thread(new ThreadStart(Task_BoxEndRead));//屏蔽
            ////thread_BoxEndread.IsBackground = true;
            ////thread_BoxEndread.Start();

            //电池扫码1线程
            thread_ScanCell1 = new Thread(new ThreadStart(Task_ScanCell1));
            thread_ScanCell1.IsBackground = true;
            thread_ScanCell1.Start();

            //电池扫码2线程
            thread_ScanCell2 = new Thread(new ThreadStart(Task_ScanCell2));
            thread_ScanCell2.IsBackground = true;
            thread_ScanCell2.Start();

            //电池扫码完上传线程;
            thread_UpdateCells = new Thread(new ThreadStart(Task_UpdateCells));
            thread_UpdateCells.IsBackground = true;
            thread_UpdateCells.Start();

            ////搬移线程 （可将盘数记录在扫码线程中，屏蔽改线程）
            ////thread_Move = new Thread(new ThreadStart(Task_Mvoe));
            ////thread_Move.IsBackground = true;
            ////thread_Move.Start();

            //称重线程
            thread_Weight = new Thread(new ThreadStart(Task_Weight));
            thread_Weight.IsBackground = true;
            thread_Weight.Start();

            //分档扫码线程
            if (SysFunction.get_Param((int)GloVar.enSystemParam.是否分档位) == "TRUE") //改完20220328
            {
                thread_BoxScan = new Thread(new ThreadStart(Task_ScanBox));
                thread_BoxScan.IsBackground = true;
                thread_BoxScan.Start();
            }

            //复制报警信息
            Alarm.ReadAlarm(); //新增
            Alarm.Toexcel();
        }

        //界面+全局变量初始化
        private void ShowInitial()
        {

            this.Text += "    Build: " + new System.IO.FileInfo(this.GetType().Assembly.Location).LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
            tx_Device.Text = GloVar.M_MACHINENO;                                             //设备号

            cbx_room.Text = SysFunction.get_Param((int)GloVar.enSystemParam.车间号);
            GetMiModel();                                                                    //加载MI号
            cbx_MI.Text = SysFunction.get_Param((int)GloVar.enSystemParam.MI);
            cbx_makecode.Text = GloVar.makecode;                                             //喷码规则（本地选择）
            cob_ov.Text = SysFunction.get_Param((int)GloVar.enSystemParam.电压类型);         //分容
            cob_region.Text = SysFunction.get_Param((int)GloVar.enSystemParam.出货地区);     //出货地区
            tx_MoNumber.Text = SysFunction.get_Param((int)GloVar.enSystemParam.工单号);      //工单号
            tx_OpenerID.Text = GloVar.mes_UserName;                                          //操作员
            tx_BatchNo.Text = SysFunction.get_Param((int)GloVar.enSystemParam.批次号);       //当前批次
            GloVar.CellCountOnePlate = GloVar.PLC_Rread[(int)GloVar.enReadPLC2900.行数] * GloVar.PLC_Rread[(int)GloVar.enReadPLC2900.列数];           //一盘的电芯数量
            LoadMESInfo();                                                                   //界面MES相关，工单号等
            GetRowColPlateCountByPLC();                                                      //加载一箱行列盘数和显示扫码显示区个数
            rtxWeightBoxList.Visible = false;
            label7.Visible = false;
            ShowLog("软件打开");

        }
        #endregion 初始化

        #region PLC刷新
        /// <summary>
        /// PLC刷新线程
        /// </summary>
        private void Task_PLC()
        {
            while (true)
            {
                Thread.Sleep(10);
                try
                {
                    var rRet = GloVar.omPLC.ReadInt16("C2900", (ushort)GloVar.PLC_Rread.Length);
                    if (rRet.IsSuccess)
                    {
                        GloVar.PLC_Rread = rRet.Content;
                    }
                    else
                    {
                        GloVar.PLCStatus = false;
                        ShowLog("PLC读失败");
                        Thread.Sleep(2000);
                        continue;
                    }

                    GloVar.PLC_Write[0] = 11;
                    var wRet = GloVar.omPLC.Write("C3000", GloVar.PLC_Write);

                    if (wRet.IsSuccess == false)
                    {
                        GloVar.PLCStatus = false;
                        ShowLog("PLC写失败");
                        Thread.Sleep(2000);
                        continue;
                    }
                    if (rRet.IsSuccess)
                    {
                        lab_plc.BackColor = Color.Green;

                    }
                    else
                    {
                        lab_plc.BackColor = Color.Red;
                    }
                }
                catch (Exception ex)
                {
                    GloVar.PLCStatus = false;
                    ShowLog(ex.Message);
                    Thread.Sleep(2000);
                }
            }
        }

        #endregion

        #region PLC刷新
        /// <summary>
        /// PLC刷新线程
        /// </summary>
        ///// 
        private void Task_PLC1()
        {
            while (true)
            {
                try
                {
                    if (GloVar.PLC_Fine == null || GloVar.PLC_Fine.Connected == false)
                    {
                        if (!SysFunction.InitSocketClient(ref GloVar.PLC_Fine, SysFunction.get_Param((int)GloVar.enSystemParam.PLCIP地址), int.Parse(SysFunction.get_Param((int)GloVar.enSystemParam.PLC端口号))))
                        {
                            GloVar.PLCStatus = false;
                            ShowLog("PLC连接初始化失败");
                            continue;
                        }
                        GloVar.PLC_Fine.Send(PLCFunction.HandShake());//发送握手命令
                        Thread.Sleep(50);
                        byte[] readBuffer0 = new byte[50];
                        int ReadBufferLength0 = GloVar.PLC_Fine.Receive(readBuffer0);//获取返回的长度
                        if (ReadBufferLength0 == 24)
                        {
                            GloVar.PLCStatus = true;
                            ShowLog("PLC连接成功");
                            while (true)
                            {
                                Thread.Sleep(10);
                                //读取100个地址的数据
                                PLCFunction.ReadPLC(2900, 100);
                                byte[] readBuffer = new byte[1024];
                                Thread.Sleep(10);
                                GloVar.PLC_Fine.Receive(readBuffer);
                                PLCFunction.PLCToPCData(readBuffer);
                                Thread.Sleep(10);

                                //写入100个地址的数据
                                //GloVar.PLC_Write[(int)GloVar.enWritePLC3000.扫码上传响应] = 11;
                                GloVar.PLC_Write[(int)GloVar.enWritePLC3000.通讯维持信号响应] = 11;
                                PLCFunction.WritePLC(3000, 100);//写入PLC
                            }
                        }
                        Thread.Sleep(2000);
                    }
                }
                catch (Exception ex)
                {
                    GloVar.PLCStatus = false;
                    GloVar.PLC_Fine.Close();
                    Thread.Sleep(2000);
                }
            }
        }

        #endregion

        #region 整机初始化线程
        /// <summary>
        /// 监控初始化信号线程
        /// </summary>
        private void Task_Init()
        {

            while (true)
            {
                switch (GloVar.初始化流程)
                {
                    case GloVar.enInit.准备初始化:
                        if (GloVar.PLC_Rread[(int)GloVar.enReadPLC2900.PLC初始化触发] == 11)
                        {

                            ShowLog("收到PLC初始化信号，开始初始化");
                            GloVar.运行状态 = GloVar.enSysStatus.暂停;
                            GloVar.初始化流程 = GloVar.enInit.开始初始化;
                        }

                        break;

                    case GloVar.enInit.开始初始化:

                        GloVar.运行状态 = GloVar.enSysStatus.暂停;
                        for (int i = 0; i < 15; i++)
                        {
                            GloVar.PLC_Write[i] = 10;
                        }
                        GloVar.扫码流程1 = 0;
                        GloVar.扫码流程2 = 0;
                        GloVar.电芯上传流程 = 0;
                        GloVar.搬移流程 = GloVar.enMoveStep.准备搬移;
                        GloVar.称重流程 = GloVar.enWeightStep.准备称重;
                        GloVar.Boxid = 101;

                        GloVar.NowUpdataCellCount = 0;//（初始化）电芯已上传数量MES
                        //GloVar.NowMovePlateCount = 0;//已搬移数量
                        GloVar.NowUpdataBoxSN = "";//正在装箱箱号MES
                        //GloVar.isBuilderNewBoxSnFlag = true;//新建箱号
                        GloVar.NeedWeightBoxSnList.Clear();//待称重箱号
                        this.Invoke((Action)(() =>
                        {
                            ShowScanBox(1, null, true);
                            GetRowColPlateCountByPLC();//从PLC获取行,列,盘数
                        }));

                        GloVar.初始化流程 = GloVar.enInit.初始化完成;
                        GloVar.PLC_Write[(int)GloVar.enWritePLC3000.上位机初始化响应] = 11;
                        break;

                    case GloVar.enInit.初始化完成:
                        if (GloVar.PLC_Rread[(int)GloVar.enReadPLC2900.PLC初始化触发] == 10)
                        {
                            GloVar.PLC_Write[(int)GloVar.enWritePLC3000.上位机初始化响应] = 10;
                            GloVar.运行状态 = GloVar.enSysStatus.运行;
                            GloVar.初始化流程 = GloVar.enInit.准备初始化;
                            ShowLog("初始化交互流程完成");
                        }

                        break;
                }
                Thread.Sleep(10);
            }
        }

        #endregion

        #region 整箱触发
        private void Task_BoxRead()
        {
            short id = 0;//触发id
            Box box;
            string msg = "";
            string qty = "";//mes返回一箱的电芯数量
            while (true)
            {
                if (GloVar.运行状态 == GloVar.enSysStatus.运行)
                {
                    Thread.Sleep(100);
                    switch (GloVar.整箱读取)
                    {
                        case GloVar.enBarRead.准备整箱记录:
                            if (GloVar.PLC_Rread[(int)GloVar.enReadPLC2900.整箱开始触发] > communID)
                            {
                                index = 1; //准备绑箱的下一位置
                                txt_cellgroup.Invoke((Action)(() => { txt_cellgroup.Text = ""; }));
                                id = GloVar.PLC_Rread[(int)GloVar.enReadPLC2900.整箱开始触发];
                                GloVar.整箱读取 = GloVar.enBarRead.开始整箱记录;
                                ShowLog("整箱开始触发");
                            }
                            break;
                        case GloVar.enBarRead.开始整箱记录:
                            //建个空箱子

                            box = new Box();
                            if (SysFunction.get_Param((int)GloVar.enSystemParam.是否上传MES) == "TRUE")
                            {
                                string screat = mes.CreateBoxSn(ref msg); //mes取箱
                                if (screat == "")
                                {
                                    ShowLog("MES取箱失败：" + msg);
                                    GloVar.运行状态 = GloVar.enSysStatus.暂停;
                                    break;
                                }
                                else
                                {
                                    ShowLog("MES取箱成功：" + msg);
                                    box.Mes_id = screat;
                                    this.tx_boxScanSN.Invoke((Action)(() => { tx_boxScanSN.Text = screat; }));
                                    GloVar.NeedWeightBoxSnList.Add(screat);
                                }
                                if (!mes.GetPackSpecifications(ref qty, ref box.weightup, ref box.weightdown, ref box.isgroup, ref box.groupcount, ref msg)) //下载工艺参数
                                {
                                    GloVar.运行状态 = GloVar.enSysStatus.暂停;
                                    break;
                                }
                                else
                                {
                                    if (box.isgroup == "1") { this.txt_cellgroup.Invoke((Action)(() => { txt_cellgroup.Text = "不分组"; })); }
                                    ShowLog("MES下载工艺参数成功：" + msg);
                                    if (Convert.ToInt16(qty) != GloVar.PLC_Rread[(int)GloVar.enReadPLC2900.行数] * GloVar.PLC_Rread[(int)GloVar.enReadPLC2900.列数] * GloVar.PLC_Rread[(int)GloVar.enReadPLC2900.盘数])
                                    {
                                        ShowLog("一箱电芯个数设置有误，实际应为：" + qty);
                                        GloVar.运行状态 = GloVar.enSysStatus.暂停;
                                        break;
                                    }
                                    ShowLog("下载工艺成功 ：" + msg);
                                }
                            }

                            Dictionary<int, Dish> dcbox = new Dictionary<int, Dish>();
                            box.dcbox = dcbox;
                            if (dc_Allbox.ContainsKey(id))//判断完整箱与否
                            {
                                dc_Allbox.Remove(id);//清箱再建箱
                                dc_Allbox.Add(id, box);
                                
                            }
                            else
                            {
                                dc_Allbox.Add(id, box);
                            }
                            GloVar.PLC_Write[(int)GloVar.enWritePLC3000.整箱开始响应] = id;
                            GloVar.整箱读取 = GloVar.enBarRead.记录结束;
                            break;
                        case GloVar.enBarRead.记录结束:
                            if (GloVar.PLC_Rread[(int)GloVar.enReadPLC2900.整箱开始触发] == 10)
                            {
                                GloVar.PLC_Write[(int)GloVar.enWritePLC3000.整箱开始响应] = 10;
                                GloVar.整箱读取 = GloVar.enBarRead.准备整箱记录;
                                ShowLog("整箱触发结束");
                                GetRowColPlateCountByPLC();//更新最新箱行列盘个数
                            }
                            break;
                    }

                }
            }
        }
        #endregion

        #region 电池扫码1线程

        //一盘电芯的扫码集合
        List<string> list_barcode = new List<string>();
        List<string> tmpSNs = new List<string>();//电芯显示集合
        private void Task_ScanCell1()
        {
            //sr2000 最大视野，在800mm高度为：700*500mm
            int id = 0;//触发id
            Dish dish;//盘
            Dictionary<int, Cell> dccell;//盘电芯
            int cellcount = 0;//盘电芯个数
            Dictionary<int, Dish> dcds;//一箱

            string strBarcode = "";

            while (true)
            {
                Thread.Sleep(10);

                if (GloVar.scaner_cell.isConnected == false)
                {
                    string msg;
                    GloVar.scaner_cell.Conn(out msg);

                    if (GloVar.scaner_cell.isConnected == true)
                    {
                        ShowLog("电芯扫码枪连接成功");
                    }
                    else
                    {
                        ShowLog("电芯扫码枪连接失败");
                        Thread.Sleep(3000);
                        continue;
                    }
                }
                try
                {
                    if (GloVar.运行状态 == GloVar.enSysStatus.运行)
                    {
                        switch (GloVar.扫码流程1)
                        {
                            case 0:
                                if (GloVar.PLC_Rread[(int)GloVar.enReadPLC2900.扫码1触发] > communID)
                                {
                                    id = GloVar.PLC_Rread[(int)GloVar.enReadPLC2900.扫码1触发];

                                    ShowScanBox(1, null, true);
                                    GloVar.扫码流程1 = 20;
                                    ShowLog("位置1扫码触发");
                                }
                                break;

                            case 20://读码

                                //读取条码
                                bool mcode = false;
                                int n = 0;
                                label1:
                                string errMsg;
                                strBarcode = GloVar.scaner_cell.Scan_Trig(out errMsg);
                                strBarcode = strBarcode.Trim().Replace("\r", "");
                                if (strBarcode.Contains("ERROR") && n < 3)
                                {
                                    Thread.Sleep(20);
                                    n++;
                                    goto label1;
                                }
                                //判断是否有扫不到的，如果没有就存在list集合中备用
                                if (strBarcode.Contains("ERROR"))
                                {
                                    GloVar.ProductCount.总投入 += 1;
                                    GloVar.ProductCount.扫码不良 += 1;
                                    GloVar.ProductCount.SaveCount(GloVar.path_productcount);//生产过程统计信息记录txt

                                    string[] readStr = strBarcode.Split(',');

                                    tmpSNs.Clear();

                                    for (int i = 0; i < readStr.Length; i++)
                                    {
                                        tmpSNs.Add(readStr[i]);

                                        if (readStr[i] == "ERROR")
                                        {
                                            errMsg += "电芯" + (i + 1) + "NG ";
                                        }
                                    }
                                    ShowScanBox(1, tmpSNs, false);//展示扫码结果在页面上
                                    ShowLog("扫码1超时:" + errMsg);
                                    GloVar.扫码流程1 = 100;
                                    break;
                                }
                                else
                                {
                                    cellcount = GloVar.CellCountOnePlate;//一盘电芯数量
                                    string[] readStr = strBarcode.Split(',');
                                    //判断喷码规则
                                    if (SysFunction.get_Param((int)GloVar.enSystemParam.是否上传MES) == "TRUE")
                                    {

                                        for (int i = 0; i < readStr.Length; i++)
                                        {
                                            if (readStr[i].Length > 8)
                                            {
                                                if (GloVar.makecode == "数字")
                                                {
                                                    if (!(readStr[i][7] >= '0' && readStr[i][7] <= '9'))
                                                    {
                                                        mcode = true;
                                                        ShowMakecode(1, readStr, GloVar.makecode, false);
                                                        MessageBox.Show("本地选择的喷码规则与电芯实际喷码规则不一致");
                                                        break;
                                                    }
                                                }
                                                else
                                                {
                                                    if (readStr[i][7] >= '0' && readStr[i][7] <= '9')
                                                    {
                                                        mcode = true;
                                                        ShowMakecode(1, readStr, GloVar.makecode, false);
                                                        MessageBox.Show("本地选择的喷码规则与电芯实际喷码规则不一致");
                                                        break;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                mcode = true;
                                            }
                                        }
                                        if (mcode)
                                        {
                                            GloVar.PLC_Write[(int)GloVar.enWritePLC3000.扫码1响应] = 12;
                                            GloVar.扫码流程1 = 30;
                                            GloVar.运行状态 = GloVar.enSysStatus.暂停;
                                            break;
                                        }
                                    }
                                    GloVar.ProductCount.总投入 += readStr.Length;
                                    GloVar.ProductCount.SaveCount(GloVar.path_productcount);

                                    dish = new Dish();//一盘
                                    dccell = new Dictionary<int, Cell>();//一盘电芯，位置+编码
                                    list_barcode.Clear();

                                    for (int i = 0; i < readStr.Length; i++)
                                    {
                                        list_barcode.Add(readStr[i]);
                                        Cell cell = new Cell();
                                        cell.barcode = readStr[i];
                                        dccell.Add(i + 1, cell);           //一盘电芯键是从1开始
                                    }
                                    dish.dishcellcount = cellcount;
                                    dish.dcdish = dccell;//至此生成一盘完整电芯数据

                                    //组别判断
                                    if (SysFunction.get_Param((int)GloVar.enSystemParam.是否上传MES) == "TRUE" && dc_Allbox[id].isgroup == "0")
                                    {
                                        for (int i = 0; i < readStr.Length; i++)
                                        {
                                            string msg = "";
                                            string nowgroup = mes.GetGroup(readStr[i], ref msg);
                                            nowgroup = nowgroup.Replace(",", "");
                                            if (!dc_Allbox[id].lsgroup.Contains(nowgroup))
                                            {
                                                if (dc_Allbox[id].lsgroup.Count.ToString() == dc_Allbox[id].groupcount)
                                                {
                                                    mcode = true;
                                                    ShowGroup(i + 1, readStr[i]);
                                                    ShowLog("电芯：" + readStr[i] + " 不在这个组别");
                                                }
                                                else
                                                {
                                                    dc_Allbox[id].lsgroup.Add(nowgroup);
                                                    dish.dcdish[i + 1].group = nowgroup;
                                                    txt_cellgroup.Invoke((Action)(() => { txt_cellgroup.Text += "," + nowgroup; }));
                                                }
                                            }
                                        }
                                    }
                                    if (mcode)
                                    {
                                        GloVar.PLC_Write[(int)GloVar.enWritePLC3000.扫码1响应] = 12;
                                        GloVar.扫码流程1 = 30;
                                        GloVar.运行状态 = GloVar.enSysStatus.暂停;
                                        break;
                                    }
                                    //绑箱
                                    if (SysFunction.get_Param((int)GloVar.enSystemParam.是否上传MES) == "TRUE")
                                    {
                                        string strSN = "";
                                        string msg = "";
                                        int nindex = index;
                                        string filename = DateTime.Now.ToString("yyyy-MM-dd") + "_MES.txt";
                                        for (int i = 0; i < readStr.Length; i++)//所有盘
                                        {
                                            //bohaishineihai,yejiushishuo
                                            PackCell2Box2_push pack_push = new PackCell2Box2_push();
                                            pack_push.BoxSn = dc_Allbox[id].Mes_id;
                                            pack_push.ProductSn = readStr[i];
                                            pack_push.Seq = nindex++.ToString();
                                            pack_push.Qty = "1";
                                            pack_push.OperatorId = GloVar.OperatorId;
                                            pack_push.TimeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                                            strSN += JsonHandler.SerializeObject(pack_push) + ",";

                                        }
                                        strSN = strSN.Remove(strSN.Length - 1);
                                        string res = "";
                                        try
                                        {
                                            string jsonData = "jsonData=[" + strSN + "]";
                                            SysFunction.SaveLog(filename, "电芯绑箱请求  "+ SysFunction.get_Param((int)GloVar.enSystemParam.电芯绑箱接口), jsonData);
                                             res = mes.HttpPost(SysFunction.get_Param((int)GloVar.enSystemParam.电芯绑箱接口), jsonData);
                                            SysFunction.SaveLog(filename, "电芯绑箱返回  "+ SysFunction.get_Param((int)GloVar.enSystemParam.电芯绑箱接口), res);
                                            PackCell2Box2_back mi = JsonConvert.DeserializeObject<PackCell2Box2_back>(res);
                                            if (mi.status == "true")
                                            {
                                                ShowLog("绑箱成功：" + res);
                                                index = nindex;
                                            }
                                            else
                                            {
                                                GloVar.电芯上传流程 = 0;                     //绑箱失败
                                                ShowLog("绑箱失败：" + res);
                                                GloVar.PLC_Write[(int)GloVar.enWritePLC3000.扫码1响应] = 12;
                                                GloVar.扫码流程1 = 30;
                                                GloVar.运行状态 = GloVar.enSysStatus.暂停;
                                                break;

                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            SysFunction.SaveLog(filename, "电芯绑箱异常", ex.ToString());
                                            ShowLog("绑箱失败：" + res);
                                            GloVar.PLC_Write[(int)GloVar.enWritePLC3000.扫码2响应] = 12;
                                            GloVar.扫码流程2 = 30;
                                            GloVar.运行状态 = GloVar.enSysStatus.暂停;
                                            break;
                                        }
                                        ShowLog("电芯绑箱成功");
                                    }


                                    for (int i = 0; i < readStr.Length; i++)
                                    {
                                        if (dish.dcdish[i + 1].group=="NO")
                                        {
                                            string msg = "";
                                            string nowgroup = mes.GetGroup(readStr[i], ref msg);
                                            nowgroup = nowgroup.Replace(",", "");
                                            dish.dcdish[i + 1].group = nowgroup;
                                        }
                                    }


                                    dcds = new Dictionary<int, Dish>();//开始装箱
                                    dcds = dc_Allbox[id].dcbox;//拿出正在装的箱，继续装
                                    dcds.Add(dcds.Count + 1, dish);//每箱电芯键也是从1开始
                                    dc_Allbox[id].dcbox = dcds;//装箱完毕，赋值给原来箱子

                                    tx_movePlate.Text = dc_Allbox[id].dcbox.Count().ToString();//已装完盘数
                                    GloVar.PLC_Write[(int)GloVar.enWritePLC3000.扫码1响应] = 11;

                                    ShowScanBox(1, list_barcode, false);
                                    GloVar.扫码流程1 = 30;
                                    ShowLog("扫码1完成,待PLC处理" + strBarcode);
                                    break;
                                }

                            case 100://扫码异常
                                GloVar.PLC_Write[(int)GloVar.enWritePLC3000.扫码1响应] = 12;
                                GloVar.扫码流程1 = 30;
                                break;

                            case 30:

                                if (GloVar.PLC_Rread[(int)GloVar.enReadPLC2900.扫码1触发] == 10)
                                {
                                    ShowLog("扫码1交互完成");
                                    GloVar.PLC_Write[(int)GloVar.enWritePLC3000.扫码1响应] = 10;
                                    GloVar.扫码流程1 = 0;
                                }
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    ShowLog("扫码1异常," + ex.Message);

                    Thread.Sleep(3000);
                }
            }
        }

        #endregion

        #region 电池扫码2线程
        //流程：拿到箱子--拿到盘-继续装-放回盘-放回箱
        private void Task_ScanCell2()
        {
            short id = 0;//触发id
            Dish dish;//盘
            Dictionary<int, Cell> dccell;//盘电芯
            int cellcount = 0;//盘电芯个数
            Dictionary<int, Dish> dcds;//一箱
            string strBarcode = "";

            while (true)
            {
                Thread.Sleep(10);

                if (GloVar.scaner_cell.isConnected == false)
                {
                    Thread.Sleep(1000);
                    continue;
                }
                try
                {
                    if (GloVar.运行状态 == GloVar.enSysStatus.运行)
                    {
                        switch (GloVar.扫码流程2)
                        {
                            case 0:
                                if (GloVar.PLC_Rread[(int)GloVar.enReadPLC2900.扫码2触发] > communID)
                                {
                                    id = GloVar.PLC_Rread[(int)GloVar.enReadPLC2900.扫码2触发];
                                    GloVar.扫码流程2 = 20;
                                    //list_barcode.Clear();
                                    ShowLog("位置2扫码触发");
                                    break;
                                }
                                break;

                            case 20://读码
                                bool mcode = false;
                                int n = 0;
                                label1:
                                string msg;
                                strBarcode = GloVar.scaner_cell.Scan_Trig(out msg);
                                strBarcode = strBarcode.Trim().Replace("\r", "");
                                if (strBarcode.Contains("ERROR") && n < 3)
                                {
                                    Thread.Sleep(20);
                                    n++;
                                    goto label1;
                                }

                                if (strBarcode.Contains("ERROR"))
                                {
                                    GloVar.ProductCount.总投入 += 1;
                                    GloVar.ProductCount.扫码不良 += 1;
                                    GloVar.ProductCount.SaveCount(GloVar.path_productcount);

                                    string[] readStr = strBarcode.Split(',');//不确定扫不到码的是""还是ERROR,可能要判断是不是有""（空）和数量

                                    //List<string> tmpSNs = new List<string>();
                                    tmpSNs.Clear();
                                    string errMsg = "";
                                    for (int i = 0; i < readStr.Length; i++)
                                    {
                                        tmpSNs.Add(readStr[i]);
                                        if (readStr[i] == "ERROR")
                                        {
                                            errMsg += "电芯" + (i + 5) + "NG ";
                                        }
                                    }
                                    ShowScanBox(5, tmpSNs, false);
                                    ShowLog("扫码2超时:" + errMsg);
                                    GloVar.扫码流程2 = 100;
                                    break;
                                }
                                else
                                {
                                    cellcount = GloVar.CellCountOnePlate;//一盘电芯数量
                                    string[] readStr = strBarcode.Split(',');
                                    //判断喷码规则
                                    if (SysFunction.get_Param((int)GloVar.enSystemParam.是否上传MES) == "TRUE")
                                    {

                                        for (int i = 0; i < readStr.Length; i++)
                                        {
                                            if (readStr[i].Length > 8)
                                            {
                                                if (GloVar.makecode == "数字")
                                                {
                                                    if (!(readStr[i][7] >= '0' && readStr[i][7] <= '9'))
                                                    {
                                                        mcode = true;
                                                        ShowMakecode(5, readStr, GloVar.makecode, false);
                                                        MessageBox.Show("本地选择的喷码规则与电芯实际喷码规则不一致");
                                                        break;
                                                    }
                                                }
                                                else
                                                {
                                                    if (readStr[i][7] >= '0' && readStr[i][7] <= '9')
                                                    {
                                                        mcode = true;
                                                        ShowMakecode(5, readStr, GloVar.makecode, false);
                                                        MessageBox.Show("本地选择的喷码规则与电芯实际喷码规则不一致");
                                                        break;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                mcode = true;
                                            }
                                        }
                                        if (mcode)
                                        {
                                            GloVar.PLC_Write[(int)GloVar.enWritePLC3000.扫码2响应] = 12;
                                            GloVar.扫码流程2 = 30;
                                            GloVar.运行状态 = GloVar.enSysStatus.暂停;
                                            break;
                                        }
                                    }
                                    GloVar.ProductCount.总投入 += readStr.Length;
                                    GloVar.ProductCount.SaveCount(GloVar.path_productcount);


                                    //
                                    string resCatch = "";
                                    dynamic mesres = "";
                                    if (SysFunction.get_Param((int)GloVar.enSystemParam.是否上传MES) == "TRUE" && dc_Allbox[id].isgroup == "0")
                                    {
                                        for (int i = 0; i < readStr.Length; i++)
                                        {

                                            string nowgroup = mes.GetGroup(readStr[i], ref msg);
                                            nowgroup = nowgroup.Replace(",", "");
                                            if (!dc_Allbox[id].lsgroup.Contains(nowgroup))
                                            {
                                                if (dc_Allbox[id].lsgroup.Count.ToString() == dc_Allbox[id].groupcount)
                                                {
                                                    mcode = true;
                                                    ShowGroup(i + 5, readStr[i]);
                                                    ShowLog("电芯：" + readStr[i] + " 不在这个组别");
                                                }
                                                else
                                                {
                                                    dc_Allbox[id].lsgroup.Add(nowgroup);
                                                    txt_cellgroup.Invoke((Action)(() => { txt_cellgroup.Text += "," + nowgroup; }));
                                                }
                                            }
                                        }
                                    }
                                    if (mcode)
                                    {
                                        GloVar.PLC_Write[(int)GloVar.enWritePLC3000.扫码2响应] = 12;
                                        GloVar.扫码流程2 = 30;
                                        GloVar.运行状态 = GloVar.enSysStatus.暂停;
                                        break;
                                    }

                                    //绑箱
                                    if (SysFunction.get_Param((int)GloVar.enSystemParam.是否上传MES) == "TRUE")
                                    {
                                        string strSN2 = "";
                                        string msg2 = "";
                                        int nindex = index;
                                        string filename = DateTime.Now.ToString("yyyy-MM-dd") + "_MES.txt";
                                        for (int i = 0; i < readStr.Length; i++)//所有盘
                                        {

                                            PackCell2Box2_push pack_push = new PackCell2Box2_push();
                                            pack_push.BoxSn = dc_Allbox[id].Mes_id;
                                            pack_push.ProductSn = readStr[i];
                                            pack_push.Seq = nindex++.ToString();
                                            pack_push.Qty = "1";
                                            pack_push.OperatorId = GloVar.OperatorId;
                                            pack_push.TimeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                                            strSN2 += JsonHandler.SerializeObject(pack_push) + ",";

                                        }
                                        strSN2 = strSN2.Remove(strSN2.Length - 1);
                                        string res = "";
                                        try
                                        {
                                            string jsonData = "jsonData=[" + strSN2 + "]";
                                            SysFunction.SaveLog(filename, "电芯绑箱请求  "+ SysFunction.get_Param((int)GloVar.enSystemParam.电芯绑箱接口), jsonData);
                                             res = mes.HttpPost(SysFunction.get_Param((int)GloVar.enSystemParam.电芯绑箱接口), jsonData);
                                            SysFunction.SaveLog(filename, "电芯绑箱返回  "+ SysFunction.get_Param((int)GloVar.enSystemParam.电芯绑箱接口), res);
                                            PackCell2Box2_back mi = JsonConvert.DeserializeObject<PackCell2Box2_back>(res);
                                            if (mi.status == "true")
                                            {
                                                ShowLog("绑箱成功：" + res);
                                                index = nindex;
                                            }
                                            else
                                            {
                                                GloVar.电芯上传流程 = 0;                     //绑箱失败
                                                ShowLog("绑箱失败：" + res);
                                                GloVar.PLC_Write[(int)GloVar.enWritePLC3000.扫码2响应] = 12;
                                                GloVar.扫码流程2 = 30;
                                                GloVar.运行状态 = GloVar.enSysStatus.暂停;
                                                break;

                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            SysFunction.SaveLog(filename, "电芯绑箱异常", ex.ToString());
                                            ShowLog("绑箱失败：" + res);
                                            GloVar.PLC_Write[(int)GloVar.enWritePLC3000.扫码2响应] = 12;
                                            GloVar.扫码流程2 = 30;
                                            GloVar.运行状态 = GloVar.enSysStatus.暂停;
                                            break;
                                        }
                                        ShowLog("电芯绑箱成功");
                                    }

                                    dcds = new Dictionary<int, Dish>();//开始取箱
                                    dcds = dc_Allbox[id].dcbox;//拿出正在装的箱，继续装

                                    dish = new Dish();//一盘
                                    dish = dcds[dcds.Count];
                                    dccell = new Dictionary<int, Cell>();//一盘电芯，位置+编码
                                    dccell = dish.dcdish;//拿到还没装完的一盘
                                    string strSN = "";//校验电芯编码
                                    foreach (string item in list_barcode) strSN += item;
                                    for (int i = 0; i < readStr.Length; i++)
                                    {

                                        strSN += readStr[i];
                                        list_barcode.Add(readStr[i]);
                                        Cell cell = new Cell();
                                        cell.barcode = readStr[i];
                                        string sg = mes.GetGroup(readStr[i], ref resCatch);
                                        sg = sg.Replace(",", "");
                                        if (sg == "") sg = "NO";
                                        cell.group = sg;
                                        dccell.Add(dccell.Count + 1, cell);       //-------i改成dccell .Count  
                                    }

                                    #region 装箱过程可以屏蔽，因为上面已经拿到地址，在地址上已经装好了
                                    dish.dishcellcount = cellcount;
                                    dish.dcdish = dccell;//至此生成一盘完整电芯数据
                                    //
                                    //dcds.Add(dcds.Count + 1, dish);//装盘           //------改成dcds[dcds.Count] = dish;
                                    dcds[dcds.Count] = dish;
                                    dc_Allbox[id].dcbox = dcds;//装箱完毕，赋值给原来箱子。
                                    #endregion  装箱过程
                                    tx_movePlate.Text = dc_Allbox[id].dcbox.Count().ToString();//已装完盘数
                                    GloVar.PLC_Write[(int)GloVar.enWritePLC3000.扫码2响应] = 11;      //-------id改11

                                    ShowScanBox(1, list_barcode, false);
                                    GloVar.扫码流程2 = 30;
                                    ShowLog("扫码2完成,待PLC处理" + strBarcode);
                                    break;
                                }

                            case 100:
                                GloVar.PLC_Write[(int)GloVar.enWritePLC3000.扫码2响应] = 12;
                                GloVar.扫码流程2 = 30;
                                break;
                            case 30:

                                if (GloVar.PLC_Rread[(int)GloVar.enReadPLC2900.扫码2触发] == 10)
                                {
                                    ShowLog("扫码2交互完成");
                                    GloVar.PLC_Write[(int)GloVar.enWritePLC3000.扫码2响应] = 10;
                                    GloVar.扫码流程2 = 0;
                                }
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    ShowLog("扫码2异常," + ex.Message);

                    Thread.Sleep(3000);
                }
            }
        }
        #endregion

        #region 电池扫码完成上传绑箱线程

        private void Task_UpdateCells()
        {
            int ID = 0;
            Box box;
            Dish dish;
            bool writeErr = false;
            string strSN = "";
            string resCatch = "";   //MES的异常信息，用来判断MES是否正常返回数据
            PackCell2Box2_push pack_push = new PackCell2Box2_push();   //绑箱输入
            List<string> lsbar = new List<string>();      //条码
            List<string> lsgrou = new List<string>();      //组别
            while (true)
            {
                try
                {
                    switch (GloVar.电芯上传流程)
                    {
                        case 0:
                            if (GloVar.PLC_Rread[(int)GloVar.enReadPLC2900.称重触发] < communID || updata == false)
                            {
                                break;
                            }

                            //一箱所有编码
                            strSN = "";
                            ID = GloVar.PLC_Rread[(int)GloVar.enReadPLC2900.称重触发];
                            box = dc_Allbox[ID];//箱
                            lsbar.Clear();
                            lsgrou.Clear();
                            int seq = 1;
                            foreach (KeyValuePair<int, Dish> boxitem in box.dcbox)//所有盘
                            {
                                dish = new Dish();
                                dish = boxitem.Value;//当前盘
                                for (int i = 1; i < dish.dcdish.Count + 1; i++)
                                {
                                    pack_push = new PackCell2Box2_push();
                                    pack_push.BoxSn = box.Mes_id;
                                    pack_push.ProductSn = dish.dcdish[i].barcode;
                                    pack_push.Seq = seq++.ToString();
                                    pack_push.Qty = "1";
                                    pack_push.OperatorId = GloVar.OperatorId;
                                    pack_push.TimeStamp = DateTime.Now.ToString();

                                    strSN += JsonHandler.SerializeObject(pack_push) + ",";
                                    lsbar.Add(dish.dcdish[i].barcode);
                                    lsgrou.Add(dish.dcdish[i].group);
                                }
                            }
                            strSN = strSN.Remove(strSN.Length - 1);
                            ShowLog("电芯上传流程触发");
                            if (SysFunction.get_Param((int)GloVar.enSystemParam.是否上传MES).ToUpper() == "FALSE")
                            {
                                ID = GloVar.PLC_Rread[(int)GloVar.enReadPLC2900.称重触发];
                                string sql = "insert into scancz02(Time,Barcode,BoxSN,Groupp,OperID,Checker) values";
                                foreach (KeyValuePair<int, Dish> boxitem in dc_Allbox[ID].dcbox)//遍历一箱
                                {
                                    for (int i = 1; i < boxitem.Value.dcdish.Count + 1; i++)//遍历一盘
                                    {
                                        string strValue = boxitem.Value.dcdish[i].barcode + "," + ID + "," + SysFunction.get_Param((int)GloVar.enSystemParam.扫码人) + "," + SysFunction.get_Param((int)GloVar.enSystemParam.检查人);
                                        GloVar.filehelper.SaveUpdataCellCSV(GloVar.dic_productOK, "电池保存csvOK记录", strValue);
                                        sql += "('" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "','" + boxitem.Value.dcdish[i].barcode + "','" + ID + "','NO','0','OK'),";
                                    }
                                }
                                sql = sql.Remove(sql.Length - 1);
                                SqlHelper.InsertSQLAll(sql);
                                List<string> lstem = new List<string>();
                                ShowCellToMainTable(lsbar, 0, "", lstem);
                                //ShowCellToMainTable(lsbar, ++GloVar.NowUpdataCellCount, "");//界面显示内容
                                ShowLog("电池保存完成");
                                updata = false;
                                //asdf
                                GloVar.电芯上传流程 = 0;
                                break;
                            }
                            else  //更新箱子状态
                            {

                                if (mes.UpdatePackStatus(box.Mes_id, ref resCatch))
                                {
                                    ShowLog("MES箱子状态更新成功: " + resCatch);
                                }
                                else
                                {
                                    GloVar.电芯上传流程 = 0;
                                    GloVar.PLC_Write[(int)GloVar.enWritePLC3000.称重响应] = 13;
                                    ShowLog("MES箱子状态更新失败: " + resCatch);
                                    GloVar.运行状态 = GloVar.enSysStatus.暂停;
                                    break;
                                }
                                string sql = "insert into scancz02(Time,Barcode,BoxSN,Groupp,OperID,Checker) values";
                                for (int i = 0; i < lsbar.Count; i++)//20220102添加保存数据库
                                {
                                    string strValue = lsbar[i] + "," + box.Mes_id + "," + SysFunction.get_Param((int)GloVar.enSystemParam.扫码人) + "," + SysFunction.get_Param((int)GloVar.enSystemParam.检查人);
                                    GloVar.filehelper.SaveUpdataCellCSV(GloVar.dic_productOK, "电池保存csvOK记录", strValue);
                                    //string mesgroup = mes.GetGroup(lsbar[i],ref resCatch);
                                    sql += "('" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "','" + lsbar[i] + "','" + box.Mes_id + "','" + lsgrou[i] + "','" + SysFunction.get_Param((int)GloVar.enSystemParam.扫码人) + "','" + SysFunction.get_Param((int)GloVar.enSystemParam.检查人) + "'),";

                                }
                                sql = sql.Remove(sql.Length - 1);
                                SqlHelper.InsertSQLAll(sql);
                                ShowCellToMainTable(lsbar, 0, box.Mes_id, lsgrou);
                                GloVar.电芯上传流程 = 80;
                                updata = false;
                                break;
                            }
                        case 80:
                            GloVar.电芯上传流程 = 0;
                            ShowLog("电芯上传流程交互完成");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    if (writeErr == false)
                    {
                        writeErr = true;
                        ShowLog("电池上传异常：" + ex.Message);

                        //if (GloVar.PLC_Rread[(int)GloVar.enReadPLC2900.扫码上传触发] == 11)
                        //{               
                        GloVar.PLC_Write[(int)GloVar.enWritePLC3000.称重响应] = 13;
                        GloVar.电芯上传流程 = 80;
                        //}
                    }

                    Thread.Sleep(2000);
                }

                Thread.Sleep(10);
            }
        }
        #endregion


        #region 称重线程

        private void Task_Weight()
        {
            int id = 0;
            bool writeErr = false;
            double allWeight = 0;
            while (true)
            {
                try
                {
                    if (GloVar.运行状态 == GloVar.enSysStatus.运行)
                    {

                        string msg = "";
                        switch (GloVar.称重流程)
                        {
                            case GloVar.enWeightStep.准备称重:
                                if (GloVar.PLC_Rread[(int)GloVar.enReadPLC2900.称重触发] > communID)
                                {
                                    id = GloVar.PLC_Rread[(int)GloVar.enReadPLC2900.称重触发];
                                    ShowLog("称重触发");
                                    updata = true;
                                    GloVar.称重流程 = GloVar.enWeightStep.开始称重;
                                    break;
                                }
                                break;

                            case GloVar.enWeightStep.开始称重:
                                while (updata) {; }//如果还没绑箱上传完就一直在这等
                                try
                                {
                                    if (dc_Allbox[id].dcbox.Count < 1)//箱子里面盘数<1
                                    {
                                        GloVar.PLC_Write[(int)GloVar.enWritePLC3000.称重响应] = 12;

                                        ShowLog("待称重箱号为空箱，此触发信号无法处理");
                                        GloVar.称重流程 = GloVar.enWeightStep.称重结束;
                                        break;
                                    }
                                    Thread.Sleep(2000);
                                    if (!GloVar.serialPort_weight.IsOpen) GloVar.serialPort_weight.Open();
                                    GloVar.serialPort_weight.DiscardInBuffer();
                                    GloVar.serialPort_weight.Write("RW" + "\r\n");
                                    Thread.Sleep(500);
                                    string weightRes = GloVar.serialPort_weight.ReadExisting();//实际称重结果
                                    GloVar.serialPort_weight.Close();

                                    int kg_index = weightRes.IndexOf("kg");
                                    string sd = "";
                                    for (int i = 0; i < weightRes.Length; i++)
                                    {
                                        if (weightRes[i] >= '0' && weightRes[i] <= '9')
                                        {
                                            for (int j = i; j < kg_index; j++)
                                            {
                                                sd += weightRes[j];
                                            }
                                            break;
                                        }
                                    }
                                    double d = Convert.ToDouble(sd);
                                    //if (weightRes.Contains("NT"))
                                    //{
                                    //    int NT = weightRes.IndexOf("NT", 0);
                                    //    if (weightRes.Substring(NT + 3, 1) == "+")
                                    //    {
                                    //        allWeight = Double.Parse(weightRes.Substring(NT + 4, 7)) * 1000;
                                    //    }
                                    //}
                                    //else if (weightRes.Contains("ST,TR") || weightRes.Contains("US,TR"))
                                    //{
                                    //    string[] st2 = weightRes.Split(' ');
                                    //    allWeight = Convert.ToDouble(st2[2].Remove(st2[2].Length - 4));
                                    //}
                                    allWeight = d;
                                    /////**********************判断重量是否合格
                                    if (SysFunction.get_Param((int)GloVar.enSystemParam.是否上传MES) == "TRUE")
                                    {

                                        if (dc_Allbox[id].weightup != "" && dc_Allbox[id].weightdown != "")
                                        {
                                            double weiup = Convert.ToDouble(dc_Allbox[id].weightup);
                                            double weidown = Convert.ToDouble(dc_Allbox[id].weightdown);
                                            if (allWeight >= weidown && allWeight <= weiup)
                                            {
                                                GloVar.称重流程 = GloVar.enWeightStep.记录称重数据接口;
                                                break;
                                            }
                                            else
                                            {
                                                ShowLog("重量不在范围："+allWeight+"g");
                                                GloVar.PLC_Write[(int)GloVar.enWritePLC3000.称重响应] = 13;
                                                GloVar.称重流程 = GloVar.enWeightStep.准备称重;
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            ShowLog("未获取重量上下限");
                                        }
                                    }
                                    tx_boxWeihingSN.Text = dc_Allbox[id].Mes_id;
                                }
                                catch (Exception ex)
                                {
                                    ShowLog("称重异常" + ex.Message);
                                }
                                //没有MES就直接结束
                                string txt = "insert into weight01(time,boxsn,netweight,totalweight,sanner,checker,info) values('" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "','" + dc_Allbox[id].Mes_id + "','" + "0" + "','" + "0" + "','" + SysFunction.get_Param((int)GloVar.enSystemParam.扫码人) + "','" + SysFunction.get_Param((int)GloVar.enSystemParam.检查人) + "','" + "0" + "')";
                                SqlHelper.InsertSQLData(txt);
                                ShowLog("ID:" + id.ToString() + " 箱子重量本地保存成功");
                                dc_Allbox.Remove(id);//移除箱子
                                GloVar.PLC_Write[(int)GloVar.enWritePLC3000.称重响应] = 11;
                                GloVar.称重流程 = GloVar.enWeightStep.称重结束;
                                break;

                            case GloVar.enWeightStep.记录称重数据接口:
                                if (mes.FinishPackBox(allWeight.ToString(), dc_Allbox[id].Mes_id, ref msg))
                                {
                                    ShowLog("MES称重上传成功：" + msg);
                                    GloVar.称重流程 = GloVar.enWeightStep.记录打印信息接口;
                                }
                                else
                                {
                                    ShowLog("MES记录称重数据失败：" + msg);
                                    GloVar.运行状态 = GloVar.enSysStatus.暂停;
                                    GloVar.称重流程 = GloVar.enWeightStep.称重结束;
                                }
                                break;

                            case GloVar.enWeightStep.记录打印信息接口:
                                if (mes.RecordPrintTimes(dc_Allbox[id].Mes_id, ref msg))
                                {
                                    try { GloVar.NeedWeightBoxSnList.Remove(dc_Allbox[id].Mes_id); } catch { }
                                    ShowLog("MES记录打印信息成功：" + msg);
                                    GloVar.称重流程 = GloVar.enWeightStep.打印箱号标签接口;
                                }
                                else
                                {
                                    ShowLog("MES记录打印信息失败:" + msg);
                                    GloVar.运行状态 = GloVar.enSysStatus.暂停;
                                    GloVar.称重流程 = GloVar.enWeightStep.称重结束;
                                }
                                break;

                            case GloVar.enWeightStep.打印箱号标签接口:
                                if (mes.printProductSn(dc_Allbox[id].Mes_id, ref msg))
                                {
                                    string txt2 = "insert into weight01(time,boxsn,netweight,totalweight,sanner,checker,info) values('" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "','" + dc_Allbox[id].Mes_id + "','" + "0" + "','" + "0" + "','" + SysFunction.get_Param((int)GloVar.enSystemParam.扫码人) + "','" + SysFunction.get_Param((int)GloVar.enSystemParam.检查人) + "','" + "0" + "')";
                                    SqlHelper.InsertSQLData(txt2);
                                    ShowLog("boxSn:" + dc_Allbox[id].Mes_id + " 箱子重量上传和保存成功");
                                    dc_Allbox.Remove(id);//移除箱子
                                    GloVar.PLC_Write[(int)GloVar.enWritePLC3000.称重响应] = 11;
                                    GloVar.称重流程 = GloVar.enWeightStep.称重结束;
                                }
                                else
                                {
                                    ShowLog("MES记录打印信息失败: " + msg);
                                    GloVar.运行状态 = GloVar.enSysStatus.暂停;
                                    GloVar.称重流程 = GloVar.enWeightStep.称重结束;
                                }
                                break;
                            case GloVar.enWeightStep.称重结束:

                                if (GloVar.PLC_Rread[(int)GloVar.enReadPLC2900.称重触发] == 10)
                                {
                                    GloVar.PLC_Write[(int)GloVar.enWritePLC3000.称重响应] = 10;
                                    GloVar.称重流程 = GloVar.enWeightStep.准备称重;
                                    ShowLog("称重交互结束");
                                }
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (GloVar.PLC_Rread[(int)GloVar.enReadPLC2900.称重触发] == 11)
                    {
                        ShowLog("称重上传异常" + ex.Message);
                        GloVar.PLC_Write[(int)GloVar.enWritePLC3000.称重响应] = 12;
                        GloVar.称重流程 = GloVar.enWeightStep.称重结束;
                    }
                    // it seem i can seehe in anywhere
                    if (writeErr == false)
                    {
                        writeErr = true;
                        string faileName = DateTime.Now.ToString("yyyy-MM-dd") + "_other.txt";
                        SysFunction.SaveLog(faileName, "称重上传异常", ex.Message);
                        ShowLog("称重上传异常" + ex.Message);
                    }
                }
                Thread.Sleep(10);
            }
        }
        #endregion

        #region 箱体扫码线程

        //获取箱体MI，在本地查询编码档位
        private void Task_ScanBox()
        {
            string strBarcode = "";
            int errcount = 0;
            while (true)
            {
                Thread.Sleep(10);
                if (SysFunction.get_Param((int)GloVar.enSystemParam.是否分档位) != "TRUE")
                    continue;

                if (GloVar.scaner_box.isConnected == false)
                {
                    string msg1;
                    GloVar.scaner_box.Conn(out msg1);

                    if (GloVar.scaner_box.isConnected == true)
                    {
                        ShowLog("箱体扫码枪连接成功");
                    }
                    else
                    {
                        ShowLog("箱体扫码枪连接失败");
                        Thread.Sleep(3000);
                        continue;
                    }
                }


                try
                {
                    if (GloVar.运行状态 == GloVar.enSysStatus.运行 && SysFunction.get_Param((int)GloVar.enSystemParam.是否分档位) == "TRUE")
                    {
                        switch (GloVar.箱体扫码流程)
                        {
                            case GloVar.enScanBoxStep.准备扫码:

                                if (GloVar.PLC_Rread[(int)GloVar.enReadPLC2900.分档扫码触发] == 11)
                                {
                                    //GloVar.PLC_Write[(int)GloVar.enWritePLC3000.分档结果响应] = 11;
                                    ShowLog("箱体分档扫码触发");
                                    GloVar.箱体扫码流程 = GloVar.enScanBoxStep.获取条码;
                                    Thread.Sleep(1000);

                                }
                                break;

                            case GloVar.enScanBoxStep.获取条码:


                                string msg = "";
                                string mino = "";
                                string msg2 = "";
                                strBarcode = GloVar.scaner_box.Scan_Trig(out msg2);
                                strBarcode = strBarcode.Trim().Replace("\r", "");
                                if (GloVar.scaner_box.isConnected == false)
                                {
                                    string msg1;
                                    GloVar.scaner_box.Conn(out msg1);
                                    Thread.Sleep(1500);
                                    strBarcode = GloVar.scaner_box.Scan_Trig(out msg2);
                                    strBarcode = strBarcode.Trim().Replace("\r", "");

                                }

                                if (strBarcode.Contains("#"))
                                {
                                    int subIndex = strBarcode.IndexOf('#');
                                    strBarcode = strBarcode.Substring(subIndex + 1);
                                }
                                if (strBarcode == "ERROR")
                                {
                                    GloVar.PLC_Write[(int)GloVar.enWritePLC3000.分档结果响应] = 13;
                                    ShowLog("箱体扫码结果为：" + strBarcode + "，扫码超时");
                                    GloVar.箱体扫码流程 = GloVar.enScanBoxStep.箱体扫码结束;
                                    break;
                                }
                                //判断档位
                                if (mes.GetPackageByPackNo(strBarcode, ref mino, ref msg))
                                {
                                    if (mino.Length > 4) { mino = mino.Remove(3); }
                                    if (mino == SysFunction.get_Param((int)GloVar.enSystemParam.档位1批次号))
                                    {
                                        GloVar.PLC_Write[(int)GloVar.enWritePLC3000.分档结果响应] = 11;
                                        ShowLog("箱体扫码结果为：" + strBarcode + "，档位结果为：档位1");
                                        GloVar.箱体扫码流程 = GloVar.enScanBoxStep.箱体扫码结束;
                                        break;
                                    }
                                    else if (mino == SysFunction.get_Param((int)GloVar.enSystemParam.档位2批次号))
                                    {
                                        GloVar.PLC_Write[(int)GloVar.enWritePLC3000.分档结果响应] = 12;
                                        ShowLog("箱体扫码结果为：" + strBarcode + "，档位结果为：档位2");
                                        GloVar.箱体扫码流程 = GloVar.enScanBoxStep.箱体扫码结束;
                                        break;
                                    }
                                    else
                                    {
                                        GloVar.PLC_Write[(int)GloVar.enWritePLC3000.分档结果响应] = 13;
                                        ShowLog("箱子档位设置有误，实际档位MI号为：" + mino);
                                        GloVar.箱体扫码流程 = GloVar.enScanBoxStep.箱体扫码结束;
                                        break;
                                    }
                                }
                                else
                                {
                                    ShowLog("分档接口获取失败：" + msg);
                                    GloVar.PLC_Write[(int)GloVar.enWritePLC3000.分档结果响应] = 13;
                                    GloVar.箱体扫码流程 = GloVar.enScanBoxStep.箱体扫码结束;
                                    break;
                                }


                            case GloVar.enScanBoxStep.箱体扫码结束:
                                if (GloVar.PLC_Rread[(int)GloVar.enReadPLC2900.分档扫码触发] == 10)
                                {
                                    ShowLog("箱体扫码交互完成");
                                    GloVar.PLC_Write[(int)GloVar.enWritePLC3000.分档结果响应] = 10;
                                    GloVar.箱体扫码流程 = GloVar.enScanBoxStep.准备扫码;
                                }
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    string faileName = DateTime.Now.ToString("yyyy-MM-dd") + "_other.txt";
                    SysFunction.SaveLog(faileName, "箱体扫码异常", ex.Message);
                    ShowLog("箱体扫码上传异常" + ex.Message);
                    GloVar.箱体扫码流程 = GloVar.enScanBoxStep.准备扫码;
                    Thread.Sleep(2000);
                }
                Thread.Sleep(10);
            }
        }

        #endregion



        /// <summary>
        /// 显示扫码结果到groupbox里的控件
        /// </summary>
        /// <param name="starCount">开始的数</param>
        /// <param name="endCount">结束的位置(包含)</param>
        /// <param name="cellsn">电芯条码集合</param>
        /// <param name="isClear">是否为Catch,true的话就直接全红+显示为ERROR</param>
        private void ShowScanBox(int starCount, List<string> cellsn, bool isClear)
        {
            if (isClear)
            {
                for (int i = 1; i < 13; i++)
                {
                    gb_ScanShow.Controls["tx_SN" + i].Text = "";
                    gb_ScanShow.Controls["tx_SN" + i].BackColor = Color.Beige;
                }
            }
            else
            {
                for (int i = 0; i < cellsn.Count; i++)
                {
                    gb_ScanShow.Controls["tx_SN" + (starCount + i)].Text = cellsn[i];
                    if (cellsn[i] != "ERROR")
                    {
                        gb_ScanShow.Controls["tx_SN" + (starCount + i)].BackColor = Color.Beige;
                    }
                    else
                    {
                        gb_ScanShow.Controls["tx_SN" + (starCount + i)].BackColor = Color.Red;
                    }
                }
            }
        }
        private void ShowMakecode(int starCount, string[] cellsn, string makecode, bool isClear)
        {
            if (isClear)
            {
                for (int i = 1; i < 13; i++)
                {
                    gb_ScanShow.Controls["tx_SN" + i].Text = "";
                    gb_ScanShow.Controls["tx_SN" + i].BackColor = Color.Beige;
                }
            }
            else
            {
                for (int i = 0; i < cellsn.Length; i++)
                {
                    gb_ScanShow.Controls["tx_SN" + (starCount + i)].Text = cellsn[i];
                    if ((makecode == "数字" && cellsn[i][7] >= 0 && cellsn[i][7] <= 9) || (makecode == "字母" && cellsn[i][7] < 0 && cellsn[i][7] > 9))
                    {
                        gb_ScanShow.Controls["tx_SN" + (starCount + i)].BackColor = Color.Beige;
                    }
                    else
                    {
                        gb_ScanShow.Controls["tx_SN" + (starCount + i)].BackColor = Color.Red;
                    }
                }
            }
        }
        private void ShowGroup(int starCount, string cellsn)
        {
            gb_ScanShow.Controls["tx_SN" + (starCount + starCount)].Text = cellsn;
            gb_ScanShow.Controls["tx_SN" + (starCount + starCount)].BackColor = Color.Red;
        }
        //显示到界面
        private void ShowCellToMainTable(List<string> list_barcode, int nowUpdataCellCount, string nowUpdataBoxSN, List<string> list_group)
        {
            try
            {
                for (int i = 0; i < list_barcode.Count; i++)
                {
                    ListViewItem item = new ListViewItem();

                    item.Text = (1 + i).ToString();//直接显示数量不行吗
                    //item.Text = (nowUpdataCellCount - GloVar.CellCountOnePlate + 1 + i).ToString();
                    item.SubItems.Add(DateTime.Now.ToLongTimeString());
                    item.SubItems.Add(list_barcode[i]);
                    item.SubItems.Add(nowUpdataBoxSN);
                    if (list_group.Count < 1)
                    {
                        item.SubItems.Add("NO");
                    }
                    else
                    {
                        item.SubItems.Add(list_group[i]);
                    }

                    lv_productInfo.Items.Add(item);
                    if (this.lv_productInfo.Items.Count > 0)
                    {
                        int index = this.lv_productInfo.Items.Count - 1;
                        this.lv_productInfo.EnsureVisible(index);//列表视图滚动定位到指定索引项的选项行。
                    }

                    //定时清理
                    if (lv_productInfo.Items.Count > 200)
                    {
                        lv_productInfo.Items.RemoveAt(0);
                    }
                }
            }
            catch (Exception ex)
            {
                string faileName = DateTime.Now.ToString("yyyy-MM-dd") + "_other.txt";
                SysFunction.SaveLog(faileName, "显示结果异常", ex.ToString());
            }
        }

        object lock_Log = new object();
        //保存运行日志
        public void ShowLog(string text)
        {
            try
            {
                this.Invoke((Action)(() =>
                {
                    lock (lock_Log)
                    {
                        if (lv_log.Items.Count > 0)
                        {
                            if (lv_log.Items[lv_log.Items.Count - 1].SubItems[1].Text == text)
                            {
                                goto poin;
                            }
                        }

                        string filename = DateTime.Now.ToString("yyyy-MM-dd") + "_auto.txt";
                        SysFunction.SaveLog(filename, "自动程序", text);

                        //防止条目过多引起卡顿
                        if (this.lv_log.Items.Count >= 300)
                        {
                            this.lv_log.Items.RemoveAt(0);
                        }
                        ListViewItem item = new ListViewItem();
                        item.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        if (text == null) text = "";
                        item.SubItems.Add(text);
                        this.lv_log.Items.Add(item);

                        if (this.lv_log.Items.Count >= 1)
                        {
                            int index = this.lv_log.Items.Count - 1;
                            this.lv_log.EnsureVisible(index);
                        }
                        poin:;
                    }
                }));

            }
            catch (Exception ex)
            {
                string faileName = DateTime.Now.ToString("yyyy-MM-dd") + "_other.txt";
                SysFunction.SaveLog(faileName, "显示日志异常", ex.ToString());
            }

        }

        int mesLoginTime;  //MES定期登录时间
        int MangeLevelTime;//权限定期注销

        private void Timer1_Tick(object sender, EventArgs e)
        {
            //设置MES相关设置权限
            if (GloVar.isset)
            {
                splitContainer3.Enabled = true;
            }
            else
            {
                splitContainer3.Enabled = false;
            }
            string tmpStr = string.Empty;

            foreach (string item in GloVar.NeedWeightBoxSnList)
            {
                tmpStr = tmpStr + item + "\n";
            }
            if (rtxWeightBoxList.Text != tmpStr)
            {
                rtxWeightBoxList.Text = tmpStr;
            }

            #region 更新可拆箱号列表

            List<string> chaiXiangSNs = new List<string>();
            chaiXiangSNs.Clear();
            if (GloVar.NowUpdataBoxSN != "")
            {
                chaiXiangSNs.Add(GloVar.NowUpdataBoxSN + " :当前打包箱号");
            }

            for (int i = 0; i < GloVar.NeedWeightBoxSnList.Count; i++)
            {
                chaiXiangSNs.Add(GloVar.NeedWeightBoxSnList[i] + " :待称重箱号" + (i + 1));
            }


            if (chaiXiangSNs.Count == cbx_ChaiXiangBoxSN.Items.Count)
            {
                for (int i = 0; i < chaiXiangSNs.Count; i++)
                {
                    if (chaiXiangSNs[i] != cbx_ChaiXiangBoxSN.Items[i].ToString())
                    {
                        cbx_ChaiXiangBoxSN.Items.Clear();

                        foreach (var item in chaiXiangSNs)
                        {
                            cbx_ChaiXiangBoxSN.Items.Add(item);
                        }

                        break;
                    }
                }
            }
            else
            {
                cbx_ChaiXiangBoxSN.Items.Clear();

                foreach (var item in chaiXiangSNs)
                {
                    cbx_ChaiXiangBoxSN.Items.Add(item);
                }
            }

            #endregion


            if (SysFunction.get_Param((int)GloVar.enSystemParam.是否上传MES).ToUpper() == "TRUE")
            {
                mesLoginTime++;
                if (mesLoginTime > 10 * 60) //10分钟登录一次
                {
                    mesLoginTime = 0;
                    string mesRes = "";
                    mes.LoginDevice(GloVar.M_MACHINENO, GloVar.mes_UserName, GloVar.mes_MI, GloVar.mes_PassWord, ref mesRes);
                }
                this.cbx_room.Invoke(new Action(() =>
                {
                    cbx_room.Text = GloVar.dcroom;
                    cbx_MI.Text = GloVar.mes_MI;
                    cbx_makecode.Text = GloVar.makecode;
                    lb_online.Visible = false;
                    //tx_boxScanSN.Text = GloVar.NeedWeightBoxSnList[GloVar.NeedWeightBoxSnList.Count - 1];

                }));
            }
            else
            {
                lb_online.Visible = true;
                lb_online.BackColor = Color.Red;
            }

            if (GloVar.MangeLevel != "")
            {
                MangeLevelTime++;
                if (MangeLevelTime > 5 * 60) //10分钟注销一次
                {
                    MangeLevelTime = 0;
                    GloVar.MangeLevel = "";
                }
            }


            if (SysFunction.get_Param((int)GloVar.enSystemParam.是否分档位) == "TRUE")
            {
                label10.Visible = true;
                label9.Visible = true;

                txt_DangWei1Sn.Visible = true;
                txt_DangWei2Sn.Visible = true;
            }
            else
            {
                label10.Visible = false;
                label9.Visible = false;

                txt_DangWei1Sn.Visible = false;
                txt_DangWei2Sn.Visible = false;
            }

            if (GloVar.运行状态 == GloVar.enSysStatus.运行)
            {
                GloVar.isset = false;    //不允许设置MES相关项
                lblRunning.Visible = true;
                lblStoping.Visible = false;

                UserLogion_ToolStrip.Enabled = false;
                AdminLock_ToolStrip.Enabled = false;
                Set_ToolStrip.Enabled = false;
                系统参数设定ToolStripMenuItem.Enabled = false;
                配方设置ToolStripMenuItem.Enabled = false;
                cbx_room.Enabled = false;
                cbx_MI.Enabled = false;
                cbx_makecode.Enabled = false;
                //tx_MoNumber.Enabled = false;
                //tx_BatchNo.Enabled = false;
                //tx_OpenerID.Enabled = false;
                //tx_CheckerID.Enabled = false;
                //btn_SaveConfig.Enabled = false;
                bt_Init.Enabled = false;
                bt_Search.Enabled = false;
                bt_Delete.Enabled = false;
                bt_ScanHandTestStar.Enabled = false;
                bt_WeightHandTestStar.Enabled = false;

                txt_DangWei1Sn.Enabled = false;
                txt_DangWei2Sn.Enabled = false;
                txt_DangWei3Sn.Enabled = false;
            }
            else
            {

                if (dc_Allbox.Count == 0)
                {
                    GloVar.isset = true;
                }

                txt_DangWei1Sn.Enabled = true;
                txt_DangWei2Sn.Enabled = true;
                lblRunning.Visible = false;
                lblStoping.Visible = true;

                if (GloVar.MangeLevel == "")
                {
                    UserLogion_ToolStrip.Enabled = true;
                    AdminLock_ToolStrip.Enabled = true;
                    Set_ToolStrip.Enabled = false;
                    系统参数设定ToolStripMenuItem.Enabled = false;
                    配方设置ToolStripMenuItem.Enabled = false;
                    cbx_room.Enabled = true;
                    cbx_MI.Enabled = true;
                    cbx_makecode.Enabled = true;
                    //tx_MoNumber.Enabled = false;
                    //tx_BatchNo.Enabled = false;
                    //tx_OpenerID.Enabled = false;
                    //tx_CheckerID.Enabled = false;
                    //btn_SaveConfig.Enabled = false;
                    bt_Init.Enabled = true;
                    bt_Search.Enabled = true;
                    bt_Delete.Enabled = false;
                    bt_ScanHandTestStar.Enabled = true;
                    bt_WeightHandTestStar.Enabled = true;


                }

                if (GloVar.MangeLevel == "技术员")
                {
                    UserLogion_ToolStrip.Enabled = true;
                    AdminLock_ToolStrip.Enabled = true;
                    Set_ToolStrip.Enabled = true;
                    系统参数设定ToolStripMenuItem.Enabled = false;
                    配方设置ToolStripMenuItem.Enabled = true;
                    cbx_room.Enabled = true;
                    cbx_MI.Enabled = true;
                    cbx_makecode.Enabled = true;
                    tx_MoNumber.Enabled = true;
                    tx_BatchNo.Enabled = true;
                    tx_OpenerID.Enabled = true;
                    tx_CheckerID.Enabled = true;
                    btn_SaveConfig.Enabled = true;
                    bt_Init.Enabled = true;
                    bt_Search.Enabled = true;
                    bt_Delete.Enabled = true;
                    bt_ScanHandTestStar.Enabled = true;
                    bt_WeightHandTestStar.Enabled = true;

                    txt_DangWei1Sn.Enabled = true;
                    txt_DangWei2Sn.Enabled = true;
                    txt_DangWei3Sn.Enabled = true;
                }

                if (GloVar.MangeLevel == "工程师")
                {
                    UserLogion_ToolStrip.Enabled = true;
                    AdminLock_ToolStrip.Enabled = true;
                    Set_ToolStrip.Enabled = true;
                    系统参数设定ToolStripMenuItem.Enabled = true;
                    配方设置ToolStripMenuItem.Enabled = true;
                    cbx_room.Enabled = true;
                    cbx_MI.Enabled = true;
                    cbx_makecode.Enabled = true;
                    tx_MoNumber.Enabled = true;
                    tx_BatchNo.Enabled = true;
                    tx_OpenerID.Enabled = true;
                    tx_CheckerID.Enabled = true;
                    btn_SaveConfig.Enabled = true;
                    bt_Init.Enabled = true;
                    bt_Search.Enabled = true;
                    bt_Delete.Enabled = true;
                    bt_ScanHandTestStar.Enabled = true;
                    bt_WeightHandTestStar.Enabled = true;

                    txt_DangWei1Sn.Enabled = true;
                    txt_DangWei2Sn.Enabled = true;
                    txt_DangWei3Sn.Enabled = true;
                }
            }



            if (GloVar.PLCStatus)
            {
                lab_plc.BackColor = Color.Green;
            }

            //tx_movePlate.Text = GloVar.NowMovePlateCount.ToString();
            //tx_updataCellCount.Text = GloVar.NowUpdataCellCount.ToString();



            //tx_boxWeihingSN.Text = "";
            //tx_Weight.Text = "";
            //tx_ZWeight.Text = "";

            //更新统计结果
            this.ShowProductCount();
            //记录停机
            GloVar.filehelper.SaveStop();

            //OEE统计
            OEEmake();
            //RFID读卡
            //Geticcard();

        }

        private void ShowProductCount()
        {
            //double a = 1.2356745;
            //string percent = a.ToString("0.00%"); //转百分数
            /*
             * 总产量
             * 拦截电芯
             * 扫码不良
             * 性能不良
             * 良品率
             * 已入箱电芯
             * 拆箱电芯
             *    */
            string 良品率;

            if (GloVar.ProductCount.总投入 == 0)
            {
                良品率 = "0.00%";
            }
            else
            {
                良品率 = ((double)(GloVar.ProductCount.总投入 - GloVar.ProductCount.marking拦截 - GloVar.ProductCount.性能不良 - GloVar.ProductCount.扫码不良) / (double)GloVar.ProductCount.总投入).ToString("0.00%");
            }

            lv_statistical.Items[0].SubItems[1].Text = GloVar.ProductCount.总投入.ToString();
            lv_statistical.Items[1].SubItems[1].Text = GloVar.ProductCount.marking拦截.ToString();
            lv_statistical.Items[2].SubItems[1].Text = GloVar.ProductCount.扫码不良.ToString();
            lv_statistical.Items[3].SubItems[1].Text = GloVar.ProductCount.性能不良.ToString();
            //lv_statistical.Items[4].SubItems[1].Text = 良品率;
            lv_statistical.Items[5].SubItems[1].Text = GloVar.ProductCount.已入箱.ToString();
            lv_statistical.Items[6].SubItems[1].Text = GloVar.ProductCount.拆箱数量.ToString();


        }



        //RFID读卡
        private void Geticcard()
        {
            string cardmsg = "";
            try
            {
                string card = GloVar.ICcard.GetCard(out cardmsg);
                if (card != "")
                {
                    bool b = GloVar.mes.LoginDevice(this.tx_Device.Text, card, "", "", ref cardmsg);
                    if (b)
                    {
                        ConfigINI.ConnectINIWriter(ConfigINI.adressCountINI, "User", "M_USERNO", card);
                        GloVar.mes_UserName = card;
                        string message = "用户：" + card + "登录成功。";
                        ShowLog(message);
                        MessageBox.Show(message);
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {

            }

        }

        private void Bt_Search_Click(object sender, EventArgs e)
        {
            if (GloVar.运行状态 != GloVar.enSysStatus.运行)
            {
                if (string.IsNullOrEmpty(txtSearchBoxMsg.Text))
                {
                    MessageBox.Show("查询箱号不能为空!");
                }
                else
                {
                    string msg = "", mino = "";
                    mes.GetPackageByPackNo(txtSearchBoxMsg.Text, ref mino, ref msg);
                    rtx_SearchResult.Text = msg;
                }
            }
            else
            {
                MessageBox.Show("必须要在暂停状态才能查询!");
            }
        }

        private void Bt_Delete_Click(object sender, EventArgs e)
        {

            //if (GloVar.运行状态 != GloVar.enSysStatus.运行)
            //{
            //    if (cbx_ChaiXiangBoxSN.Text != "")//权限
            //    {
            //        List<string> list_searchInfo = new List<string>();

            //        string boxSN = cbx_ChaiXiangBoxSN.Text.Split(':')[0].Trim();
            //        mes.SearchOrDeleteBox(boxSN, ref list_searchInfo, "拆箱");
            //    }
            //    else
            //    {
            //        MessageBox.Show("请先选择要拆的箱号!");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("必须要在暂停状态才能查询!");
            //}
        }

        //开始
        private void Bt_Star_Click(object sender, EventArgs e)
        {
            if (GloVar.运行状态 != GloVar.enSysStatus.运行)
            {
                if (SysFunction.get_Param((int)GloVar.enSystemParam.是否上传MES) == "TRUE")
                {
                    if (cbx_room.Text == "" || cbx_MI.Text == "" || cbx_makecode.Text == "" || cob_ov.Text == "" || cob_region.Text == "" || tx_MoNumber.Text == "" || tx_BatchNo.Text == "" || tx_OpenerID.Text == "")
                    {
                        MessageBox.Show("请填写完整MES相关项");
                        GloVar.运行状态 = GloVar.enSysStatus.暂停;
                        return;
                    }
                }
                SysFunction.LoadSystemParam(Environment.CurrentDirectory + "\\SysConfig.csv");           //加载配置文件
                GloVar.运行状态 = GloVar.enSysStatus.运行;
                ShowLog("程序已运行");
            }
            else
            {
                ShowLog("程序已运行");
            }

        }

        //暂停
        private void Bt_Stop_Click(object sender, EventArgs e)
        {
            if (GloVar.运行状态 != GloVar.enSysStatus.暂停)
            {
                GloVar.运行状态 = GloVar.enSysStatus.暂停;
                //GloVar.PLC_Write[(int)GloVar.enWritePLC3000.上位机启动信号触发] = 10;
                //timer1.Enabled = false;
                ShowLog("程序已暂停");
            }
            else
            {
                ShowLog("程序已暂停");
            }
        }

        //初始化
        private void Bt_Init_Click(object sender, EventArgs e)
        {
            ShowLog("开始初始化");
            //GloVar.PLC_Write[(int)GloVar.enWritePLC3000.上位机初始化触发] = 11;

            for (int i = 1; i < 15; i++)
            {
                GloVar.PLC_Write[i] = 10;
            }

            GloVar.扫码流程1 = 0;
            GloVar.扫码流程2 = 0;
            GloVar.电芯上传流程 = 0;
            GloVar.搬移流程 = GloVar.enMoveStep.准备搬移;
            GloVar.称重流程 = GloVar.enWeightStep.准备称重;
            GloVar.初始化流程 = GloVar.enInit.准备初始化;

            //gls.Initial();                                                           //初始化配置
            //dc_Allbox.Clear();                                                       //清空所有箱
            //this.Invoke((Action)(() => { ShowInitial(); }));                         //初始化界面

            //数据清除
            GloVar.NowUpdataCellCount = 0;//初始化
            //GloVar.NowMovePlateCount = 0;//初始化
            GloVar.NowUpdataBoxSN = "";
            ShowScanBox(1, null, true);
            //GloVar.isBuilderNewBoxSnFlag = true;//新加上的
            GloVar.NeedWeightBoxSnList.Clear();
            GetRowColPlateCountByPLC();//从PLC获取行,列,盘数
            txt_cellgroup.Invoke((Action)(() => { txt_cellgroup.Text = ""; }));
            this.tx_boxScanSN.Invoke((Action)(() => { tx_boxScanSN.Text = ""; }));
            ShowLog("初始化完成");

        }


        private void 权限锁定ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GloVar.MangeLevel = "";
            MessageBox.Show("权限已锁定");
        }

        private void AdminMange_ToolStrip_Click(object sender, EventArgs e)
        {
            new Form_AdminMange().ShowDialog();
        }

        private void UserLogion_ToolStrip_Click(object sender, EventArgs e)
        {
            //new Form_权限登陆().ShowDialog();
            new Form_Logion().ShowDialog();
        }

        private void bt_ScanHandTestStar_Click(object sender, EventArgs e)
        {
            string strBarcode = "";
            if (GloVar.运行状态 != GloVar.enSysStatus.运行)
            {
                try
                {
                    string msg;
                    strBarcode = GloVar.scaner_cell.Scan_Trig(out msg);
                    strBarcode = strBarcode.Trim().Replace("\r", "");
                    string[] readStr = strBarcode.Split(',');//不确定扫不到码的是""还是ERROR,可能要判断是不是有""（空）和数量
                    for (int i = 0; i < readStr.Length; i++)
                    {
                        tx_ScanHandTestResult.Text += readStr[i] + "\r\n";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("手动扫码失败:" + ex.Message);
                    return;
                }
            }
            else
            {
                MessageBox.Show("程序处于运行状态，请暂停后再执行该操作");
            }
        }

        private void bt_ScanHandTestClear_Click(object sender, EventArgs e)
        {
            tx_ScanHandTestResult.Text = "";
        }

        private void bt_WeightHandTestClear_Click(object sender, EventArgs e)
        {
            tx_WeightHandTestResult.Text = "";
        }

        private void bt_WeightHandTestStar_Click(object sender, EventArgs e)
        {
            string weightON = "RW" + "\r\n";
            string weightClear = "MZ" + "\r\n";
            double weight = 0;
            if (GloVar.运行状态 != GloVar.enSysStatus.运行)
            {
                try
                {
                    if (!GloVar.serialPort_weight.IsOpen) GloVar.serialPort_weight.Open();
                    GloVar.serialPort_weight.DiscardInBuffer();
                    GloVar.serialPort_weight.Write(weightON);
                    GloVar.serialPort_weight.ReadTimeout = 500;
                    Thread.Sleep(300);
                    string weightRes = GloVar.serialPort_weight.ReadExisting();

                    int kg_index = weightRes.IndexOf("kg");
                    string sd = "";
                    for (int i = 0; i < weightRes.Length; i++)
                    {
                        if (weightRes[i] >= '0' && weightRes[i] <= '9')
                        {
                            for (int j = i; j < kg_index; j++)
                            {
                                sd += weightRes[j];
                            }
                            break;
                        }
                    }
                    double d = Convert.ToDouble(sd);

                    tx_WeightHandTestResult.Text += d.ToString() + "kg" + "\r\n";
                    GloVar.serialPort_weight.Close();
                }
                catch (Exception ex)
                {
                    GloVar.serialPort_weight.Write(weightClear);
                    GloVar.serialPort_weight.Close();
                    MessageBox.Show("手动称重异常!error:" + ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("程序处于运行状态，请暂停后再执行该操作");
            }
        }

        private void DevStatus_ToolStrip_Click(object sender, EventArgs e)
        {
            new Form_DevStatus().ShowDialog();
        }

        private void 系统参数设定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form_SystemParam().ShowDialog();
        }

        private void 配方设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GloVar.form_cellParam.ShowDialog();
        }

        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (MessageBox.Show("是否退出系统？", "提醒", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    SysFunction.SaveSystemParam(Environment.CurrentDirectory + "\\SysConfig.csv");   //保存配置文件
                }
                else
                {
                    e.Cancel = true;
                }
                //System.Environment.Exit(Environment.ExitCode);
            }
            catch (Exception ex)
            {

            }

        }

        private void BtnClearQuantity_Click(object sender, EventArgs e)
        {
            GloVar.ProductCount.ClearCount();
        }

        private void iO_ToolStrip_Click(object sender, EventArgs e)
        {
            new Form_IO().ShowDialog();
        }

        private void btn_ScanBox_Click(object sender, EventArgs e)
        {
            string strBarcode = "";
            if (GloVar.运行状态 != GloVar.enSysStatus.运行)
            {
                try
                {
                    string msg;
                    strBarcode = GloVar.scaner_box.Scan_Trig(out msg);
                    strBarcode = strBarcode.Trim().Replace("\r", "");
                    string[] readStr = strBarcode.Split(',');//不确定扫不到码的是""还是ERROR,可能要判断是不是有""（空）和数量
                    for (int i = 0; i < readStr.Length; i++)
                    {
                        tx_ScanHandTestResult.Text += readStr[i] + "\r\n";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("手动扫码失败:" + ex.Message);
                    return;
                }
            }
            else
            {
                MessageBox.Show("程序处于运行状态，请暂停后再执行该操作");
            }
        }

        private void Cbx_cellModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbx_room.Text != null && SysFunction.get_Param((int)GloVar.enSystemParam.是否上传MES) == "TRUE")
            {
                SysFunction.set_Param((int)GloVar.enSystemParam.车间号, cbx_room.Text);
                GloVar.dcroom = cbx_room.Text;
                GloVar.WorkShop = cbx_room.Text.Split(' ')[1];
            }

        }

        private void cbx_MI_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbx_room.Text != null && SysFunction.get_Param((int)GloVar.enSystemParam.是否上传MES) == "TRUE")
            {
                SysFunction.set_Param((int)GloVar.enSystemParam.MI, cbx_MI.Text);
                GloVar.mes_MI = cbx_MI.Text;
                GloVar.ItemCode = GloVar.dcmi[cbx_MI.Text];
            }

        }

        private void Cbx_voltageHorL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbx_makecode.Text != "")
            {
                SysFunction.set_Param((int)GloVar.enSystemParam.喷码规则, cbx_makecode.Text);
                GloVar.makecode = cbx_makecode.Text;
            }
        }

        private void btn_SaveConfig_Click(object sender, EventArgs e)
        {
            if (tx_BatchNo.Text.Length != 13)
            {
                MessageBox.Show("保存失败：批次号的长度应该为13，请检查");
                return;
            }
            try
            {
                //SysFunction.set_Param((int)GloVar.enSystemParam.电芯型号, cbx_room.Text);
                //SysFunction.set_Param((int)GloVar.enSystemParam.MI, cbx_MI.Text);
                //SysFunction.set_Param((int)GloVar.enSystemParam.电压类型, cbx_makecode.Text);
                SysFunction.set_Param((int)GloVar.enSystemParam.工单号, tx_MoNumber.Text);
                SysFunction.set_Param((int)GloVar.enSystemParam.批次号, tx_BatchNo.Text);
                //SysFunction.set_Param((int)GloVar.enSystemParam.扫码人, tx_OpenerID.Text);
                //SysFunction.set_Param((int)GloVar.enSystemParam.检查人, tx_CheckerID.Text);

                SysFunction.set_Param((int)GloVar.enSystemParam.档位1批次号, txt_DangWei1Sn.Text);
                SysFunction.set_Param((int)GloVar.enSystemParam.档位2批次号, txt_DangWei2Sn.Text);

                SysFunction.SaveSystemParam(Environment.CurrentDirectory + "\\SysConfig.csv");

                GloVar.MO = tx_MoNumber.Text;
                GloVar.Lot = tx_BatchNo.Text;
                MessageBox.Show("保存成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败" + ex.Message);
            }

        }

        private void btnClearDisplay_Click(object sender, EventArgs e)
        {
            rtx_SearchResult.Clear();
        }

        private void 历史数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //new Form_production().ShowDialog();
            new US_Scancz().ShowDialog();
        }

        private void 报警信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form_Alarm().ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //while (lsv_io.Items.Count > 0)
            //{
            //    lsv_io.Items.RemoveAt(0);
            //}
            //try
            //{
            //    int nadd = Convert.ToInt32(cob_plcadd.Text);
            //    if (nadd >= 3000)
            //    {
            //        GloVar.PLC_Write[nadd - 3000] = (short)Convert.ToInt32(txt_outplc.Text.Trim());
            //        var wRet = plc.Write("C" + nadd.ToString(), GloVar.PLC_Write);
            //    }
            //    else
            //    {
            //        GloVar.PLC_Rread[nadd - 2900] = (short)Convert.ToInt32(txt_outplc.Text.Trim());
            //        var wRet = plc.Write("C" + nadd.ToString(), GloVar.PLC_Rread);
            //    }

            //}
            //catch
            //{
            //    txt_outplc.Text = "0";

            //    MessageBox.Show("状态输入有误");
            //}
            //Thread.Sleep(200);
            //for (int i = 0; i < 20; i++)
            //{
            //    ListViewItem item = new ListViewItem();
            //    item.SubItems.Add((2900 + i).ToString());//输入地址
            //    item.SubItems.Add(GloVar.PLC_Rread[i].ToString());//状态
            //    item.SubItems.Add((3000 + i).ToString());//输出地址
            //    item.SubItems.Add(GloVar.PLC_Write[i].ToString());//状态
            //    lsv_io.Items.Add(item);
            //}

        }

        private void groBox_WeightHandTest_Enter(object sender, EventArgs e)
        {

        }

        //删除数据库旧数据用
        private void timer2_Tick(object sender, EventArgs e)
        {

            //5个小时删除数据库旧数据
            new Thread(() =>
            {
                //电芯表scancz
                int count;
                string sql = "select count(*) from scancz02";
                count = SqlHelper.GetTableRow(sql);
                //大于50w&&已经经过一年才决定清除
                if (count > 5000000)
                {
                    sql = "delete from scancz02 where time<'" + DateTime.Now.AddYears(-1) + "';";
                    SqlHelper.InsertSQLData(sql);
                }
                //称重表weight
                sql = "select count(*) from weight01";
                count = SqlHelper.GetTableRow(sql);
                if (count > 5000000)
                {
                    sql = "delete from weight01 where time<'" + DateTime.Now.AddYears(-1) + "';";
                    SqlHelper.InsertSQLData(sql);
                }
            }).Start();
            //删除设备状态超过一年的记录
            if (Directory.Exists(GloVar.path_Stop))
            {
                GloVar.filehelper.Delectfile(GloVar.path_Stop, ".csv");
            }

        }

        #region 各种方法
        //加载电芯型号配方(暂不使用)
        private void LoadCellWeightParam()
        {

            try
            {
                cbx_room.Items.Clear();
                DataTable readParam;
                int count1;
                readParam = SqlHelper.GetAllSQLDataAsDataTable("select * from cell ", out count1);
                for (int i = 0; i < readParam.Rows.Count; i++)
                {
                    cbx_room.Items.Add(readParam.Rows[i][0].ToString());
                }
                string tmpCellModel = SysFunction.get_Param(GloVar.enSystemParam.电芯型号.ToString());
                if (cbx_room.Items.Contains(tmpCellModel))
                {
                    cbx_room.Text = tmpCellModel;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载电芯参数异常" + ex.Message);
            }
        }

        //加载电压（高/低） 暂时不用
        //private void GetVoltageModel()
        //{
        //    try
        //    {
        //        string resCatch = "";
        //        Dictionary<string, string> list = new Dictionary<string, string>();
        //        list = mes.GetVoltageTypeRootObject(ref resCatch);
        //        if (list != null)
        //        {
        //            GloVar.voltageTypeDic = list;
        //            //添加到下拉框的选项中
        //            //this.cbx_voltageHorL.DataSource = list.Keys.ToList<string>();

        //            cbx_makecode.Items.Clear();
        //            foreach (var item in list)
        //            {
        //                cbx_makecode.Items.Add(item.Key);
        //            }

        //            ShowLog("获取电压型号成功");

        //            string tmpVoltage = SysFunction.get_Param(GloVar.enSystemParam.电压类型.ToString());
        //            if (cbx_makecode.Items.Contains(tmpVoltage))
        //            {
        //                cbx_makecode.Text = tmpVoltage;
        //            }
        //        }
        //        else
        //        {
        //            ShowLog(resCatch);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string faileName = DateTime.Now.ToString("yyyy-MM-dd") + "_other.txt";
        //        SysFunction.SaveLog(faileName, "获取电压型号异常", ex.ToString());
        //    }
        //}


        //加载MI号
        private void GetMiModel()
        {
            try
            {

                if (GloVar.dcmi == null)
                {
                    MessageBox.Show("获取MI接口失败");
                }
                else
                {
                    foreach (KeyValuePair<string, string> item in GloVar.dcmi)
                    {
                        cbx_MI.Items.Add(item.Key);
                    }
                }
                cbx_MI.Text = SysFunction.get_Param((int)GloVar.enSystemParam.MI);
            }
            catch (Exception ex)
            {
            }
        }



        //界面MES相关
        private void LoadMESInfo()
        {
            tx_MoNumber.Text = SysFunction.get_Param((int)GloVar.enSystemParam.工单号);
            tx_BatchNo.Text = SysFunction.get_Param((int)GloVar.enSystemParam.批次号);
            tx_OpenerID.Text = SysFunction.get_Param((int)GloVar.enSystemParam.扫码人);
            tx_CheckerID.Text = SysFunction.get_Param((int)GloVar.enSystemParam.检查人);

            txt_DangWei1Sn.Text = SysFunction.get_Param((int)GloVar.enSystemParam.档位1批次号);
            txt_DangWei2Sn.Text = SysFunction.get_Param((int)GloVar.enSystemParam.档位2批次号);
        }

        //加载一箱行列盘数和显示扫码显示区个数
        private void GetRowColPlateCountByPLC()
        {
            try
            {
                this.txb_RowColPlate.Text = GloVar.PLC_Rread[(int)GloVar.enReadPLC2900.行数] + "," + GloVar.PLC_Rread[(int)GloVar.enReadPLC2900.列数] + "," + GloVar.PLC_Rread[(int)GloVar.enReadPLC2900.盘数];
                //隐藏多余数量的lab和text(先显示再隐藏)
                for (int i = 0; i < gb_ScanShow.Controls.Count; i++)
                {
                    foreach (Control item in gb_ScanShow.Controls)
                    {
                        item.Visible = true;
                    }
                }
                GloVar.CellCountOnePlate = GloVar.PLC_Rread[(int)GloVar.enReadPLC2900.行数] * GloVar.PLC_Rread[(int)GloVar.enReadPLC2900.列数];           //一盘的电芯数量
                for (int i = gb_ScanShow.Controls.Count / 2; i > GloVar.CellCountOnePlate; i--)
                {
                    foreach (Control item in gb_ScanShow.Controls)
                    {
                        if (item is Label)
                        {
                            if (item.Text == i.ToString())
                            {
                                item.Visible = false;
                            }
                        }
                        else if (item is TextBox)
                        {
                            if (item.Name == "tx_SN" + i)
                            {
                                item.Visible = false;
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                string faileName = DateTime.Now.ToString("yyyy-MM-dd") + "_other.txt";
                SysFunction.SaveLog(faileName, "获取行列盘数异常", ex.Message);
            }
        }

        #region OEE统计
        private DateTime dt_star = DateTime.Now;//开机时间点
        private DateTime dt_stop = new DateTime();//停机时长
        private DateTime dt_stop_star;//开始停机
        private double av_propety = 0;//性能利用率
        private double av_time = 0;//时间利用率
        private double av_quality = 0;//质量利用率
        private double OEE = 0;
        private bool b_oee = false;//启动OEE计算
        private void OEEmake()
        {
            try
            {
                //OEE统计班，日，周，月
                if (GloVar.PLC_Rread[12] == 0)//停机
                {
                    dt_stop_star = DateTime.Now;
                    b_oee = true;
                }
                else if (GloVar.PLC_Rread[12] == 1 && b_oee == true)
                {
                    dt_stop += DateTime.Now - dt_stop_star;
                    //性能利用率=生产产品数/【（总开机时间-停机时间）*设计速度】*100%
                    av_propety = (double)GloVar.ProductCount.总投入 / (((DateTime.Now - dt_star).Minutes - dt_stop.Minute) * 60);
                    //时间利用率 =（总开机时间 - 停机时间）/ 总开机时间 * 100 %
                    av_time = (double)((DateTime.Now - dt_star).Minutes - dt_stop.Minute) / (DateTime.Now - dt_star).Minutes;
                    //质量利用率 =（生产产品数 - 不良品数）/ 生产产品数 * 100 %
                    av_quality = ((double)(GloVar.ProductCount.总投入 - GloVar.ProductCount.marking拦截 - GloVar.ProductCount.性能不良 - GloVar.ProductCount.扫码不良) / (double)GloVar.ProductCount.总投入);
                    av_quality = 1;
                    //设备OEE=性能利用率*时间利用率*质量利用率*100%
                    OEE = av_propety * av_time * av_quality * 100;
                    int count = 0;
                    DataTable dtsql = SqlHelper.GetSQLDataAsDataTable("select * from oee order by id DESC limit 1", out count);
                    string s = dtsql.Rows[0][1].ToString();
                    s = DateTime.Now.ToString("yyyyMMdd");
                    if (dtsql.Rows[0][1].ToString() == DateTime.Now.ToString("yyyyMMdd"))
                    {
                        string str = string.Format("UPDATE OEE SET 停机时间='{0}',性能利用率='{1}',时间利用率='{2}',质量利用率='{3}',OEE='{4}' "
                        , dt_stop.Minute, av_propety, av_time, av_quality, OEE);
                        str += "where 日期='" + s + "'";
                        SqlHelper.UpdateSQLData(str);
                    }
                    else
                    {
                        s = dt_stop.AddMinutes(0).ToString();
                        s = dt_stop.Minute.ToString();
                        SqlHelper.InsertSQLAll("insert into oee(日期,停机时间,性能利用率,时间利用率,质量利用率,OEE) values('" + DateTime.Now.ToString("yyyyMMdd") + "','" + dt_stop.AddMinutes(0) + "','" + av_propety + "','" + av_time + "','" + av_quality + "','" + OEE + "')");
                    }
                    b_oee = false;
                }
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #endregion 各种方法

        private void cbx_MI_Click(object sender, EventArgs e)
        {
            foreach (KeyValuePair<string, string> item in GloVar.dcmi)
            {
                cbx_MI.Items.Add(item.Key);
            }
        }

        private void cob_ov_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cob_ov.Text != null)
            {

                string type = "1";
                switch (cob_ov.Text)
                {
                    case "高电压 1":
                        type = "1";
                        break;
                    case "低电压 2":
                        type = "2";
                        break;
                    case "高电压转低电压 3":
                        type = "3";
                        break;
                    case "低电压转高电压 4":
                        type = "4";
                        break;
                    case "高SOC转低SOC 5":
                        type = "5";
                        break;
                    case "低SOC转高SOC 6":
                        type = "6";
                        break;
                }
                GloVar.StepNo = type;
                SysFunction.set_Param((int)GloVar.enSystemParam.电压类型, cob_ov.Text);
            }
        }

        private void cob_region_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cob_region.Text != null)
            {
                switch (cob_region.Text)
                {
                    case "兰溪 LX":
                        GloVar.Region = "LX";
                        break;
                    case "东莞 DG":
                        GloVar.Region = "DG";
                        break;
                    case "惠州 HZ":
                        GloVar.Region = "HZ";
                        break;
                }
                SysFunction.set_Param((int)GloVar.enSystemParam.出货地区, cob_region.Text);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MES_io_test mestest = new MES_io_test();
            mestest.Show();
        }
    }
}
