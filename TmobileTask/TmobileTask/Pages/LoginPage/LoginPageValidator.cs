using System;
using NUnit.Framework;
using OpenQA.Selenium;
using TmobileTask.BaseFramework;
using TmobileTask.Utilities;

namespace TmobileTask.Pages.LoginPage
{
    public class LoginPageValidator : BasePageValidator<LoginPageMap>
    {
        LoginPage loginPage = new LoginPage();

        public void LoginFormDisplayedCorrectly()
        {
            Assert.AreEqual("submit()",Map.LoginForm.GetAttribute("ng-submit"), "There is no submit function specified for the login form");
        }

        public void UsernameTxtBxDisplayedCorrectly()
        {
            Assert.Multiple(() =>
            {
                Assert.IsTrue(Map.UsernameLabel.Displayed, "Username text box label is not displayed");
                Assert.AreEqual("Username*",loginPage.GetUsernameLabel(), "Username text box label is not correct");
                Assert.IsTrue(Map.UsernameTxtBx.Displayed, "Username text box is not displayed");
            });
        }
        public void PasswordTxtBxDisplayedCorrectly()
        {
            Assert.Multiple(() =>
            {
                Assert.IsTrue(Map.PasswordLabel.Displayed, "Password text box label is not displayed");
                Assert.AreEqual("Password*", loginPage.GetPasswordLabel(), "Password text box label is not correct");
                Assert.IsTrue(Map.PasswordTxtBx.Displayed, "Password text box is not displayed");
            });
        }
        public void LoginBtnDisplayedCorrectly()
        {
            Assert.Multiple(() =>
            {
                Assert.IsTrue(Map.LoginBtn.Displayed, "Login button is not displayed");
                Assert.IsTrue(Map.LoginBtn.Enabled, "Login button is not enabled");
                Assert.AreEqual("Login", loginPage.GetLoginBtnTxt(), "Login button text is not correct");
            });
        }
        public void LoginFormInfoTxtDisplayedCorrectlyWithUsernameAndPassword(String username, String password)
        {
            Assert.Multiple(() =>
            {
                Assert.IsTrue(Map.InfoTxt.Displayed, "Login form info text is not displayed");
                Assert.AreEqual("Username: \""+username+"\" Password: \""+password+"\"", loginPage.GetLoginFormInfoTxt(), "Login form info text is not correct");
            });
        }
        public void ErrorMessageDisplayedWithText(string expectedErrorMessageTxt)
        {
            Driver.WaitTillElementIsVisible(10, By.CssSelector("form#login-form>fieldset>p.error-message"));
            Assert.AreEqual(expectedErrorMessageTxt, loginPage.GetErrorMsgTxt(), "Error message text is not correct");

        }
    }
}
