using System;

namespace NewsPosts
{
    public class Post
    {
        public string topic { get; set; }
        public DateTime dateOfPost { get; set; }
        public string author { get; set; }
        public string text { get; set; }
        public DateTime ReadTime { get; set; }


        public Post(string text)
        {
            this.text = text;
        }

    }
}
