using System;
using System.Data;
using Crosshelper.Models;
using MySql.Data.MySqlClient;

namespace Crosshelper.Helpers
{
    public class TopicInfoHelper
    {
        readonly string connStr = "server=chdb.cakl0xweapqd.us-west-1.rds.amazonaws.com;port=3306;database=chdb;user=chroot;password=ch123456;charset=utf8";

        internal void ListMyTopic(int tagID, string zipcode, string language, string description)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    Console.WriteLine("Connecting to MySQL...");
                    conn.Open();
                    string sql = "INSERT INTO TopicInfo(Uid,TagID,Zip,Language,Description) VALUES(@para1, @para2, @para3, @para4, @para5) ";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("para1", Settings.UserId);
                    cmd.Parameters.AddWithValue("para2", tagID);
                    cmd.Parameters.AddWithValue("para3", zipcode);
                    cmd.Parameters.AddWithValue("para4", language);
                    cmd.Parameters.AddWithValue("para5", description);

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



        public TopicInfoHelper()
        {

        }
    }
}
