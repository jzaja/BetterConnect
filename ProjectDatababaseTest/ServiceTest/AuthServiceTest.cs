using Moq;
using NUnit.Framework;
using ProjectDatabase.Domain;
using ProjectDatabase.Repository;
using ProjectDatabase.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectDatababaseTest.ServiceTest
{
    [TestFixture]
    public class AuthServiceTest
    {
        private Mock<IUserRepository> _mockUserRepo;

        [SetUp]
        public void Setup()
        {
            _mockUserRepo = new Mock<IUserRepository>();
        }

        [Test]
        public void TestLogin()
        {
            var user = GenerateUser("test", "pass", "091");
            _mockUserRepo.Setup(u => u.GetByUsername("test")).Returns(user);

            var user2 = GenerateUser("proba", "password", "098");
            _mockUserRepo.Setup(u => u.GetByUsername("proba")).Returns(user2);

            var service = new AuthService(_mockUserRepo.Object);
            Assert.NotNull(service.Login("test", "pass"));
            Assert.Null(service.Login("test", "krivipass"));
            Assert.Null(service.Login("desi", "nista"));

            Assert.NotNull(service.Login("proba", "password"));
            Assert.Null(service.Login("proba", "krivipass"));
        }

        private User GenerateUser(string username, string password, string phoneNumber)
        {
            return new User { Username = username, Password = password, PhoneNumber = phoneNumber };
        }

    }
}
