using Automation.Enums;
using Automation.Settings;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;

namespace Automation.DriverFactory
{
    class Driver
    {
        public static IWebDriver driver = null;

        public static IWebDriver GetDriver()
        {
            if (driver == null)
                driver = SetDriver();

            return driver;
        }

        public static IWebDriver SetDriver()
        {
            try
            {
                var remoteAddress = new Uri(Environment.GetEnvironmentVariable("REMOTE_DRIVER_ADDRESS"));
                var useRemoteDriver = Environment.GetEnvironmentVariable("REMOTE_DRIVER").ToUpper();

                switch (Environment.GetEnvironmentVariable("BROWSER_TYPE"))
                {
                    case BrowserNames.CHROME:
                        ChromeOptions chromeOptions = new ChromeOptions();
                        chromeOptions.AddArguments("--incognito");
                        chromeOptions.AddArguments("--disable-notifications");

                        driver = useRemoteDriver.Equals("YES") ?
                            new RemoteWebDriver(remoteAddress, chromeOptions) : new ChromeDriver(ChromeDriverService.CreateDefaultService(), chromeOptions, TimeSpan.FromSeconds((int)DefaultWaitTimes.PAGE_LOAD));

                        break;
                    case BrowserNames.IE:
                        InternetExplorerOptions IEOptions = new InternetExplorerOptions();
                        IEOptions.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                        //IEOptions.ForceCreateProcessApi = true;
                        IEOptions.BrowserCommandLineArguments = "-private";
                        IEOptions.EnsureCleanSession = true;

                        driver = useRemoteDriver.Equals("YES") ?
                            new RemoteWebDriver(remoteAddress, IEOptions) : new InternetExplorerDriver(IEOptions);

                        break;
                    case BrowserNames.FF:
                        FirefoxOptions FFOptions = new FirefoxOptions();
                        FFOptions.AddArgument("-private");

                        driver = useRemoteDriver.Equals("YES") ?
                        new RemoteWebDriver(remoteAddress, FFOptions) : new FirefoxDriver(FFOptions);

                        break;
                    case BrowserNames.EDGE:
                        EdgeOptions EdgeOptions = new EdgeOptions();
                        //EDGEOptions.AddAdditionalCapability("ms:inPrivate", true);

                        driver = useRemoteDriver.Equals("YES") ?
                        new RemoteWebDriver(remoteAddress, EdgeOptions) : new EdgeDriver(EdgeOptions);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Selecione uma opção válida de browser no arquivo App.config.");
                }

                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds((int)DefaultWaitTimes.PAGE_LOAD);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds((int)DefaultWaitTimes.IMPLICITY_TIMEOUT);

                return driver;
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao instanciar o driver.\n{e.Message}");
            }
        }

        public static void QuitDriver()
        {
            if (driver != null)
            {
                driver.Quit();
                driver = null;
            }
        }
    }
}
