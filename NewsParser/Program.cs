using System;
using HtmlParser;
using DB;
using NewsPosts;
using System.Collections.Generic;
using System.Linq;

namespace NewsParser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now + ":Запуск программы");


            try
            {

             var parser = new ParserMainPage(Config.WEBPAGE, Config.XPATHMAIN, Config.XPATHDATE,
                                                            Config.XPATHTITLE,Config.XPATHTEXT);
               
             var links= parser.GetNewsUrls(Config.XPATHMAIN);

             Console.WriteLine("получено ссылок: " + links.Count);
             var news = parser.GetNews(links);
               
             var handler= new DBHandler();
             handler.InsertNews(news);
             List<Post> resultsFromDb = handler.ReadNews();
             Console.WriteLine(resultsFromDb.Count+" новоостей загружены из БД");
             foreach (var r in resultsFromDb) {
                    Console.WriteLine("из БД: "+r.ToString());
             }
             
             handler.Recycle();
             Console.ReadLine();
            }
            catch (Exception e)
            { 
                Console.WriteLine( e.ToString());
            }

    //        Regex.Split("Hello World This is a great world, This World is simply great".ToLower(), @"\W+")
    //.Where(s => s.Length > 3)
    //.GroupBy(s => s)
    //.OrderByDescending(g => g.Count())

        }
    }
}


