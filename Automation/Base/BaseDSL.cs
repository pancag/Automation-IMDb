using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using static Automation.DriverFactory.Driver;
using Automation.Helper;
using System.Threading;
using Automation.Enums;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace Automation.Base
{
    public abstract class BaseDSL
    {
        protected Actions actions = new Actions(GetDriver());
        protected WaitHelper waitHelper = new WaitHelper();

        public string upperLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public string lowerLetters = "abcdefghijklmnopqrstuvwxyz";
        public string newSendKeysText = "";
        public void SendKeys(By by, string text, bool print = true)
        {
            try
            {
                this.newSendKeysText = (text);

                waitHelper.WaitUntilVisible(by, (int)DefaultWaitTimes.SENDKEYS).SendKeys(this.newSendKeysText);
                Sleep(500);
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao enviar texto para elemento ({by.ToString()}).\n{e.Message}");
            }
            finally
            {
                if (print) BaseTestBDD.reportHelper.AddScreenCapture(BaseTestBDD.printPath);
            }
        }

        public void SendKeys(string xpath, string text, bool print = true)
        {
            try
            {
                this.newSendKeysText = (text);

                waitHelper.WaitUntilVisible(By.XPath(xpath), (int)DefaultWaitTimes.SENDKEYS).SendKeys(this.newSendKeysText);
                Sleep(500);
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao enviar texto para elemento.\n{xpath}.\n{e.Message}");
            }
            finally
            {
                if (print) BaseTestBDD.reportHelper.AddScreenCapture(BaseTestBDD.printPath);
            }
        }

        public string GetElementProperty(By by, string property, bool print = false)
        {
            try
            {
                return waitHelper.WaitUntilVisible(by, (int)DefaultWaitTimes.GET_TEXT).GetProperty(property);
            }
            catch (Exception)
            {
                throw new Exception($"Erro ao obter propriedade de elemento.\nBy: {by.ToString()}");
            }
            finally
            {
                if (print) BaseTestBDD.reportHelper.AddScreenCapture(BaseTestBDD.printPath);
            }
        }

        public string GetElementText(By by, bool print = false)
        {
            try
            {
                return waitHelper.WaitUntilVisible(by, (int)DefaultWaitTimes.GET_TEXT).Text;
            }
            catch (ElementNotInteractableException)
            {
                throw new ElementNotInteractableException("Não foi possível obter texto de elemento, pois o mesmo não está disponível.");
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao obter texto de elemento ({by.ToString()}).\n{e.Message}");
            }
            finally
            {
                if(print) BaseTestBDD.reportHelper.AddScreenCapture(BaseTestBDD.printPath);
            }
        }
        

        public void Click(By by, bool print = true)
        {
            try
            {
                waitHelper.WaitUntilClickable(by, (int)DefaultWaitTimes.CLICK).Click();
                Sleep(500);
            }
            catch (ElementNotInteractableException e)
            {
                throw new ElementNotInteractableException($"Não foi possível clicar em elemento, pois o mesmo não está disponível.\n{e.Message}");
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao clicar em elemento.\n{by.ToString()}\n{e.Message}");
            }
            finally
            {
                if(print) BaseTestBDD.reportHelper.AddScreenCapture(BaseTestBDD.printPath);
            }
        }

        public void ClickOnButton(string buttonText, bool print = true)
        {
            try
            {
                var xpath = new StringBuilder();
                xpath.Append($"(//button[translate(text(),'{upperLetters}','{lowerLetters}')='{buttonText.ToLower()}']");
                xpath.Append($" | //button[./*[translate(text(),'{upperLetters}','{lowerLetters}')='{buttonText.ToLower()}']]");
                xpath.Append($" | //a[translate(text(),'{upperLetters}','{lowerLetters}')='{buttonText.ToLower()}']");
                xpath.Append($" | //a[./*[translate(text(),'{upperLetters}','{lowerLetters}')='{buttonText.ToLower()}']]");
                xpath.Append($" | //span[translate(text(),'{upperLetters}','{lowerLetters}')='{buttonText.ToLower()}']");
                xpath.Append($" | //span[./*[translate(text(),'{upperLetters}','{lowerLetters}')='{buttonText.ToLower()}']]");
                xpath.Append($" | //p[translate(text(),'{upperLetters}','{lowerLetters}')='{buttonText.ToLower()}']");
                xpath.Append($" | //p[./*[translate(text(),'{upperLetters}','{lowerLetters}')='{buttonText.ToLower()}']]");
                xpath.Append($" | //div[translate(text(),'{upperLetters}','{lowerLetters}')='{buttonText.ToLower()}']");
                xpath.Append($" | //div[./*[translate(text(),'{upperLetters}','{lowerLetters}')='{buttonText.ToLower()}']]");
                xpath.Append(")");

                var button = By.XPath(xpath.ToString());
                
                Click(button, print);
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao clicar em elemento.\n{e.Message}");
            }
        }

        public void ValidAssertIsTrue(By by, bool print = true)
        {
            Assert.IsTrue(IsElementVisible(by));
        }

        public void ValidAssertIsFalse(By by, bool print = true)
        {
            Assert.IsFalse(IsElementVisible(by));
        }
        public void ValidAssertAreEqual(object xpath, object value, bool print = true)
        {

            try
            {
                Assert.AreEqual(xpath,value);
            }
            catch (ElementNotVisibleException e)
            {
                throw new ElementNotVisibleException($"Erro ao encontrar elemento.\n{e.Message}");
            }
        }


        public void Sleep(int milliseconds)
        {
            waitHelper.Sleep(milliseconds);
        }

        public void GoTo(string url, bool print = true)
        {
            try
            {
                driver.Navigate().GoToUrl(url);                
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao acessar URL: {url}.\n{e.Message}");
            }
            finally
            {
                if(print) BaseTestBDD.reportHelper.AddScreenCapture(BaseTestBDD.printPath);
            }
        }
        
        public bool IsElementVisible(By by, bool print = true)
        {
            try
            {
                return waitHelper.WaitElementExists(by, (int)DefaultWaitTimes.GET_TEXT).Displayed;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (print) BaseTestBDD.reportHelper.AddScreenCapture(BaseTestBDD.printPath);
            }
        }

        public bool IsElementNotVisible(By by, bool print = true)
        {
            try
            {
                return !waitHelper.WaitElementExists(by, (int)DefaultWaitTimes.GET_TEXT).Displayed;
            }
            catch (Exception)
            {
                return true;
            }
            finally
            {
                if (print) BaseTestBDD.reportHelper.AddScreenCapture(BaseTestBDD.printPath);
            }
        }

        public void RefreshPage()
        {
            driver.Navigate().Refresh();
        }

        public void AguardarElementoAparecer(By by)
        {
            waitHelper.WaitUntilVisible(by);
        }

        public void AguardarElementoDesaparecer(By by)
        {
            waitHelper.WaitUntilDesappear(by);
        }
    }
}