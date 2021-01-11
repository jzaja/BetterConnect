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
    public class UserServiceTest
    {
        private Mock<IUserRepository> _mockUserRepo;
        private Mock<IInterestRepository> _mockInterestRepo;

        [SetUp]
        public void Setup()
        {
            _mockUserRepo = new Mock<IUserRepository>();
            _mockInterestRepo = new Mock<IInterestRepository>();
        }

        [Test]
        public void TestAddingInterestToUser()
        {
            var user = Generator.GenerateUser("user", "pass", "098");
            var interest1 = Generator.GenerateInterest("skijanje");
            var interest2 = Generator.GenerateInterest("planinarenje");

            _mockInterestRepo.Setup(x => x.GetByName(interest1.Name)).Returns(interest1);
            _mockInterestRepo.Setup(x => x.GetByName(interest2.Name)).Returns(interest2);
            _mockUserRepo.Setup(x => x.Get(0)).Returns(user);
            _mockUserRepo.Setup(x => x.Save(user)).Returns(user);

            var userService = new UserService(_mockUserRepo.Object, _mockInterestRepo.Object);
            User updated = userService.AddInterest(0, interest1.Name);

            Assert.NotNull(updated);
            Assert.AreEqual(1, updated.Interests.Count);

            updated = userService.AddInterest(0, interest2.Name);
            Assert.AreEqual(2, updated.Interests.Count);
            Assert.IsFalse(updated.Interests.Count == 1);
        }

        [Test]
        public void TestRemovingInterestFromUser()
        {
            var user = Generator.GenerateUser("user", "pass", "098");
            user.Id = 0;
            var interest1 = Generator.GenerateInterest("skijanje");
            var interest2 = Generator.GenerateInterest("planinarenje");

            _mockInterestRepo.Setup(x => x.GetByName(interest1.Name)).Returns(interest1);
            _mockInterestRepo.Setup(x => x.GetByName(interest2.Name)).Returns(interest2);
            _mockUserRepo.Setup(x => x.Get(user.Id)).Returns(user);
            _mockUserRepo.Setup(x => x.Save(user)).Returns(user);

            var service = new UserService(_mockUserRepo.Object, _mockInterestRepo.Object);
            service.AddInterest(user.Id, interest1.Name);
            service.AddInterest(user.Id, interest2.Name);
            User deletedInterest = service.RemoveInterest(user.Id, interest1.Name);

            Assert.NotNull(deletedInterest);
            Assert.AreEqual(1, deletedInterest.Interests.Count);

            // try to delete already deleted interest
            deletedInterest = service.RemoveInterest(user.Id, interest1.Name);
            Assert.AreEqual(1, deletedInterest.Interests.Count);

            // try to delete another interest
            deletedInterest = service.RemoveInterest(user.Id, interest2.Name);
            Assert.AreEqual(0, deletedInterest.Interests.Count);
        }

        [Test]
        public void AdminDeletesUserTest()
        {
            var user = Generator.GenerateUser("user", "pass", "091");
            user.Id = 1;
            var admin = new Admin { Username = "admin", Password = "adminpass" };
            admin.Id = 0;

            _mockUserRepo.Setup(x => x.Get(0)).Returns(admin);
            _mockUserRepo.Setup(x => x.GetUser(1)).Returns(user);
            _mockUserRepo.Setup(x => x.Delete(user)).Returns(user);

            var service = new UserService(_mockUserRepo.Object, _mockInterestRepo.Object);

            var deleted = service.DeleteUser(admin.Id, user.Id);
            Assert.NotNull(deleted);

            // try to delete with user role, shouldn't pass
            _mockUserRepo.Setup(x => x.Get(1)).Returns(user);
            var notDeleted = service.DeleteUser(user.Id, user.Id);
            Assert.Null(notDeleted);
        }

    }
}
