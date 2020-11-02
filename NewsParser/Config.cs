using System;
namespace NewsParser
{
    public static class Config
    {
       public static string WEBPAGE = "http://zakon.kz/news/";
       
       public static string XPATHMAIN= "//div[@class='cat_news_item']/a";
       public static string XPATHTITLE = "//div[@class='fullnews white_block']/h1";
       public static string XPATHDATE = "//span[@class='news_date']";
       public static string XPATHTEXT = "//div[@id='initial_news_story']";

    }

}
