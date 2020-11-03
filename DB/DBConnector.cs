using System;
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

        public void Loader()
        {
            //var conStr = @"Server=localhost\SQLEXPRESS;Database=tempdb;Trusted_Connection=True;";
            //SqlConnection con = new SqlConnection(conStr);
            //con.Open();

            var stver = "SELECT  @@VERSION";
            var st = @"
            CREATE TABLE  NEWSITEM
                            (TITLE VARCHAR(500),
                              DATE DATETIME,
                              URL VARCHAR(500),
                              TEXT VARCHAR(8000)

                             )";
            //IF NOT EXISTS
           // (SELECT * FROM SYSOBJECTS WHERE NAME == 'NEWSITEM' AND XTYPE = 'U'

          

            var cmd = new SqlCommand(st, connect);
            var version = cmd.ExecuteScalar();

            var crstr = "select COUNT(*) FROM NEWSITEM";
            // var cmdTable = new SqlCommand();
            //cmdTable.Connection = con;
            //cmdTable.CommandText = crstr;
            // var tt=cmdTable.ExecuteScalar();

            Console.WriteLine(version+"____");




            //conn.Close();
        }

        public void LoadTODb()
        {
            var sql = "INSERT INTO NEWSITEM (TITLE, DATE, URL, TEXT )"+
                      " VALUES(@TITLE, @DATE, @URL, @TEXT)";

            var cmd = new SqlCommand(sql,connect);
            cmd.Parameters.Add(new SqlParameter("@TITLE", System.Data.SqlDbType.VarChar, 500)).Value = "TITLEINSERTED";
            cmd.Parameters.Add(new SqlParameter("@DATE", System.Data.SqlDbType.DateTime)).Value = DateTime.Now;
            cmd.Parameters.Add(new SqlParameter("@URL", System.Data.SqlDbType.VarChar, 500)).Value = "TURLINSERTED";
            cmd.Parameters.Add(new SqlParameter("@TEXT", System.Data.SqlDbType.VarChar, 8000)).Value = "TEXTINSERTED";
            cmd.Prepare();
            cmd.ExecuteNonQuery();


        }

        public void ReadDb()
        {
            var sql = "SELECT * FROM NEWSITEM";
            var cmd = new SqlCommand(sql, connect);
            using SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Console.WriteLine(rdr.GetString(0));
                Console.WriteLine(rdr.GetDateTime(1));
            }
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
