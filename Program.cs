using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Edge;
using HtmlAgilityPack;
using NFTExplorerScan.Models;
using System.Collections.Generic;
using System.Threading;

namespace NFTExplorerScan
{
    class Program
    {
        static string[] urls = new string[] { "yieldlings", "the-parliament-of-aowls", "trinley-s-many-figures" };//last part of url you want to scrape

        static void Main(string[] args)
        {
            IWebDriver driver = new EdgeDriver();
            //IWebDriver driver = new SafariDriver();

            List<CollectionStats> ScrapedStats = new List<CollectionStats>();

            for (int i = 0; i < urls.Length; i++)
            {
                string innerHtml = System.String.Empty;
                IWebElement collections;
                try
                {
                    driver.Navigate().GoToUrl(string.Format("{0}/{1}", "https://www.nftexplorer.app/collection", urls[i]));
                    Thread.Sleep(30000); //Wait 30 seconds to give javascript time to load
                    collections = driver.FindElement(By.XPath(".//div[@class='flex-wrap justify-content-center list-group list-group-horizontal']"));
                    innerHtml = collections.GetAttribute("innerHTML");
                }
                catch (Exception e) { throw new Exception("Issue scraping website!", e); }
                             
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(innerHtml);
                //Parse data scraped from website 
                ScrapedStats.Add(new CollectionStats(
                    collectionName: urls[i],
                    items: doc.DocumentNode.SelectNodes("div")[0].InnerText,
                    floorPrice: doc.DocumentNode.SelectNodes("div")[1].InnerText,
                    totalVolume: doc.DocumentNode.SelectNodes("div")[2].InnerText,
                    scrapedTime: DateTime.Now)
                );
            }

            driver.Quit();

            foreach (CollectionStats c in ScrapedStats)
                Console.WriteLine("{0}{1}{2}{3}{4}", c.CollectionName, c.Items, c.FloorPrice, c.TotalVolume, c.ScrapeTime.ToString());

        }
    }
}
