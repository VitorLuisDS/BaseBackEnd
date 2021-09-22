using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaseBackEnd.Security.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseBackEnd.Security.Domain.ValueObjects;

namespace BaseBackEnd.Security.Domain.Entities.Tests
{
    [TestClass()]
    public class UserTests
    {
        [TestMethod()]
        public void AddNullProfileToExistingUser()
        {
            //Arrange
            var user = new User(new NameVO("Vitor"), new LoginVO("123"), new PasswordVO("111111"));
            Profile profile = null;

            // Act
            user.AddProfile(profile);

            //Assert
            Assert.IsFalse(user.UserProfiles.Any());
        }

        [TestMethod()]
        public void AddNullSessionToExistingUser()
        {
            //Arrange
            var user = new User(new NameVO("Vitor"), new LoginVO("123"), new PasswordVO("111111"));
            Session session = null;

            // Act
            user.AddSession(session);

            //Assert
            Assert.IsFalse(user.Sessions.Any());
        }
    }
}