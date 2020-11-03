using System;
using System.Linq;
using System.Net.Http;
using HtmlAgilityPack;
using HtmlParser;
using DB;
using NewsPosts;
using Search;


namespace NewsParser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now + "_______________________1_____________________________");


            try
            {

             var parser = new ParserMainPage(Config.WEBPAGE, Config.XPATHMAIN, Config.XPATHDATE,
                                                           Config.XPATHTITLE,Config.XPATHTEXT);
             var links= parser.GetNewsUrls(Config.XPATHMAIN);
             var news = parser.GetNews(links);
            

              

            //var newsItemParser = new ParserNewsItem(Config.WEBPAGE+links.First());
            //var title = newsItemParser.ExtractTitle(Config.XPATHTITLE);
            //var datetime = newsItemParser.ExtractDatetime(Config.XPATHTITLE);
            //var text = newsItemParser.ExtractText(Config.XPATHTITLE);


            Console.WriteLine("получено ссылок: " + links.Count);
               foreach(var n in news)
                {
                    Console.WriteLine(n.ToString());
                }
            

            }
            catch (Exception e)
            { 
                Console.WriteLine("ошибка при чтении " + Config.WEBPAGE + ": " + e.ToString());
            }

    //        Regex.Split("Hello World This is a great world, This World is simply great".ToLower(), @"\W+")
    //.Where(s => s.Length > 3)
    //.GroupBy(s => s)
    //.OrderByDescending(g => g.Count())

        }
    }
}



//DB
//create tables
//load webpage (30) 
//delete old data
// delete oldest(30)
// load webpage today
//load webpage (date)



//  html parse webpage - get pages[]
//extract data from pages[]


//UI
//show tables from db
//load new pages
// search functions
// create/delete db



//unit test
//hosting
