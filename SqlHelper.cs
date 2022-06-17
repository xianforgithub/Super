using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data;
using MySql.Data.MySqlClient;


namespace LWDBJ
{
    public static class SqlHelper
    {
		string s="123";
        // 插入信息到数据库(scancz和weight)
        public static void InsertSQLData(string txt)
        {
            
            try
            {
                MySqlConnection con = new MySqlConnection(GloVar.SqlConn);
                con.Open();
                using (con)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = txt;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                string faileName = DateTime.Now.ToString("yyyy-MM-dd") + "_other.txt";
                SysFunction.SaveLog(faileName, "保存数据到数据库异常", ex.ToString());
            }
        }
       
        //批量写入scancz01
        public static void InsertSQLAll(string sql)
        {
            try
            {
                MySqlConnection mcon = new MySqlConnection(GloVar.SqlConn);
                mcon.Open();
                MySqlCommand mcom = new MySqlCommand(sql, mcon);
                mcom.ExecuteNonQuery();
                mcon.Close();
            }
            catch(Exception ex)
            {

            }
            
        }
        public static void InsertSQLData(string txt, out int index)
        {
            index = 0;
            try
            {
                MySqlConnection con = new MySqlConnection(GloVar.SqlConn);
                con.Open();
                using (con)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = txt;
                    index = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                string faileName = DateTime.Now.ToString("yyyy-MM-dd") + "_other.txt";
                SysFunction.SaveLog(faileName, "保存数据到数据库异常", ex.ToString());
            }
        }

        //查询账号
        public static List<AdminMange> SearchAdminMange(string UserName, string Passdowm, string MangeLevel)
        {
            try
            {
                string sql = "select * from AdminMange where UserName like '%" + UserName + "%' and Passdowm like '%" + Passdowm + "%' and MangeLevel like '%" + MangeLevel + "%'";
                List<AdminMange> list = new List<AdminMange>();
                MySqlConnection con = new MySqlConnection(GloVar.SqlConn);
                con.Open();
                using (con)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = sql;
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        AdminMange admin = new AdminMange();
                        admin.MangeLevel = reader["MangeLevel"].ToString();
                        admin.Passdowm = reader["Passdowm"].ToString();
                        admin.UserName = reader["UserName"].ToString();
                        list.Add(admin);
                    }

                    con.Close();
                }
                return list;
            }
            catch (Exception ex)
            {
                string faileName = DateTime.Now.ToString("yyyy-MM-dd") + "_other.txt";
                SysFunction.SaveLog(faileName, "查询数据库异常", ex.ToString());
                return new List<AdminMange>();
            }
        }

        //添加账号
        public static bool AddMange(string UserName, string Passdowm, string MangeLevel)
        {
            try
            {
                int num = 0;
                string sql = string.Format("insert into AdminMange values('{0}','{1}','{2}')", UserName, Passdowm, MangeLevel);
                MySqlConnection connection = new MySqlConnection(GloVar.SqlConn);
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = sql;
                    num = cmd.ExecuteNonQuery();
                    connection.Close();
                }
                return num > 0 ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //修改账号
        public static bool ChangeMange(string UserName, string Passdowm, string MangeLevel)
        {
            try
            {
                int num = 0;
                string sql = string.Format("update AdminMange set Passdowm='{0}',MangeLevel='{1}' where UserName='{2}'", Passdowm, MangeLevel, UserName);
                MySqlConnection connection = new MySqlConnection(GloVar.SqlConn);
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = sql;
                    num = cmd.ExecuteNonQuery();
                    connection.Close();
                }
                return num > 0 ? true : false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //删除账户
        public static bool DeleteMange(string UserName)
        {
            try
            {
                int num = 0;
                string sql = string.Format("delete from AdminMange where UserName='{0}'", UserName);
                MySqlConnection connection = new MySqlConnection(GloVar.SqlConn);
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    num = cmd.ExecuteNonQuery();
                    connection.Close();
                }
                return num > 0 ? true : false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //修改数据--配方
        public static int UpdateSQLData(string txt)
        {
            try
            {
                int index = 0;
                MySqlConnection con = new MySqlConnection(GloVar.SqlConn);
                con.Open();
                using (con)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = txt;
                    index = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return index;
            }
            catch (Exception ex)
            {
                string faileName = DateTime.Now.ToString("yyyy-MM-dd") + "_other.txt";
                SysFunction.SaveLog(faileName, "修改数据到数据库异常", ex.ToString());
                return 0;
            }
        }

        //查询电芯配方
       

        //修改电芯配方
        public static int ChangeCellParam(string WeightUp, string WeightDowm, string ZWeightUp, string ZWeightDowm, string BoxWeight, string CellModel)
        {
            try
            {
                string sql = string.Format("updata paramSet set werightUp='{0}',werightDowm='{1}',ZwerightUp='{2}',ZwerightDowm='{3}',BoxWeight='{4}'" +
              " where CellModel='{5}'", WeightUp, WeightDowm, ZWeightUp, ZWeightDowm, BoxWeight, CellModel);
                MySqlConnection connection = new MySqlConnection(GloVar.SqlConn);
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                string faileName = DateTime.Now.ToString("yyyy-MM-dd") + "_other.txt";
                SysFunction.SaveLog(faileName, "修改电芯配方到数据库异常", ex.ToString());
                return 0;
            }

        }

        //删除电芯配方
        public static int DeleteCellParam(string cellmodel)
        {
            try
            {
                string sql = string.Format("delete from cell where CellModel='{0}'", cellmodel);
                MySqlConnection connection = new MySqlConnection(GloVar.SqlConn);
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                string faileName = DateTime.Now.ToString("yyyy-MM-dd") + "_other.txt";
                SysFunction.SaveLog(faileName, "删除电芯配方异常", ex.ToString());
                return 0;
            }
        }

        public static int AddCellParam(string CellModel, string WeightUp, string WeightDowm, string ZWeightUp, string ZWeightDowm, string BoxWeight)
        {
            try
            {
                string sql = string.Format("insert into paramSet values('{0}','{1}','{2}','{3}','{4}','{5}')", CellModel, WeightUp, WeightDowm, ZWeightUp, ZWeightDowm, BoxWeight);
                MySqlConnection connection = new MySqlConnection(GloVar.SqlConn);
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                string faileName = DateTime.Now.ToString("yyyy-MM-dd") + "_other.txt";
                SysFunction.SaveLog(faileName, "添加电芯配方异常", ex.ToString());
                return 0;
            }

        }

        /// <summary>
        /// 查询数据(配方+重量，电芯数量)
        /// </summary>
        /// <param name="strQuery">查询语句</param>
        /// <returns>DataTable类型</returns>
        public static DataTable GetAllSQLDataAsDataTable(string strQuery, out int count)
        {
            DataTable inv = new DataTable();//保存数据
            MySqlConnection connection = new MySqlConnection(GloVar.SqlConn);
            connection.Open();
            using (MySqlCommand cmd = new MySqlCommand(strQuery, connection))
            {
                MySqlDataReader dr = cmd.ExecuteReader();
                inv.Load(dr);
                count = inv.Rows.Count;
                dr.Close();
            }
            return inv;
        }


        /// <summary>
        /// 查询数据(配方)
        /// </summary>
        /// <param name="strQuery">查询语句</param>
        /// <returns>DataTable类型</returns>
        public static DataTable GetSQLDataAsDataTable(string strQuery, out int count)
        {
            count = 0;
            DataTable inv = new DataTable();//保存数据
            try
            {
                MySqlConnection connection = new MySqlConnection(GloVar.SqlConn);
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(strQuery, connection))
                {
                    MySqlDataReader dr = cmd.ExecuteReader();
                    inv.Load(dr);
                    count = inv.Rows.Count;
                    dr.Close();
                }
                return inv;
            }
            catch (Exception ex)
            {
                return inv;
            }
        }

        //查询表行数
        public static int GetTableRow(string sql)
        {
            int count=-1;
            try
            {
                using (MySqlConnection con = new MySqlConnection(GloVar.SqlConn))
                {
                    con.Open();
                    MySqlCommand command = new MySqlCommand(sql, con);
                    count = Convert.ToInt32(command.ExecuteScalar());
                    return count;
                }
            }
            catch
            {
                return -1;
            }
            
        }

        //创建电芯数据表格+登录账号表格+称重表格
        public static bool  CreatMysqltable()
        {
            try
            {
                
                MySqlConnection mcon = new MySqlConnection(GloVar.SqlConn);
                mcon.Open();
                //生产数据
                string sqlcom = "create table if not exists  `scancz01` (`ID` int UNSIGNED AUTO_INCREMENT,`Time` datetime not null,`Barcode` varchar(30) not null,`BoxSn` varchar(20) not null,`OperID` varchar(20) not null,`Checker` varchar(20) not null,primary key (`ID`))";
                MySqlCommand mcom = new MySqlCommand(sqlcom, mcon);
                mcom.ExecuteNonQuery();
                //账号
                sqlcom = "create table if not exists `AdminMange`(`UserName` varchar(20) not null,`Passdom` varchar(20) not null, `MangeLevel` varchar(20) not null,primary key(`UserName`));";
                mcom = new MySqlCommand(sqlcom, mcon);
                mcom.ExecuteNonQuery();
                //称重
                sqlcom = "create table if not exists `weight01`(`ID` int UNSIGNED AUTO_INCREMENT,`time` datetime not null, `boxsn` varchar(30) not null, `netweight` varchar(15) not null, `totalweight` varchar(15) not null, `sanner` varchar(20) not null, `checker` varchar(20) not null, `info` varchar(120) not null,primary key (`ID`))";
                mcom = new MySqlCommand(sqlcom, mcon);
                mcom.ExecuteNonQuery();
                //配方
                sqlcom = "create table if not exists `cell`( `CellModel` varchar(20) not null,`WeightUp` varchar(10) not null,`WeightDowm` varchar(10) not null,`ZWeightUp` varchar(10) not null,`ZWeightDowm` varchar(10) not null,`BoxWeight` varchar (10) not null,primary key(`CellModel`))";
                mcom = new MySqlCommand(sqlcom, mcon);
                mcom.ExecuteNonQuery();
                //OEE
                sqlcom = "create table if not exists `OEE`( `ID` int UNSIGNED AUTO_INCREMENT,`日期` varchar(10) not null,`停机时间` varchar(40) not null,`性能利用率` varchar(40) not null,`时间利用率` varchar(40) not null,`质量利用率` varchar (40) not null,`OEE` varchar(40) not null,primary key(`ID`))";
                sqlcom += ";INSERT INTO OEE VALUES(1, '20000101', '0', '0', '0', '0','0');";
                mcom = new MySqlCommand(sqlcom, mcon);
                mcom.ExecuteNonQuery();
                mcon.Close();
                return true;
        }
            catch
            {
                return false;
            }
        }
    }
}
