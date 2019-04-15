using System;
using NUnit.Framework;
using OpenQA.Selenium;
using TmobileTask.BaseFramework;
using TmobileTask.Utilities;

namespace TmobileTask.Pages.LoginPage
{
    public class LoginPage: BasePage<LoginPageMap, LoginPageValidator>
    {
        public LoginPage() : base(@"/login")
        {
        }
        public void WaitTillLoginFormIsDisplayed()
        {
            try
            {
                Driver.WaitTillElementIsVisible(20, By.Id("login-form"));
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail("Login form is not displayed");
            }

        }

        public void EnterUsername(String username)
        {
            Map.UsernameTxtBx.SendKeys(username);
        }
        public void EnterPassword(String password)
        {
            Map.PasswordTxtBx.SendKeys(password);
        }
        public void ClickOnLoginButton()
        {
            Map.LoginBtn.Click();
        }
        public String GetUsernameLabel()
        {
            return Map.UsernameLabel.Text;
        }
        public String GetPasswordLabel()
        {
            return Map.PasswordLabel.Text;
        }
        public String GetLoginBtnTxt()
        {
            return Map.LoginBtn.Text;
        }
        public String GetLoginFormInfoTxt()
        {
            return Map.InfoTxt.Text;
        }
        public String GetErrorMsgTxt()
        {
            return Map.ErrorMessage.Text;
        }

        public void ClickOnLogoutBtn()
        {
            Map.LogoutBtn.Click();
        }
    }
}
