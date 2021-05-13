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
    public class AirEmissionsFormPage : BasePage 
    {
        public AirEmissionsFormPage(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// Sets text in the Description field
        /// </summary>
        /// <param name="descriptionText">Text to enter</param>
        public void SetDescriptionText(string descriptionText)
        {
            SendKeys(Elements.descriptionField, descriptionText);
        }

        /// <summary>
        /// Set the Sample Date field to todays date
        /// </summary>
        public void SetSampleDateToday()
        {
            Click(Elements.calendarButton);
            Click(Elements.todaysDateButton);
        }

        /// <summary>
        /// Save and close a record
        /// </summary>
        public void SaveAndClose()
        {
            Click(Elements.saveAndCloseButton);
        }

        public void SelectMonthDropdown()
        {
            Click(By.XPath("//select[@class='ui-datepicker-month']"));
        }

        public void SetSampleDate(string month, int date)
        {
            SelectMonthDropdown();
            Click(By.XPath($"//option[contains(text(), '{month}')]"));
            SampleDateDaySelector(date);
        }

        public void SampleDateDaySelector(int date)
        {
            Click(By.XPath($"//td[@data-handler='selectDay']//a[contains(text(), '{date}')]"));
        }

        public static class Elements
        {
            public static By
            descriptionField = By.Id("SheAirEmissions_Description"),
            calendarButton = By.CssSelector(".fa-calendar"),
            todaysDateButton = By.CssSelector(".ui-datepicker-current"),
            saveAndCloseButton = By.XPath("//button[@value='Close']");
        }
    }
}
