using NUnit.Framework;
using System;
using TechnicalTestSHE.PageObjects;
using TechnicalTestSHE.TestManagement;

namespace TechnicalTestSHE.Tests
{

    [TestFixture]
    public class AirEmissionsTests : TestBaseClass
    {
        private LoginPage loginPage;
        private HomePage homePage;
        private AirEmissionsEnvironmentPage airEmissionsEnvironmentPage;
        private AirEmissionsFormPage airEmissionsFormPage;

        [SetUp]
        public void Setup()
        {
            loginPage = new LoginPage(Driver);
            homePage = new HomePage(Driver);
            airEmissionsEnvironmentPage = new AirEmissionsEnvironmentPage(Driver);
            airEmissionsFormPage = new AirEmissionsFormPage(Driver);
        }

        [Test]
        public void AddAndDeleteAirEmissionsRecords()
        {
            string record1DescriptionText = Guid.NewGuid().ToString();
            string record2DescriptionText = Guid.NewGuid().ToString();

            try
            {
                #region Arrange
                loginPage.Login("LukeJ", "f8*GTZ");
                homePage.SelectEnvironmentModule("Air Emissions");
                #endregion

                #region Act
                airEmissionsEnvironmentPage.SelectNewRecordButton();
                airEmissionsFormPage.CreateDefaultAirEmissionsRecord(record1DescriptionText, "August", 5);

                airEmissionsEnvironmentPage.SelectNewRecordButton();
                airEmissionsFormPage.CreateDefaultAirEmissionsRecord(record2DescriptionText, "August", 5);

                airEmissionsEnvironmentPage.DeleteRecord(record1DescriptionText);
                #endregion

                #region Assert
                Console.WriteLine($"Verifying that the Air Emissions record containing the Description text of {record1DescriptionText} is deleted");
                Assert.IsTrue(airEmissionsEnvironmentPage.RecordDeleted(record1DescriptionText), $"{record1DescriptionText} is unexpectedly still listed");
                #endregion
            }
            finally
            {
                #region Cleanup
                Console.WriteLine("Deleting any Air Emissions records that may have been left over from the test");
                if (!airEmissionsEnvironmentPage.RecordDeleted(record1DescriptionText))
                    airEmissionsEnvironmentPage.DeleteRecord(record1DescriptionText);

                if (!airEmissionsEnvironmentPage.RecordDeleted(record2DescriptionText))
                    airEmissionsEnvironmentPage.DeleteRecord(record2DescriptionText);
                #endregion
            }
        }
    }
}
