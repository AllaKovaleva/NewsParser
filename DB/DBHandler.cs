using System.Collections.Generic;
using NewsPosts;

namespace DB
{
    public class DBHandler
    {

        private DBConnector db;
        public DBHandler()
        {
            db = new DBConnector();
            db.CreateTable();
        }

        public void Recycle()
        {
            db.Recycle();
        }

        public void InsertNews(List<Post> news)
        {
            
            foreach (var item in news)
            {
                db.LoadTODb(item);
            }
           
        }

        public List<Post> ReadNews()
        {
            var result= db.ReadDb();
            return result;
        }

    }
}
