using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalTestSHE.PageObjects;
using TechnicalTestSHE.TestManagement;

namespace TechnicalTestSHE.Tests
{
    [TestFixture]
    public class AirEmissionsTests : TestBaseClass
    {
        private LoginPage _loginPage;
        private HomePage _homePage;
        private AirEmissionsEnvironmentPage _airEmissionsEnvironmentPage;
        private AirEmissionsFormPage _airEmissionsFormPage;

        [SetUp]
        public void Before()
        {
            _loginPage = new LoginPage(Driver);
            _homePage = new HomePage(Driver);
            _airEmissionsEnvironmentPage = new AirEmissionsEnvironmentPage(Driver);
            _airEmissionsFormPage = new AirEmissionsFormPage(Driver);
        }

        [Test]
        public void AddAndDeleteAirEmissionsRecords()
        {
            string record1DescriptionText = Guid.NewGuid().ToString();
            string record2DescriptionText = Guid.NewGuid().ToString();
            _loginPage.Login("LukeJ", "f8*GTZ");
            _homePage.SelectEnvironmentModule("Air Emissions");
            _airEmissionsEnvironmentPage.SelectNewRecordButton();
            _airEmissionsFormPage.SetDescriptionText(record1DescriptionText);
            _airEmissionsFormPage.SetSampleDate("Aug", 3);
            _airEmissionsFormPage.SaveAndClose();

            _airEmissionsEnvironmentPage.SelectNewRecordButton();
            _airEmissionsFormPage.SetDescriptionText(record2DescriptionText);
            _airEmissionsFormPage.SetSampleDate("Aug", 3);
            _airEmissionsFormPage.SaveAndClose();

            _airEmissionsEnvironmentPage.SelectManageRecordButton(record1DescriptionText);
            _airEmissionsEnvironmentPage.SelectDeleteButton();
            _airEmissionsEnvironmentPage.ClickConfirm();
        }
    }
}
