using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalTestSHE.TestManagement;

namespace TechnicalTestSHE.PageObjects
{
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
            Click(Elements.modulesDropdown);
            Hover(Elements.environment);
            Click(By.LinkText($"{environmentModule}"));
            WaitUntilElementVisible(AirEmissionsEnvironmentPage.Elements.newRecordBtn);
        }

        public static class Elements
        {
            public static By
            modulesDropdown = By.LinkText("Modules"),
            environment = By.XPath("//li[@data-areaname='Environment']");
        }
    }
}
