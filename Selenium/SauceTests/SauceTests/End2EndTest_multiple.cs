using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NUnit.Framework.Constraints;
using OpenQA.Selenium.DevTools.V136.Network;
namespace SauceTests
{
    public class End2EndTest_multiple
    {

        IWebDriver driver;
        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }
        // [Test]
        [TestCase("Poxos","Pertrosyan","0002")]
        [TestCase("Arman", "Hakobyan", "1111")]


        public void Purchase_Flow(string name,string lname,int post)
        {
            // starti login
            driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
            driver.FindElement(By.Id("password")).SendKeys("secret_sauce"); 
            driver.FindElement(By.Id("login-button")).Click();

            driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack")).Click();
            driver.FindElement(By.ClassName("shopping_cart_link")).Click();

            driver.FindElement(By.Id("checkout")).Click();
            driver.FindElement(By.Id("first-name")).SendKeys(name);
            driver.FindElement(By.Id("last-name")).SendKeys(lname);
            driver.FindElement(By.Id("postal-code")).SendKeys(Convert.ToString(post));
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
