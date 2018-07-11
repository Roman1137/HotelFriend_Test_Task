using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssert;
using NUnit.Framework;
using Test_Task_HotelFriend.model;

namespace Test_Task_HotelFriend.tests
{
    [TestFixture]
    public class Test : TestBase
    {
        [Test, TestCaseSource(typeof(DataProvider), nameof(DataProvider.CorrectCredentials))]
        public void VerifyLoginWithCorrectCredentials(AccountModel model)
        {
            app.gmailMainPage.Open();
            app.gmailMainPage.GoToGoogleSignInPage();
            app.googleSignInPage.SignIn(model);
            var email = app.gmailInboxPage.GetLoggedUserEmail();

            email.ShouldBeEqualTo(model.Login,
                $"The already logged user title should have included user email {email}");
        }

        [Test, TestCaseSource(typeof(DataProvider), nameof(DataProvider.WrongCredentials))]
        public void VerifyLoginWithWrongCredentials(AccountModel model)
        {
            app.gmailMainPage.Open();
            app.gmailMainPage.GoToGoogleSignInPage();
            app.googleSignInPage.SignIn(model);

            app.googleSignInPage.IsWrongPasswordErrorDisplayed()
                .ShouldBeTrue("Error should be displayed after attempt to login with wrong credentials");
        }
    }
}
