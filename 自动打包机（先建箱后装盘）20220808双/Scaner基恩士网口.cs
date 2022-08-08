using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;


public partial class Scaner
{
    private string ip = "127.0.0.1";
    private int port = 60000;
    private int timout = 3000;

    private byte[] strOFF = Encoding.Default.GetBytes("LOFF" + "\r\n");
    private byte[] strON = Encoding.Default.GetBytes("LON" + "\r\n");
    private Socket _Socket;

    private Thread thread_rcv;
    private string dataRecv;

    public bool isConnected = false;

    /// <summary>
    /// 初始化扫码枪
    /// </summary>
    /// <param name="ipAddress">IP地址</param>
    /// <param name="port">端口</param>
    public Scaner(string ipAddress, int port, int timeOut = 3000)
    {
        this.ip = ipAddress;
        this.port = port;
        this.timout = timeOut;
    }

    public void Conn(out string exMsg)
    {
        exMsg = "";
        try
        {
            if (this._Socket != null)
            {
                this._Socket.Close();
                Thread.Sleep(200);
            }

            this._Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipPort = new IPEndPoint(IPAddress.Parse(this.ip), port);
            //this._Socket.ReceiveTimeout = this.timout;
            //this._Socket.SendTimeout = this.timout;
            this._Socket.Connect(ipPort);
            isConnected = true;

            if (thread_rcv != null)
            {
                thread_rcv.Abort();
            }

            thread_rcv = new Thread(Task_Recv);
            thread_rcv.IsBackground = true;
            thread_rcv.Start();

        }
        catch (Exception ex)
        {
            exMsg = ex.Message;
            isConnected = false;
        }
    }
   
    private void Task_Recv()
    {
        try
        {
            while (true)
            {
                // 实际接收到的字节数
                byte[] buffer = new byte[1024];

                //从接收缓冲区接收数据，没果没有数据，会一直阻塞等待
                int recvLen = _Socket.Receive(buffer);

                //recvLen==0表示服务器主动断开自己；
                //recvLen==-1表示网络故障，连接已被迫断开
                if (recvLen < 1)
                {
                    isConnected = false;
                    _Socket.Close();
                    return;
                }
                else
                {
                    dataRecv = Encoding.Default.GetString(buffer).Replace("\0", "");
                }
            }
        }
        catch (Exception)
        {
            isConnected = false;
            _Socket.Close();
        }

    }


    //扫码触发
    public string Scan_Trig(out string exMsg)
    {
        exMsg = string.Empty;

        try
        {
            byte[] buffer = new byte[1024];
            dataRecv = string.Empty;
            this._Socket.Send(strON);
            int tick = Environment.TickCount;
            while (dataRecv == string.Empty)
            {
                if (Environment.TickCount - tick > timout)
                {
                    this._Socket.Send(strOFF);
                    exMsg = "扫码超时";
                    //return "ERROR";
                }

                if (Environment.TickCount - tick > timout + 2000)
                {
                    this._Socket.Send(strOFF);
                    exMsg = "扫码超时";
                    return "ERROR";
                }

                Thread.Sleep(5);
            }

            return dataRecv.Replace("\r", "").Replace("\n", "");

        }
        catch (Exception ex)
        {
            exMsg = "扫码触发方法异常" + ex.Message;

            return "ERROR";

        }
    }
}

