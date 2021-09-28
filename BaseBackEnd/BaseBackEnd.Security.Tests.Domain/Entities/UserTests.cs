using BaseBackEnd.Security.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

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
            LoginVO login = new("123");
            PasswordVO password = new("111111");

            //Act
            Func<object> newUser = () => new User(name, login, password);

            //Assert
            Assert.ThrowsException<NullReferenceException>(newUser);
        }

        [TestMethod()]
        public void Constructor_NullLogin_ThrowsException()
        {
            //Arrange
            NameVO name = new("Vitor");
            LoginVO login = null;
            PasswordVO password = new("111111");

            //Act
            Func<object> newUser = () => new User(name, login, password);

            //Assert
            Assert.ThrowsException<NullReferenceException>(newUser);
        }

        [TestMethod()]
        public void Constructor_NullPassword_ThrowsException()
        {
            //Arrange
            NameVO name = new("Vitor");
            LoginVO login = new("123");
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
            User? user = new(new NameVO("Vitor"), new LoginVO("123"), new PasswordVO("111111"));
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
            User? user = new(new NameVO("Vitor"), new LoginVO("123"), new PasswordVO("111111"));
            Session session = null;

            //Act
            user.AddSession(session);

            //Assert
            Assert.IsFalse(user.Sessions.Any());
        }
    }
}