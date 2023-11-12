using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TFL_Test_Project.Helpers
{
    public class WaitExtension
    {
        private Lazy<WebDriverWait> _wait = null;

        public WebDriverWait GetWaitDriver(IWebDriver driver)
        {
            return new(driver, TimeSpan.FromSeconds(30))
            {
                PollingInterval = TimeSpan.FromSeconds(30)
            };
        }

        public IWebElement FindAndReturnElement(IWebDriver driver, By by)
        {
            _wait = new Lazy<WebDriverWait>(GetWaitDriver(driver));
            return _wait.Value.Until(x => x.FindElement(by));
        }
    }
}
