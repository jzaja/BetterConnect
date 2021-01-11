using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ProjectDatabase.Domain;

namespace ProjectDatabase.Tests
{
    public class UserTest
    {
        [Test]
        public void GetEmailTest()
        {
            var user = new User { Username = "username", Password = "pass" };
            Assert.AreEqual("username", user.Username);
            Assert.AreEqual("pass", user.Password);
        }
    }
}
