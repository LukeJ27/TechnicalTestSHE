using OpenQA.Selenium;

namespace TechnicalTestSHE.PageObjects
{
    /// <summary>
    /// Page Object for methods performed from the home page
    /// </summary>
    public class HomePage : BasePage 
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// Selects a module from the Environment option in the Modules menu
        /// </summary>
        /// <param name="environmentModule">The environment module to open</param>
        public void SelectEnvironmentModule(string environmentModule)
        {
            Logger($"Selecting Modules > Environment > {environmentModule}");
            Click(Elements.modulesDropdown);
            Hover(Elements.environment);
            Click(By.LinkText($"{environmentModule}"));
            WaitUntilElementVisible(AirEmissionsEnvironmentPage.Elements.newRecordBtn);
        }

        public static class Elements
        {
            public static By
            modulesDropdown = By.LinkText("Modules"),
            environment = By.LinkText("Environment");
        }
    }
}
