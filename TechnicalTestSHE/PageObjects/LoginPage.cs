using OpenQA.Selenium;

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
            Logger($"Entering the username of {username}");
            SendKeys(Elements.username, username);
            Logger($"Entering the password of {password}");
            SendKeys(Elements.password, password);
            Logger("Selecting the login button");
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
