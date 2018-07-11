using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Test_Task_HotelFriend.pages
{
    public class Page
    {
        protected IWebDriver driver;
        public Page(IWebDriver driver)
        {
            this.driver = driver;
            this.driver.Manage().Window.Maximize();
        }

        public void WaitUntilIsDisplayed(string locator)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5))
            {
                Message = $"Locator {locator} should have been displayed at the page"
            };

            wait.Until(x => x.FindElement(By.CssSelector(locator)).Displayed);
        }

        public void EnterText(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }
    }
}
