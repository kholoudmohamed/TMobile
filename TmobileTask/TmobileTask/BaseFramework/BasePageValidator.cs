using System;
using NUnit.Framework;
using OpenQA.Selenium;
using TmobileTask.Pages.LoginPage;
using TmobileTask.Utilities;

namespace TmobileTask.BaseFramework
{
    public class BasePageValidator<TM>
        where TM : BasePageElementMap, new()
    {
        protected TM Map
        {
            get
            {
                return new TM();
            }
        }
        LoginPage loginPage = new LoginPage();

        public void GreetingsTxtDisplayedCorrectlyWithUsername(string username)
        {
            Driver.WaitTillElementIsVisible(10, By.Id("greetings"));
            Assert.AreEqual("Hello "+username, loginPage.GetGreetingsTxt(), "Greetings text is not correct");
        }
    }
}
