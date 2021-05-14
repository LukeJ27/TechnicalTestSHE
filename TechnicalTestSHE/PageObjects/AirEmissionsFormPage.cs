﻿using OpenQA.Selenium;

namespace TechnicalTestSHE.PageObjects
{
    /// <summary>
    /// Page Object for methods performed within an Air Emissions form
    /// </summary>
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
            Logger($"Setting description text of {descriptionText}");
            SendKeys(Elements.descriptionField, descriptionText);
        }

        /// <summary>
        /// Save and close a record
        /// </summary>
        public void SaveAndClose()
        {
            Logger("Selecting the Save and Close button");
            Click(Elements.saveAndCloseButton);
        }

        /// <summary>
        /// Selects the Month dropdown from the Sample Date picker
        /// </summary>
        public void SelectMonthDropdown()
        {
            Logger("Selecting the Month dropdown");
            Click(By.XPath("//select[@class='ui-datepicker-month']"));
        }

        /// <summary>
        /// Select a day from the Sample Date picker
        /// </summary>
        /// <param name="date">The date to select</param>
        public void SampleDateDaySelector(int date)
        {
            Logger($"Select the date of {date}");
            Click(By.XPath($"//td[@data-handler='selectDay']//a[contains(text(), '{date}')]"));
        }

        /// <summary>
        /// Setting the Sample Date field, selecting a month and date to populate the field with
        /// </summary>
        /// <param name="month">The month to select (first 3 characters of the month name only)</param>
        /// <param name="date">The date of the month to select</param>
        public void SetSampleDate(string month, int date)
        {
            Logger($"Opening the Sample Date calendar, and selecting the month of {month} and the date of {date}");
            Click(Elements.calendarButton);
            SelectMonthDropdown();
            Click(By.XPath($"//option[contains(text(), '{month.Substring(0, 3)}')]"));
            SampleDateDaySelector(date);
        }

        /// <summary>
        /// Creates a default Air Emissions record, populating the required field Sample Date, and the Description field
        /// </summary>
        /// <param name="descriptionText">The description text to enter</param>
        /// <param name="month">The month to select from the Sample Date picker (first 3 characters of the month name only)</param>
        /// <param name="date">The date of the month to select</param>
        public void CreateDefaultAirEmissionsRecord(string descriptionText, string month, int date)
        {
            Logger("Setting the required fields for the Air Emissions record, then saving and closing the record");
            SetDescriptionText(descriptionText);
            SetSampleDate(month, date);
            SaveAndClose();
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
