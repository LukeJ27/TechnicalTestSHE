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

        [TearDown]
        public void Teardown()
        {
            loginPage.Logout();
        }

        [Test]
        public void AddAndDeleteAirEmissionsRecords()
        {
            string record1DescriptionText = Guid.NewGuid().ToString();
            string record2DescriptionText = Guid.NewGuid().ToString();

            #region Arrange
            loginPage.Login("LukeJ", "f8*GTZ");
            homePage.SelectEnvironmentModule("Air Emissions");
            #endregion

            #region Act
            airEmissionsEnvironmentPage.SelectNewRecordButton();
            airEmissionsFormPage.CreateDefaultAirEmissionsRecord(record1DescriptionText, "August", 5);

            airEmissionsEnvironmentPage.SelectNewRecordButton();
            airEmissionsFormPage.CreateDefaultAirEmissionsRecord(record2DescriptionText, "August", 5);

            airEmissionsEnvironmentPage.DeleteRecord(record2DescriptionText);
            #endregion

            #region Assert
            Console.WriteLine($"Verifying that the Air Emissions record containing the Description text of {record2DescriptionText} is deleted");
            Assert.IsTrue(airEmissionsEnvironmentPage.RecordDeleted(record2DescriptionText), $"{record2DescriptionText} is unexpectedly still listed");
            #endregion
        }
    }
}
