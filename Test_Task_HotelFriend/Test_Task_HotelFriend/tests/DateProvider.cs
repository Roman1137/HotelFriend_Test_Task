using System.Collections;
using Test_Task_HotelFriend.model;

namespace Test_Task_HotelFriend.tests
{
    internal class DataProvider
    {
        public static IEnumerable CorrectCredentials
        {
            get
            {
                yield return new AccountModel
                {
                    Login = "example123456789example1@gmail.com",
                    Password = "123456789p"
                };
            }
        }

        public static IEnumerable WrongCredentials
        {
            get
            {
                yield return new AccountModel
                {
                    Login = "example123456789example1@gmail.com",
                    Password = "123456789ppppp"
                };
            }
        }
    }
}
