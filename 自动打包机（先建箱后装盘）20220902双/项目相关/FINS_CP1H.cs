using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Windows;
namespace LWDBJ
{
    public static class FINS_CP1H
    {
        public static bool[] plcToPC = new bool[16];  // 2998.00-2998.15 PLC-->PC signal
        public static bool[] pcToPlc = new bool[16];  // 3000.00-3000.15 PC-->PLC signal
        public static Int16 pcToPlcInt;  //PC-->PLC 扫码位置数设置
        public static Int16 plcToPcInt;  //PC-->PLC 扫码位置数设置
        public static string ipAddress = "192.168.250.1";///服务器(PLC)IP地址
        private static int portAdress = 9600; //服务器端口号码
        public static int ReadAdress =2998;//PLC 读取地址
        public static int WriteAdress =3000;//PLC 读取地址
        public static bool falgPLCRunErr;

        public static string errorMeg;//错误信息
        private static  byte[] nodeClient, nodeServer;
        private static byte rFinslength;//Fins 
        private static byte rWordLength;//读取字节数
        private static byte wWordLength;//写入字节数
        private static TcpClient mSender; //客户端
        private static Socket mSock;      //套接字
        private static readonly Int32[] bit = new Int32[32]; //解码从PLC读出数据的待用数组
        private static bool _connected = false; //定义连接字段 默认断开
        private static bool Connected//定义连接属性
        {
            get { return _connected; }
            set { _connected = value; }
        }
   
        private static byte byteLengthHandle(Int32 rLength)
        {
            string countStr=Convert.ToString(rLength,16).ToUpper();
            byte byteData=20;
            if (countStr.Length ==1)
            {
               // countStr="0"+countStr;
                countStr = "0x01";
                byteData = Convert.ToByte(countStr);
            }
            if (countStr.Length ==2)
            {
                byteData=Convert.ToByte("0x"+countStr);
            }
            return byteData;
        }
        /// <summary>
        /// 读CIO区指定长度数据数据
        /// </summary>
        /// <param name="readAddress">读地址</param>
        /// <param name="_dataFromPLC">读出PLC数据</param>
        /// <returns>读成功返回true，失败返回false</returns>
        public static bool ReadSomeWord(int readAddress, out string _dataFromPLC, Int32 readLength)
        {
           // wLength = readLength;
            ////rWordLength = byteLengthHandle(readLength);
            ////rFinslength = byteLengthHandle(readLength + 20);
            rFinslength = 0x1C;
            rWordLength = 0x01;
            wWordLength = 0x01;
            _dataFromPLC = "";
            try
            {
                if (!Connected)
                {
                    if (!Connect())
                    {
                        return false;
                    }
                }
                byte[] readBackBuffer2 = new byte[40];
                mSock.Send(ReadCMD(readAddress), SocketFlags.None);
                mSock.Receive(readBackBuffer2);
                if (CheckHeadError(readBackBuffer2[15]))//no header error
                {
                    if (CheckEndCode(readBackBuffer2[28], readBackBuffer2[29]))//Fins响应帧 no error
                    {
                        //string bufferData = Convert.ToString(readBackBuffer[30], 16).PadLeft(2, '0') + Convert.ToString(readBackBuffer[31], 16).PadLeft(2, '0');
                        for (int ii = 0; ii < 1 ; ii++)
                        {
                            _dataFromPLC += Hex_TO_Dec(Convert.ToString(readBackBuffer2[30 + ii], 16).PadLeft(2, '0') + Convert.ToString(readBackBuffer2[31 + ii], 16).PadLeft(2, '0')).ToString() + ",";
                        }
                        
                    }
                }
                 return true;
            }
            catch (Exception ex)
            {
                errorMeg = ex.Message;
                return false;
            }
        }
        /// <summary>
        /// 写 CIO区指定长度数据数据,写入格式“80,90,100”；
        /// </summary>
        /// <param name="writeAddress">写地址</param>
        /// <param name="_dataToPLC">写入PLC数据</param>
        /// <returns>读成功返回true，失败返回false</returns>
        public static bool WriteSomeWord(int writeAddress, ref string _dataToPLC, Int32 writeLength)
        {
            try
            {

                ////wLength = writeLength;
                ////wWordLength = byteLengthHandle(writeLength);
                ////rFinslength = byteLengthHandle(writeLength + 20);
            
                rWordLength = 0x01;
                wWordLength = 0x01;
                if (!Connected)
                {
                    if (!Connect())
                    {
                        return false;
                    }
                }
                byte[] readBackBuffer3 = new byte[40];
                mSock.SendTimeout = 600;
                mSock.Send(WriteSomeCMD(writeAddress, _dataToPLC), SocketFlags.None);
                mSock.ReceiveTimeout = 600;
                mSock.Receive(readBackBuffer3);
                if (CheckHeadError(readBackBuffer3[15]))//no header error
                {
                    if (CheckEndCode(readBackBuffer3[28], readBackBuffer3[29]))//true
                    {
                        //do nothing
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                errorMeg = ex.Message;
                return false;
            }
        }
        /// <summary>
        /// 读写CIO区域16个位数据
        /// </summary>
        /// <param name="readAddress">读地址</param>
        /// <param name="writeAddress">写地址</param>
        /// <param name="_ioFromPLC">读出PLC数据</param>
        /// <param name="_ioToPLC">写入PLC数据</param>
        /// <returns>读写成功返回true，失败返回false</returns>
        public static  bool RWPlc16Bit(int readAddress, int writeAddress, ref bool[] _ioFromPLC, ref bool[] _ioToPLC)
        {
            try
            {
                if (!Connected)
                {
                    if(!Connect())
                    {
                        return false;
                    }
                }
                rFinslength = 0x1C;
                rWordLength = 0x01;
                wWordLength = 0x01;
              _ioFromPLC=ReadData(readAddress);
               WriteData(writeAddress, _ioToPLC);
                return true;
            }
            catch (Exception ex)
            {
                errorMeg=ex.Message;
                return false;
            }
        }

        /// <summary>
        /// 读取数据
        /// </summary>
        /// <returns>返回读取的数据</returns>
        private static bool[] ReadData(int rAddress)
        {
            bool[] _ioform32 = new bool[32];


            mSock.Send(ReadCMD(rAddress), SocketFlags.None);
            byte[] readBackBuffer1 = new byte[40];
            mSock.ReceiveTimeout = 500;
            mSock.Receive(readBackBuffer1);
            if (CheckHeadError(readBackBuffer1[15]))//no header error
            {
                if (CheckEndCode(readBackBuffer1[28], readBackBuffer1[29]))//Fins响应帧 no error
                {
                    string bufferData = Convert.ToString(readBackBuffer1[30], 16).PadLeft(2, '0') + Convert.ToString(readBackBuffer1[31], 16).PadLeft(2, '0');
                    DecodePLC(bufferData, _ioform32);
                    return _ioform32;
                }
            }
            return _ioform32;
        }
        /// <summary>
        /// 读取指令
        /// </summary>
        /// <returns>返回读取指令</returns>
        private static byte[] ReadCMD(int ReadPLCAdress)
        {
            byte[] FullCmd = new byte[34];
            //TCP FINS header
            FullCmd[0] = 0x46;//F
            FullCmd[1] = 0x49;//I
            FullCmd[2] = 0x4e;//N
            FullCmd[3] = 0x53;//S
            //length
            FullCmd[4] = 0x00;
            FullCmd[5] = 0x00;
            FullCmd[6] = 0x00;
            //FullCmd[7] = rFinslength;//字节
            FullCmd[7] = 0x1A;//字节 26个字节，
            //command
            FullCmd[8] = 0x00;
            FullCmd[9] = 0x00;
            FullCmd[10] = 0x00;
            FullCmd[11] = 0x02;
            //Error Code
            FullCmd[12] = 0x00;
            FullCmd[13] = 0x00;
            FullCmd[14] = 0x00;
            FullCmd[15] = 0x00;
            //FINS Frame header
            FullCmd[16] = 0x80;//ICF:Displays frame information:80要求有回复，81不要求有回复
            FullCmd[17] = 0x00;//RSV:Reserved by system ，默认00
            FullCmd[18] = 0x02;//GCT:Permissible number of gateways，表示穿过的网络层数，0层为02,1层为01，2层为00
            FullCmd[19] = 0x00;//DNA: Distination network address,目的网络地址
            FullCmd[20] = 0x01;//DA1：目的节点地址，默认是目的PLC的IP地址的最后位，16进制表示，eg,192.1.1.24,该段为18
            FullCmd[21] = 0x00;//DA2, 目的单元地址
            FullCmd[22] = 0x00;//SNA, local network，源网络地址
            FullCmd[23] = 31;//SA1，源节点地址，即上位机IP地址的最后位，16进制表示
            FullCmd[24] = 0x00;//SA2, 源单元地址
            FullCmd[25] = 0x00; //SID段----10
            //FINS ReadCommand 0101 ,写指令0102
            FullCmd[26] = 0x01;//MRC Fins主指令
            FullCmd[27] = 0x01;//SRC Fins从指令
            FullCmd[28] = 0xB0;//相应区域和具体方式，B1表示WR区按字，B0表示CIO按字，30表示CIO按位
            //读取的寄存器地址
            FullCmd[29] = Convert.ToByte(ReadPLCAdress / (int)(Math.Pow(2, 8)));
            FullCmd[30] = Convert.ToByte(ReadPLCAdress % (int)(Math.Pow(2, 8)));
            //开始位首地址
            FullCmd[31] = 0x00;
            //读取的字数目
            FullCmd[32] = 0x00;
            FullCmd[33] = rWordLength;//字数
            return FullCmd;
        }
        /// <summary>
        /// FINS写入命令
        /// </summary>
        /// <param name="data">要写入的数据</param>
        /// <returns>返回写入的指令</returns>
        private static byte[] WriteCMD(int WritePLCAdress, string data)
        {
            byte[] FullCmd = new byte[36];
            //TCP FINS header
            FullCmd[0] = 0x46;//F
            FullCmd[1] = 0x49;//I
            FullCmd[2] = 0x4e;//N
            FullCmd[3] = 0x53;//S
            //cmd length
            FullCmd[4] = 0;
            FullCmd[5] = 0;
            FullCmd[6] = 0;
            // FullCmd[7] = rFinslength;
            FullCmd[7] = 0x1C;//从[8]开始到要传送的长度的末尾，因为现在只写入一个0x01，所以长度是[8] -[33]一共26个，[34][35]是要写入的数据，所以是1C  如果要写入49个地址，那就是26 + 49 * 2
            //frame command
            FullCmd[8] = 0;
            FullCmd[9] = 0;
            FullCmd[10] = 0;
            FullCmd[11] = 0x02; 
            //err
            FullCmd[12] = 0;
            FullCmd[13] = 0;
            FullCmd[14] = 0;
            FullCmd[15] = 0;
            //command frame header
            FullCmd[16] = 0x80;//ICF
            FullCmd[17] = 0x00;//RSV
            FullCmd[18] = 0x02;//GCT, less than 8 network layers
            FullCmd[19] = 0x00;//DNA, local network
            FullCmd[20] = 1;//Server[3];//DA1
            FullCmd[21] = 0x00;//DA2, CPU unit
            FullCmd[22] = 0x00;//SNA, local network
            FullCmd[23] = 31;//Client[3];//SA1
            FullCmd[24] = 0x00;//SA2, CPU unit
            FullCmd[25] = 0x00;//Convert.ToByte(21);//SID
            //FINS Command 0102 -memory area write
            FullCmd[26] = 0x01;
            FullCmd[27] = 0x02;
            //寄存器区域
            FullCmd[28] = 0xB0; //按照Bit读取 (0xB0:按1word=16bit读取)
            //var Head = new HeadAddress(WriteAdress);
            //写入的通道地址
            FullCmd[29] = Convert.ToByte(WritePLCAdress / (int)(Math.Pow(2, 8)));
            FullCmd[30] = Convert.ToByte(WritePLCAdress % (int)(Math.Pow(2, 8)));
            //写入的起始位数
            FullCmd[31] = 0;
            //写入的个数
            FullCmd[32] = 0;
            FullCmd[33] = wWordLength;
            //写入一个字
            //data = "0001";
            Int32 _dataT = Convert.ToInt32(data, 16);
            FullCmd[34] = Convert.ToByte(_dataT / (int)(Math.Pow(2, 8)));//要写入的数据
            FullCmd[35] = Convert.ToByte(_dataT % (int)(Math.Pow(2, 8)));//要写入的数据
            return FullCmd;
        }
        /// <summary>
        /// FINS写入命令
        /// </summary>
        /// <param name="data">要写入的数据</param>
        /// <returns>返回写入的指令</returns>
        private static byte[] WriteSomeCMD(int WritePLCAdress, string data)
        {
            
            byte[] FullCmd = new byte[36];
            //TCP FINS header
            FullCmd[0] = 0x46;//F
            FullCmd[1] = 0x49;//I
            FullCmd[2] = 0x4e;//N
            FullCmd[3] = 0x53;//S
            //cmd length
            FullCmd[4] = 0;
            FullCmd[5] = 0;
            FullCmd[6] = 0;
            FullCmd[7] = rFinslength;
            //frame command
            FullCmd[8] = 0;
            FullCmd[9] = 0;
            FullCmd[10] = 0;
            FullCmd[11] = 0x02;
            //err
            FullCmd[12] = 0;
            FullCmd[13] = 0;
            FullCmd[14] = 0;
            FullCmd[15] = 0;
            //command frame header
            FullCmd[16] = 0x80;//ICF
            FullCmd[17] = 0x00;//RSV
            FullCmd[18] = 0x02;//GCT, less than 8 network layers
            FullCmd[19] = 0x00;//DNA, local network
            FullCmd[20] = 1;//Server[3];//DA1
            FullCmd[21] = 0x00;//DA2, CPU unit
            FullCmd[22] = 0x00;//SNA, local network
            FullCmd[23] = 31;//Client[3];//SA1
            FullCmd[24] = 0x00;//SA2, CPU unit
            FullCmd[25] = 0x00;//Convert.ToByte(21);//SID
            //FINS Command 0102 -memory area write
            FullCmd[26] = 0x01;
            FullCmd[27] = 0x02;
            //寄存器区域
            FullCmd[28] = 0xB0; //按照Bit读取 (0xB0:按1word=16bit读取)
            //var Head = new HeadAddress(WriteAdress);
            //写入的通道地址
            FullCmd[29] = Convert.ToByte(WritePLCAdress / (int)(Math.Pow(2, 8)));
            FullCmd[30] = Convert.ToByte(WritePLCAdress % (int)(Math.Pow(2, 8)));
            //写入的起始位数
            FullCmd[31] = 0;
            //写入的个数
            FullCmd[32] = 0;
            FullCmd[33] = wWordLength;
            //写入一个字
            string[] wData=data.Split(',');
            for (int ii = 0; ii < wData.Length; ii++)
            {
                Int32 _dataT = Convert.ToInt32(wData[ii]);
                FullCmd[34+ii] = Convert.ToByte(_dataT / (int)(Math.Pow(2, 8)));//要写入的数据
                FullCmd[35+ii] = Convert.ToByte(_dataT % (int)(Math.Pow(2, 8)));//要写入的数据
            }
           
            return FullCmd;
        }
        /// <summary>
        /// 输出信号状态给PLC
        /// </summary>
        /// <param name="writeIO">准备输出的布尔型数组-标示各个位的状态</param>
        private static void WriteData(int wAdress, bool[] writeIO)
        {
            string writtenData = GetPLCOutStr(writeIO);
         
           // mSock.SendTimeout = 500;
            byte[] by;
            by = WriteCMD(wAdress, writtenData);
            mSock.Send(WriteCMD(wAdress, writtenData), SocketFlags.None);
            byte[] writeBackBuffer1 = new byte[40];
            mSock.ReceiveTimeout = 500;
            mSock.Receive(writeBackBuffer1);
            if (CheckHeadError(writeBackBuffer1[15]))//no header error
            {
                if (CheckEndCode(writeBackBuffer1[28], writeBackBuffer1[29]))//true
                {
                    //do nothing
                }
            }
        }
        /// <summary>
        /// 握手建立通信
        /// </summary>
        /// <returns>返回通信状态</returns>
        private static bool Connect()
        {
            try
            {
                if (Connected)
                {
                    mSender.Close();
                    Connected = false;
                }
                mSender = new TcpClient(ipAddress, portAdress);
                mSock = mSender.Client;
                mSock.SendTimeout = 1000;
                mSock.Send(HandShake());
                byte[] buffer = new byte[24];
                mSock.ReceiveTimeout = 1000;
                mSock.Receive(buffer, SocketFlags.None);
                {
                    if(buffer[15]==0x00)
                    {
                    //获取客户端节点号码-四个字节pc
                    nodeClient = new byte[4];
                    nodeClient[0] = buffer[16];
                    nodeClient[1] = buffer[17];
                    nodeClient[2] = buffer[18];
                    nodeClient[3] = buffer[19];
                    //获取服务器节点号码-4个字节plc
                    nodeServer = new byte[4];
                    nodeServer[0] = buffer[20];
                    nodeServer[1] = buffer[21];
                    nodeServer[2] = buffer[22];
                    nodeServer[3] = buffer[23];
                    Connected = true;
                    return true;
                    }
                    else 
                    {
                        Connected = false;
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Connected = false;
                errorMeg =ex.Message; 
                return false;

            }
        }
        /// <summary>
        /// 布尔型字节数组转换成十六进制字符串 
        /// </summary>
        /// <param name="_out">输出Out状态</param>
        /// <returns>返回编辑好的输出指令</returns>
        private static string GetPLCOutStr(bool[] _out)
        {
            string _sender = "";
            if (_out.Length <= 16)
            {
                for (int i = 0; i < 16; )
                {
                    int _tmpRes = 0;
                    if (_out[i + 0]) _tmpRes = _tmpRes + (int)Math.Pow(2, 0);
                    if (_out[i + 1]) _tmpRes = _tmpRes + (int)Math.Pow(2, 1);
                    if (_out[i + 2]) _tmpRes = _tmpRes + (int)Math.Pow(2, 2);
                    if (_out[i + 3]) _tmpRes = _tmpRes + (int)Math.Pow(2, 3);
                    _sender = Convert.ToString(_tmpRes, 16) + _sender;
                    i += 4;
                }
            }
            else if (_out.Length <= 32)
            {
                for (int i = 16; i < 32; )
                {
                    int _tmpRes = 0;
                    if (_out[i + 0]) _tmpRes = _tmpRes + (int)Math.Pow(2, 0);
                    if (_out[i + 1]) _tmpRes = _tmpRes + (int)Math.Pow(2, 1);
                    if (_out[i + 2]) _tmpRes = _tmpRes + (int)Math.Pow(2, 2);
                    if (_out[i + 3]) _tmpRes = _tmpRes + (int)Math.Pow(2, 3);
                    _sender = Convert.ToString(_tmpRes, 16) + _sender;
                    i += 4;
                }
                for (int i = 0; i < 16; )
                {
                    int _tmpRes = 0;
                    if (_out[i + 0]) _tmpRes = _tmpRes + (int)Math.Pow(2, 0);
                    if (_out[i + 1]) _tmpRes = _tmpRes + (int)Math.Pow(2, 1);
                    if (_out[i + 2]) _tmpRes = _tmpRes + (int)Math.Pow(2, 2);
                    if (_out[i + 3]) _tmpRes = _tmpRes + (int)Math.Pow(2, 3);
                    _sender = Convert.ToString(_tmpRes, 16) + _sender;
                    i += 4;
                }
            }
            return _sender;
        }
        /// <summary>
        /// （若返回的头指令为3）检查命令头中的错误代码
        /// </summary>
        /// <param name="Code">错误代码</param>
        /// <returns>指示程序是否可以继续进行</returns>
        private static  bool CheckHeadError(byte Code)
        {
            switch (Code)
            {
                case 0x00: return true;
                case 0x01: RaiseException("the head is not 'FINS'"); return false;
                case 0x02: RaiseException("the data length is too long"); return false;
                case 0x03: RaiseException("the command is not supported"); return false;
            }
            //no hit
            RaiseException("unknown exception"); return false;
        }
        private static void RaiseException(string p)
        {
            errorMeg=p;
            Connected = false;
        }
        /// <summary>
        /// 十六进制转化成十进制
        /// </summary>
        /// <param name="value">待转化的字符串(ASII)</param>
        /// <returns>返回的整数型（十进制）</returns>
        private  static Int32 Hex_TO_Dec(string value)
        {
            return Convert.ToInt32(value, 16);
        }
        /// <summary>
        /// PLC 解码操作-十六进制字符串转换成字节数组
        /// </summary>
        /// <param name="_code">待解码的字符串</param>
        /// <param name="_res">解码后->存储的数组</param> 
        private static void DecodePLC(string _code, bool[] _res)
        {
            for (int i = 0; i < bit.Length; i++)
            {
                bit[i] = 1 << i;
            }
            int _resdec = Convert.ToInt32(_code, 16);
            int _p;
            for (int i = 0; i < 16; i++)
            {
                _p = _resdec & bit[i];
                if (_p != 0)
                {
                    _res[i] = true;
                }
                else
                {
                    _res[i] = false;
                }
            }
        }
        /// <summary>
        /// 检查命令帧中的EndCode
        /// </summary>
        /// <param name="Main">主码</param>
        /// <param name="Sub">副码</param>
        /// <returns>指示程序是否可以继续进行</returns>
        private static bool CheckEndCode(byte Main, byte Sub)
        {
            switch (Main)
            {
                case 0x00:
                    switch (Sub)
                    {
                        case 0x00: return true;//the only situation of success
                        case 0x01: RaiseException("service canceled"); return false;
                    }
                    break;
                case 0x01:
                    switch (Sub)
                    {
                        case 0x01: RaiseException("local node not in network"); return false;
                        case 0x02: RaiseException("token timeout"); return false;
                        case 0x03: RaiseException("retries failed"); return false;
                        case 0x04: RaiseException("too many send frames"); return false;
                        case 0x05: RaiseException("node address range error"); return false;
                        case 0x06: RaiseException("node address duplication"); return false;
                    }
                    break;
                case 0x02:
                    switch (Sub)
                    {
                        case 0x01: RaiseException("destination node not in network"); return false;
                        case 0x02: RaiseException("unit missing"); return false;
                        case 0x03: RaiseException("third node missing"); return false;
                        case 0x04: RaiseException("destination node busy"); return false;
                        case 0x05: RaiseException("response timeout"); return false;
                    }
                    break;
                case 0x03:
                    switch (Sub)
                    {
                        case 0x01: RaiseException("communications controller error"); return false;
                        case 0x02: RaiseException("CPU unit error"); return false;
                        case 0x03: RaiseException("controller error"); return false;
                        case 0x04: RaiseException("unit number error"); return false;
                    }
                    break;
                case 0x04:
                    switch (Sub)
                    {
                        case 0x01: RaiseException("undefined command"); return false;
                        case 0x02: RaiseException("not supported by model/version"); return false;
                    }
                    break;
                case 0x05:
                    switch (Sub)
                    {
                        case 0x01: RaiseException("destination address setting error"); return false;
                        case 0x02: RaiseException("no routing tables"); return false;
                        case 0x03: RaiseException("routing table error"); return false;
                        case 0x04: RaiseException("too many relays"); return false;
                    }
                    break;
                case 0x10:
                    switch (Sub)
                    {
                        case 0x01: RaiseException("command too long"); return false;
                        case 0x02: RaiseException("command too short"); return false;
                        case 0x03: RaiseException("elements/data don't match"); return false;
                        case 0x04: RaiseException("command format error"); return false;
                        case 0x05: RaiseException("header error"); return false;
                    }
                    break;
                case 0x11:
                    switch (Sub)
                    {
                        case 0x01: RaiseException("area classification missing"); return false;
                        case 0x02: RaiseException("access size error"); return false;
                        case 0x03: RaiseException("address range error"); return false;
                        case 0x04: RaiseException("address range exceeded"); return false;
                        case 0x06: RaiseException("program missing"); return false;
                        case 0x09: RaiseException("relational error"); return false;
                        case 0x0a: RaiseException("duplicate data access"); return false;
                        case 0x0b: RaiseException("response too long"); return false;
                        case 0x0c: RaiseException("parameter error"); return false;
                    }
                    break;
                case 0x20:
                    switch (Sub)
                    {
                        case 0x02: RaiseException("protected"); return false;
                        case 0x03: RaiseException("table missing"); return false;
                        case 0x04: RaiseException("data missing"); return false;
                        case 0x05: RaiseException("program missing"); return false;
                        case 0x06: RaiseException("file missing"); return false;
                        case 0x07: RaiseException("data mismatch"); return false;
                    }
                    break;
                case 0x21:
                    switch (Sub)
                    {
                        case 0x01: RaiseException("read-only"); return false;
                        case 0x02: RaiseException("protected , cannot write data link table"); return false;
                        case 0x03: RaiseException("cannot register"); return false;
                        case 0x05: RaiseException("program missing"); return false;
                        case 0x06: RaiseException("file missing"); return false;
                        case 0x07: RaiseException("file name already exists"); return false;
                        case 0x08: RaiseException("cannot change"); return false;
                    }
                    break;
                case 0x22:
                    switch (Sub)
                    {
                        case 0x01: RaiseException("not possible during execution"); return false;
                        case 0x02: RaiseException("not possible while running"); return false;
                        case 0x03: RaiseException("wrong PLC mode"); return false;
                        case 0x04: RaiseException("wrong PLC mode"); return false;
                        case 0x05: RaiseException("wrong PLC mode"); return false;
                        case 0x06: RaiseException("wrong PLC mode"); return false;
                        case 0x07: RaiseException("specified node not polling node"); return false;
                        case 0x08: RaiseException("step cannot be executed"); return false;
                    }
                    break;
                case 0x23:
                    switch (Sub)
                    {
                        case 0x01: RaiseException("file device missing"); return false;
                        case 0x02: RaiseException("memory missing"); return false;
                        case 0x03: RaiseException("clock missing"); return false;
                    }
                    break;
                case 0x24:
                    switch (Sub)
                    { case 0x01:RaiseException("table missing"); return false; }
                    break;
                case 0x25:
                    switch (Sub)
                    {
                        case 0x02: RaiseException("memory error"); return false;
                        case 0x03: RaiseException("I/O setting error"); return false;
                        case 0x04: RaiseException("too many I/O points"); return false;
                        case 0x05: RaiseException("CPU bus error"); return false;
                        case 0x06: RaiseException("I/O duplication"); return false;
                        case 0x07: RaiseException("CPU bus error"); return false;
                        case 0x09: RaiseException("SYSMAC BUS/2 error"); return false;
                        case 0x0a: RaiseException("CPU bus unit error"); return false;
                        case 0x0d: RaiseException("SYSMAC BUS No. duplication"); return false;
                        case 0x0f: RaiseException("memory error"); return false;
                        case 0x10: RaiseException("SYSMAC BUS terminator missing"); return false;
                    }
                    break;
                case 0x26:
                    switch (Sub)
                    {
                        case 0x01: RaiseException("no protection"); return false;
                        case 0x02: RaiseException("incorrect password"); return false;
                        case 0x04: RaiseException("protected"); return false;
                        case 0x05: RaiseException("service already executing"); return false;
                        case 0x06: RaiseException("service stopped"); return false;
                        case 0x07: RaiseException("no execution right"); return false;
                        case 0x08: RaiseException("settings required before execution"); return false;
                        case 0x09: RaiseException("necessary items not set"); return false;
                        case 0x0a: RaiseException("number already defined"); return false;
                        case 0x0b: RaiseException("error will not clear"); return false;
                    }
                    break;
                case 0x30:
                    switch (Sub)
                    { case 0x01:RaiseException("no access right"); return false; }
                    break;
                case 0x40:
                    switch (Sub)
                    { case 0x01:RaiseException("service aborted"); return false; }
                    break;
            }
            //no hit
            RaiseException("unknown exception"); return false;
        }
        /// <summary>
        /// 握手通信命令
        /// </summary>
        /// <returns>返回握手指令</returns>
        private static byte[] HandShake()
        {
            //handshake
            byte[] Handshake = new byte[20];
            //ASII 码：FINS
            Handshake[0] = 0x46;//F
            Handshake[1] = 0x49;//I
            Handshake[2] = 0x4e;//N
            Handshake[3] = 0x53;//S
            //以下命令字节长度-12字节（握手）
            Handshake[4] = 0x00;
            Handshake[5] = 0x00;
            Handshake[6] = 0x00;
            Handshake[7] = 0x0C;//12字节长度(以下字节总数)
            //Command 
            Handshake[8] = 0x00;
            Handshake[9] = 0x00;
            Handshake[10] = 0x00;
            Handshake[11] = 0x00;
            //Error Code
            Handshake[12] = 0x00;
            Handshake[13] = 0x00;
            Handshake[14] = 0x00;
            Handshake[15] = 0x00;
            //客户端节点地址-自动获取客户端节点号码(0000)
            Handshake[16] = 0x00;
            Handshake[17] = 0x00;
            Handshake[18] = 0x00;
            Handshake[19] = 31;//ksd for client and server node number, the client node will allocated automatically
            return Handshake;
        }
        #region 基础类

        /// <summary>
        /// 代表一个内存的地址
        /// </summary>
        public  class HeadAddress
        {
            /// <summary>
            /// 代表欧姆龙PLC中一个内存的地址
            /// </summary>
            /// <param name="FullHeadAddress">地址的文本表示，形如：DM.100.0。
            /// <para>区域名称与Areas枚举成员一致。</para>
            /// </param>
            public HeadAddress(string FullHeadAddress)
            {
                string[] AddrParts = FullHeadAddress.Split('.');
                Area = (Areas)Enum.Parse(typeof(Areas), AddrParts[0]);
                CH = Convert.ToUInt16(AddrParts[1]);
                BIT = Convert.ToByte(AddrParts[2]);
            }
            /// <summary>
            /// 内部使用：空的构造函数
            /// </summary>
            internal HeadAddress() { }
            /// <summary>
            /// 区域
            /// </summary>
            public Areas Area;
            /// <summary>
            /// 通道
            /// </summary>
            public ushort CH;
            /// <summary>
            /// 位，0~15
            /// </summary>
            public byte BIT;

            /// <summary>
            /// 克隆此实例，返回一个包含相同地址信息的实例
            /// </summary>
            /// <returns>包含相同地址信息的新实例</returns>
            public HeadAddress Clone()
            {
                HeadAddress Target = new HeadAddress();
                Target.Area = this.Area;
                Target.CH = this.CH;
                Target.BIT = this.BIT;
                return Target;
            }
            /// <summary>
            /// 在通道数上加指定的偏移量
            /// </summary>
            /// <param name="Offset">偏移量，应为正数</param>
            public void PlusCH(int Offset)
            { CH = (byte)(CH + Offset); }
            /// <summary>
            /// 在位数上加指定的偏移量
            /// </summary>
            /// <param name="Offset">偏移量，应为正数</param>
            public void PlusBIT(int Offset)
            {
                int DiffCache = 0x0F - BIT;
                if (DiffCache < Offset)
                    BIT = (byte)(BIT + Offset);
                else
                {
                    int SumCache = BIT + Offset;
                    int CHRise = SumCache / 16;
                    int BITNew = SumCache % 16;
                    BIT = (byte)BITNew;
                    PlusCH(CHRise);
                }
            }
        }

        /// <summary>
        /// 列举已支持的内存区域
        /// 存储区操作Code
        /// CIO:bit(0x30)/word(0xB0)
        /// DM:bit(0x02)/word(0x82)
        /// WR:bit(0x31)/word(0xB1)
        /// </summary>
        public enum Areas
        {
            /// <summary>
            /// CIO区 eg:2990
            /// </summary>
            CIO,
            /// <summary>
            /// D区 eg:D23
            /// </summary>
            DM,
            /// <summary>
            /// W区 eg:W100
            /// </summary>
            WR
        }
        #endregion
    }
}

