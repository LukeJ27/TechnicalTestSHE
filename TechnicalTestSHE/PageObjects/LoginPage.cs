using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalTestSHE.TestManagement;

namespace TechnicalTestSHE.PageObjects
{
    public class LoginPage : BasePage 
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// Logs into the Assure homepage after inputting the username and password
        /// </summary>
        /// <param name="username">Username to enter</param>
        /// <param name="password">Password to enter</param>
        public void Login(string username, string password)
        {
            SendKeys(Elements.username, username);
            SendKeys(Elements.password, password);
            Click(Elements.loginBtn);
        }

        public static class Elements
        {
            public static By
            username = By.Id("username"),
            password = By.Id("password"),
            loginBtn = By.Id("login");
        }
    }
}
