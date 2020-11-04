using System;

namespace NewsPosts
{
    public class Post
    {
        public string Title { get; set; }
        public DateTime DateOfPost { get; set; }
        public string Text { get; set; }
        public string Url { get; set; }


        public Post(string title, DateTime date, string url, string text)
        {
            Title = title;
            DateOfPost = date;
            Url = url;
            Text = text;
        }

        public override String ToString()
        {
            var str = Title + "\n" + DateOfPost.ToString() + "\n"+Url + "\n"  + Text;
            return str;
        }

    }
}