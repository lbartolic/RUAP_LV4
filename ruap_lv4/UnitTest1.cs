using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ruap_lv4
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://demo.opencart.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            NUnit.Framework.Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheOpencartTest()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 100000);

            driver.Navigate().GoToUrl(baseURL + "/index.php?route=account/register");
            driver.FindElement(By.Id("input-firstname")).Clear();
            driver.FindElement(By.Id("input-firstname")).SendKeys("asdasdasdasd");
            driver.FindElement(By.Id("input-lastname")).Clear();
            driver.FindElement(By.Id("input-lastname")).SendKeys("asdasdasdasda");
            driver.FindElement(By.Id("input-email")).Clear();
            driver.FindElement(By.Id("input-email")).SendKeys("luka" + randomNumber + "@asdasd.asd");
            driver.FindElement(By.Id("input-telephone")).Clear();
            driver.FindElement(By.Id("input-telephone")).SendKeys("12312312123");
            driver.FindElement(By.Id("input-address-1")).Clear();
            driver.FindElement(By.Id("input-address-1")).SendKeys("asdadasdasdas");
            driver.FindElement(By.Id("input-city")).Clear();
            driver.FindElement(By.Id("input-city")).SendKeys("asdasdasd");
            driver.FindElement(By.Id("input-postcode")).Clear();
            driver.FindElement(By.Id("input-postcode")).SendKeys("40000");
            Thread.Sleep(2000);
            new SelectElement(driver.FindElement(By.Id("input-country"))).SelectByText("Croatia");
            Thread.Sleep(2000);
            new SelectElement(driver.FindElement(By.Id("input-zone"))).SelectByText("Osječko-baranjska");
            Thread.Sleep(2000);
            driver.FindElement(By.Id("input-password")).Clear();
            driver.FindElement(By.Id("input-password")).SendKeys("asdasdasd");
            driver.FindElement(By.Id("input-confirm")).Clear();
            driver.FindElement(By.Id("input-confirm")).SendKeys("asdasdasd");
            // ERROR: Caught exception [ERROR: Unsupported command [getEval |  | ]]
            driver.FindElement(By.Name("agree")).Click();
            driver.FindElement(By.CssSelector("input.btn.btn-primary")).Click();
            driver.FindElement(By.XPath("//div[@id='top-links']/ul/li[2]/a/span")).Click();
            driver.FindElement(By.LinkText("Logout")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
