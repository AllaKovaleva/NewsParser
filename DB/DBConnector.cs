using NewsPosts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Dynamic;

namespace DB
{
    public class DBConnector
    {

        private SqlConnection connect;

        public DBConnector()
        {
            var conStr = @"Server=localhost\SQLEXPRESS;Database=tempdb;Trusted_Connection=True;";
            connect = new SqlConnection(conStr);
            connect.Open();
            CreateTable();
        }

        public  void Recycle()
        {
            connect.Close();
        }


        public void LoadTODb(Post post)
        {
            var sql = "INSERT INTO NEWSITEM (TITLE, DATE, URL, TEXT )"+
                      " VALUES(@TITLE, @DATE, @URL, @TEXT)";

            var cmd = new SqlCommand(sql,connect);
            cmd.Parameters.Add(new SqlParameter("@TITLE", System.Data.SqlDbType.VarChar, 500)).Value = post.Title;
            cmd.Parameters.Add(new SqlParameter("@DATE", System.Data.SqlDbType.DateTime)).Value = post.DateOfPost;
            cmd.Parameters.Add(new SqlParameter("@URL", System.Data.SqlDbType.VarChar, 500)).Value = post.Url;
            cmd.Parameters.Add(new SqlParameter("@TEXT", System.Data.SqlDbType.VarChar, 8000)).Value = post.Text;
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            Console.WriteLine("inserting");

        }

        public List<Post> ReadDb()
        {
            Console.WriteLine("reading db");
            var sql = "SELECT * FROM NEWSITEM";
            var cmd = new SqlCommand(sql, connect);
            using SqlDataReader rdr = cmd.ExecuteReader();
            var news = new List<Post>();
            while (rdr.Read())
            {
                Console.WriteLine(rdr.GetString(0));
                var post = new Post(rdr.GetString(0), rdr.GetDateTime(1), rdr.GetString(2), rdr.GetString(3));
                news.Add(post);
            }
            return news;
        }

        public void CreateTable()
        {
            var dropSql = "DROP TABLE IF EXISTS  NEWSITEM ";
            var createSql = @" CREATE TABLE  NEWSITEM
                            ( TITLE VARCHAR(500),
                              DATE  DATETIME,
                              URL VARCHAR(500),
                              TEXT VARCHAR(8000)

                             )";

     

            var cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = dropSql;
            cmd.ExecuteNonQuery();

            cmd.Connection = connect;
            cmd.CommandText = createSql;
            cmd.ExecuteNonQuery();
        }
    }
}
