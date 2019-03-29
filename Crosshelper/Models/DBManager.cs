using System;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace Crosshelper.Models
{
    public class DBManager
    {
        private string connStr = "Server=chdb.cakl0xweapqd.us-west-1.rds.amazonaws.com;Port=3306;database=chdb;User Id=chroot;Password=ch123456;charset=utf8";
        public DBManager()
        {
            
        }

        public void UpdateDB(string Uname, string Pwd)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                if(conn.State == ConnectionState.Closed)
                {
                    Console.WriteLine("Connecting to MySQL...");
                    conn.Open();
                    Console.WriteLine("Connecting to MySQL success");

                }
                //Console.WriteLine("Connecting to MySQL...");
                //conn.Open();
                //string sql = "INSERT INTO `chdb`.`UserMaster`(`Uid`, `Uname`, `Pwd`, `Permission`) VALUES (NULL, " + Uname + ", " + Pwd + ", NULL) ";
                //MySqlCommand cmd = new MySqlCommand(sql, conn);
                //cmd.ExecuteNonQuery();
               
                
                
                //MySqlDataReader mySqlDataReader = cmd.ExecuteReader();
                //while (mySqlDataReader.Read())
                //{
                //Console.WriteLine(mySqlDataReader[0]);
                //}
                //mySqlDataReader.Close();
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
            //Console.WriteLine();
        }
    }
}
