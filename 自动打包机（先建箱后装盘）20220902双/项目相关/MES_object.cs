using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LWDBJ_自建_.项目相关
{
    class MES_object
    {
    }

    #region 登录接口

    //输入
    public class Login_push
    {
        public string UserNumber = "";             //登录账号，员工输入	
        public string Mi = "";                     //Mi号（生产标准）
        public string PassWord = "";               //登录账号密码，员工输入（页面显示密文）
        public string MachineId = "";              //设备编号，上位机软件的设定值
        public string Formula = "";                //预留字段
        public void Clear()
        {
            this.UserNumber = "";
            this.Mi = "";
            this.PassWord = "";
            this.MachineId = "";
            this.Formula = "";
        }
    }
    //返回
    public class Login_back
    {
        public string status="";                                           //登录结果
        public string result="";                                           //返回信息：“登录成功”
        public string testResult="";                                       //登录权限，1,2,3，---
        public List<string> testResultDetails = new List<string>();     //权限预留字段
        public string remark="";                                           //备注，预留字段
        public void Clear()
        {
            this.status = "";
            this.result = "";
            this.testResult = "";
            this.testResultDetails.Clear();
            this.remark = "";
        }
    }
    #endregion 登录接口

    #region MI号
    //输入
    class TechnicsInfos_push
    {
        
    }
    //返回
    public class MIObject
    {
        public string status { get; set; }           //信息上传状态，true为上传成功，false为上传失败
        public string result { get; set; }
        public string testResult { get; set; }
        public List<MItestResultDetails> testResultDetails { get; set; }          //电芯详细数据信息
        public string remark { get; set; }
    }
    public class MItestResultDetails
    {
        public string technicsName { get; set; }       //工艺名称  H25-A
        public string modelCode { get; set; }         //物料料号  4588
        public string technicsId { get; set; }        //工艺ID    SC-AEC-476589-001
    }
    #endregion MI号
    
    #region 规格参数
    //输入
    public class PackSpecifications_push
    {
        public string TechnicsName { get; set; }      //工艺名称
    }
    //返回
    public class PackSpecifications
    {
        public string status { get; set; }           //信息上传状态，true为上传成功，false为上传失败
        public string result { get; set; }
        public string testResult { get; set; }
        public List < PackDetails> testResultDetails { get; set; }         //详细规格数据列表，无管控项时为空集合
        public string remark { get; set; }

    }
    public class PackDetails
    {
        public string itemcode { get; set; }        
        public string qty { get; set; }                 
        public string boxWeightMin { get; set; }
        public string boxWeightMax { get; set; }
        public string print2PackTimeMin { get; set; }
        public string print2PackTimeMax { get; set; }
        public string isGroup { get; set; }
        public string groupCount { get; set; }
        public string isReserve { get; set; }
        public string reserveNumber { get; set; }
    }
    #endregion 规格参数

    #region 新箱号
    //输入
    class CreateBoxSn_push
    {
        public string Mi { get; set; }          
        public string StepNo { get; set; }   //电压类型
        public string Mo { get; set; }       //工单
        public string Lot { get; set; }       //批次号     
        public string GroupCode { get; set; } //打包代码1163
        public string MachineId { get; set; }  //车间ID
        public string WorkShop { get; set; }   //箱号类型 ： 1      
        public string Type { get; set; }       //操作员工号，登陆时返回的sessionid
        public string OperatorId { get; set; }
        public string TimeStamp { get; set; }           
        public string ItemCode { get; set; }   //MI对应的料号
    }
    //返回
    public class CreateBoxSn_back
    {
        public string status { get; set; }           
        public string result { get; set; }         //箱号  LWJ9922070640002
        public string testResult { get; set; }
        public List<object> testResultDetails { get; set; }          //备用
        public string remark { get; set; }
    }
    #endregion 新箱号

    #region 电芯分组
    //输入
    class GetGroup_push
    {
        public string Sn { get; set; }    //条码
    }
    //返回
    public class GetGroup_back
    {
        public string status { get; set; }
        public string result { get; set; }         
        public string testResult { get; set; }       //返回组别"C,D,D"，需处理成CDD
        public List<object> testResultDetails { get; set; }          //备用
        public string remark { get; set; }
    }
    #endregion 电芯分组

    #region 绑箱
    //输入
    class PackCell2Box2_push
    {
        public string BoxSn { get; set; }    //箱号
        public string ProductSn { get; set; }    //条码
        public string Seq { get; set; }    //电芯位置
        public string Qty { get; set; }    //数量 1
        public string OperatorId { get; set; }    //操作员工号，登陆时返回的sessionid
        public string TimeStamp { get; set; }    
    }
    //返回
    public class PackCell2Box2_back
    {
        public string status { get; set; }
        public string result { get; set; }
        public string testResult { get; set; }       
        public List<object> testResultDetails { get; set; }          //备用
        public string remark { get; set; }
    }
    #endregion 绑箱

    #region 箱子状态更新
    //输入
    class UpdatePackStatus_push
    {
        public string boxSn { get; set; }    //箱号
    }
    //返回
    public class UpdatePackStatus_back
    {
        public string status { get; set; }
        public string result { get; set; }
        public string testResult { get; set; }
        public List<object> testResultDetails { get; set; }          //备用
        public string remark { get; set; }
    }
    #endregion 箱子状态更新

    #region 称重
    //输入
    class FinishPackBox_push
    {
        public string BoxSn { get; set; }    //箱号
        public string Weight { get; set; }    //重量单位是kg
        public string Unit { get; set; }    //kg
        public string MachineId { get; set; }    
        public string TimeStamp { get; set; }    
        public string GroupCode { get; set; }    //工序代码，“1163”
    }
    //返回
    public class FinishPackBox_back
    {
        public string status { get; set; }
        public string result { get; set; }
        public string testResult { get; set; }
        public List<object> testResultDetails { get; set; }          //备用
        public string remark { get; set; }
    }
    #endregion 称重

    #region 记录打印信息
    //输入
    class RecordPrintTimes_push
    {
        public string Sn { get; set; }    //箱号
        public string SnType { get; set; }    //默认是 0
        public string MachineId { get; set; }    
        public string OperatorId { get; set; }
        public string TimeStamp { get; set; }
    }
    //返回
    public class RecordPrintTimes_back
    {
        public string status { get; set; }
        public string result { get; set; }
        public string testResult { get; set; }
        public List<object> testResultDetails { get; set; }          //备用
        public string remark { get; set; }
    }
    #endregion 记录打印信息

    #region 打印箱号标签
    //输入
    class printProductSn_push
    {
        public string BoxSn { get; set; }    //箱号
        public string SnType { get; set; }    //LX ,兰溪
        public string MachineId { get; set; }    
    }
    //返回
    public class printProductSn_back
    {
        public string status { get; set; }
        public string result { get; set; }
        public string testResult { get; set; }
        public List<object> testResultDetails { get; set; }          //备用
        public string remark { get; set; }
    }
    #endregion 打印箱号标签

    #region 箱子解绑
    //输入
    class allFitting_push
    {
        public string BoxSn { get; set; }    //箱号
        public string OperatorId { get; set; }    
        public string TimeStamp { get; set; }
    }
    //返回
    public class allFitting_back
    {
        public string status { get; set; }
        public string result { get; set; }
        public string testResult { get; set; }
        public List<object> testResultDetails { get; set; }          //备用
        public string remark { get; set; }
    }
    #endregion 箱子解绑

    #region 分档
    //输入
    class GetPackageByPackNo_push
    {
        public string BoxSn { get; set; }    //箱号
    }
    //返回
    public class GetPackageByPackNo_back
    {
        public string status { get; set; }           //信息上传状态，true为上传成功，false为上传失败
        public string result { get; set; }
        public string testResult { get; set; }       //预留字段
        public List<GetPackageByPackNoDetails_back> testResultDetails { get; set; }          //MI，电压类型，组别
        public string remark { get; set; }
    }
    public class   GetPackageByPackNoDetails_back
    {
        public string miNo { get; set; }       
        public string voltageType { get; set; }        
        public string groupRecord { get; set; }     
    }
    #endregion 分档
}
