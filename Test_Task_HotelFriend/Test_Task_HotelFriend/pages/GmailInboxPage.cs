using System.Linq;
using OpenQA.Selenium;

namespace Test_Task_HotelFriend.pages
{
    public class GmailInboxPage : Page
    {
        public GmailInboxPage(IWebDriver driver) : base(driver) { }

        public string GetLoggedUserEmail()
        {
            WaitUntilIsDisplayed(this.UserTitleButtonLocator);

            var allTitle = UserTitleButtonElement.GetAttribute("title");
            var splittedTitle = allTitle.Split('(');

            return splittedTitle.Last().Replace(")", "");
        }

        public string UserTitleButtonLocator => "a[role=button][title^='Аккаунт Google']";
        public IWebElement UserTitleButtonElement => driver.FindElement(By.CssSelector(this.UserTitleButtonLocator));
    }
}
