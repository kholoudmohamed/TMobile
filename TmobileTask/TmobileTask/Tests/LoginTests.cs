using System;
using NUnit.Framework;
using TmobileTask.BaseFramework;
using TmobileTask.Pages.EmployeesPage;
using TmobileTask.Pages.LoginPage;
using TmobileTask.Utilities;

namespace TmobileTask.Tests
{
    [TestFixture]
    public class LoginTests:BaseTest
    {
        [Test]
        public void T001_AllLoginPageElementsDisplayedCorrectly()
        {
            var loginPage = new LoginPage();

            loginPage.Navigate();
            loginPage.WaitTillLoginFormIsDisplayed();
            loginPage.Validate().LoginFormDisplayedCorrectly();
            loginPage.Validate().UsernameTxtBxDisplayedCorrectly();
            loginPage.Validate().PasswordTxtBxDisplayedCorrectly();
            loginPage.Validate().LoginBtnDisplayedCorrectly();
            loginPage.Validate().LoginFormInfoTxtDisplayedCorrectlyWithUsernameAndPassword(Data.UserName, Data.Password);
        }
        [Test]
        public void T002_ValidLoginAndLogout()
        {
            var loginPage = new LoginPage();
            var employeesPage = new EmployeesPage();

            loginPage.Navigate();
            loginPage.WaitTillLoginFormIsDisplayed();
            loginPage.EnterUsername(Data.UserName);
            loginPage.EnterPassword(Data.Password);
            loginPage.ClickOnLoginButton();
            loginPage.WaitTillUserIsDirectedTo("/employees");
            loginPage.Validate().GreetingsTxtDisplayedCorrectlyWithUsername(Data.UserName);

            loginPage.ClickOnLogoutBtn();
            loginPage.WaitTillUserIsDirectedTo("/login");
            loginPage.WaitTillLoginFormIsDisplayed();

            employeesPage.Navigate();
            loginPage.WaitTillUserIsDirectedTo("/login");
            loginPage.WaitTillLoginFormIsDisplayed();

        }

        [Test]
        public void T003_InvalidLogin()
        {
            var loginPage = new LoginPage();

            loginPage.Navigate();
            loginPage.WaitTillLoginFormIsDisplayed();
            loginPage.EnterUsername("Invalid");
            loginPage.EnterPassword("Invalid");
            loginPage.ClickOnLoginButton();
            loginPage.Validate().ErrorMessageDisplayedWithText("Invalid username or password!");
        }
    }
}
