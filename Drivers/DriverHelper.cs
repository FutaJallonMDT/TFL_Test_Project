using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;

namespace TFL_Test_Project.Drivers
{
    public class DriverHelper
    {
       public IWebDriver driver;

        public void InitialisedBrowser()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            var options = new ChromeOptions();
            options.AddArguments(Enviroment.Max, Enviroment._private);
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(Enviroment.TFLAutomationExcercise);

        }

        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}
