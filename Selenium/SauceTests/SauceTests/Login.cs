using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SauceTests
{
    public class LoginTest
    {
        IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver=new ChromeDriver();  
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [Test]
        public void Test1()
        {
            driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
            driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
            driver.FindElement(By.Id("login-button")).Click();

            string title = driver.FindElement(By.ClassName("title")).Text;

            Assert.AreEqual("Products",title,"Login failed or products page not displayed");
        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            // shut es anum
            driver.Dispose();
        }
    }
}