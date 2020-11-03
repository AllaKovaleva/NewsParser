using System;

namespace NewsPosts
{
    public class Post
    {
        public string Title { get; set; }
        public DateTime DateOfPost { get; set; }
        public string Text { get; set; }
        public DateTime ReadTimeStamp { get; set; }
        public string Url { get; set; }


        public Post(string title, DateTime date, string text, string url)
        {
            Title = title;
            DateOfPost = date;
            Text = text;
            Url = url;
        }

        public override String ToString()
        {
            var str = Url+"\n"+Title + "\n" + DateOfPost.ToString() + "\n" + Text;
            return str;
        }

    }
}
