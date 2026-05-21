using SalesSystem.Data.Controllers;

namespace TestingControllerUser
{
    public class Tests
    {
        private UsersCotroller _controller;
        [SetUp]
        public void Setup()
        {
            _controller = new UsersCotroller();
        }

        [Test]
        public void TestGetAllUsers()
        {
           
        }
    }
}
