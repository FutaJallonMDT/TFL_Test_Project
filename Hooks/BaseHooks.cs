using TechTalk.SpecFlow;
using TFL_Test_Project.Drivers;

namespace TFL_Test_Project.Hooks
{
    [Binding]
    public sealed class BaseHooks
    {
        private readonly DriverHelper driverHelper;

        public BaseHooks(DriverHelper driverHelper)
        {
            this.driverHelper = driverHelper;
        }


        [BeforeScenario]
        public void BeforeScenarioWithTag()
        {
            driverHelper.InitialisedBrowser();
        }

       

        [AfterScenario]
        public void AfterScenario()
        {
            driverHelper.CloseBrowser();
        }
    }
}