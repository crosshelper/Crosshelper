using System;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace Crosshelper.Models
{
    public class DBManager
    {
        private string connStr = "server=chdb.cakl0xweapqd.us-west-1.rds.amazonaws.com;port=3306;database=chdb;user=chroot;password=ch123456;charset=utf8";

        public DBManager()
        {
            
        }
        /// <summary>
        /// 读取数据库中的数据
        /// </summary>
        void ReadSQL()
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();    //建立连接，打开数据库
                Console.WriteLine("Open Success");

                string sqlstr = "select * from czhenya001";   //SQL语句
                MySqlCommand cmd = new MySqlCommand(sqlstr, conn);
                /* cmd.ExecuteReader();     //执行一些查询
                   cmd.ExecuteScalar();     //执行一些查询，返回一个单个的值
                   cmd.ExecuteNonQuery();   //插入删除   */

                //相当于数据读出流
                MySqlDataReader reader = cmd.ExecuteReader();
                //reader.Read();  //读取下一页数据 ，读取成功，返回true，下一页没有数据则返回false表示到了最后一页

                while (reader.Read())   //遍历表中数据
                {
                    //读取并打印数据
                    reader.Read();
                    //索引是一行有几个数据
                    Console.WriteLine(reader[0].ToString() + reader[1].ToString() + reader[2].ToString() + reader[3].ToString());
                    //还可以使用Getxxx方式去写 参数（索引）
                    Console.WriteLine(reader.GetInt32(0) + reader.GetString(1) + reader.GetString(2));
                    //Getxxx方法的重载  参数(列名)
                    Console.WriteLine(reader.GetInt32("id") + reader.GetString("name") + reader.GetString("age"));
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

        /// <summary>
        /// 插入数据到数据库中
        /// </summary>
        void InsertSQL()
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {   //建立连接，打开数据库
                conn.Open();
                //注意一条SQL语句不要一条语句执行两次，会因为已存在而报错
                string sqlstr = "insert into czhenya001(Id,Name) values('1006','ChenChen')";   //SQL语句
                MySqlCommand cmd = new MySqlCommand(sqlstr, conn);

                int result = cmd.ExecuteNonQuery();   //返回值为执行后数据库中受影响的数据行数
                Console.WriteLine("Success", result);
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

        /// <summary>
        /// 修改数据库中数据
        /// </summary>
        void UpdateSQL()
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {   //建立连接，打开数据库
                conn.Open();
                //注意一条SQL语句不要一条语句执行两次，会因为已存在而报错
                string sqlstr = "update czhenya001 set Id ='2',Name = 'admin' where Id = '1' ";   //SQL语句
                MySqlCommand cmd = new MySqlCommand(sqlstr, conn);

                int result = cmd.ExecuteNonQuery();   //返回值为执行后数据库中受影响的数据行数
                Console.WriteLine("Success", result);
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

        /// <summary>
        /// 删除数据库中的数据
        /// </summary>
        void DeleteSQL()
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {   //建立连接，打开数据库
                conn.Open();
                //注意一条SQL语句不要一条语句执行两次，会因为已存在而报错
                string sqlstr = "Delete from czhenya001 where Id = '1002' ";   //SQL语句
                MySqlCommand cmd = new MySqlCommand(sqlstr, conn);

                int result = cmd.ExecuteNonQuery();   //返回值为执行后数据库中受影响的数据行数
                Console.WriteLine("Success", result);
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
