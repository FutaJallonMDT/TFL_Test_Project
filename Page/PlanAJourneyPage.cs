using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFL_Test_Project.Drivers;
using TFL_Test_Project.Helpers;

namespace TFL_Test_Project.Page
{
    public class PlanAJourneyPage
    {
       private readonly DriverHelper driverHelper;
        WaitExtension waitExtension;
        public PlanAJourneyPage(DriverHelper driverHelper)
        {
            this.driverHelper = driverHelper;
            this.waitExtension = new WaitExtension();
        }

        //Element
        IWebElement From => driverHelper.driver.FindElement(By.Name("InputFrom"));
        IWebElement To => driverHelper.driver.FindElement(By.Name("InputTo"));
        IWebElement PlanMYJButton => driverHelper.driver.FindElement(By.Id("plan-journey-button"));
        IWebElement FromErrorMsg =>
            waitExtension.FindAndReturnElement(driverHelper.driver, By.CssSelector("[data-valmsg-for='InputFrom']"));
        IWebElement ToErrorMsg =>
            waitExtension.FindAndReturnElement(driverHelper.driver, By.CssSelector("[data-valmsg-for='InputTo']"));
        IWebElement changeLink =>
            waitExtension.FindAndReturnElement(driverHelper.driver, By.CssSelector("[class='change-departure-time'"));
        IWebElement ArrivingOption =>
            waitExtension.FindAndReturnElement(driverHelper.driver, By.CssSelector("[for='arriving']"));
        IWebElement plannerDay =>
            waitExtension.FindAndReturnElement(driverHelper.driver, By.CssSelector("#Date"));
        IWebElement plannerTime =>
            waitExtension.FindAndReturnElement(driverHelper.driver, By.CssSelector("#Time"));
        
        IReadOnlyCollection<IWebElement> ListOfRecentJourney =>
            driverHelper.driver.FindElements(By.CssSelector("[data-journey-type='recent']"));

        //Method
        public void FillJourneyInformation(string from, string to)
        {
            From.SendKeys(from);
            To.SendKeys(to);
            PlanMYJButton.ClickViaJs(driverHelper.driver);
        }

        public void ClickchangeLink(string from, string to)
        {
            driverHelper.driver.Navigate().Refresh();
            From.SendKeys(from);
            To.SendKeys(to);
            new Actions(driverHelper.driver).SendKeys(Keys.Escape).Perform();
            changeLink.ClickViaJs(driverHelper.driver);
        }
        public bool IsChangeLinkDisplayed() => changeLink.Displayed;
        public bool IsFromErrorMsgDisplayed() => FromErrorMsg.Displayed;
        public bool IsToErrorMsgDisplayed() => ToErrorMsg.Displayed;
        public bool IsArrivingOptionDisplayed() => ArrivingOption.Displayed;
        public void SetPlannerDayAndTime(string option, string time)
        {
            ArrivingOption.Click();
            plannerDay.SendKeys(option);
            plannerTime.SendKeys(time);
            PlanMYJButton.ClickViaJs(driverHelper.driver);
        }
        

        public List<IWebElement> IsListOfRecentDisplayed() => ListOfRecentJourney.ToList();
    }
}
