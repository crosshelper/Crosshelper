using Crosshelper.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Crosshelper.Helpers
{
    class UserProListHelper
    {
        readonly string connStr = "server=chdb.cakl0xweapqd.us-west-1.rds.amazonaws.com;port=3306;database=chdb;user=chroot;password=ch123456;charset=utf8";

        IList<UserPro> helperlist;

        List<int> helperuidlist;


        public void Init()
        {
             
        }

        void GetProHelperByTag()
        { 

        }




        public void GetHelperList(int userid)
        {
            UserPro helper = new UserPro();
            
            //并没有建立数据库连接
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {   //建立连接，打开数据库
                conn.Open();
                string sqlstr = //"select * from UserInfo where Uid = @para1";// and Pwd = @para2";
                "SELECT Rating,`Status`,PriceSign,FirstName,LastName,ChatID,FLanguage,SLanguage,Icon FROM HelperInfo,UserInfo WHERE HelperInfo.Uid = @para1 AND UserInfo.Uid = @para1";
                //"SELECT * FROM HelperInfo WHERE HelperInfo.Uid = @para1 AND UserInfo.Uid = @para1";

                MySqlCommand cmd = new MySqlCommand(sqlstr, conn);
                //通过设置参数的形式给SQL 语句串值
                cmd.Parameters.AddWithValue("para1", userid);
                //cmd.Parameters.AddWithValue("para2", password);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    helper.UserID = reader.GetString(0);
                    helper.FirstName = reader.GetString(1);
                    helper.LastName = reader.GetString(2);
                    helper.ChatID = reader.GetString(3);
                    helper.FLanguage = reader.GetString(4);
                    helper.SLanguage = reader.GetString(5);
                    helper.PaymentID = reader.GetString(6);
                    helper.Icon = reader.GetString(7);
                    helper.Homeland = reader.GetString(8);
                    helper.FENo = reader.GetString(9);
                    helper.SENo = reader.GetString(10);
                    helper.Address = reader.GetString(11);
                    helper.Location = reader.GetString(12);
                    helper.SSN = reader.GetString(13);
                    helper.Rating = reader.GetString(14);
                    helper.Status = reader.GetString(15);
                    helper.PriceSign = reader.GetString(16);
                    helper.IDFile = reader.GetString(17);
                    helperlist.Add(helper);
                    //return helper;
                }
                return helperlist;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                conn.Close();   //关闭连接              
            }
            return helperlist;
        }

    }
}
