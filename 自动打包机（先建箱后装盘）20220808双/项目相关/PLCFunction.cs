using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LWDBJ
{
    public static class PLCFunction
    {
        /// <summary>
        /// 握手通信命令
        /// </summary>
        /// <returns>返回握手指令</returns>
        public static byte[] HandShake()
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
            Handshake[19] = 0x03;//本机IP地址最后一个数，如254
            return Handshake;
        }


        /// <summary>
        /// 读取PLC数据的指令
        /// </summary>
        /// <param name="addressStart">起始地址</param>
        /// <param name="count">读取数据的个数 小于256</param>
        public static void ReadPLC(int addressStart, int count)
        {
            byte[] buffer = new byte[34];
            buffer[0] = 0X46;//F
            buffer[1] = 0X49;//I
            buffer[2] = 0X4E;//N
            buffer[3] = 0X53;//S
            buffer[4] = 0X00;
            buffer[5] = 0X00;
            buffer[6] = 0X00;
            buffer[7] = 0X1A;//指令从这里开始后面的字数和
            buffer[8] = 0X00;
            buffer[9] = 0X00;
            buffer[10] = 0X00;
            buffer[11] = 0X02;
            buffer[12] = 0X00;
            buffer[13] = 0X00;
            buffer[14] = 0X00;
            buffer[15] = 0X00;
            buffer[16] = 0X80;
            buffer[17] = 0X00;
            buffer[18] = 0X02;
            buffer[19] = 0X00;
            buffer[20] = 1;//PLC地址
            buffer[21] = 0X00;
            buffer[22] = 0X00;
            buffer[23] = 3;//本机IP地址最后一个数
            buffer[24] = 0X00;
            buffer[25] = 0X00;
            //0101代表读
            buffer[26] = 0X01;
            buffer[27] = 0X01;
            //B1表示WR区按字，B0表示CIO按字，30表示CIO按位
            buffer[28] = 0XB0;
            //起始地址
            buffer[29] = Convert.ToByte(addressStart / (int)(Math.Pow(2, 8)));
            buffer[30] = Convert.ToByte(addressStart % (int)(Math.Pow(2, 8)));
            //开始读的首地址
            buffer[31] = 0X00;
            //读取的数据个数
            buffer[32] = Convert.ToByte(count / (int)(Math.Pow(2, 8)));
            buffer[33] = Convert.ToByte(count % (int)(Math.Pow(2, 8)));

            GloVar.PLC_Fine.Send(buffer);
            Thread.Sleep(50);

        }
        /// <summary>
        /// 写PLC指令
        /// </summary>
        /// <param name="addressStart">起始地址</param>
        public static void WritePLC(int addressStart, int count)
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
            buffer_Write[32] = Convert.ToByte(count / (int)(Math.Pow(2, 8)));
            buffer_Write[33] = Convert.ToByte(count % (int)(Math.Pow(2, 8)));//写入的地址个数，100个地址
            //写入的数据
            int index1 = 34;
            for (int i = 0; i < 20; i++)
            {
                buffer_Write[index1] = Convert.ToByte(GloVar.PLC_Write[i] / (int)(Math.Pow(2, 8)));//high
                buffer_Write[index1 + 1] = Convert.ToByte(GloVar.PLC_Write[i] % (int)(Math.Pow(2, 8)));//low
                index1 += 2;
            }
            GloVar.PLC_Fine.Send(buffer_Write);
            Thread.Sleep(10);
            byte[] writeBuffer = new byte[50];
            int writeBufferLength = GloVar.PLC_Fine.Receive(writeBuffer);
        }

        /// <summary>
        /// 解码PLC传来的字节数组
        /// </summary>
        /// <param name="readBuffer">PLC回传的字节数组</param>
        public static void PLCToPCData(byte[] readBuffer)
        {
            try
            {
                int j = 0;
                for (int i = 0; i < 100;)
                {
                    GloVar.PLC_Rread[j] = (short)(readBuffer[30 + i] * 256 + readBuffer[31 + i]);
                    i = i + 2;
                    if (j == 31)
                    {
                        int a;
                    }
                    j++;
                }
            }
            catch (Exception)
            {

            }
        }







    }
}
