using Crosshelper.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Crosshelper.Helpers
{
    class UserInfoHelper
    {
        readonly string connStr = "server=chdb.cakl0xweapqd.us-west-1.rds.amazonaws.com;port=3306;database=chdb;user=chroot;password=ch123456;charset=utf8";

        private readonly List<CaseInfo> caselist  = new List<CaseInfo>();
        private readonly List<CaseInfo> pastcaselist = new List<CaseInfo>();
        private readonly List<ReviewsInfo> reviewlist = new List<ReviewsInfo>();
        private readonly List<PaymentInfo> paymentlist = new List<PaymentInfo>();

        private readonly List<UserPro> helperlist = new List<UserPro>();
        private readonly List<int> helperuidlist = new List<int>();

        private string speclist = "";
        private readonly List<int> tagidlist = new List<int>();

        internal List<CaseInfo> GetCaseInfoByUid(string userId)
        {
            //建立数据库连接
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {   //建立连接，打开数据库
                conn.Open();
                string sqlstr =
                "SELECT CaseID,HelperUID,ReceiptID,CaseType,CaseDateTime,CaseDes FROM CaseInfo WHERE CustomerUID = @para1";

                MySqlCommand cmd = new MySqlCommand(sqlstr, conn);
                //通过设置参数的形式给SQL 语句串值
                cmd.Parameters.AddWithValue("para1", userId);
                //cmd.Parameters.AddWithValue("para2", password);

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.GetString(2) == "0")
                    {
                        string CaseID = reader.GetString(0);
                        string HelperUID = reader.GetString(1);
                        string ReceiptID = reader.GetString(2);
                        string CaseType = reader.GetString(3);
                        string CaseTypeLabelText = "";
                        if (CaseType == "1")
                            CaseTypeLabelText = "Emergency";
                        DateTime CaseDateTime = reader.GetDateTime(4);
                        string CaseDes = reader.GetString(5);

                        CaseInfo tmp = new CaseInfo() 
                        { 
                            CaseID = CaseID, 
                            HelperID = HelperUID,
                            HelperName = GetNameByID(HelperUID),
                            CustomerID = userId,
                            ReceiptID = ReceiptID, 
                            CaseType = CaseType, 
                            CaseTypeLabelText = CaseTypeLabelText, 
                            CaseDateTime = CaseDateTime, 
                            CaseDescription = CaseDes 
                        };
                        caselist.Add(tmp);
                    }
                }
                if (caselist != null)
                return caselist;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                conn.Close();   //关闭连接              
            }
            return caselist;
        }

        internal void UpdateUserRealNameEmail(string fName, string lName, string email)
        {
            //建立数据库连接
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    Console.WriteLine("Connecting to MySQL...");
                    conn.Open();
                    string sql = "INSERT INTO UserInfo(Uid,FirstName,LastName,ChatID" +
                        "Flanguage,SLanguage,PaymentID,Icon,FENum,SENum," +
                        "Address,Location,Email,ZipCode) " +
                        "VALUES(@para4, @para1, @para2, cycbis, English, English, cycbis0000, http, " +
                        "0000000000, 0000000000, example, example, @para3, 95131)";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("para1", fName);
                    cmd.Parameters.AddWithValue("para2", lName);
                    cmd.Parameters.AddWithValue("para3", email);
                    cmd.Parameters.AddWithValue("para4", Settings.UserId);

                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Connecting to MySQL success");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                conn.Close();//关闭连接              
            }
        }

        internal void DeleteMyPaymentByID(string paymentID)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    Console.WriteLine("Connecting to MySQL...");
                    conn.Open();
                    string sql = "DELETE From PaymentInfo Where Pid = @para1";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("para1", paymentID);
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

        internal ReceiptInfo GetReceiptByID(string receiptID)
        {
            ReceiptInfo tmp = new ReceiptInfo();
            //建立数据库连接
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {   //建立连接，打开数据库
                conn.Open();
                string sqlstr =
                "SELECT ServiceFee,EqFee,Tax,Surcharges,PayTime FROM Receipts WHERE ReceiptID = @para1";

                MySqlCommand cmd = new MySqlCommand(sqlstr, conn);
                //通过设置参数的形式给SQL 语句串值
                cmd.Parameters.AddWithValue("para1", receiptID);
                //cmd.Parameters.AddWithValue("para2", password);

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    tmp.ServiceFee = reader.GetDouble(0);
                    tmp.EqFee = reader.GetDouble(1);
                    tmp.Tax = reader.GetDouble(2);
                    tmp.Surcharge = reader.GetDouble(3);
                    tmp.PaymentDateTime = reader.GetDateTime(4);
                    tmp.PaymentName = "7785-9085-3425-8797";
                }
                if (tmp != null)
                    return tmp;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                conn.Close();   //关闭连接 
            }
            return tmp;
        }

        internal List<CaseInfo> GetPastCaseInfoByUid(string userId)
        {
            //建立数据库连接
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {   //建立连接，打开数据库
                conn.Open();
                string sqlstr =
                "SELECT CaseID,HelperUID,ReceiptID,CaseType,CaseDateTime,CaseDes FROM CaseInfo WHERE CustomerUID = @para1";

                MySqlCommand cmd = new MySqlCommand(sqlstr, conn);
                //通过设置参数的形式给SQL 语句串值
                cmd.Parameters.AddWithValue("para1", userId);
                //cmd.Parameters.AddWithValue("para2", password);

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if(reader.GetString(2) != "0")
                    {
                        string CaseID = reader.GetString(0);
                        string HelperUID = reader.GetString(1);
                        string ReceiptID = reader.GetString(2);
                        string CaseType = reader.GetString(3);
                        string CaseTypeLabelText = "";
                        if (CaseType == "1")
                            CaseTypeLabelText = "Emergency";
                        DateTime CaseDateTime = reader.GetDateTime(4);
                        string CaseDes = reader.GetString(5);
                        CaseInfo tmp = new CaseInfo()
                        {
                            CaseID = CaseID,
                            HelperID = HelperUID,
                            HelperName = GetNameByID(HelperUID),
                            CustomerID = userId,
                            ReceiptID = ReceiptID,
                            CaseType = CaseType,
                            CaseTypeLabelText = CaseTypeLabelText,
                            CaseDateTime = CaseDateTime,
                            CaseDescription = CaseDes
                        };
                        pastcaselist.Add(tmp);
                    }
                }
                if (pastcaselist != null)
                    return pastcaselist;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                conn.Close();   //关闭连接              
            }
            return pastcaselist;
        }

        internal void InsertPaymentInfo(PaymentInfo pinfo)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    Console.WriteLine("Connecting to MySQL...");
                    conn.Open();
                    string sql = "INSERT INTO PaymentInfo(AccountNumber,CName,ExDate,CVV,Zip,Uid) VALUES(@para1, @para2, @para3, @para4, @para5, @para6) ";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("para1", pinfo.AccountNo);
                    cmd.Parameters.AddWithValue("para2", pinfo.CName);
                    cmd.Parameters.AddWithValue("para3", pinfo.ExDate);
                    cmd.Parameters.AddWithValue("para4", pinfo.CVV);
                    cmd.Parameters.AddWithValue("para5", pinfo.Zipcode);
                    cmd.Parameters.AddWithValue("para6", pinfo.Uid);
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

        internal void UpdatePaymentInfo(PaymentInfo paymentinfo)
        {
            //建立数据库连接
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {   //建立连接，打开数据库
                conn.Open();
                string sqlstr =
                    "UPDATE PaymentInfo SET " +
                    "AccountNumber = @para1, " +
                    "CName = @para2, " +
                    "ExDate = @para3, " +
                    "CVV = @para4, " +
                    "Zip = @para5" +
                    " WHERE Pid = @para6";
                MySqlCommand cmd = new MySqlCommand(sqlstr, conn);
                //通过设置参数的形式给SQL 语句串值
                cmd.Parameters.AddWithValue("para1", paymentinfo.AccountNo);
                cmd.Parameters.AddWithValue("para2", paymentinfo.CName);
                cmd.Parameters.AddWithValue("para3", paymentinfo.ExDate);
                cmd.Parameters.AddWithValue("para4", paymentinfo.CVV);
                cmd.Parameters.AddWithValue("para5", paymentinfo.Zipcode);
                cmd.Parameters.AddWithValue("para6", paymentinfo.PaymentID);

                cmd.ExecuteNonQuery();
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

        internal void UpdateUac(Uac ac)
        {
            //建立数据库连接
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {   //建立连接，打开数据库
                conn.Open();
                string sqlstr =
                    "UPDATE UserMaster SET " +
                    "ContactNo = @para3, " +
                    "Pwd = @para4" +
                    " WHERE Uid = @para1";
                MySqlCommand cmd = new MySqlCommand(sqlstr, conn);
                //通过设置参数的形式给SQL 语句串值
                cmd.Parameters.AddWithValue("para1", ac.UserID);
                cmd.Parameters.AddWithValue("para3", ac.ContactNo);
                cmd.Parameters.AddWithValue("para4", ac.Pwd);
                cmd.ExecuteNonQuery();
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

        internal void UpdateUserInfo(UserInfo usr)
        {
            //建立数据库连接
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {   //建立连接，打开数据库
                conn.Open();
                string sqlstr =
                    "UPDATE UserInfo SET " +
                    "FirstName = @para2, " +
                    "LastName = @para3, " +
                    "FLanguage = @para4, " +
                    "SLanguage = @para5, " +
                    "PaymentID = @para6, " +
                    "Icon = @para7, " +
                    "FENum = @para8, " +
                    "SENum = @para9, " +
                    "Address = @para10" +
                    " WHERE Uid = @para1";
                MySqlCommand cmd = new MySqlCommand(sqlstr, conn);
                //通过设置参数的形式给SQL 语句串值
                cmd.Parameters.AddWithValue("para1", usr.UserID);
                cmd.Parameters.AddWithValue("para2", usr.FirstName);
                cmd.Parameters.AddWithValue("para3", usr.LastName);
                cmd.Parameters.AddWithValue("para4", usr.FLanguage);
                cmd.Parameters.AddWithValue("para5", usr.SLanguage);
                cmd.Parameters.AddWithValue("para6", usr.PaymentID);
                cmd.Parameters.AddWithValue("para7", usr.Icon);
                cmd.Parameters.AddWithValue("para8", usr.FENo);
                cmd.Parameters.AddWithValue("para9", usr.SENo);
                cmd.Parameters.AddWithValue("para10", usr.Address);
                cmd.ExecuteNonQuery();
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

        public List<UserPro> GetHelperList(string tagid, string language, string zipCode)
        {
            var newhelperlist = new List<UserPro>();
            GetHelperIDByTag(tagid);
            foreach (int uid in helperuidlist)
            {
                GetHelperInfoByID(uid.ToString());
            }
            foreach(UserPro helper in helperlist)
            {
                if(helper.FLanguage == language || helper.SLanguage == language)
                {
                    if (helper.ZipCode1 == zipCode || helper.ZipCode2 == zipCode || helper.ZipCode3 == zipCode)
                    {
                        newhelperlist.Add(helper);
                    }
                }
            }
            return newhelperlist;
        }

        public UserPro GetHelperInfo()
        {
            return helperlist[0];
        }

        public List<PaymentInfo> GetPaymentsList(string userid)
        {
            GetPaymentByID(userid);
            return paymentlist;
        }

        internal string GetTagsByID(string helperID)
        {
            GetTagByHelperID(helperID);
            foreach (int tagid in tagidlist)
            {
                GetTagInfoByID(tagid.ToString());
            }
            return speclist;
        }

        private void GetTagByHelperID(string helperID)
        {
            //建立数据库连接
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {   //建立连接，打开数据库
                conn.Open();
                string sqlstr = "SELECT TagID FROM HelperTag WHERE Uid = @para1";
                MySqlCommand cmd = new MySqlCommand(sqlstr, conn);
                //通过设置参数的形式给SQL 语句串值
                cmd.Parameters.AddWithValue("para1", helperID);
                //cmd.Parameters.AddWithValue("para2", password);

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    tagidlist.Add(reader.GetInt32(0));
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

        private void GetTagInfoByID(string v)
        {
            //建立数据库连接
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {   //建立连接，打开数据库
                conn.Open();
                string sqlstr =
                "SELECT TagName FROM Tags WHERE TagID = @para1";

                MySqlCommand cmd = new MySqlCommand(sqlstr, conn);
                //通过设置参数的形式给SQL 语句串值
                cmd.Parameters.AddWithValue("para1", v);
                //cmd.Parameters.AddWithValue("para2", password);

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    speclist += reader.GetString(0) + ", ";
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

        public List<ReviewsInfo> GetReviewsList(string userid)
        {
            GetReviewByID(userid);
            return reviewlist;
        }

        private void GetReviewByID(string userid)
        {
            //建立数据库连接
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {   //建立连接，打开数据库
                conn.Open();
                string sqlstr =
                "SELECT ReviewID,RRating,Content FROM Reviews WHERE Uid = @para1";

                MySqlCommand cmd = new MySqlCommand(sqlstr, conn);
                //通过设置参数的形式给SQL 语句串值
                cmd.Parameters.AddWithValue("para1", userid);
                //cmd.Parameters.AddWithValue("para2", password);

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string ReviewID = reader.GetString(0);
                    int ReviewRating = reader.GetInt32(1);
                    string ReviewContent = reader.GetString(2);
                    ReviewsInfo tmp = new ReviewsInfo() { UserID = userid, ReviewRating = ReviewRating, ReviewContent = ReviewContent, ReviewID = ReviewID };
                    reviewlist.Add(tmp);
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

        private void GetHelperIDByTag(string tagid)
        {
            //建立数据库连接
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {   //建立连接，打开数据库
                conn.Open();
                string sqlstr = "SELECT Uid FROM HelperTag WHERE TagID = @para1";
                MySqlCommand cmd = new MySqlCommand(sqlstr, conn);
                //通过设置参数的形式给SQL 语句串值
                cmd.Parameters.AddWithValue("para1", tagid);
                //cmd.Parameters.AddWithValue("para2", password);

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    helperuidlist.Add(reader.GetInt32(0));
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

        public UserInfo GetUserInfoByID(string userid)
        {
            UserInfo user = new UserInfo();
            //并没有建立数据库连接
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {   //建立连接，打开数据库
                conn.Open();
                string sqlstr =
                "SELECT FirstName,LastName,Icon,ChatID,FLanguage,SLanguage,PaymentID,FENum,SENum,Address FROM UserInfo WHERE Uid = @para1";

                MySqlCommand cmd = new MySqlCommand(sqlstr, conn);
                //通过设置参数的形式给SQL 语句串值
                cmd.Parameters.AddWithValue("para1", userid);
                //cmd.Parameters.AddWithValue("para2", password);

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    user.FirstName = reader.GetString(0);
                    user.LastName = reader.GetString(1);
                    user.Icon = reader.GetString(2);
                    user.ChatID = reader.GetString(3);
                    user.FLanguage = reader.GetString(4);
                    user.SLanguage = reader.GetString(5);
                    user.PaymentID = reader.GetString(6);
                    user.FENo = reader.GetString(7);
                    user.SENo = reader.GetString(8);
                    user.Address = reader.GetString(9);
                    user.UserID = userid.ToString();
                }
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
            finally
            {
                conn.Close();   //关闭连接              
            }
        }

        public string GetNameByID(string userid)
        {
            string name = "";
            //并没有建立数据库连接
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {   //建立连接，打开数据库
                conn.Open();
                string sqlstr =
                "SELECT FirstName,LastName FROM UserInfo WHERE Uid = @para1";

                MySqlCommand cmd = new MySqlCommand(sqlstr, conn);
                //通过设置参数的形式给SQL 语句串值
                cmd.Parameters.AddWithValue("para1", userid);
                //cmd.Parameters.AddWithValue("para2", password);

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    name = reader.GetString(0) + " " + reader.GetString(1);
                }
                return name;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return "";
            }
            finally
            {
                conn.Close();   //关闭连接              
            }
        }

        public Uac GetUacByID(string userid)
        {
            Uac ac = new Uac();
            //并没有建立数据库连接
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {   //建立连接，打开数据库
                conn.Open();
                string sqlstr =
                "SELECT * FROM UserMaster WHERE Uid = @para1";
                MySqlCommand cmd = new MySqlCommand(sqlstr, conn);
                //通过设置参数的形式给SQL 语句串值
                cmd.Parameters.AddWithValue("para1", userid);

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ac.UserID = reader.GetString(0);
                    ac.ContactNo = reader.GetString(1);
                    ac.Pwd = reader.GetString(2);
                }
                return ac;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
            finally
            {
                conn.Close();   //关闭连接              
            }
        }

        private void GetPaymentByID(string uid)
        {
            //建立数据库连接
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {   //建立连接，打开数据库
                conn.Open();
                string sqlstr =
                "SELECT Pid,AccountNumber,CName,ExDate,CVV,Zip FROM PaymentInfo WHERE Uid = @para1";

                MySqlCommand cmd = new MySqlCommand(sqlstr, conn);
                //通过设置参数的形式给SQL 语句串值
                cmd.Parameters.AddWithValue("para1", uid);
                //cmd.Parameters.AddWithValue("para2", password);

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string PaymentID = reader.GetString(0);
                    string AccountNo = reader.GetString(1);
                    string CName = reader.GetString(2);
                    DateTime ExDate = reader.GetDateTime(3);
                    string CVV = reader.GetString(4);
                    string Zipcode = reader.GetString(5);
                    PaymentInfo ptmp = new PaymentInfo() { Uid = uid, PaymentID = PaymentID, AccountNo = AccountNo, CName = CName, ExDate = ExDate, CVV = CVV, Zipcode = Zipcode };
                    paymentlist.Add(ptmp);
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

        public void GetHelperInfoByID(string userid)
        {
            //并没有建立数据库连接
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {   //建立连接，打开数据库
                conn.Open();
                string sqlstr =
                "SELECT FirstName,LastName,Icon,ChatID,FLanguage,SLanguage,PaymentID,Location,Rating,`Status`,PriceSign,Bio,ServiceZip1,ServiceZip2,ServiceZip3 FROM HelperInfo,UserInfo WHERE HelperInfo.Uid = @para1 AND UserInfo.Uid = @para1";

                MySqlCommand cmd = new MySqlCommand(sqlstr, conn);
                //通过设置参数的形式给SQL 语句串值
                cmd.Parameters.AddWithValue("para1", userid);
                //cmd.Parameters.AddWithValue("para2", password);

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string FirstName = reader.GetString(0);
                    string LastName = reader.GetString(1);
                    string Icon = reader.GetString(2);
                    string ChatID = reader.GetString(3);
                    string FLanguage = reader.GetString(4);
                    string SLanguage = reader.GetString(5);
                    string PaymentID = reader.GetString(6);
                    string Location = reader.GetString(7);
                    int Rating = reader.GetInt32(8);
                    int Status = reader.GetInt32(9);
                    string PriceSign = reader.GetString(10);
                    string Bio = reader.GetString(11);
                    string zip1 = reader.GetString(12);
                    string zip2 = reader.GetString(13);
                    string zip3 = reader.GetString(14);

                    string UserID = userid;
                    UserPro helper = new UserPro()
                    {
                        FirstName = FirstName,
                        LastName = LastName,
                        Icon = Icon,
                        ChatID = ChatID,
                        FLanguage = FLanguage,
                        SLanguage = SLanguage,
                        PaymentID = PaymentID,
                        Location = Location,
                        Rating = Rating,
                        Status = Status,
                        PriceSign = PriceSign,
                        UserID = UserID,
                        Bio = Bio,
                        ZipCode1=zip1,
                        ZipCode2=zip2,
                        ZipCode3=zip3
                    };
                    helperlist.Add(helper);
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


    }
}
