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
    public class PlanAJourneyresultPage
    {
       private readonly DriverHelper driverHelper;
        WaitExtension WaitExtension;
        public PlanAJourneyresultPage(DriverHelper driverHelper)
        {
            this.driverHelper = driverHelper;
            this.WaitExtension= new WaitExtension();
        }

        IWebElement resultPageheaderTxt => 
            WaitExtension.FindAndReturnElement(driverHelper.driver, By.CssSelector("[data-favourite-journey=\"My journey\"] , [class='basic-journey-options clearfix']"));
        IWebElement resultPageheaderErrorTxt =>
            WaitExtension.FindAndReturnElement(driverHelper.driver, By.XPath("//li[@class='field-validation-error']"));
        IWebElement ClickEditJourneyLnk =>
            WaitExtension.FindAndReturnElement(driverHelper.driver, By.CssSelector("[class='edit-journey']"));
        IWebElement updatePlanner => WaitExtension.FindAndReturnElement(driverHelper.driver, By.CssSelector("#plan-journey-button"));



        public bool IsResultPageDisplayed() => resultPageheaderTxt.Displayed;
        public bool IsResultPageErrorMsgDisplayed() => resultPageheaderErrorTxt.Displayed;
        public void EditJourney()
        {
            ClickEditJourneyLnk.ClickViaJs(driverHelper.driver);
            updatePlanner.Click();
        }
    }
}
