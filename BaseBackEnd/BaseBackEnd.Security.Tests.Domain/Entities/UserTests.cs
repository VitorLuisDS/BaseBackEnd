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
        public void Constructor_NullName_ThrowsException()
        {
            //Arrange
            NameVO name = null;
            LoginVO login = new LoginVO("123");
            PasswordVO password = new PasswordVO("111111");

            //Act
            Func<object> newUser = () => new User(name, login, password);

            //Assert
            Assert.ThrowsException<NullReferenceException>(newUser);
        }

        [TestMethod()]
        public void Constructor_NullLogin_ThrowsException()
        {
            //Arrange
            NameVO name = new NameVO("Vitor");
            LoginVO login = null;
            PasswordVO password = new PasswordVO("111111");

            //Act
            Func<object> newUser = () => new User(name, login, password);

            //Assert
            Assert.ThrowsException<NullReferenceException>(newUser);
        }

        [TestMethod()]
        public void Constructor_NullPassword_ThrowsException()
        {
            //Arrange
            NameVO name = new NameVO("Vitor");
            LoginVO login = new LoginVO("123");
            PasswordVO password = null;

            //Act
            Func<object> newUser = () => new User(name, login, password);

            //Assert
            Assert.ThrowsException<NullReferenceException>(newUser);
        }

        [TestMethod()]
        public void AddProfile_NullProfile_DoesNotAdd()
        {
            //Arrange
            var user = new User(new NameVO("Vitor"), new LoginVO("123"), new PasswordVO("111111"));
            Profile profile = null;

            //Act
            user.AddProfile(profile);

            //Assert
            Assert.IsFalse(user.UserProfiles.Any());
        }

        [TestMethod()]
        public void AddSession_NullSession_DoesNotAdd()
        {
            //Arrange
            var user = new User(new NameVO("Vitor"), new LoginVO("123"), new PasswordVO("111111"));
            Session session = null;

            //Act
            user.AddSession(session);

            //Assert
            Assert.IsFalse(user.Sessions.Any());
        }
    }
}