using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TmobileTask.Utilities;

namespace TmobileTask.BaseFramework
{
    public class BasePageElementMap
    {
        protected IWebDriver Browser;
        protected WebDriverWait BrowserWait;

        public BasePageElementMap()
        {
            Browser = Driver.Browser;
            BrowserWait = Driver.BrowserWait;
        }

        public void SwitchToDefault()
        {
            Browser.SwitchTo().DefaultContent();
        }

        public IWebElement Greetings => Browser.FindElement(By.Id("greetings"));
    }
}
