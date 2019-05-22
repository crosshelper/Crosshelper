using System;
using System.Collections.Generic;
using System.Data;
using Crosshelper.Models;
using MySql.Data.MySqlClient;

namespace Crosshelper.Helpers
{
    public class TopicInfoHelper
    {
        private readonly List<TopicInfo> topiclist = new List<TopicInfo>();
        

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

        public List<TopicInfo> GetMyTopicList(string userid)
        {
            GetMyTopicByUid(userid);
            return topiclist;
        }

        private void GetMyTopicByUid(string userId)
        {
            //建立数据库连接
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {   //建立连接，打开数据库
                conn.Open();
                string sqlstr =
                "SELECT TopicID,TagID,Zip,Language,Description FROM TopicInfo WHERE Uid = @para1";

                MySqlCommand cmd = new MySqlCommand(sqlstr, conn);
                //通过设置参数的形式给SQL 语句串值
                cmd.Parameters.AddWithValue("para1", userId);
                //cmd.Parameters.AddWithValue("para2", password);

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int TopicID = reader.GetInt32(0);
                    int TagID = reader.GetInt32(1);
                    string Zip = reader.GetString(2);
                    string Language = reader.GetString(3);
                    string Description = reader.GetString(4);

                    TopicInfo tmp = new TopicInfo() 
                    { 
                        UserID = userId, 
                        TopicID = TopicID, 
                        TagID = TagID, 
                        Zipcode = Zip, 
                        Language= Language, 
                        Description = Description
                    };
                    topiclist.Add(tmp);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                conn.Close();   //关闭连接              
            }
        }

        public TopicInfoHelper()
        {

        }
    }
}
