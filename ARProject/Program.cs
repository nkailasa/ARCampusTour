using System;

using IronWebScraper;
namespace scraperprgm
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var scraper = new BlogScraper();
            scraper.Start();
        }
    }
    class BlogScraper : WebScraper
    {
        public override void Init()
        {
            this.LoggingLevel = WebScraper.LogLevel.All;
            this.Request("https://webapp4.asu.edu/catalog/classlist?t=2211&s=SER&hon=F&promod=F&c=POLY&e=open&page=1", Parse);
        }
        public override void Parse(Response response)
        {
            foreach (var title_link in response.Css("h2.entry-title a"))
            {
                string strTitle = title_link.TextContentClean;
                Scrape(new ScrapedData() { { "Title", strTitle } });
            }
            if (response.CssExists("div.prev-post > a[href]"))
            {
                var next_page = response.Css("div.prev-post > a[href]")[0].Attributes["href"];
                this.Request(next_page, Parse);
            }
        }
    }
}
