namespace LWDBJ
{
    partial class Form_Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "总产量(pcs)：",
            "0"}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "拦截电芯(pcs)：",
            "0"}, -1);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "扫码不良(pcs)：",
            "0"}, -1);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem(new string[] {
            "性能不良(pcs)：",
            "0"}, -1);
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem(new string[] {
            "",
            "0"}, -1);
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem(new string[] {
            "已入箱电芯(pcs)",
            "0"}, -1);
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem(new string[] {
            "拆箱数量(pcs)",
            "0"}, -1);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lb_online = new System.Windows.Forms.Label();
            this.lab_plc = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.UserLogion_ToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.AdminLock_ToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.AdminMange_ToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.Set_ToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.系统参数设定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.配方设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iO_ToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.DevStatus_ToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.历史数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.报警信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbc = new System.Windows.Forms.TabControl();
            this.tab_ProductInfo = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.cob_region = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cob_ov = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_DangWei3Sn = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_DangWei2Sn = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_DangWei1Sn = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_SaveConfig = new System.Windows.Forms.Button();
            this.tx_CheckerID = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.tx_OpenerID = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.tx_BatchNo = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.tx_MoNumber = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.tx_updataCellCount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tx_movePlate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txb_RowColPlate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbx_makecode = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbx_MI = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbx_room = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tx_ZWeight = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tx_Weight = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tx_boxWeihingSN = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tx_boxScanSN = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tx_Device = new System.Windows.Forms.TextBox();
            this.gb_ScanShow = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.rtxWeightBoxList = new System.Windows.Forms.RichTextBox();
            this.tx_SN12 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.tx_SN10 = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.tx_SN8 = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.tx_SN6 = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.tx_SN4 = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.tx_SN2 = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.tx_SN11 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.tx_SN9 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.tx_SN7 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tx_SN5 = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.tx_SN3 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tx_SN1 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.lv_productInfo = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainer6 = new System.Windows.Forms.SplitContainer();
            this.lv_log = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainer7 = new System.Windows.Forms.SplitContainer();
            this.btnClearQuantity = new System.Windows.Forms.PictureBox();
            this.lv_statistical = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblStoping = new System.Windows.Forms.Label();
            this.lblRunning = new System.Windows.Forms.Label();
            this.bt_Init = new System.Windows.Forms.Button();
            this.bt_Stop = new System.Windows.Forms.Button();
            this.bt_Star = new System.Windows.Forms.Button();
            this.tab_MESOperation = new System.Windows.Forms.TabPage();
            this.splitContainer8 = new System.Windows.Forms.SplitContainer();
            this.button1 = new System.Windows.Forms.Button();
            this.txtSearchBoxMsg = new System.Windows.Forms.TextBox();
            this.cbx_ChaiXiangBoxSN = new System.Windows.Forms.ComboBox();
            this.rtx_SearchResult = new System.Windows.Forms.RichTextBox();
            this.btnClearDisplay = new System.Windows.Forms.Button();
            this.bt_Delete = new System.Windows.Forms.Button();
            this.bt_Search = new System.Windows.Forms.Button();
            this.label29 = new System.Windows.Forms.Label();
            this.tx_DeviceID = new System.Windows.Forms.TextBox();
            this.tx_InputDeviceID = new System.Windows.Forms.TextBox();
            this.tx_InputCheckerID = new System.Windows.Forms.TextBox();
            this.tx_InputOpenerID = new System.Windows.Forms.TextBox();
            this.tx_InputBatchNo = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.tx_InputMoNumber = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.tab_HandOperation = new System.Windows.Forms.TabPage();
            this.splitContainer9 = new System.Windows.Forms.SplitContainer();
            this.groBox_ScanHandTest = new System.Windows.Forms.GroupBox();
            this.btn_ScanBox = new System.Windows.Forms.Button();
            this.bt_ScanHandTestClear = new System.Windows.Forms.Button();
            this.bt_ScanHandTestStar = new System.Windows.Forms.Button();
            this.tx_ScanHandTestResult = new System.Windows.Forms.TextBox();
            this.groBox_WeightHandTest = new System.Windows.Forms.GroupBox();
            this.bt_WeightHandTestClear = new System.Windows.Forms.Button();
            this.tx_WeightHandTestResult = new System.Windows.Forms.TextBox();
            this.bt_WeightHandTestStar = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tbc.SuspendLayout();
            this.tab_ProductInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gb_ScanShow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).BeginInit();
            this.splitContainer6.Panel1.SuspendLayout();
            this.splitContainer6.Panel2.SuspendLayout();
            this.splitContainer6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer7)).BeginInit();
            this.splitContainer7.Panel1.SuspendLayout();
            this.splitContainer7.Panel2.SuspendLayout();
            this.splitContainer7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClearQuantity)).BeginInit();
            this.tab_MESOperation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer8)).BeginInit();
            this.splitContainer8.Panel1.SuspendLayout();
            this.splitContainer8.Panel2.SuspendLayout();
            this.splitContainer8.SuspendLayout();
            this.tab_HandOperation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer9)).BeginInit();
            this.splitContainer9.Panel1.SuspendLayout();
            this.splitContainer9.Panel2.SuspendLayout();
            this.splitContainer9.SuspendLayout();
            this.groBox_ScanHandTest.SuspendLayout();
            this.groBox_WeightHandTest.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lb_online);
            this.splitContainer1.Panel1.Controls.Add(this.lab_plc);
            this.splitContainer1.Panel1.Controls.Add(this.menuStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tbc);
            this.splitContainer1.Size = new System.Drawing.Size(1904, 1041);
            this.splitContainer1.SplitterDistance = 38;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 0;
            // 
            // lb_online
            // 
            this.lb_online.AutoSize = true;
            this.lb_online.BackColor = System.Drawing.Color.Transparent;
            this.lb_online.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_online.Location = new System.Drawing.Point(1453, 13);
            this.lb_online.Name = "lb_online";
            this.lb_online.Size = new System.Drawing.Size(65, 12);
            this.lb_online.TabIndex = 2;
            this.lb_online.Text = "设备离线中";
            // 
            // lab_plc
            // 
            this.lab_plc.AutoSize = true;
            this.lab_plc.Location = new System.Drawing.Point(1549, 14);
            this.lab_plc.Name = "lab_plc";
            this.lab_plc.Size = new System.Drawing.Size(23, 12);
            this.lab_plc.TabIndex = 1;
            this.lab_plc.Text = "PLC";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UserLogion_ToolStrip,
            this.AdminLock_ToolStrip,
            this.AdminMange_ToolStrip,
            this.Set_ToolStrip,
            this.iO_ToolStrip,
            this.DevStatus_ToolStrip,
            this.历史数据ToolStripMenuItem,
            this.报警信息ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1904, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // UserLogion_ToolStrip
            // 
            this.UserLogion_ToolStrip.Name = "UserLogion_ToolStrip";
            this.UserLogion_ToolStrip.Size = new System.Drawing.Size(68, 21);
            this.UserLogion_ToolStrip.Text = "权限登陆";
            this.UserLogion_ToolStrip.Click += new System.EventHandler(this.UserLogion_ToolStrip_Click);
            // 
            // AdminLock_ToolStrip
            // 
            this.AdminLock_ToolStrip.Name = "AdminLock_ToolStrip";
            this.AdminLock_ToolStrip.Size = new System.Drawing.Size(68, 21);
            this.AdminLock_ToolStrip.Text = "权限锁定";
            this.AdminLock_ToolStrip.Click += new System.EventHandler(this.权限锁定ToolStripMenuItem1_Click);
            // 
            // AdminMange_ToolStrip
            // 
            this.AdminMange_ToolStrip.Enabled = false;
            this.AdminMange_ToolStrip.Name = "AdminMange_ToolStrip";
            this.AdminMange_ToolStrip.Size = new System.Drawing.Size(68, 21);
            this.AdminMange_ToolStrip.Text = "权限管理";
            this.AdminMange_ToolStrip.Visible = false;
            this.AdminMange_ToolStrip.Click += new System.EventHandler(this.AdminMange_ToolStrip_Click);
            // 
            // Set_ToolStrip
            // 
            this.Set_ToolStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.系统参数设定ToolStripMenuItem,
            this.配方设置ToolStripMenuItem});
            this.Set_ToolStrip.Name = "Set_ToolStrip";
            this.Set_ToolStrip.Size = new System.Drawing.Size(44, 21);
            this.Set_ToolStrip.Text = "设定";
            // 
            // 系统参数设定ToolStripMenuItem
            // 
            this.系统参数设定ToolStripMenuItem.Name = "系统参数设定ToolStripMenuItem";
            this.系统参数设定ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.系统参数设定ToolStripMenuItem.Text = "系统参数设定";
            this.系统参数设定ToolStripMenuItem.Click += new System.EventHandler(this.系统参数设定ToolStripMenuItem_Click);
            // 
            // 配方设置ToolStripMenuItem
            // 
            this.配方设置ToolStripMenuItem.Name = "配方设置ToolStripMenuItem";
            this.配方设置ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.配方设置ToolStripMenuItem.Text = "配方设置";
            this.配方设置ToolStripMenuItem.Visible = false;
            this.配方设置ToolStripMenuItem.Click += new System.EventHandler(this.配方设置ToolStripMenuItem_Click);
            // 
            // iO_ToolStrip
            // 
            this.iO_ToolStrip.Name = "iO_ToolStrip";
            this.iO_ToolStrip.Size = new System.Drawing.Size(34, 21);
            this.iO_ToolStrip.Text = "IO";
            this.iO_ToolStrip.Click += new System.EventHandler(this.iO_ToolStrip_Click);
            // 
            // DevStatus_ToolStrip
            // 
            this.DevStatus_ToolStrip.Name = "DevStatus_ToolStrip";
            this.DevStatus_ToolStrip.Size = new System.Drawing.Size(68, 21);
            this.DevStatus_ToolStrip.Text = "设备状态";
            this.DevStatus_ToolStrip.Visible = false;
            this.DevStatus_ToolStrip.Click += new System.EventHandler(this.DevStatus_ToolStrip_Click);
            // 
            // 历史数据ToolStripMenuItem
            // 
            this.历史数据ToolStripMenuItem.Name = "历史数据ToolStripMenuItem";
            this.历史数据ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.历史数据ToolStripMenuItem.Text = "历史数据";
            this.历史数据ToolStripMenuItem.Click += new System.EventHandler(this.历史数据ToolStripMenuItem_Click);
            // 
            // 报警信息ToolStripMenuItem
            // 
            this.报警信息ToolStripMenuItem.Name = "报警信息ToolStripMenuItem";
            this.报警信息ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.报警信息ToolStripMenuItem.Text = "报警信息";
            this.报警信息ToolStripMenuItem.Click += new System.EventHandler(this.报警信息ToolStripMenuItem_Click);
            // 
            // tbc
            // 
            this.tbc.Controls.Add(this.tab_ProductInfo);
            this.tbc.Controls.Add(this.tab_MESOperation);
            this.tbc.Controls.Add(this.tab_HandOperation);
            this.tbc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbc.Location = new System.Drawing.Point(0, 0);
            this.tbc.Margin = new System.Windows.Forms.Padding(2);
            this.tbc.Name = "tbc";
            this.tbc.SelectedIndex = 0;
            this.tbc.Size = new System.Drawing.Size(1904, 1000);
            this.tbc.TabIndex = 0;
            // 
            // tab_ProductInfo
            // 
            this.tab_ProductInfo.Controls.Add(this.splitContainer2);
            this.tab_ProductInfo.Location = new System.Drawing.Point(4, 22);
            this.tab_ProductInfo.Margin = new System.Windows.Forms.Padding(2);
            this.tab_ProductInfo.Name = "tab_ProductInfo";
            this.tab_ProductInfo.Padding = new System.Windows.Forms.Padding(2);
            this.tab_ProductInfo.Size = new System.Drawing.Size(1896, 974);
            this.tab_ProductInfo.TabIndex = 0;
            this.tab_ProductInfo.Text = "生产页面";
            this.tab_ProductInfo.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(2, 2);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer5);
            this.splitContainer2.Size = new System.Drawing.Size(1892, 970);
            this.splitContainer2.SplitterDistance = 228;
            this.splitContainer2.SplitterWidth = 3;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer3.Panel1.Controls.Add(this.cob_region);
            this.splitContainer3.Panel1.Controls.Add(this.label12);
            this.splitContainer3.Panel1.Controls.Add(this.cob_ov);
            this.splitContainer3.Panel1.Controls.Add(this.label11);
            this.splitContainer3.Panel1.Controls.Add(this.txt_DangWei3Sn);
            this.splitContainer3.Panel1.Controls.Add(this.label8);
            this.splitContainer3.Panel1.Controls.Add(this.txt_DangWei2Sn);
            this.splitContainer3.Panel1.Controls.Add(this.label9);
            this.splitContainer3.Panel1.Controls.Add(this.txt_DangWei1Sn);
            this.splitContainer3.Panel1.Controls.Add(this.label10);
            this.splitContainer3.Panel1.Controls.Add(this.btn_SaveConfig);
            this.splitContainer3.Panel1.Controls.Add(this.tx_CheckerID);
            this.splitContainer3.Panel1.Controls.Add(this.label37);
            this.splitContainer3.Panel1.Controls.Add(this.tx_OpenerID);
            this.splitContainer3.Panel1.Controls.Add(this.label35);
            this.splitContainer3.Panel1.Controls.Add(this.tx_BatchNo);
            this.splitContainer3.Panel1.Controls.Add(this.label33);
            this.splitContainer3.Panel1.Controls.Add(this.tx_MoNumber);
            this.splitContainer3.Panel1.Controls.Add(this.label32);
            this.splitContainer3.Panel1.Controls.Add(this.tx_updataCellCount);
            this.splitContainer3.Panel1.Controls.Add(this.label6);
            this.splitContainer3.Panel1.Controls.Add(this.tx_movePlate);
            this.splitContainer3.Panel1.Controls.Add(this.label5);
            this.splitContainer3.Panel1.Controls.Add(this.txb_RowColPlate);
            this.splitContainer3.Panel1.Controls.Add(this.label4);
            this.splitContainer3.Panel1.Controls.Add(this.cbx_makecode);
            this.splitContainer3.Panel1.Controls.Add(this.label3);
            this.splitContainer3.Panel1.Controls.Add(this.cbx_MI);
            this.splitContainer3.Panel1.Controls.Add(this.label2);
            this.splitContainer3.Panel1.Controls.Add(this.cbx_room);
            this.splitContainer3.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer3.Size = new System.Drawing.Size(1892, 228);
            this.splitContainer3.SplitterDistance = 686;
            this.splitContainer3.SplitterWidth = 3;
            this.splitContainer3.TabIndex = 0;
            // 
            // cob_region
            // 
            this.cob_region.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cob_region.FormattingEnabled = true;
            this.cob_region.Items.AddRange(new object[] {
            "兰溪 LX",
            "惠州 HZ",
            "东莞 DG"});
            this.cob_region.Location = new System.Drawing.Point(471, 33);
            this.cob_region.Margin = new System.Windows.Forms.Padding(2);
            this.cob_region.Name = "cob_region";
            this.cob_region.Size = new System.Drawing.Size(93, 20);
            this.cob_region.TabIndex = 30;
            this.cob_region.SelectedIndexChanged += new System.EventHandler(this.cob_region_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label12.Location = new System.Drawing.Point(414, 35);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 29;
            this.label12.Text = "出货地区";
            // 
            // cob_ov
            // 
            this.cob_ov.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cob_ov.FormattingEnabled = true;
            this.cob_ov.Items.AddRange(new object[] {
            "高电压 1",
            "低电压 2",
            "高电压转低电压 3",
            "低电压转高电压 4",
            "高SOC转低SOC 5",
            "低SOC转高SOC 6"});
            this.cob_ov.Location = new System.Drawing.Point(471, 5);
            this.cob_ov.Margin = new System.Windows.Forms.Padding(2);
            this.cob_ov.Name = "cob_ov";
            this.cob_ov.Size = new System.Drawing.Size(93, 20);
            this.cob_ov.TabIndex = 28;
            this.cob_ov.SelectedIndexChanged += new System.EventHandler(this.cob_ov_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label11.Location = new System.Drawing.Point(414, 7);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 27;
            this.label11.Text = "分容流程";
            // 
            // txt_DangWei3Sn
            // 
            this.txt_DangWei3Sn.Location = new System.Drawing.Point(372, 129);
            this.txt_DangWei3Sn.Name = "txt_DangWei3Sn";
            this.txt_DangWei3Sn.Size = new System.Drawing.Size(196, 21);
            this.txt_DangWei3Sn.TabIndex = 26;
            this.txt_DangWei3Sn.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(289, 132);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 12);
            this.label8.TabIndex = 25;
            this.label8.Text = "档位3批次号：";
            this.label8.Visible = false;
            // 
            // txt_DangWei2Sn
            // 
            this.txt_DangWei2Sn.Location = new System.Drawing.Point(372, 99);
            this.txt_DangWei2Sn.Name = "txt_DangWei2Sn";
            this.txt_DangWei2Sn.Size = new System.Drawing.Size(196, 21);
            this.txt_DangWei2Sn.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(288, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 12);
            this.label9.TabIndex = 23;
            this.label9.Text = "档位2批次号：";
            // 
            // txt_DangWei1Sn
            // 
            this.txt_DangWei1Sn.Location = new System.Drawing.Point(372, 69);
            this.txt_DangWei1Sn.Name = "txt_DangWei1Sn";
            this.txt_DangWei1Sn.Size = new System.Drawing.Size(196, 21);
            this.txt_DangWei1Sn.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(290, 72);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 12);
            this.label10.TabIndex = 21;
            this.label10.Text = "档位1批次号：";
            // 
            // btn_SaveConfig
            // 
            this.btn_SaveConfig.Location = new System.Drawing.Point(292, 159);
            this.btn_SaveConfig.Name = "btn_SaveConfig";
            this.btn_SaveConfig.Size = new System.Drawing.Size(276, 21);
            this.btn_SaveConfig.TabIndex = 20;
            this.btn_SaveConfig.Text = "保存";
            this.btn_SaveConfig.UseVisualStyleBackColor = true;
            this.btn_SaveConfig.Click += new System.EventHandler(this.btn_SaveConfig_Click);
            // 
            // tx_CheckerID
            // 
            this.tx_CheckerID.Location = new System.Drawing.Point(88, 159);
            this.tx_CheckerID.Name = "tx_CheckerID";
            this.tx_CheckerID.Size = new System.Drawing.Size(196, 21);
            this.tx_CheckerID.TabIndex = 19;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(4, 162);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(77, 12);
            this.label37.TabIndex = 18;
            this.label37.Text = "当前检查人：";
            // 
            // tx_OpenerID
            // 
            this.tx_OpenerID.Enabled = false;
            this.tx_OpenerID.Location = new System.Drawing.Point(88, 129);
            this.tx_OpenerID.Name = "tx_OpenerID";
            this.tx_OpenerID.Size = new System.Drawing.Size(196, 21);
            this.tx_OpenerID.TabIndex = 17;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(5, 132);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(77, 12);
            this.label35.TabIndex = 16;
            this.label35.Text = "当前扫码人：";
            // 
            // tx_BatchNo
            // 
            this.tx_BatchNo.Location = new System.Drawing.Point(88, 99);
            this.tx_BatchNo.Name = "tx_BatchNo";
            this.tx_BatchNo.Size = new System.Drawing.Size(196, 21);
            this.tx_BatchNo.TabIndex = 15;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(4, 102);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(77, 12);
            this.label33.TabIndex = 14;
            this.label33.Text = "当前批次号：";
            // 
            // tx_MoNumber
            // 
            this.tx_MoNumber.Location = new System.Drawing.Point(88, 69);
            this.tx_MoNumber.Name = "tx_MoNumber";
            this.tx_MoNumber.Size = new System.Drawing.Size(196, 21);
            this.tx_MoNumber.TabIndex = 13;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(6, 72);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(77, 12);
            this.label32.TabIndex = 12;
            this.label32.Text = "当前工单号：";
            // 
            // tx_updataCellCount
            // 
            this.tx_updataCellCount.Location = new System.Drawing.Point(317, 32);
            this.tx_updataCellCount.Margin = new System.Windows.Forms.Padding(2);
            this.tx_updataCellCount.Name = "tx_updataCellCount";
            this.tx_updataCellCount.ReadOnly = true;
            this.tx_updataCellCount.Size = new System.Drawing.Size(61, 21);
            this.tx_updataCellCount.TabIndex = 11;
            this.tx_updataCellCount.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(273, 36);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "已上传";
            // 
            // tx_movePlate
            // 
            this.tx_movePlate.Location = new System.Drawing.Point(200, 32);
            this.tx_movePlate.Margin = new System.Windows.Forms.Padding(2);
            this.tx_movePlate.Name = "tx_movePlate";
            this.tx_movePlate.ReadOnly = true;
            this.tx_movePlate.Size = new System.Drawing.Size(57, 21);
            this.tx_movePlate.TabIndex = 9;
            this.tx_movePlate.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label5.Location = new System.Drawing.Point(146, 36);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "搬移盘数";
            // 
            // txb_RowColPlate
            // 
            this.txb_RowColPlate.Location = new System.Drawing.Point(68, 32);
            this.txb_RowColPlate.Margin = new System.Windows.Forms.Padding(2);
            this.txb_RowColPlate.Name = "txb_RowColPlate";
            this.txb_RowColPlate.ReadOnly = true;
            this.txb_RowColPlate.Size = new System.Drawing.Size(76, 21);
            this.txb_RowColPlate.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 36);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "行,列,盘数";
            // 
            // cbx_makecode
            // 
            this.cbx_makecode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_makecode.FormattingEnabled = true;
            this.cbx_makecode.Items.AddRange(new object[] {
            "数字",
            "字母"});
            this.cbx_makecode.Location = new System.Drawing.Point(311, 5);
            this.cbx_makecode.Margin = new System.Windows.Forms.Padding(2);
            this.cbx_makecode.Name = "cbx_makecode";
            this.cbx_makecode.Size = new System.Drawing.Size(93, 20);
            this.cbx_makecode.TabIndex = 5;
            this.cbx_makecode.SelectedIndexChanged += new System.EventHandler(this.Cbx_voltageHorL_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(254, 8);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "喷码规则";
            // 
            // cbx_MI
            // 
            this.cbx_MI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_MI.FormattingEnabled = true;
            this.cbx_MI.Location = new System.Drawing.Point(167, 5);
            this.cbx_MI.Margin = new System.Windows.Forms.Padding(2);
            this.cbx_MI.Name = "cbx_MI";
            this.cbx_MI.Size = new System.Drawing.Size(73, 20);
            this.cbx_MI.TabIndex = 3;
            this.cbx_MI.SelectedIndexChanged += new System.EventHandler(this.cbx_MI_SelectedIndexChanged);
            this.cbx_MI.Click += new System.EventHandler(this.cbx_MI_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(146, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "MI";
            // 
            // cbx_room
            // 
            this.cbx_room.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_room.FormattingEnabled = true;
            this.cbx_room.Items.AddRange(new object[] {
            "一车间 100",
            "二车间 101",
            "三车间 102",
            "四车间 103",
            "五车间 104",
            "六车间 105",
            "七车间 106",
            "八车间 107",
            "LXLW_阳极备料 98",
            "LXLW_阴极备料 99"});
            this.cbx_room.Location = new System.Drawing.Point(59, 4);
            this.cbx_room.Margin = new System.Windows.Forms.Padding(2);
            this.cbx_room.Name = "cbx_room";
            this.cbx_room.Size = new System.Drawing.Size(78, 20);
            this.cbx_room.TabIndex = 1;
            this.cbx_room.SelectedIndexChanged += new System.EventHandler(this.Cbx_cellModel_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(2, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "车间编号";
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.gb_ScanShow);
            this.splitContainer4.Size = new System.Drawing.Size(1203, 228);
            this.splitContainer4.SplitterDistance = 410;
            this.splitContainer4.SplitterWidth = 3;
            this.splitContainer4.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tx_ZWeight);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.tx_Weight);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.tx_boxWeihingSN);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.tx_boxScanSN);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.tx_Device);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(410, 228);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "当前信息监控";
            // 
            // tx_ZWeight
            // 
            this.tx_ZWeight.Location = new System.Drawing.Point(161, 118);
            this.tx_ZWeight.Margin = new System.Windows.Forms.Padding(2);
            this.tx_ZWeight.Name = "tx_ZWeight";
            this.tx_ZWeight.ReadOnly = true;
            this.tx_ZWeight.Size = new System.Drawing.Size(66, 21);
            this.tx_ZWeight.TabIndex = 32;
            this.tx_ZWeight.Visible = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(9, 124);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(77, 12);
            this.label16.TabIndex = 31;
            this.label16.Text = "上次称重数据";
            this.label16.Visible = false;
            // 
            // tx_Weight
            // 
            this.tx_Weight.Location = new System.Drawing.Point(90, 119);
            this.tx_Weight.Margin = new System.Windows.Forms.Padding(2);
            this.tx_Weight.Name = "tx_Weight";
            this.tx_Weight.ReadOnly = true;
            this.tx_Weight.Size = new System.Drawing.Size(66, 21);
            this.tx_Weight.TabIndex = 30;
            this.tx_Weight.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 90);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 12);
            this.label15.TabIndex = 29;
            this.label15.Text = "上次称重料箱";
            this.label15.Visible = false;
            // 
            // tx_boxWeihingSN
            // 
            this.tx_boxWeihingSN.Location = new System.Drawing.Point(90, 87);
            this.tx_boxWeihingSN.Margin = new System.Windows.Forms.Padding(2);
            this.tx_boxWeihingSN.Name = "tx_boxWeihingSN";
            this.tx_boxWeihingSN.ReadOnly = true;
            this.tx_boxWeihingSN.Size = new System.Drawing.Size(137, 21);
            this.tx_boxWeihingSN.TabIndex = 28;
            this.tx_boxWeihingSN.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 49);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 12);
            this.label14.TabIndex = 27;
            this.label14.Text = "当前扫码料箱";
            // 
            // tx_boxScanSN
            // 
            this.tx_boxScanSN.Location = new System.Drawing.Point(90, 46);
            this.tx_boxScanSN.Margin = new System.Windows.Forms.Padding(2);
            this.tx_boxScanSN.Name = "tx_boxScanSN";
            this.tx_boxScanSN.ReadOnly = true;
            this.tx_boxScanSN.Size = new System.Drawing.Size(137, 21);
            this.tx_boxScanSN.TabIndex = 26;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 27);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 12);
            this.label13.TabIndex = 25;
            this.label13.Text = "当前设备编号";
            // 
            // tx_Device
            // 
            this.tx_Device.Location = new System.Drawing.Point(90, 21);
            this.tx_Device.Margin = new System.Windows.Forms.Padding(2);
            this.tx_Device.Name = "tx_Device";
            this.tx_Device.ReadOnly = true;
            this.tx_Device.Size = new System.Drawing.Size(137, 21);
            this.tx_Device.TabIndex = 24;
            // 
            // gb_ScanShow
            // 
            this.gb_ScanShow.Controls.Add(this.label7);
            this.gb_ScanShow.Controls.Add(this.rtxWeightBoxList);
            this.gb_ScanShow.Controls.Add(this.tx_SN12);
            this.gb_ScanShow.Controls.Add(this.label23);
            this.gb_ScanShow.Controls.Add(this.tx_SN10);
            this.gb_ScanShow.Controls.Add(this.label24);
            this.gb_ScanShow.Controls.Add(this.tx_SN8);
            this.gb_ScanShow.Controls.Add(this.label25);
            this.gb_ScanShow.Controls.Add(this.tx_SN6);
            this.gb_ScanShow.Controls.Add(this.label26);
            this.gb_ScanShow.Controls.Add(this.tx_SN4);
            this.gb_ScanShow.Controls.Add(this.label27);
            this.gb_ScanShow.Controls.Add(this.tx_SN2);
            this.gb_ScanShow.Controls.Add(this.label28);
            this.gb_ScanShow.Controls.Add(this.tx_SN11);
            this.gb_ScanShow.Controls.Add(this.label21);
            this.gb_ScanShow.Controls.Add(this.tx_SN9);
            this.gb_ScanShow.Controls.Add(this.label22);
            this.gb_ScanShow.Controls.Add(this.tx_SN7);
            this.gb_ScanShow.Controls.Add(this.label19);
            this.gb_ScanShow.Controls.Add(this.tx_SN5);
            this.gb_ScanShow.Controls.Add(this.label20);
            this.gb_ScanShow.Controls.Add(this.tx_SN3);
            this.gb_ScanShow.Controls.Add(this.label18);
            this.gb_ScanShow.Controls.Add(this.tx_SN1);
            this.gb_ScanShow.Controls.Add(this.label17);
            this.gb_ScanShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_ScanShow.Location = new System.Drawing.Point(0, 0);
            this.gb_ScanShow.Margin = new System.Windows.Forms.Padding(2);
            this.gb_ScanShow.Name = "gb_ScanShow";
            this.gb_ScanShow.Padding = new System.Windows.Forms.Padding(2);
            this.gb_ScanShow.Size = new System.Drawing.Size(790, 228);
            this.gb_ScanShow.TabIndex = 0;
            this.gb_ScanShow.TabStop = false;
            this.gb_ScanShow.Text = "电芯扫码显示";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(335, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 12);
            this.label7.TabIndex = 25;
            this.label7.Text = "待称重箱号列表：";
            // 
            // rtxWeightBoxList
            // 
            this.rtxWeightBoxList.Location = new System.Drawing.Point(337, 36);
            this.rtxWeightBoxList.Name = "rtxWeightBoxList";
            this.rtxWeightBoxList.ReadOnly = true;
            this.rtxWeightBoxList.Size = new System.Drawing.Size(217, 138);
            this.rtxWeightBoxList.TabIndex = 24;
            this.rtxWeightBoxList.Text = "";
            // 
            // tx_SN12
            // 
            this.tx_SN12.Location = new System.Drawing.Point(199, 143);
            this.tx_SN12.Margin = new System.Windows.Forms.Padding(2);
            this.tx_SN12.Name = "tx_SN12";
            this.tx_SN12.ReadOnly = true;
            this.tx_SN12.Size = new System.Drawing.Size(108, 21);
            this.tx_SN12.TabIndex = 23;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(178, 146);
            this.label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(17, 12);
            this.label23.TabIndex = 22;
            this.label23.Text = "12";
            // 
            // tx_SN10
            // 
            this.tx_SN10.Location = new System.Drawing.Point(200, 118);
            this.tx_SN10.Margin = new System.Windows.Forms.Padding(2);
            this.tx_SN10.Name = "tx_SN10";
            this.tx_SN10.ReadOnly = true;
            this.tx_SN10.Size = new System.Drawing.Size(108, 21);
            this.tx_SN10.TabIndex = 21;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(178, 121);
            this.label24.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(17, 12);
            this.label24.TabIndex = 20;
            this.label24.Text = "10";
            // 
            // tx_SN8
            // 
            this.tx_SN8.Location = new System.Drawing.Point(200, 93);
            this.tx_SN8.Margin = new System.Windows.Forms.Padding(2);
            this.tx_SN8.Name = "tx_SN8";
            this.tx_SN8.ReadOnly = true;
            this.tx_SN8.Size = new System.Drawing.Size(108, 21);
            this.tx_SN8.TabIndex = 19;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(178, 96);
            this.label25.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(11, 12);
            this.label25.TabIndex = 18;
            this.label25.Text = "8";
            // 
            // tx_SN6
            // 
            this.tx_SN6.Location = new System.Drawing.Point(200, 68);
            this.tx_SN6.Margin = new System.Windows.Forms.Padding(2);
            this.tx_SN6.Name = "tx_SN6";
            this.tx_SN6.ReadOnly = true;
            this.tx_SN6.Size = new System.Drawing.Size(108, 21);
            this.tx_SN6.TabIndex = 17;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(178, 71);
            this.label26.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(11, 12);
            this.label26.TabIndex = 16;
            this.label26.Text = "6";
            // 
            // tx_SN4
            // 
            this.tx_SN4.Location = new System.Drawing.Point(200, 43);
            this.tx_SN4.Margin = new System.Windows.Forms.Padding(2);
            this.tx_SN4.Name = "tx_SN4";
            this.tx_SN4.ReadOnly = true;
            this.tx_SN4.Size = new System.Drawing.Size(108, 21);
            this.tx_SN4.TabIndex = 15;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(178, 46);
            this.label27.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(11, 12);
            this.label27.TabIndex = 14;
            this.label27.Text = "4";
            // 
            // tx_SN2
            // 
            this.tx_SN2.Location = new System.Drawing.Point(200, 18);
            this.tx_SN2.Margin = new System.Windows.Forms.Padding(2);
            this.tx_SN2.Name = "tx_SN2";
            this.tx_SN2.ReadOnly = true;
            this.tx_SN2.Size = new System.Drawing.Size(108, 21);
            this.tx_SN2.TabIndex = 13;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(178, 21);
            this.label28.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(11, 12);
            this.label28.TabIndex = 12;
            this.label28.Text = "2";
            // 
            // tx_SN11
            // 
            this.tx_SN11.Location = new System.Drawing.Point(38, 143);
            this.tx_SN11.Margin = new System.Windows.Forms.Padding(2);
            this.tx_SN11.Name = "tx_SN11";
            this.tx_SN11.ReadOnly = true;
            this.tx_SN11.Size = new System.Drawing.Size(108, 21);
            this.tx_SN11.TabIndex = 11;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(16, 148);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(17, 12);
            this.label21.TabIndex = 10;
            this.label21.Text = "11";
            // 
            // tx_SN9
            // 
            this.tx_SN9.Location = new System.Drawing.Point(38, 118);
            this.tx_SN9.Margin = new System.Windows.Forms.Padding(2);
            this.tx_SN9.Name = "tx_SN9";
            this.tx_SN9.ReadOnly = true;
            this.tx_SN9.Size = new System.Drawing.Size(108, 21);
            this.tx_SN9.TabIndex = 9;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(16, 121);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(11, 12);
            this.label22.TabIndex = 8;
            this.label22.Text = "9";
            // 
            // tx_SN7
            // 
            this.tx_SN7.Location = new System.Drawing.Point(38, 93);
            this.tx_SN7.Margin = new System.Windows.Forms.Padding(2);
            this.tx_SN7.Name = "tx_SN7";
            this.tx_SN7.ReadOnly = true;
            this.tx_SN7.Size = new System.Drawing.Size(108, 21);
            this.tx_SN7.TabIndex = 7;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(16, 96);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(11, 12);
            this.label19.TabIndex = 6;
            this.label19.Text = "7";
            // 
            // tx_SN5
            // 
            this.tx_SN5.Location = new System.Drawing.Point(38, 68);
            this.tx_SN5.Margin = new System.Windows.Forms.Padding(2);
            this.tx_SN5.Name = "tx_SN5";
            this.tx_SN5.ReadOnly = true;
            this.tx_SN5.Size = new System.Drawing.Size(108, 21);
            this.tx_SN5.TabIndex = 5;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(16, 71);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(11, 12);
            this.label20.TabIndex = 4;
            this.label20.Text = "5";
            // 
            // tx_SN3
            // 
            this.tx_SN3.Location = new System.Drawing.Point(38, 43);
            this.tx_SN3.Margin = new System.Windows.Forms.Padding(2);
            this.tx_SN3.Name = "tx_SN3";
            this.tx_SN3.ReadOnly = true;
            this.tx_SN3.Size = new System.Drawing.Size(108, 21);
            this.tx_SN3.TabIndex = 3;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(16, 46);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(11, 12);
            this.label18.TabIndex = 2;
            this.label18.Text = "3";
            // 
            // tx_SN1
            // 
            this.tx_SN1.Location = new System.Drawing.Point(38, 18);
            this.tx_SN1.Margin = new System.Windows.Forms.Padding(2);
            this.tx_SN1.Name = "tx_SN1";
            this.tx_SN1.ReadOnly = true;
            this.tx_SN1.Size = new System.Drawing.Size(108, 21);
            this.tx_SN1.TabIndex = 1;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(16, 21);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(11, 12);
            this.label17.TabIndex = 0;
            this.label17.Text = "1";
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Name = "splitContainer5";
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.lv_productInfo);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.splitContainer6);
            this.splitContainer5.Size = new System.Drawing.Size(1892, 739);
            this.splitContainer5.SplitterDistance = 686;
            this.splitContainer5.TabIndex = 0;
            // 
            // lv_productInfo
            // 
            this.lv_productInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lv_productInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_productInfo.GridLines = true;
            this.lv_productInfo.HideSelection = false;
            this.lv_productInfo.Location = new System.Drawing.Point(0, 0);
            this.lv_productInfo.Name = "lv_productInfo";
            this.lv_productInfo.Size = new System.Drawing.Size(686, 739);
            this.lv_productInfo.TabIndex = 0;
            this.lv_productInfo.UseCompatibleStateImageBehavior = false;
            this.lv_productInfo.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "电池序号";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "时间";
            this.columnHeader2.Width = 140;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "电芯条码";
            this.columnHeader3.Width = 140;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "外箱条码";
            this.columnHeader4.Width = 236;
            // 
            // splitContainer6
            // 
            this.splitContainer6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer6.Location = new System.Drawing.Point(0, 0);
            this.splitContainer6.Name = "splitContainer6";
            // 
            // splitContainer6.Panel1
            // 
            this.splitContainer6.Panel1.Controls.Add(this.lv_log);
            // 
            // splitContainer6.Panel2
            // 
            this.splitContainer6.Panel2.Controls.Add(this.splitContainer7);
            this.splitContainer6.Size = new System.Drawing.Size(1202, 739);
            this.splitContainer6.SplitterDistance = 637;
            this.splitContainer6.TabIndex = 0;
            // 
            // lv_log
            // 
            this.lv_log.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6});
            this.lv_log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_log.GridLines = true;
            this.lv_log.HideSelection = false;
            this.lv_log.Location = new System.Drawing.Point(0, 0);
            this.lv_log.Name = "lv_log";
            this.lv_log.Size = new System.Drawing.Size(637, 739);
            this.lv_log.TabIndex = 2;
            this.lv_log.UseCompatibleStateImageBehavior = false;
            this.lv_log.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "时间";
            this.columnHeader5.Width = 150;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "内容";
            this.columnHeader6.Width = 600;
            // 
            // splitContainer7
            // 
            this.splitContainer7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer7.Location = new System.Drawing.Point(0, 0);
            this.splitContainer7.Name = "splitContainer7";
            this.splitContainer7.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer7.Panel1
            // 
            this.splitContainer7.Panel1.Controls.Add(this.btnClearQuantity);
            this.splitContainer7.Panel1.Controls.Add(this.lv_statistical);
            // 
            // splitContainer7.Panel2
            // 
            this.splitContainer7.Panel2.Controls.Add(this.lblStoping);
            this.splitContainer7.Panel2.Controls.Add(this.lblRunning);
            this.splitContainer7.Panel2.Controls.Add(this.bt_Init);
            this.splitContainer7.Panel2.Controls.Add(this.bt_Stop);
            this.splitContainer7.Panel2.Controls.Add(this.bt_Star);
            this.splitContainer7.Size = new System.Drawing.Size(561, 739);
            this.splitContainer7.SplitterDistance = 224;
            this.splitContainer7.TabIndex = 0;
            // 
            // btnClearQuantity
            // 
            this.btnClearQuantity.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnClearQuantity.Image = ((System.Drawing.Image)(resources.GetObject("btnClearQuantity.Image")));
            this.btnClearQuantity.Location = new System.Drawing.Point(371, 3);
            this.btnClearQuantity.Name = "btnClearQuantity";
            this.btnClearQuantity.Size = new System.Drawing.Size(33, 34);
            this.btnClearQuantity.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnClearQuantity.TabIndex = 40;
            this.btnClearQuantity.TabStop = false;
            this.btnClearQuantity.Click += new System.EventHandler(this.BtnClearQuantity_Click);
            // 
            // lv_statistical
            // 
            this.lv_statistical.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8});
            this.lv_statistical.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_statistical.FullRowSelect = true;
            this.lv_statistical.GridLines = true;
            this.lv_statistical.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lv_statistical.HideSelection = false;
            this.lv_statistical.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7});
            this.lv_statistical.Location = new System.Drawing.Point(0, 0);
            this.lv_statistical.MultiSelect = false;
            this.lv_statistical.Name = "lv_statistical";
            this.lv_statistical.Size = new System.Drawing.Size(561, 224);
            this.lv_statistical.TabIndex = 0;
            this.lv_statistical.UseCompatibleStateImageBehavior = false;
            this.lv_statistical.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "记录项";
            this.columnHeader7.Width = 138;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "数据";
            this.columnHeader8.Width = 120;
            // 
            // lblStoping
            // 
            this.lblStoping.AutoSize = true;
            this.lblStoping.BackColor = System.Drawing.Color.Red;
            this.lblStoping.Location = new System.Drawing.Point(46, 35);
            this.lblStoping.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStoping.Name = "lblStoping";
            this.lblStoping.Size = new System.Drawing.Size(77, 12);
            this.lblStoping.TabIndex = 33;
            this.lblStoping.Text = "   暂停中   ";
            // 
            // lblRunning
            // 
            this.lblRunning.AutoSize = true;
            this.lblRunning.BackColor = System.Drawing.Color.LimeGreen;
            this.lblRunning.Location = new System.Drawing.Point(46, 23);
            this.lblRunning.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRunning.Name = "lblRunning";
            this.lblRunning.Size = new System.Drawing.Size(77, 12);
            this.lblRunning.TabIndex = 32;
            this.lblRunning.Text = "   运行中   ";
            // 
            // bt_Init
            // 
            this.bt_Init.Location = new System.Drawing.Point(34, 164);
            this.bt_Init.Name = "bt_Init";
            this.bt_Init.Size = new System.Drawing.Size(112, 45);
            this.bt_Init.TabIndex = 3;
            this.bt_Init.Text = "初始化";
            this.bt_Init.UseVisualStyleBackColor = true;
            this.bt_Init.Click += new System.EventHandler(this.Bt_Init_Click);
            // 
            // bt_Stop
            // 
            this.bt_Stop.Location = new System.Drawing.Point(34, 113);
            this.bt_Stop.Name = "bt_Stop";
            this.bt_Stop.Size = new System.Drawing.Size(112, 45);
            this.bt_Stop.TabIndex = 1;
            this.bt_Stop.Text = "暂停";
            this.bt_Stop.UseVisualStyleBackColor = true;
            this.bt_Stop.Click += new System.EventHandler(this.Bt_Stop_Click);
            // 
            // bt_Star
            // 
            this.bt_Star.Location = new System.Drawing.Point(34, 62);
            this.bt_Star.Name = "bt_Star";
            this.bt_Star.Size = new System.Drawing.Size(112, 45);
            this.bt_Star.TabIndex = 0;
            this.bt_Star.Text = "启动";
            this.bt_Star.UseVisualStyleBackColor = true;
            this.bt_Star.Click += new System.EventHandler(this.Bt_Star_Click);
            // 
            // tab_MESOperation
            // 
            this.tab_MESOperation.Controls.Add(this.splitContainer8);
            this.tab_MESOperation.Location = new System.Drawing.Point(4, 22);
            this.tab_MESOperation.Margin = new System.Windows.Forms.Padding(2);
            this.tab_MESOperation.Name = "tab_MESOperation";
            this.tab_MESOperation.Padding = new System.Windows.Forms.Padding(2);
            this.tab_MESOperation.Size = new System.Drawing.Size(1896, 974);
            this.tab_MESOperation.TabIndex = 1;
            this.tab_MESOperation.Text = "MES操作";
            this.tab_MESOperation.UseVisualStyleBackColor = true;
            // 
            // splitContainer8
            // 
            this.splitContainer8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer8.Location = new System.Drawing.Point(2, 2);
            this.splitContainer8.Name = "splitContainer8";
            // 
            // splitContainer8.Panel1
            // 
            this.splitContainer8.Panel1.Controls.Add(this.button1);
            this.splitContainer8.Panel1.Controls.Add(this.txtSearchBoxMsg);
            this.splitContainer8.Panel1.Controls.Add(this.cbx_ChaiXiangBoxSN);
            this.splitContainer8.Panel1.Controls.Add(this.rtx_SearchResult);
            this.splitContainer8.Panel1.Controls.Add(this.btnClearDisplay);
            this.splitContainer8.Panel1.Controls.Add(this.bt_Delete);
            this.splitContainer8.Panel1.Controls.Add(this.bt_Search);
            this.splitContainer8.Panel1.Controls.Add(this.label29);
            // 
            // splitContainer8.Panel2
            // 
            this.splitContainer8.Panel2.Controls.Add(this.tx_DeviceID);
            this.splitContainer8.Panel2.Controls.Add(this.tx_InputDeviceID);
            this.splitContainer8.Panel2.Controls.Add(this.tx_InputCheckerID);
            this.splitContainer8.Panel2.Controls.Add(this.tx_InputOpenerID);
            this.splitContainer8.Panel2.Controls.Add(this.tx_InputBatchNo);
            this.splitContainer8.Panel2.Controls.Add(this.label40);
            this.splitContainer8.Panel2.Controls.Add(this.label39);
            this.splitContainer8.Panel2.Controls.Add(this.tx_InputMoNumber);
            this.splitContainer8.Panel2.Controls.Add(this.label38);
            this.splitContainer8.Panel2.Controls.Add(this.label36);
            this.splitContainer8.Panel2.Controls.Add(this.label34);
            this.splitContainer8.Panel2.Controls.Add(this.label31);
            this.splitContainer8.Size = new System.Drawing.Size(1892, 970);
            this.splitContainer8.SplitterDistance = 1215;
            this.splitContainer8.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(765, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "登录接口测试";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // txtSearchBoxMsg
            // 
            this.txtSearchBoxMsg.Location = new System.Drawing.Point(47, 22);
            this.txtSearchBoxMsg.Name = "txtSearchBoxMsg";
            this.txtSearchBoxMsg.Size = new System.Drawing.Size(106, 21);
            this.txtSearchBoxMsg.TabIndex = 8;
            // 
            // cbx_ChaiXiangBoxSN
            // 
            this.cbx_ChaiXiangBoxSN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_ChaiXiangBoxSN.FormattingEnabled = true;
            this.cbx_ChaiXiangBoxSN.Location = new System.Drawing.Point(305, 22);
            this.cbx_ChaiXiangBoxSN.Name = "cbx_ChaiXiangBoxSN";
            this.cbx_ChaiXiangBoxSN.Size = new System.Drawing.Size(115, 20);
            this.cbx_ChaiXiangBoxSN.TabIndex = 7;
            this.cbx_ChaiXiangBoxSN.Visible = false;
            // 
            // rtx_SearchResult
            // 
            this.rtx_SearchResult.Location = new System.Drawing.Point(6, 49);
            this.rtx_SearchResult.Name = "rtx_SearchResult";
            this.rtx_SearchResult.Size = new System.Drawing.Size(1135, 725);
            this.rtx_SearchResult.TabIndex = 6;
            this.rtx_SearchResult.Text = "";
            // 
            // btnClearDisplay
            // 
            this.btnClearDisplay.Location = new System.Drawing.Point(550, 22);
            this.btnClearDisplay.Name = "btnClearDisplay";
            this.btnClearDisplay.Size = new System.Drawing.Size(141, 23);
            this.btnClearDisplay.TabIndex = 5;
            this.btnClearDisplay.Text = "清空显示";
            this.btnClearDisplay.UseVisualStyleBackColor = true;
            this.btnClearDisplay.Click += new System.EventHandler(this.btnClearDisplay_Click);
            // 
            // bt_Delete
            // 
            this.bt_Delete.Location = new System.Drawing.Point(444, 22);
            this.bt_Delete.Name = "bt_Delete";
            this.bt_Delete.Size = new System.Drawing.Size(75, 23);
            this.bt_Delete.TabIndex = 3;
            this.bt_Delete.Text = "拆箱";
            this.bt_Delete.UseVisualStyleBackColor = true;
            this.bt_Delete.Visible = false;
            this.bt_Delete.Click += new System.EventHandler(this.Bt_Delete_Click);
            // 
            // bt_Search
            // 
            this.bt_Search.Location = new System.Drawing.Point(175, 20);
            this.bt_Search.Name = "bt_Search";
            this.bt_Search.Size = new System.Drawing.Size(75, 23);
            this.bt_Search.TabIndex = 2;
            this.bt_Search.Text = "查询";
            this.bt_Search.UseVisualStyleBackColor = true;
            this.bt_Search.Click += new System.EventHandler(this.Bt_Search_Click);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(6, 25);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(35, 12);
            this.label29.TabIndex = 0;
            this.label29.Text = "箱号:";
            // 
            // tx_DeviceID
            // 
            this.tx_DeviceID.Location = new System.Drawing.Point(107, 382);
            this.tx_DeviceID.Name = "tx_DeviceID";
            this.tx_DeviceID.Size = new System.Drawing.Size(125, 21);
            this.tx_DeviceID.TabIndex = 19;
            this.tx_DeviceID.Visible = false;
            // 
            // tx_InputDeviceID
            // 
            this.tx_InputDeviceID.Location = new System.Drawing.Point(107, 342);
            this.tx_InputDeviceID.Name = "tx_InputDeviceID";
            this.tx_InputDeviceID.Size = new System.Drawing.Size(125, 21);
            this.tx_InputDeviceID.TabIndex = 18;
            this.tx_InputDeviceID.Visible = false;
            // 
            // tx_InputCheckerID
            // 
            this.tx_InputCheckerID.Location = new System.Drawing.Point(109, 262);
            this.tx_InputCheckerID.Name = "tx_InputCheckerID";
            this.tx_InputCheckerID.Size = new System.Drawing.Size(125, 21);
            this.tx_InputCheckerID.TabIndex = 16;
            this.tx_InputCheckerID.Visible = false;
            // 
            // tx_InputOpenerID
            // 
            this.tx_InputOpenerID.Location = new System.Drawing.Point(108, 182);
            this.tx_InputOpenerID.Name = "tx_InputOpenerID";
            this.tx_InputOpenerID.Size = new System.Drawing.Size(125, 21);
            this.tx_InputOpenerID.TabIndex = 14;
            this.tx_InputOpenerID.Visible = false;
            // 
            // tx_InputBatchNo
            // 
            this.tx_InputBatchNo.Location = new System.Drawing.Point(108, 102);
            this.tx_InputBatchNo.Name = "tx_InputBatchNo";
            this.tx_InputBatchNo.Size = new System.Drawing.Size(250, 21);
            this.tx_InputBatchNo.TabIndex = 12;
            this.tx_InputBatchNo.Visible = false;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(25, 385);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(77, 12);
            this.label40.TabIndex = 10;
            this.label40.Text = "当前设备号：";
            this.label40.Visible = false;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(25, 345);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(53, 12);
            this.label39.TabIndex = 9;
            this.label39.Text = "设备号：";
            this.label39.Visible = false;
            // 
            // tx_InputMoNumber
            // 
            this.tx_InputMoNumber.Location = new System.Drawing.Point(107, 22);
            this.tx_InputMoNumber.Name = "tx_InputMoNumber";
            this.tx_InputMoNumber.Size = new System.Drawing.Size(250, 21);
            this.tx_InputMoNumber.TabIndex = 8;
            this.tx_InputMoNumber.Visible = false;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(25, 265);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(53, 12);
            this.label38.TabIndex = 6;
            this.label38.Text = "检查人：";
            this.label38.Visible = false;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(25, 185);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(53, 12);
            this.label36.TabIndex = 4;
            this.label36.Text = "扫码人：";
            this.label36.Visible = false;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(25, 105);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(77, 12);
            this.label34.TabIndex = 2;
            this.label34.Text = "批次号输入：";
            this.label34.Visible = false;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(25, 25);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(77, 12);
            this.label31.TabIndex = 0;
            this.label31.Text = "工单号输入：";
            this.label31.Visible = false;
            // 
            // tab_HandOperation
            // 
            this.tab_HandOperation.Controls.Add(this.splitContainer9);
            this.tab_HandOperation.Location = new System.Drawing.Point(4, 22);
            this.tab_HandOperation.Margin = new System.Windows.Forms.Padding(2);
            this.tab_HandOperation.Name = "tab_HandOperation";
            this.tab_HandOperation.Size = new System.Drawing.Size(1896, 974);
            this.tab_HandOperation.TabIndex = 2;
            this.tab_HandOperation.Text = "手动调试";
            this.tab_HandOperation.UseVisualStyleBackColor = true;
            // 
            // splitContainer9
            // 
            this.splitContainer9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer9.Location = new System.Drawing.Point(0, 0);
            this.splitContainer9.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer9.Name = "splitContainer9";
            // 
            // splitContainer9.Panel1
            // 
            this.splitContainer9.Panel1.Controls.Add(this.groBox_ScanHandTest);
            // 
            // splitContainer9.Panel2
            // 
            this.splitContainer9.Panel2.Controls.Add(this.groBox_WeightHandTest);
            this.splitContainer9.Size = new System.Drawing.Size(1896, 974);
            this.splitContainer9.SplitterDistance = 940;
            this.splitContainer9.SplitterWidth = 3;
            this.splitContainer9.TabIndex = 0;
            // 
            // groBox_ScanHandTest
            // 
            this.groBox_ScanHandTest.Controls.Add(this.btn_ScanBox);
            this.groBox_ScanHandTest.Controls.Add(this.bt_ScanHandTestClear);
            this.groBox_ScanHandTest.Controls.Add(this.bt_ScanHandTestStar);
            this.groBox_ScanHandTest.Controls.Add(this.tx_ScanHandTestResult);
            this.groBox_ScanHandTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groBox_ScanHandTest.Location = new System.Drawing.Point(0, 0);
            this.groBox_ScanHandTest.Margin = new System.Windows.Forms.Padding(2);
            this.groBox_ScanHandTest.Name = "groBox_ScanHandTest";
            this.groBox_ScanHandTest.Padding = new System.Windows.Forms.Padding(2);
            this.groBox_ScanHandTest.Size = new System.Drawing.Size(940, 974);
            this.groBox_ScanHandTest.TabIndex = 0;
            this.groBox_ScanHandTest.TabStop = false;
            this.groBox_ScanHandTest.Text = "扫码枪调试";
            // 
            // btn_ScanBox
            // 
            this.btn_ScanBox.Location = new System.Drawing.Point(325, 654);
            this.btn_ScanBox.Margin = new System.Windows.Forms.Padding(2);
            this.btn_ScanBox.Name = "btn_ScanBox";
            this.btn_ScanBox.Size = new System.Drawing.Size(101, 41);
            this.btn_ScanBox.TabIndex = 3;
            this.btn_ScanBox.Text = "分档箱号扫码";
            this.btn_ScanBox.UseVisualStyleBackColor = true;
            this.btn_ScanBox.Visible = false;
            this.btn_ScanBox.Click += new System.EventHandler(this.btn_ScanBox_Click);
            // 
            // bt_ScanHandTestClear
            // 
            this.bt_ScanHandTestClear.Location = new System.Drawing.Point(628, 654);
            this.bt_ScanHandTestClear.Margin = new System.Windows.Forms.Padding(2);
            this.bt_ScanHandTestClear.Name = "bt_ScanHandTestClear";
            this.bt_ScanHandTestClear.Size = new System.Drawing.Size(101, 41);
            this.bt_ScanHandTestClear.TabIndex = 2;
            this.bt_ScanHandTestClear.Text = "扫码清空";
            this.bt_ScanHandTestClear.UseVisualStyleBackColor = true;
            this.bt_ScanHandTestClear.Click += new System.EventHandler(this.bt_ScanHandTestClear_Click);
            // 
            // bt_ScanHandTestStar
            // 
            this.bt_ScanHandTestStar.Location = new System.Drawing.Point(20, 654);
            this.bt_ScanHandTestStar.Margin = new System.Windows.Forms.Padding(2);
            this.bt_ScanHandTestStar.Name = "bt_ScanHandTestStar";
            this.bt_ScanHandTestStar.Size = new System.Drawing.Size(101, 41);
            this.bt_ScanHandTestStar.TabIndex = 1;
            this.bt_ScanHandTestStar.Text = "电池扫码触发";
            this.bt_ScanHandTestStar.UseVisualStyleBackColor = true;
            this.bt_ScanHandTestStar.Click += new System.EventHandler(this.bt_ScanHandTestStar_Click);
            // 
            // tx_ScanHandTestResult
            // 
            this.tx_ScanHandTestResult.Location = new System.Drawing.Point(20, 18);
            this.tx_ScanHandTestResult.Margin = new System.Windows.Forms.Padding(2);
            this.tx_ScanHandTestResult.Multiline = true;
            this.tx_ScanHandTestResult.Name = "tx_ScanHandTestResult";
            this.tx_ScanHandTestResult.Size = new System.Drawing.Size(709, 614);
            this.tx_ScanHandTestResult.TabIndex = 0;
            // 
            // groBox_WeightHandTest
            // 
            this.groBox_WeightHandTest.Controls.Add(this.bt_WeightHandTestClear);
            this.groBox_WeightHandTest.Controls.Add(this.tx_WeightHandTestResult);
            this.groBox_WeightHandTest.Controls.Add(this.bt_WeightHandTestStar);
            this.groBox_WeightHandTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groBox_WeightHandTest.Location = new System.Drawing.Point(0, 0);
            this.groBox_WeightHandTest.Margin = new System.Windows.Forms.Padding(2);
            this.groBox_WeightHandTest.Name = "groBox_WeightHandTest";
            this.groBox_WeightHandTest.Padding = new System.Windows.Forms.Padding(2);
            this.groBox_WeightHandTest.Size = new System.Drawing.Size(953, 974);
            this.groBox_WeightHandTest.TabIndex = 1;
            this.groBox_WeightHandTest.TabStop = false;
            this.groBox_WeightHandTest.Text = "电子秤调试";
            this.groBox_WeightHandTest.Enter += new System.EventHandler(this.groBox_WeightHandTest_Enter);
            // 
            // bt_WeightHandTestClear
            // 
            this.bt_WeightHandTestClear.Location = new System.Drawing.Point(624, 654);
            this.bt_WeightHandTestClear.Margin = new System.Windows.Forms.Padding(2);
            this.bt_WeightHandTestClear.Name = "bt_WeightHandTestClear";
            this.bt_WeightHandTestClear.Size = new System.Drawing.Size(101, 41);
            this.bt_WeightHandTestClear.TabIndex = 5;
            this.bt_WeightHandTestClear.Text = "称重清空";
            this.bt_WeightHandTestClear.UseVisualStyleBackColor = true;
            this.bt_WeightHandTestClear.Click += new System.EventHandler(this.bt_WeightHandTestClear_Click);
            // 
            // tx_WeightHandTestResult
            // 
            this.tx_WeightHandTestResult.Location = new System.Drawing.Point(15, 18);
            this.tx_WeightHandTestResult.Margin = new System.Windows.Forms.Padding(2);
            this.tx_WeightHandTestResult.Multiline = true;
            this.tx_WeightHandTestResult.Name = "tx_WeightHandTestResult";
            this.tx_WeightHandTestResult.Size = new System.Drawing.Size(710, 614);
            this.tx_WeightHandTestResult.TabIndex = 3;
            // 
            // bt_WeightHandTestStar
            // 
            this.bt_WeightHandTestStar.Location = new System.Drawing.Point(15, 654);
            this.bt_WeightHandTestStar.Margin = new System.Windows.Forms.Padding(2);
            this.bt_WeightHandTestStar.Name = "bt_WeightHandTestStar";
            this.bt_WeightHandTestStar.Size = new System.Drawing.Size(101, 41);
            this.bt_WeightHandTestStar.TabIndex = 4;
            this.bt_WeightHandTestStar.Text = "称重触发";
            this.bt_WeightHandTestStar.UseVisualStyleBackColor = true;
            this.bt_WeightHandTestStar.Click += new System.EventHandler(this.bt_WeightHandTestStar_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 18000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自动打包机";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Main_FormClosing);
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tbc.ResumeLayout(false);
            this.tab_ProductInfo.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb_ScanShow.ResumeLayout(false);
            this.gb_ScanShow.PerformLayout();
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.splitContainer6.Panel1.ResumeLayout(false);
            this.splitContainer6.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).EndInit();
            this.splitContainer6.ResumeLayout(false);
            this.splitContainer7.Panel1.ResumeLayout(false);
            this.splitContainer7.Panel2.ResumeLayout(false);
            this.splitContainer7.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer7)).EndInit();
            this.splitContainer7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnClearQuantity)).EndInit();
            this.tab_MESOperation.ResumeLayout(false);
            this.splitContainer8.Panel1.ResumeLayout(false);
            this.splitContainer8.Panel1.PerformLayout();
            this.splitContainer8.Panel2.ResumeLayout(false);
            this.splitContainer8.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer8)).EndInit();
            this.splitContainer8.ResumeLayout(false);
            this.tab_HandOperation.ResumeLayout(false);
            this.splitContainer9.Panel1.ResumeLayout(false);
            this.splitContainer9.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer9)).EndInit();
            this.splitContainer9.ResumeLayout(false);
            this.groBox_ScanHandTest.ResumeLayout(false);
            this.groBox_ScanHandTest.PerformLayout();
            this.groBox_WeightHandTest.ResumeLayout(false);
            this.groBox_WeightHandTest.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lab_plc;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabControl tbc;
        private System.Windows.Forms.TabPage tab_ProductInfo;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TextBox tx_updataCellCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tx_movePlate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txb_RowColPlate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbx_makecode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbx_MI;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbx_room;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tx_ZWeight;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tx_Weight;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tx_boxWeihingSN;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tx_boxScanSN;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tx_Device;
        private System.Windows.Forms.GroupBox gb_ScanShow;
        private System.Windows.Forms.TextBox tx_SN12;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox tx_SN10;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox tx_SN8;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox tx_SN6;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox tx_SN4;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox tx_SN2;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox tx_SN11;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox tx_SN9;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox tx_SN7;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox tx_SN5;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox tx_SN3;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tx_SN1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.SplitContainer splitContainer6;
        private System.Windows.Forms.SplitContainer splitContainer7;
        private System.Windows.Forms.PictureBox btnClearQuantity;
        private System.Windows.Forms.ListView lv_statistical;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Button bt_Init;
        private System.Windows.Forms.Button bt_Stop;
        private System.Windows.Forms.Button bt_Star;
        private System.Windows.Forms.TabPage tab_MESOperation;
        private System.Windows.Forms.SplitContainer splitContainer8;
        private System.Windows.Forms.Button bt_Delete;
        private System.Windows.Forms.Button bt_Search;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox tx_InputDeviceID;
        private System.Windows.Forms.TextBox tx_InputCheckerID;
        private System.Windows.Forms.TextBox tx_InputOpenerID;
        private System.Windows.Forms.TextBox tx_InputBatchNo;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.TextBox tx_InputMoNumber;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TabPage tab_HandOperation;
        private System.Windows.Forms.SplitContainer splitContainer9;
        private System.Windows.Forms.GroupBox groBox_ScanHandTest;
        private System.Windows.Forms.Button bt_ScanHandTestClear;
        private System.Windows.Forms.Button bt_ScanHandTestStar;
        private System.Windows.Forms.TextBox tx_ScanHandTestResult;
        private System.Windows.Forms.GroupBox groBox_WeightHandTest;
        private System.Windows.Forms.Button bt_WeightHandTestClear;
        private System.Windows.Forms.TextBox tx_WeightHandTestResult;
        private System.Windows.Forms.Button bt_WeightHandTestStar;
        private System.Windows.Forms.ListView lv_productInfo;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ListView lv_log;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem UserLogion_ToolStrip;
        private System.Windows.Forms.ToolStripMenuItem Set_ToolStrip;
        private System.Windows.Forms.ToolStripMenuItem 系统参数设定ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 配方设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AdminMange_ToolStrip;
        private System.Windows.Forms.ToolStripMenuItem iO_ToolStrip;
        private System.Windows.Forms.ToolStripMenuItem DevStatus_ToolStrip;
        private System.Windows.Forms.ToolStripMenuItem AdminLock_ToolStrip;
        private System.Windows.Forms.Button btn_ScanBox;
        private System.Windows.Forms.TextBox tx_DeviceID;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.TextBox tx_CheckerID;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TextBox tx_OpenerID;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox tx_BatchNo;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox tx_MoNumber;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Button btn_SaveConfig;
        private System.Windows.Forms.Label lblRunning;
        private System.Windows.Forms.Label lblStoping;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox rtxWeightBoxList;
        private System.Windows.Forms.Button btnClearDisplay;
        private System.Windows.Forms.TextBox txt_DangWei3Sn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_DangWei2Sn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_DangWei1Sn;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RichTextBox rtx_SearchResult;
        private System.Windows.Forms.ComboBox cbx_ChaiXiangBoxSN;
        private System.Windows.Forms.TextBox txtSearchBoxMsg;
        private System.Windows.Forms.ToolStripMenuItem 历史数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 报警信息ToolStripMenuItem;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ComboBox cob_ov;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cob_region;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lb_online;
    }
}