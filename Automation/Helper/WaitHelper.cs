using Automation.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Automation.DriverFactory.Driver;

namespace Automation.Helper
{
    public class WaitHelper
    {
        public WebDriverWait wait;
        private readonly IWebDriver driver = GetDriver();

        public WaitHelper()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds((int)DefaultWaitTimes.WAIT_DEFAULT));
        }

        private WebDriverWait SetWait(int seconds)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
        }

        public IWebElement WaitUntilVisible(By by)
        {
            try
            {
                IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));

                return element;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IWebElement WaitUntilVisible(By by, int seconds)
        {
            try
            {
                wait = SetWait(seconds);
                IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));

                return element;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SetImplicityWait(int seconds)
        {
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Sleep(int milliseconds)
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(milliseconds));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void WaitFrameAvailable(By by)
        {
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.FrameToBeAvailableAndSwitchToIt(by));
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void WaitFrameAvailable(By by, int seconds)
        {
            try
            {
                wait = SetWait(seconds);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.FrameToBeAvailableAndSwitchToIt(by));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IWebElement WaitUntilClickable(IWebElement element)
        {
            try
            {
                wait = SetWait((int)DefaultWaitTimes.CLICK);
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IWebElement WaitUntilClickable(IWebElement element, int seconds)
        {
            try
            {
                wait = SetWait(seconds);
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public IWebElement WaitUntilClickable(By by)
        {
            try
            {
                wait = SetWait((int)DefaultWaitTimes.CLICK);
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IWebElement WaitUntilClickable(By by, int seconds)
        {
            try
            {
                wait = SetWait(seconds);
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IReadOnlyList<IWebElement> WaitUntilVisibles(By by)
        {
            try
            {
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(by));
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IReadOnlyList<IWebElement> WaitUntilVisibles(By by, int seconds)
        {
            try
            {
                wait = SetWait(seconds);
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(by));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void WaitUntilDesappear(string xPath)
        {
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath(xPath)));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void WaitUntilDesappear(string xPath, int seconds)
        {
            try
            {
                wait = SetWait(seconds);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath(xPath)));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void WaitUntilDesappear(By by)
        {
            try
            {
                wait = SetWait((int)DefaultWaitTimes.WAIT_DEFAULT);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(by));
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void WaitUntilDesappear(By by, int seconds)
        {
            try
            {
                wait = SetWait(seconds);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(by));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IWebElement WaitElementIsVisible(By by)
        {
            try
            {
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IWebElement WaitElementIsVisible(By by, int seconds)
        {
            try
            {
                wait = SetWait(seconds);
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IWebElement WaitElementExists(By by)
        {
            try
            {
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IWebElement WaitElementExists(By by, int seconds)
        {
            try
            {
                wait = SetWait(seconds);
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao aguardar até elemento existir.\n{e.Message}");
            }
        }
    }
}
