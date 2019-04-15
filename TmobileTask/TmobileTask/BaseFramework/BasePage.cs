using System;
using NUnit.Framework;
using OpenQA.Selenium;
using TmobileTask.Utilities;

namespace TmobileTask.BaseFramework
{
    public class BasePage<TM>
        where TM : BasePageElementMap, new()
    {
        protected readonly string RelativeUrl;

        private static BasePage<TM> _instance;

        public BasePage(string relativeUrl)
        {
            RelativeUrl = relativeUrl;
        }

        public BasePage()
        {
            RelativeUrl = null;
        }

        public static BasePage<TM> Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BasePage<TM>();
                }

                return _instance;
            }
        }

        protected TM Map
        {
            get
            {
                return new TM();
            }
        }

        public virtual void Navigate()
        {
            Driver.Browser.Navigate().GoToUrl(string.Concat(Data.BaseUrl,RelativeUrl));
        }
    }

    public class BasePage<TM, TV> : BasePage<TM>
        where TM : BasePageElementMap, new()
        where TV : BasePageValidator<TM>, new()
    {
        public BasePage(string relativeUrl) : base(relativeUrl)
        {
        }

        public BasePage()
        {

        }

        public TV Validate()
        {
            return new TV();
        }

        public void WaitTillUserIsDirectedTo(string relativeUrl)
        {
            try{
                Driver.WaitTillUrlMatch(20, relativeUrl);
            }
            catch (WebDriverTimeoutException) {
                Assert.Fail("Current URL is not " + relativeUrl);

            }
        }

        public string GetGreetingsTxt()
        {
            return Map.Greetings.Text;
        }

    }
}
