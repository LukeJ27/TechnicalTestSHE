using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace TechnicalTestSHE.PageObjects
{
    public class BasePage
    {
        private readonly IWebDriver _driver;

        protected BasePage(IWebDriver driver)
        {
            _driver = driver;
        }

        /// <summary>
        /// Waits until an element is visible
        /// </summary>
        /// <param name="byLocator">The element to check</param>
        protected void WaitUntilElementVisible(By byLocator)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementToBeClickable(byLocator));
        }

        /// <summary>
        /// Gets an element from a By locator
        /// </summary>
        /// <param name="byLocator">By locator to find</param>
        /// <returns>IWebElement of the element</returns>
        protected IWebElement GetElement(By byLocator)
        {
            WaitUntilElementVisible(byLocator);
            return _driver.FindElement(byLocator);
        }

        /// <summary>
        /// Performs a click on an element
        /// </summary>
        /// <param name="byLocator">Element to click</param>
        protected void Click(By byLocator)
        {
            WaitUntilElementVisible(byLocator);
            _driver.FindElement(byLocator).Click();
        }

        /// <summary>
        /// Enters text into the element text field
        /// </summary>
        /// <param name="byLocator">Element to enter text into</param>
        /// <param name="text">Text to enter</param>
        protected void SendKeys(By byLocator, string text)
        {
            WaitUntilElementVisible(byLocator);
            _driver.FindElement(byLocator).SendKeys(text);
        }

        /// <summary>
        /// Performs a hover over an element
        /// </summary>
        /// <param name="byLocator">Element to hover over</param>
        protected void Hover(By byLocator)
        {
            Actions actions = new Actions(_driver);
            IWebElement element = _driver.FindElement(byLocator);
            actions.MoveToElement(element).Build().Perform();
        }

        /// <summary>
        /// Waits until the requested element is not visible on the page
        /// </summary>
        /// <param name="bylocator">Element to check for visibility of</param>
        /// <param name="timeout">Timeout to set for the wait</param>
        /// <returns>True if element is not visible, otherwise false</returns>
        protected bool WaitUntilElementNotVisible(By bylocator, int timeout = 20)
        {
            bool conditionMet = false;
            try
            {
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeout));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(bylocator));
                conditionMet = true;
            }
            catch (Exception e)
            {
                Logger("Exception caught in WaitUntilElementNotVisible: " + bylocator +", " + e.Message);
                conditionMet = false;
            }
            return conditionMet;
        }

        /// <summary>
        /// Adds logs when called, to be used against methods
        /// </summary>
        /// <param name="logMessage">Log message to enter</param>
        public void Logger(string logMessage)
        {
            Console.WriteLine(logMessage);
        }
    }
}