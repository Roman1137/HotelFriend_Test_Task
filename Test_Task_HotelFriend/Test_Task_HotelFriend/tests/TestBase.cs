using NUnit.Framework;
using Test_Task_HotelFriend.app;

namespace Test_Task_HotelFriend.tests
{
    public class TestBase
    {
        public Application app;

        [SetUp]
        public void SetUp()
        {
            this.app = new Application();
        }

        [TearDown]
        public void Quit()
        {
            app.Quit();
        }
    }
}
