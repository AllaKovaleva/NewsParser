using System;
using System.Globalization;
using System.Text.RegularExpressions;
using HtmlAgilityPack;



    public class ParserNewsItem
    {

    private HtmlDocument HtmlFile;




     public ParserNewsItem(string url)
        {
         HtmlWeb web = new HtmlWeb();
         HtmlFile = web.Load(url);
    }


    public String ExtractTitle(String xPath)
        {
        HtmlNode node = HtmlFile.DocumentNode.SelectSingleNode(xPath);
        var title = node.InnerHtml;
        return title;
        }

    public String ExtractDatetimeStr(String xPath)
    {  
        var node = HtmlFile.DocumentNode.SelectSingleNode(xPath);
        var dateStr= node.InnerHtml;
        dateStr = CleanTags(dateStr);
        return dateStr;
    }

    public DateTime ExtractDatetime(String xPath)
    {
        var node = HtmlFile.DocumentNode.SelectSingleNode(xPath);
        var dateStr = node.InnerHtml;
        dateStr = CleanTags(dateStr);

        var date = ParseDate(dateStr);
        
        return date;
    }


    public DateTime ParseDate(String str)
    {
        var cultureInfo = new CultureInfo("ru-RU");
      
        var dateTime = DateTime.Parse(str, cultureInfo);
        return dateTime;
    }



    public String ExtractText(String xPath)
    {
        String text = "";
        var nodes = HtmlFile.DocumentNode.SelectNodes(xPath);
        if (nodes != null)
        {
            foreach (HtmlNode node in nodes)
            {
                text = text+ CleanTags(node.InnerHtml);

            }
        }
        return text;
    }


    public String CleanTags(String st)
    {
       return Regex.Replace(st, @"<[^>]*>", String.Empty);
    }

     
}

