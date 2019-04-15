using System;
using OpenQA.Selenium;
using TmobileTask.BaseFramework;

namespace TmobileTask.Pages.LoginPage
{
    public class LoginPageMap:BasePageElementMap
    {
        public IWebElement LoginForm => Browser.FindElement(By.Id("login-form"));

        public IWebElement UsernameLabel => Browser.FindElement(By.CssSelector("form#login-form>fieldset>label:nth-child(3)>span:nth-child(1)"));
        public IWebElement PasswordLabel => Browser.FindElement(By.CssSelector("form#login-form>fieldset>label:nth-child(4)>span:nth-child(1)"));
        public IWebElement InfoTxt => Browser.FindElement(By.CssSelector("form#login-form>fieldset>p.info"));

        public IWebElement UsernameTxtBx => Browser.FindElement(By.CssSelector("form#login-form>fieldset>label>input[ng-model='user.name']"));
        public IWebElement PasswordTxtBx => Browser.FindElement(By.CssSelector("form#login-form>fieldset>label>input[ng-model='user.password']"));
        public IWebElement LoginBtn => Browser.FindElement(By.CssSelector("form#login-form>fieldset>button"));

        public IWebElement ErrorMessage => Browser.FindElement(By.CssSelector("form#login-form>fieldset>p.error-message"));

        public IWebElement LogoutBtn => Browser.FindElement(By.CssSelector("p[ng-click='logout()']"));
    }


}
