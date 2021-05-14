using OpenQA.Selenium;

namespace TechnicalTestSHE.PageObjects
{
    /// <summary>
    /// Page Object for methods performed for logging in and out of the application
    /// </summary>
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

        /// <summary>
        /// Selects the user dropdown and selects an option from the dropdown menu
        /// </summary>
        /// <param name="userDropdownMenuOption">User option to select</param>
        public void SelectFromUserDropdown(string userDropdownMenuOption)
        {
            Logger($"Select the User dropdown > {userDropdownMenuOption}");
            Click(Elements.userDropdown);
            Click(By.XPath($"//ul[@class='js-she-dropdown-menu']//*[contains(text(),'{userDropdownMenuOption}')]"));
        }

        /// <summary>
        /// Logout from the application
        /// </summary>
        public void Logout()
        {
            Logger("Logout from the application");
            SelectFromUserDropdown("Log Out");
            WaitUntilElementVisible(Elements.loggedOutPage);
        }

        public static class Elements
        {
            public static By
            username = By.Id("username"),
            password = By.Id("password"),
            loginBtn = By.Id("login"),
            userDropdown = By.Id("uservoice-activation"),
            loggedOutPage = By.XPath("//div[@class='she-login-one-content']//*[contains(text(),'You are now logged out')]");
        }
    }
}
