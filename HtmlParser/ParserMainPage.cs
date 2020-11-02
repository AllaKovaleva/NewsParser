using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using HtmlAgilityPack;
using NewsPosts;

namespace HtmlParser
{
    public class ParserMainPage
    {
        public string UrlMain { get; set; }
        public string XpathMain { get; set; }
        public string XpathTitle { get; set; }
        public string XpathDatetime { get; set; }
        public string XpathText { get; set; }

        private HtmlDocument HtmlDoc { get; set; }

        public ParserMainPage(string link)
        {
            UrlMain = link;

            HtmlWeb web = new HtmlWeb();
            HtmlDoc= web.Load(UrlMain);
        }

        public ParserMainPage(string urlMain, string xpathMain,
            string xpathDatetime, string xpathTitle, string xpathText)
        {
            UrlMain = urlMain;
            XpathMain = xpathMain;
            XpathTitle = xpathTitle;
            XpathDatetime = xpathDatetime;
            XpathText = xpathText;

            HtmlWeb web = new HtmlWeb();
            HtmlDoc = web.Load(UrlMain);
        }



        public List<String> GetNewsUrls(String xPath)
        {
            var urls = new List<String>();
           
            var nodes = HtmlDoc.DocumentNode.SelectNodes(xPath);
            if (nodes != null){
                foreach (HtmlNode node in nodes)
                {
                   var link = node.GetAttributeValue("href","");
                   urls.Add(link);
             } }

            return urls;
        }



        public List<Post> GetNews(List<String> urls)
        {
            var data = new List<Post>();

            var url = urls.First();
           // foreach (var url in urls)
            //{

                var newsItemParser = new ParserNewsItem(UrlMain + url);
                var title = newsItemParser.ExtractTitle(XpathTitle);
                var datetime = newsItemParser.ExtractDatetime(XpathDatetime);
                var text = newsItemParser.ExtractText(XpathText);

                Console.WriteLine(title);
                Console.WriteLine(datetime);
                Console.WriteLine(text);
                var newsItem = new Post("");
                data.Add(newsItem);
           // }
            
            return data;
        }

    }
}
