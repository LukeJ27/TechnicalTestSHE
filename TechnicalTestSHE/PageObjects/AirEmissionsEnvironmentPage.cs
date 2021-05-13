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
    public class AirEmissionsEnvironmentPage : BasePage 
    {
        public AirEmissionsEnvironmentPage(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// Selects the new record button
        /// </summary>
        public void SelectNewRecordButton()
        {
            Click(Elements.newRecordBtn);
        }

        /// <summary>
        /// Selects the Manage Record button for the defined Air Emissions record
        /// </summary>
        /// <param name="description">The description text for the record to select the Manage Records button against</param>
        public void SelectManageRecordButton(string description)
        {
            Click(By.XPath($"//*[@title='{description}']/following::div[@class='btn-group']/button[@data-toggle='dropdown']"));
        }

        /// <summary>
        /// Selects the delete button from the Manage Record menu
        /// </summary>
        public void SelectDeleteButton()
        {
            Click(Elements.delete);
            WaitUntilElementVisible(Elements.deleteDialog);
        }

        /// <summary>
        /// Selects the confirm button from the modal for deleting a record
        /// </summary>
        public void ClickConfirm()
        {
            Click(Elements.confirmButton);
        }

        //public bool RecordDisplayed(string description)
        //{
           // return 
        //}

        public static class Elements
        {
            public static By
            newRecordBtn = By.LinkText("New Record"),
            delete = By.LinkText("Delete"),
            deleteDialog = By.Id("deleteDialog"),
            confirmButton = By.XPath("//button[contains(text(),'Confirm')]");
        }
    }
}
