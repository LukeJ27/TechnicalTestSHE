using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace TechnicalTestSHE.TestManagement
{
    /// <summary>
    /// Test Base class to initiate WebDriver
    /// </summary>
    [TestFixture]
    public class TestBaseClass
    {
        public IWebDriver Driver;
        private readonly string _baseUrl = "https://stirling.she-development.net/automation";

        [SetUp]
        public void SetUp()
        {
            Console.WriteLine("Initialising Chrome Driver");
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(_baseUrl);
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("Killing the WebDriver");
            Driver.Quit();
        }
    }
}
