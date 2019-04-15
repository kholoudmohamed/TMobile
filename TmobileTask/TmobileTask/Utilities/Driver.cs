using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace TmobileTask.Utilities
{
    public class Driver
    {
        private static WebDriverWait _browserWait;

        private static IWebDriver _browser;

        public static IWebDriver Browser
        {
            get
            {
                if (_browser == null)
                {
                    throw new NullReferenceException("The WebDriver browser instance was not initialized. You should first call the method Start.");
                }
                return _browser;
            }
            private set
            {
                _browser = value;
            }
        }

        public static WebDriverWait BrowserWait
        {
            get
            {
                if (_browserWait == null || _browser == null)
                {
                    throw new NullReferenceException("The WebDriver browser wait instance was not initialized. You should first call the method Start.");
                }
                return _browserWait;
            }
            private set
            {
                _browserWait = value;
            }
        }

        public static void StartBrowser(BrowserTypes browserType = BrowserTypes.Chrome, int defaultTimeOut = 30)
        {
            switch (browserType)
            {
                case BrowserTypes.Firefox:
                    Browser = new FirefoxDriver();
                    break;
                case BrowserTypes.InternetExplorer:
                    break;
                case BrowserTypes.Chrome:
                    Browser = new ChromeDriver();
                    break;
                default:
                    break;
            }
            Browser.Manage().Window.Maximize();
            BrowserWait = new WebDriverWait(Browser, TimeSpan.FromSeconds(defaultTimeOut));
        }

        public static void StopBrowser()
        {
            Browser.Quit();
            Browser = null;
            BrowserWait = null;
        }
        public static void WaitTillElementIsVisible(int sec, By selector)
        {
            new WebDriverWait(Browser, TimeSpan.FromSeconds(sec)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(selector));
        }
        public static void WaitTillUrlMatch(int sec, string expectedRelativeUrl)
        {
            new WebDriverWait(Browser, TimeSpan.FromSeconds(sec)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlMatches(Data.BaseUrl+expectedRelativeUrl));
        }
        public static string GetCurrentUrl()
        {
            return Browser.Url;
        }
    }
}
