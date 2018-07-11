using System;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.Events;
using Test_Task_HotelFriend.pages;

namespace Test_Task_HotelFriend.app
{
    public class Application
    {
        private EventFiringWebDriver driver;

        public GmailMainPage gmailMainPage;
        public GmailInboxPage gmailInboxPage;
        public GoogleSignInPage googleSignInPage;

        public Application()
        {
            driver = new EventFiringWebDriver(new FirefoxDriver());
            this.gmailMainPage = new GmailMainPage(driver);
            this.gmailInboxPage = new GmailInboxPage(driver);
            this.googleSignInPage = new GoogleSignInPage(driver);
            InitializeEvents();
        }

        public void Quit()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                var fileName = TestContext.CurrentContext.TestDirectory + "\\" +
                               DateTime.Now.ToString("yy-MM-dd-HH-mm-ss-FFF") + "-" + GetType().Name + "-" +
                               TestContext.CurrentContext.Test.FullName + "." + ScreenshotImageFormat.Jpeg;
                try
                {
                    ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(fileName, ScreenshotImageFormat.Jpeg);
                    TestContext.AddTestAttachment(fileName);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            driver.Close();
            driver.Quit();
            driver.Dispose();
            driver = null;
        }

        public void InitializeEvents()
        {
            driver.FindingElement += (sender, args) => Console.WriteLine($"Looking for elemet {args.FindMethod}");
            driver.FindElementCompleted += (sender, args) => Console.WriteLine($"Element {args.FindMethod} was found");
            driver.ElementClicking += (sender, args) => Console.WriteLine($"Clicking element {args.Element}");
            driver.ElementClicked += (sender, args) => Console.WriteLine($"Element {args.Element} was clicked");
            driver.Navigating += (sender, args) => Console.WriteLine($"Navigating to {args.Url}");
            driver.Navigated += (sender, args) => Console.WriteLine($"Navigated to {args.Url}");
        }
    }
}
