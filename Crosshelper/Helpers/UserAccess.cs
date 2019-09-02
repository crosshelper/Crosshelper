using Crosshelper.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

using Twilio;
using Twilio.Rest.Verify.V2;
using Twilio.Rest.Verify.V2.Service;
using Yunpian.Sdk;
using Yunpian.Sdk.Model;

namespace Crosshelper.Helpers
{
    class UserAccess
    {
        public UserAccess()
        {

        }

        readonly string connStr = "server=chdb.cakl0xweapqd.us-west-1.rds.amazonaws.com;port=3306;database=chdb;user=chroot;password=ch123456;charset=utf8";
        private int currentUid;
        public int CurrentUid { get { return currentUid; } }

        public string SendverifyCodeYP(string phone, string verificationCode)
        {
            try
            {
                Settings.ChinaVerify = verificationCode;
                var clnt = new YunpianClient("d3a5e366f73162fe514f4883d1cd1cf3").Init();
                var param = new Dictionary<string, string>
                {
                    [Const.Mobile] = phone,
                    [Const.Text] = "【Cycbis】您的验证码是" + verificationCode+ "。如非本人操作，请忽略本短信",
                    [Const.TplId] = "3180896",
                    [Const.TplValue] = "【Cycbis】您的验证码是#code#。如非本人操作，请忽略本短信",
                    [Const.Code] = verificationCode
                };
                var r = clnt.Sms().SingleSend(param);
                clnt.Dispose();
                return r.Msg;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string GetVerificationCode()
        {
            Guid g = Guid.NewGuid();
            string verificationCode = Convert.ToBase64String(g.ToByteArray());
            verificationCode = verificationCode.Replace("=", "");
            verificationCode = verificationCode.Replace("+", "");
            verificationCode = verificationCode.Replace("/", "");
            verificationCode = verificationCode.Remove(6);
            return verificationCode;
        }

        public void TwilioVerifyService(string tempNumber)
        {
            string accountSid = Crosshelper.Properties.Resources.TWILIO_TOKEN;
            string authToken = Crosshelper.Properties.Resources.TWILIO_KEY;
            TwilioClient.Init(accountSid, authToken);
            //var service = ServiceResource.Create(friendlyName: "My First Verify Service");
            //Console.WriteLine(service.Sid);
            var verification = VerificationResource.Create(
                to: tempNumber, //"+14084641309",
                channel: "sms",
                pathServiceSid: Crosshelper.Properties.Resources.TWILIO_SERVICEID
            );

            Console.WriteLine(verification.Status);
        }

        public void UserRegister(string ContactNo, string Pwd)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    Console.WriteLine("Connecting to MySQL...");
                    conn.Open();
                    string sql = "INSERT INTO UserMaster(ContactNo,Pwd,Permission) VALUES(@para1, @para2, 0) ";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("para1", ContactNo);
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

        internal void UpdateEmailNo(string email, string contactNo)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    Console.WriteLine("Connecting to MySQL...");
                    conn.Open();
                    string sql = "UPDATE UserMaster SET " +
                                 "Email = @para2 " +
                                 "ContactNo = @para3" +
                                 " WHERE Uid = @para1";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("para1", currentUid);
                    cmd.Parameters.AddWithValue("para2", email);
                    cmd.Parameters.AddWithValue("para3", contactNo);

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

        internal string GetUserIDbyNo(string contactNo)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {   //建立连接，打开数据库
                conn.Open();
                string sqlstr = "select * from UserMaster where ContactNo = @para1";// and Pwd = @para2";
                MySqlCommand cmd = new MySqlCommand(sqlstr, conn);
                //通过设置参数的形式给SQL 语句串值
                cmd.Parameters.AddWithValue("para1", contactNo);
                //cmd.Parameters.AddWithValue("para2", password);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return reader.GetString(0);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                conn.Close();   //关闭连接
            }
            return "";
        }

        internal string GetNobyID(string uid)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {   //建立连接，打开数据库
                conn.Open();
                string sqlstr = "select * from UserMaster where Uid = @para1";// and Pwd = @para2";
                MySqlCommand cmd = new MySqlCommand(sqlstr, conn);
                //通过设置参数的形式给SQL 语句串值
                cmd.Parameters.AddWithValue("para1", uid);
                //cmd.Parameters.AddWithValue("para2", password);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return reader.GetString(1);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                conn.Close();   //关闭连接
            }
            return "";
        }

        internal bool CheckPhoneNoExist(string contactNo)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    Console.WriteLine("Connecting to MySQL...");
                    conn.Open();
                    string sql = "select 1 from UserMaster where ContactNo = @para1 limit 1";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("para1", contactNo);
                    object result = cmd.ExecuteScalar();
                    if (Convert.ToInt32(result) == 1)
                        return true;
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
            return false;
        }

        internal void SetChatID()
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    Console.WriteLine("Connecting to MySQL...");
                    conn.Open();
                    string sql = "UPDATE UserInfo SET " +
                                 "ChatID = @para1" +
                                 " WHERE Uid = @para2";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("para1", "cycbis_" + Settings.UserId);
                    cmd.Parameters.AddWithValue("para2", Settings.UserId);
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
        public bool VerifyUser(string phonenumber, string password)
        {
            //并没有建立数据库连接
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {   //建立连接，打开数据库
                conn.Open();
                string sqlstr = "select * from UserMaster where ContactNo = @para1 and Pwd = @para2";
                MySqlCommand cmd = new MySqlCommand(sqlstr, conn);
                //通过设置参数的形式给SQL 语句串值
                cmd.Parameters.AddWithValue("para1", phonenumber);
                cmd.Parameters.AddWithValue("para2", password);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    currentUid = reader.GetInt32(0);
                    Settings.IsLogin = true;
                    return true;
                }
                return false;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                conn.Close();   //关闭连接              
            }
            return false;
        }

        public UserInfo GetUserInfo(int userid)
        {
            UserInfo user = new UserInfo();
            //并没有建立数据库连接
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {   //建立连接，打开数据库
                conn.Open();
                string sqlstr = "select * from UserInfo where Uid = @para1";// and Pwd = @para2";
                MySqlCommand cmd = new MySqlCommand(sqlstr, conn);
                //通过设置参数的形式给SQL 语句串值
                cmd.Parameters.AddWithValue("para1", userid);
                //cmd.Parameters.AddWithValue("para2", password);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    user.UserID = reader.GetString(0);
                    user.FirstName = reader.GetString(1);
                    user.LastName = reader.GetString(2);
                    user.ChatID = reader.GetString(3);
                    user.FLanguage = reader.GetString(4);
                    user.SLanguage = reader.GetString(5);
                    user.PaymentID = reader.GetString(6);
                    user.Icon = reader.GetString(7);
                    user.FENo = reader.GetString(8);
                    user.SENo = reader.GetString(9);
                    user.Address = reader.GetString(10);
                    user.Location = reader.GetString(11);
                    return user;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                conn.Close();   //关闭连接              
            }
            return user;
        }


    }
}
