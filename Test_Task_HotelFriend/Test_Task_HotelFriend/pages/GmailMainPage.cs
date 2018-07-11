using OpenQA.Selenium;

namespace Test_Task_HotelFriend.pages
{
    public class GmailMainPage : Page
    {
        public GmailMainPage(IWebDriver driver) : base(driver) { }

        public void GoToGoogleSignInPage()
        {
            this.LoginButtonElement.Click();
        }

        public void Open()
        {
            driver.Url = "https://www.google.com/intl/ru/gmail/about/";
            WaitUntilIsDisplayed(this.LoginButtonLocator);
        }

        public string LoginButtonLocator => "[data-g-label='Sign in']";
        public IWebElement LoginButtonElement => driver.FindElement(By.CssSelector(this.LoginButtonLocator));
    }
}
