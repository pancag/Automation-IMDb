using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.Pages
{
    public class HomePages
    {
        public static By btnSignIn = By.XPath("//div[text()='Sign In']");
        public static By btnWithIMDb = By.XPath("//span[text()='Sign in with IMDb']");
        public static By btnMenu = By.Id("imdbHeader-navDrawerOpen--desktop");
    }
}
