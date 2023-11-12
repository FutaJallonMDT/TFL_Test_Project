using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFL_Test_Project.Drivers;
using TFL_Test_Project.Helpers;

namespace TFL_Test_Project.Page
{
    public class HomePage
    {
        private readonly DriverHelper driverHelper;
        WaitExtension waitExtension;
        public HomePage(DriverHelper driverHelper)
        {
            this.driverHelper = driverHelper;
            this.waitExtension= new WaitExtension();
        }

        IWebElement PlanAJourney => waitExtension.FindAndReturnElement(driverHelper.driver, By.PartialLinkText("Plan a journey"));
        IWebElement Acceptcookies => 
            waitExtension.FindAndReturnElement(driverHelper.driver, By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll"));
        IWebElement recentTab =>
            waitExtension.FindAndReturnElement(driverHelper.driver, By.XPath("(//a[@href=\"#jp-recent\"])[1]"));

        public void ClickPlanAJourneyTab()
        {
            Acceptcookies.Click();
            PlanAJourney.Click();
        }

        public void ClickRecentTab()
        {
            Acceptcookies.Click();
            recentTab.Click();
        }
    }
}
