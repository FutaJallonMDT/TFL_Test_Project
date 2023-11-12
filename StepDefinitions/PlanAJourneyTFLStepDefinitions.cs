using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using TFL_Test_Project.Drivers;
using TFL_Test_Project.Page;

namespace TFL_Test_Project.StepDefinitions
{
    [Binding]
    public class PlanAJourneyTFLStepDefinitions
    {
        HomePage Hpage;
        PlanAJourneyPage JourneyPage;
        PlanAJourneyresultPage PlanAJourneyresultPage;
        private readonly DriverHelper driverHelper;
        public PlanAJourneyTFLStepDefinitions(DriverHelper _driverhelper)
        {
            driverHelper = _driverhelper;
            Hpage = new HomePage(driverHelper);
            JourneyPage = new PlanAJourneyPage(driverHelper);
            PlanAJourneyresultPage = new PlanAJourneyresultPage(driverHelper);
        }

        [Given(@"I am on TFL Site")]
        public void GivenIAmOnTFLSite()
        {
            Assert.IsTrue(driverHelper.driver.Url.Contains("https://tfl.gov.uk/"));
        }

        [When(@"I click on Plan a Journey Tab")]
        public void WhenIClickOnPlanAJourneyTab()
        {
            Hpage.ClickPlanAJourneyTab();
        }

        [Then(@"change time is displayed")]
        public void ThenIsDisplayed()
        {
            Assert.True(JourneyPage.IsChangeLinkDisplayed());
        }

        [Then(@"Arriving is displayed on the planner")]
        public void ThenArrivingIsDisplayedOnThePlanner()
        {
            JourneyPage.IsArrivingOptionDisplayed();
        }

        //[When(@"I enter '(.*)' in the From Widget and '(.*)' in to Widget and '(.*)'")]
        [When(@"I enter '(.*)' in the From Widget and '(.*)' in to Widget and '(.*)'")]
        public void ThenIShouldEnterManchesterInTheFromWidget(string from, string to, string option)
        {
            if (option == "click plan a journey button")
            {
                JourneyPage.FillJourneyInformation(from, to);
            }
            else if(option == "click change time")
            {
                JourneyPage.ClickchangeLink(from, to);
            }
        }

        [Then(@"I should verify that a Valid Journey can be Planned")]
        [Then(@"I should verify that a Valid Journey can be updated")]
        public void ThenIShouldVerifyThatAValidJourneyCanBePlanned()
        {
            Assert.True(PlanAJourneyresultPage.IsResultPageDisplayed());
        }

        [Then(@"i should verify From and To Error msg displayed")]
        public void ThenIShouldVerifyFromAndToErrorMsgDisplayed()
        {
            new Actions(driverHelper.driver).SendKeys(Keys.Escape).Perform();
            Assert.True(JourneyPage.IsFromErrorMsgDisplayed());
            Assert.True(JourneyPage.IsToErrorMsgDisplayed());
        }

        [Then(@"'([^']*)'t find a journey matching your criteria' Error msg displayed")]
        public void ThenTFindAJourneyMatchingYourCriteriaErrorMsgDisplayed(string erroMsg)
        {
            Assert.True(PlanAJourneyresultPage.IsResultPageErrorMsgDisplayed());
        }

        [When(@"I set arrival time to '([^']*)' and '([^']*)'")]
        public void WhenISetArrivalTimeToAnd(string option, string time)
        {
            JourneyPage.SetPlannerDayAndTime(option, time);
        }

        [When(@"I edit journey")]
        public void WhenIEditJourney()
        {
            PlanAJourneyresultPage.EditJourney();
        }

        [When(@"I click recent")]
        public void WhenIClickRecent()
        {
            Hpage.ClickRecentTab();
        }

        [Then(@"List of recently planned Journey is displayed")]
        public void ThenListFRecentlyPlannedJourneyIsDisplayed()
        {
            Assert.True(JourneyPage.IsListOfRecentDisplayed().Count > 0);
        }
    }
}
