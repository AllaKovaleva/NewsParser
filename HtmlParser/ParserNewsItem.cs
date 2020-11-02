using System;
using System.Text.RegularExpressions;
using HtmlAgilityPack;



    public class ParserNewsItem
    {

    private HtmlDocument HtmlFile { get; set; }




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

    public String ExtractDatetime(String xPath)
    {  
        var node = HtmlFile.DocumentNode.SelectSingleNode(xPath);
        var dateStr= node.InnerHtml;
        dateStr = CleanTags(dateStr);
         return dateStr;
    }



   

    public String ExtractText(String xPath)
    {
        String text = "";
        var nodes = HtmlFile.DocumentNode.SelectNodes(xPath);
        if (nodes != null)
        {
            foreach (HtmlNode node in nodes)
            {
                 text = text+CleanTags(node.InnerHtml);
                Console.WriteLine(text + " text");
            }
        }
        return text;
    }


    public String CleanTags(String st)
    {
       return Regex.Replace(st, @"<[^>]*>", String.Empty);
    }
}

