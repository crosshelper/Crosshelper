using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Crosshelper.Models
{
    class UserAccess
    {
        public UserAccess()
        {

        }

        string connStr = "server=chdb.cakl0xweapqd.us-west-1.rds.amazonaws.com;port=3306;database=chdb;user=chroot;password=ch123456;charset=utf8";

        public void UserRegister(string Uname, string Pwd)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    Console.WriteLine("Connecting to MySQL...");
                    conn.Open();
                    string sql = "INSERT INTO UserMaster(Uid,Uname,Pwd,Permission) VALUES(NULL, @para1, @para2, 0) ";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("para1", Uname);
                    cmd.Parameters.AddWithValue("para2", Pwd);

                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Connecting to MySQL success");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine("Connection failed");
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 验证用户名密码，存放回true，否则为false
        /// </summary>
        public bool VerifyUser(string username, string password)
        {
            
            //并没有建立数据库连接
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {   //建立连接，打开数据库
                conn.Open();
                string sqlstr = "select * from UserMaster where Uname = @para1 and Pwd = @para2";
                MySqlCommand cmd = new MySqlCommand(sqlstr, conn);
                //通过设置参数的形式给SQL 语句串值
                cmd.Parameters.AddWithValue("para1", username);
                cmd.Parameters.AddWithValue("para2", password);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                conn.Close();   //关闭连接              
            }
            return false;
        }
    }
}
