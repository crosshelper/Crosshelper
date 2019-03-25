using System;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace Crosshelper.Models
{
    public class DBManager
    {
        public DBManager()
        {
            string connStr = "server = chelperdb.cakl0xweapqd.us-west-1.rds.amazonaws.com; user = CHdbm; database = CHelperDB; port = 3306; password = ";
            void UpdateDB()
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                try
                {
                    Console.WriteLine("Connecting to MySQL");
                    conn.Open();
                    string sql = "Update ";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader mySqlDataReader = cmd.ExecuteReader();
                    while (mySqlDataReader.Read())
                    {
                        Console.WriteLine(mySqlDataReader[0]);
                    }
                    mySqlDataReader.Close();
                }
                catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                conn.Close();
                Console.WriteLine();
            }

        }
    }
}
