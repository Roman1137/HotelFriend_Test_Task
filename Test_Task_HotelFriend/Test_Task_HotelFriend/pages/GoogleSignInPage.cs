using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Test_Task_HotelFriend.model;

namespace Test_Task_HotelFriend.pages
{
    public class GoogleSignInPage : Page
    {
        public GoogleSignInPage(IWebDriver driver) : base(driver) { }

        public void SignIn(AccountModel model)
        {
            WaitUntilIsDisplayed(this.LoginFormLocator);

            EnterEmailAndSubmit(model.Login);
            WaitUntilEmailFieldIsDisappeared();
            EnterPasswordAndSumbit(model.Password);
        }

        public void WaitUntilEmailFieldIsDisappeared()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5))
            {
                Message = "Email field should have disappeared aftet clicking [Next button]"
            };
            wait.Until(ExpectedConditions.StalenessOf(EmailFieldElement));
        }

        public void EnterEmailAndSubmit(string login)
        {
            EnterText(EmailFieldElement, login);
            NextButtonAfterLoginElement.Click();
        }

        public void EnterPasswordAndSumbit(string password)
        {
            EnterText(PasswordFieldElement, password);
            NextButtonAfterPasswordElement.Click();
        }

        public bool IsWrongPasswordErrorDisplayed()
        {
            WaitUntilErrorMessageDisplayed();
            return ErrorBlockElement.Text.Contains("Неверный пароль");
        }

        public void WaitUntilErrorMessageDisplayed()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5))
            {
                Message = "Error element should have appared"
            };
            wait.Until(x => ErrorBlockElement.Displayed);
        }

        public string LoginFormLocator => ".xkfVF";
        public string EmailFieldLocator => "[type=email]";
        public string NextButtonAfterLoginLocator => "#identifierNext";
        public string PasswordFieldLocator => "[type=password]";
        public string NextButtonAfterPasswordLocator => "#passwordNext";
        public string ErrorBlockLocator => "#password [aria-live=assertive]";

        public IWebElement LoginFormElement => driver.FindElement(By.CssSelector(this.LoginFormLocator));
        public IWebElement EmailFieldElement => driver.FindElement(By.CssSelector(this.EmailFieldLocator));
        public IWebElement NextButtonAfterLoginElement => driver.FindElement(By.CssSelector(this.NextButtonAfterLoginLocator));
        public IWebElement PasswordFieldElement => driver.FindElement(By.CssSelector(this.PasswordFieldLocator));
        public IWebElement NextButtonAfterPasswordElement => driver.FindElement(By.CssSelector(this.NextButtonAfterPasswordLocator));
        public IWebElement ErrorBlockElement => driver.FindElement(By.CssSelector(this.ErrorBlockLocator));
    }
}
