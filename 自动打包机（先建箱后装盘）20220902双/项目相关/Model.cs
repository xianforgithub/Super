using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LWDBJ
{
    public class AdminMange
    {
        public string UserName { get; set; }
        public string Passdowm { get; set; }
        public string MangeLevel { get; set; }
    }

    public class CellParam
    {
        public string CellModel;//电芯型号
        public double werightDowm;//净重下限
        public double werightUp;//净重上限
        public double ZwerightDowm;//毛重下限
        public double ZwerightUp;//毛重上限
        public double BoxWeight;//箱子重量
    }




}
