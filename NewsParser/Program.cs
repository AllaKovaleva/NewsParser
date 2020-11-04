using System;
using HtmlParser;
using DB;
using NewsPosts;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace NewsParser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now + ":Запуск программ.");
            var parser = new ParserMainPage(Config.WEBPAGE, Config.XPATHMAIN, Config.XPATHDATE,
                                                            Config.XPATHTITLE, Config.XPATHTEXT);

            var links = parser.GetNewsUrls(Config.XPATHMAIN);
            Console.WriteLine("За сегодня доступно новостей: " + links.Count+ " \n Загрузка данных с " + Config.WEBPAGE);
            var news = parser.GetNews(links);
            var handler = new DBHandler();
            handler.InsertNews(news);

            bool read = true;
            while (read)
            {
                Console.WriteLine("выберите действие: load all| search val| dates from to | topten |exit");
                var prm= Console.ReadLine();
                switch (prm.Substring(0, 4))
                {
                    case "dates":// dates from to
                        //TODO
                        break;
                    case "load"://readall
                        List<Post> resultsFromDb = handler.ReadNews();
                        Console.WriteLine(resultsFromDb.Count + " новоостей загружено из БД");
                        foreach (var r in resultsFromDb) {
                            Console.WriteLine(r.ToString());
                        }
                        break;


                    case "sear"://search

                        var arg = prm.Split(' ');
                        if (arg.Length == 2) { 
                            List<Post> resultSearch = handler.ReadNews(arg[1]);
                            Console.WriteLine(resultSearch.Count + " новостей содержат заданное слово");
                            foreach (var r in resultSearch)
                            {
                                Console.WriteLine(" " + r.ToString());
                            } 
                        }

                        break;
                    case "date":
                       //TODO

                        break;
                    case "topt": //topten
                        var words=GetTopten(news);
                        Console.WriteLine("Наиболее используемые слова:");
                       foreach(var w in words)
                        {
                            int i = 1;
                            Console.Write(i + ". " + w+"/n");
                            i++;
                        }
                        break;

                    case "exit": 
                        break;
                 }
                 if (string.Equals(prm, "exit")) read = false;

            }
            handler.Recycle();



          
 
        }


        public static List<string> GetTopten(List<Post> news)
        {
         
            String allText="";
            foreach(var n in news){
            allText= allText+n.Text;
            }
            var sorted = Regex.Split(allText.ToLower(), @"\W+")
            .Where(s => s.Length > 2)
            .GroupBy(s => s)
            .OrderByDescending(g => g.Count());

            var result = new List<String>();
        
            foreach(var s in sorted.Take(10).ToList())
            {
                var word = s.ElementAt(0);  
                result.Add(word);
            }
            return result;

        }
    }
}


