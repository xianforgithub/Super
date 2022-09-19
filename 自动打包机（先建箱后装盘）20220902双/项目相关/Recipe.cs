using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LWDBJ
{
    public class Recipe
    {
        public bool GetResultWeght(double Zweight, ref double jingWeight, ref string resCatch, ref string NGItem)
        {
            //return true;//不进行重量范围判断
            try
            {
                jingWeight = Zweight - GloVar.cellParam.BoxWeight;
                if (Zweight>=GloVar.cellParam.ZwerightDowm&& Zweight <= GloVar.cellParam.ZwerightUp)
                {
                    if (jingWeight >= GloVar.cellParam.werightDowm && jingWeight <= GloVar.cellParam.werightUp)
                    {
                        return true;
                    }
                    else
                    {
                        NGItem += "净重不在合格范围";
                        return false;
                    }
                }
                else
                {
                    NGItem += "毛重不在合格范围";
                    return false;
                }
            }
            catch (Exception ex)
            {
                resCatch = ex.Message;
                return false;
            }
        }

    }
}
