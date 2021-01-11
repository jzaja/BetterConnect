using NHibernate;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using ProjectDatabase.Domain;
using ProjectDatabase.HibernateHelper;
using ProjectDatabase.Repository;
using ProjectDatabase.Repository.ConcreteRepository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProjectDatababaseTest.RepositoryTest
{
    [TestFixture]
    public class UserRepositoryTest
    {
        private IUserRepository _userRepo;

        [SetUp]
        public void CreateSchema()
        {
            _userRepo = new UserRepository(new InMemoryNHibernateHelper());
        }

        [Test]
        public void CanSaveUser()
        {
            var user = new User { Username = "fjsabgfja", Password = "fsfs", PhoneNumber = "00000000000000000" };
            var saved = _userRepo.Save(user);
            Assert.AreEqual(1, _userRepo.RowCount());
            Assert.AreEqual("fjsabgfja", saved.Username);
            Assert.AreNotEqual(0, _userRepo.RowCount());
            Assert.IsTrue(_userRepo.RowCount() >= 1);
        }

        [Test]
        public void CanGetUser()
        {
            var user = new User { Username = "testic", Password = "pass", PhoneNumber = "09843754" };
            _userRepo.Save(user);
            Assert.AreEqual(1, _userRepo.RowCount());

            BasicUser contained = _userRepo.Get(user.Id);
            Assert.IsNotNull(contained);
        }

        [Test]
        public void CanUpdateUser()
        {
            var user = new User { Username = "testic", Password = "pass", PhoneNumber = "09843754" };
            _userRepo.Save(user);
            Assert.AreEqual(1, _userRepo.RowCount());

            BasicUser usr = _userRepo.Get(user.Id);
            usr.Username = "testni";
            _userRepo.Update(usr);

            Assert.AreEqual(1, _userRepo.RowCount());
            Assert.AreEqual("testni", _userRepo.Get(usr.Id).Username);
        }

        [Test]
        public void CanFindByUsername()
        {
            var newUser = new User { Username = "misko", Password = "pass", PhoneNumber = "091" };
            _userRepo.Save(newUser);

            Assert.NotNull(_userRepo.GetByUsername("misko"));
            Assert.NotNull(_userRepo.GetByPhoneNumber("091"));

            Assert.Null(_userRepo.GetByUsername("nema me"));
            Assert.Null(_userRepo.GetByPhoneNumber("000"));
        }

        [Test]
        public void CanFindByPhoneNumber()
        {
            var newUser = new User { Username = "misko", Password = "pass", PhoneNumber = "091" };
            _userRepo.Save(newUser);

            Assert.NotNull(_userRepo.GetByPhoneNumber("091"));
            Assert.Null(_userRepo.GetByPhoneNumber("000"));
        }

        [Test]
        public void CanFindByUsernameOrPhoneNumber2()
        {
            var newUser = new User { Username = "misko", Password = "pass", PhoneNumber = "091" };
            _userRepo.Save(newUser);

            Assert.NotNull(_userRepo.GetByUsername("misko"));
            Assert.NotNull(_userRepo.GetByPhoneNumber("091"));

            Assert.Null(_userRepo.GetByUsername("nema me"));
            Assert.Null(_userRepo.GetByPhoneNumber("000"));

            Assert.IsTrue(_userRepo.ExistsByUsernameOrPhoneNumber("misko", "00000"));
            Assert.IsTrue(_userRepo.ExistsByUsernameOrPhoneNumber("maleniiii", "091"));
            Assert.IsFalse(_userRepo.ExistsByUsernameOrPhoneNumber("nepostojeci", "024982108421"));
        }

        [Test]
        public void CanDeleteUser()
        {
            var newUser = new User { Username = "misko", Password = "pass", PhoneNumber = "091" };
            var admin = new Admin { Username = "admin", Password = "pass" };
            _userRepo.Save(newUser);
            _userRepo.Save(admin);
            Assert.AreEqual(2, _userRepo.RowCount());

            _userRepo.Delete(newUser);
            Assert.AreEqual(1, _userRepo.RowCount());
        }

        [Test]
        public void CanGetRightNumberOfAdmins()
        {
            var user1 = Generator.GenerateUser("user1", "pass1", "091");
            var user2 = Generator.GenerateUser("user2", "pass2", "098");
            var admin = new Admin { Username = "admin", Password = "adminpass" };

            _userRepo.Save(user1);
            _userRepo.Save(user2);
            _userRepo.Save(admin);

            BasicUser usr = Generator.GenerateUser("dadaa", "nene", "dadads");
            _userRepo.Save(usr);

            Assert.AreEqual(4, _userRepo.RowCount());
            Assert.AreEqual(1, _userRepo.AdminRowCount());

            var admin2 = new Admin { Username = "admin2", Password = "pass2" };
            _userRepo.Save(admin2);
            Assert.AreEqual(2, _userRepo.AdminRowCount());
            Assert.AreEqual(5, _userRepo.RowCount());

            Assert.AreEqual(3, _userRepo.UsersRowCount());
        }

    }
}
