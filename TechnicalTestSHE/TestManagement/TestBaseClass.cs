using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechnicalTestSHE.PageObjects;

namespace TechnicalTestSHE.TestManagement
{
    [TestFixture]
    public class TestBaseClass
    {
        public static IWebDriver Driver;
        private readonly string _baseUrl = "https://stirling.she-development.net/automation";

        [SetUp]
        public void SetUp()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(_baseUrl);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}
