using OpenQA.Selenium;

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
            Logger("Selecting the new record button");
            Click(Elements.newRecordBtn);
        }

        /// <summary>
        /// Selects the Manage Record button for the defined Air Emissions record
        /// </summary>
        /// <param name="description">The description text of the record to select the Manage Records button against</param>
        public void SelectManageRecordButton(string description)
        {
            Logger($"Selecting the Manage Records button for the Air Emissions record with the Description of {description}");
            Click(ManageRecordButton(description));
        }

        /// <summary>
        /// Selects the delete button from the Manage Record menu
        /// </summary>
        public void SelectDeleteButton()
        {
            Logger("Selecting the Delete button and waiting fore the delete confirmation modal to appear");
            Click(Elements.delete);
            WaitUntilElementVisible(Elements.deleteDialog);
        }

        /// <summary>
        /// Selects the confirm button from the modal for deleting a record
        /// </summary>
        public void ClickConfirm()
        {
            Logger("Selecting the confirm button on the delete confirmation modal");
            Click(Elements.confirmButton);
        }

        public void DeleteRecord(string descriptionText)
        {
            SelectManageRecordButton(descriptionText);
            SelectDeleteButton();
            ClickConfirm();
        }

        /// <summary>
        /// Checks if a record is deleted from the list of Air Emissions records
        /// </summary>
        /// <param name="description">The desciption text of the record to check</param>
        /// <returns>True if the record is deleted, otherwise false</returns>
        public bool RecordDeleted(string description)
        {
            WaitUntilElementVisible(Elements.newRecordBtn);
            Logger($"Checking if the record containing the Description text of {description} has been deleted");
            return WaitUntilElementNotVisible(ManageRecordButton(description), 3);
        }

        /// <summary>
        /// Element path for the Manage Record button of the chosen record
        /// </summary>
        /// <param name="description">The description text for the record the Manage Records button element is associated to</param>
        /// <returns>The button element path</returns>
        public By ManageRecordButton(string description)
        {
            Logger($"Getting the Manage Record button element path for record containing the Description of {description}");
            return By.XPath($"//*[@title='{description}']/following::div[@class='btn-group']/button[@data-toggle='dropdown']");
        }

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
