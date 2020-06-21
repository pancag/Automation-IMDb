using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Automation.Base;
using Automation.DSL;

namespace Automation.Pages
{
    class WatchListPages : BasePage
    {
        public static By selectFilm = By.XPath("//div[@title='Click to add to watchlist'][1]/ancestor::tr[1]/descendant::a[1]");
        public static By titleFilmeXPath = By.XPath("//div[@class='title_wrapper']/h1");
        public static string titleFilm;
        public static By removeFilm = By.XPath("//div[@title='Click to remove from watchlist']");
        public static By wacthlistTitle = By.XPath("//div[@title='Click to remove from watchlist']/preceding-sibling::a/img");

        public static By GetTitleFilmWatchlist (string title)
        {
            string xpath = $"//a[text()='{title}']";
            return By.XPath(xpath);
        }

    }
}
