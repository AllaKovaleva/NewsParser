using System;
namespace HtmlParser
{
    public class NewsPost
    {
        public String Name { get; set; }
        public DateTime CreationDate { get; set; }
        public String Contents { get; set; }
        public String Author { get; set; }
        public String Url { get; set; }
        public String WebPortal { get; set; }




        public NewsPost(string name, DateTime creationDate, string contents, string author)
        {
            Name = name;
            CreationDate = creationDate;
            Contents = contents;
            Author = author;
        }

        public NewsPost(string name, DateTime creationDate, string contents, string author, string url)
        {
            Name = name;
            CreationDate = creationDate;
            Contents = contents;
            Author = author;
            Url = url;
        }

        public NewsPost(string url)
        {
           
            Url = url;
        }




    }
}
