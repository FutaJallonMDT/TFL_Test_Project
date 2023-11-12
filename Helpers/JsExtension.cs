using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFL_Test_Project.Helpers
{
    public static class JsExtension
    {
        public static IJavaScriptExecutor ClickViaJs(this IWebElement element, IWebDriver driver)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", element);
            Thread.Sleep(1000);
            return js;
        }

    }
}
