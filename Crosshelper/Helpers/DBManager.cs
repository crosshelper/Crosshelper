using System;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace Crosshelper.Models
{
    public class DBManager
    {
        string connStr = "server = chdb.cakl0xweapqd.us-west-1.rds.amazonaws.com; user = chroot; database = chdb; port = 3306; password = ch123456 ";

        public DBManager()
        {

        }

        public void UpdateDB(string Uname, string Pwd)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "INSERT INTO `chdb`.`UserMaster`(`Uid`, `Uname`, `Pwd`, `Permission`) VALUES (NULL, " + Uname + ", " + Pwd + ", NULL) ";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                //MySqlDataReader mySqlDataReader = cmd.ExecuteReader();
                //while (mySqlDataReader.Read())
                //{
                //Console.WriteLine(mySqlDataReader[0]);
                //}
                //mySqlDataReader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            conn.Close();
            Console.WriteLine("Done.");
        }

        public void InsertDB(string Uname, string Pwd)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "INSERT INTO `chdb`.`UserMaster`(`Uid`, `Uname`, `Pwd`, `Permission`) VALUES (NULL, " + Uname + ", " + Pwd + ", NULL) ";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                //MySqlDataReader mySqlDataReader = cmd.ExecuteReader();
                //while (mySqlDataReader.Read())
                //{
                //Console.WriteLine(mySqlDataReader[0]);
                //}
                //mySqlDataReader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            conn.Close();
            Console.WriteLine("Done.");
        }
    }
}
