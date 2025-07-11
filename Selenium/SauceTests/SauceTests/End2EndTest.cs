using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace SauceTests
{
    public class End2EndTest
    {
        IWebDriver driver;
        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [Test]
        
        public void Purchase_Flow()
        {
            // starti login
            driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
            driver.FindElement(By.Id("password")).SendKeys("secret_sauce"); 
            driver.FindElement(By.Id("login-button")).Click();

            // add prdo to cart
            driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack")).Click();
            driver.FindElement(By.ClassName("shopping_cart_link")).Click();

            // order mechanism
            driver.FindElement(By.Id("checkout")).Click();
            driver.FindElement(By.Id("first-name")).SendKeys("Poxos");
            driver.FindElement(By.Id("last-name")).SendKeys("Petrosyan");
            driver.FindElement(By.Id("postal-code")).SendKeys("0002");
            driver.FindElement(By.Id("continue")).Click();
            driver.FindElement(By.Id("finish")).Click();

            string confirmation = driver.FindElement(By.ClassName("complete-header")).Text;
            Assert.AreEqual("Thank you for your order!", confirmation);

            
        }
        [TearDown]
        public void TearDown()
        {
            if(TestContext.CurrentContext.Result.Outcome.Status==NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                string screenshotdir = Path.Combine(AppContext.BaseDirectory, "Screenshots");
                Directory.CreateDirectory(screenshotdir);

                string filename = $"Fail_{TestContext.CurrentContext.Test.Name}_{DateTime.Now:yyyyMMdd__HHmmss}.png";
                string fullpath=Path.Combine(screenshotdir, filename);

                var screenshot=((ITakesScreenshot)driver).GetScreenshot();
                File.WriteAllBytes(fullpath, screenshot.AsByteArray);
                
                TestContext.AddTestAttachment(fullpath, "Failure screenshot");
            }
            driver.Quit();
            driver.Dispose();
        }
    }
}
