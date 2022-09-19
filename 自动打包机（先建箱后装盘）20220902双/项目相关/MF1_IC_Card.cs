using HFrfid;
using LWDBJ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LWDBJ_自建_.项目相关
{
    //读卡器类
    public  class MF1_IC_Card
    {
        private string port;
        private int rate;
        private static RfidReader Reader = new RfidReader();
        public MF1_IC_Card (string Port, int BaudRate)
        {
            port = Port;
            rate = BaudRate;
        }

        public MF1_IC_Card()
        {
        }

        //读卡方法
        public string  GetCard(out string msg)
        {
            string card = "";
            msg = "";
            try
            {
                if(!Reader.Connect(port, rate))
                {
                    msg = "读卡器连接失败";
                    return card;
                }
                int status;
                byte[] type = new byte[2];
                byte[] id = new byte[4];

                Reader.Cmd = Cmd.M1_ReadId;//读卡号命令
                Reader.Addr = Convert.ToByte("20", 16);//读写器地址,设备号
                Reader.Beep = Beep.On;

                status = Reader.M1_Operation();
                if (status == 0)//读卡成功
                {
                    for (int i = 0; i < 2; i++)//获取2字节卡类型
                    {
                        type[i] = Reader.RxBuffer[i];
                    }
                    for (int i = 0; i < 04; i++)//获取4字节卡号
                    {
                        id[i] = Reader.RxBuffer[i + 2];
                    }
                    card = byteToHexStr(type, 2);
                    card = byteToHexStr(id, 4);            //  CC620EF0    
                    card = To16Convert10(card).ToString().PadLeft(14, '0');  //  3428978416      保存十进制14位数据显示
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return card;
        }
        //数组转十六进制字符    
        public string byteToHexStr(byte[] bytes, int len)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < len; i++)
                {
                    returnStr += bytes[i].ToString("X2");
                }
            }
            return returnStr;
        }

        #region 十六进制字符串转十进制
        static double To16Convert10(string str)
        {
            int res = 0;
            double d = 0;
            StringBuilder sb = new StringBuilder();
            try
            {
                //str = str.Trim().Replace(" ", "");//移除空字符
                for (int i = 0; i < str.Length; i++)
                {
                    int r3 = Convert.ToInt32(str[i].ToString(), 16);
                    d += r3 * Math.Pow(16, str.Length - i - 1);
                }

            }
            catch (Exception e)
            {
                res = 0;
            }

            return d;

        }
        #endregion

    }
}
