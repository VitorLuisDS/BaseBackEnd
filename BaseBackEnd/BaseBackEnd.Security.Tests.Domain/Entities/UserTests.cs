using BaseBackEnd.Security.Domain.ValueObjects;
using BaseBackEnd.Security.Tests.Domain.Fakes.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace BaseBackEnd.Security.Domain.Entities.Tests
{
    [TestClass()]
    public class UserTests
    {
        [TestMethod()]
        public void Constructor_NullName_UserIsNotValid()
        {
            //Arrange
            NameVO nameVO         = null;
            LoginVO loginVO       = FakeLoginVOData.GetLoginVO();
            PasswordVO passwordVO = FakePasswordVOData.GetPasswordVO();

            //Act
            User user = new User(nameVO, loginVO, passwordVO);

            //Assert
            Assert.IsFalse(user.IsValid);
        }

        [TestMethod()]
        public void Constructor_NullLogin_UserIsNotValid()
        {
            //Arrange
            NameVO name         = new("Vitor");
            LoginVO? login      = null;
            PasswordVO password = new("111111");

            //Act
            object newUser() => new User(name, login, password);

            //Assert
            Assert.Fail();
            Assert.ThrowsException<NullReferenceException>(newUser);
        }

        [TestMethod()]
        public void Constructor_NullPassword_ThrowsException()
        {
            //Arrange
            NameVO name          = new("Vitor");
            LoginVO login        = new("123");
            PasswordVO? password = null;

            //Act
            object newUser() => new User(name, login, password);

            //Assert
            Assert.Fail();
            Assert.ThrowsException<NullReferenceException>(newUser);
        }

        [TestMethod()]
        public void AddProfile_NullProfile_DoesNotAdd()
        {
            //Arrange
            User? user       = new(new NameVO("Vitor"), new LoginVO("123"), new PasswordVO("111111"));
            Profile? profile = null;

            //Act
            user.AddProfile(profile);

            //Assert
            Assert.Fail();
            Assert.IsFalse(user.UserProfiles.Any());
        }

        [TestMethod()]
        public void AddSession_NullSession_DoesNotAdd()
        {
            //Arrange
            User? user       = new(new NameVO("Vitor"), new LoginVO("123"), new PasswordVO("111111"));
            Session? session = null;

            //Act
            user.AddSession(session);

            //Assert
            Assert.Fail();
            Assert.IsFalse(user.Sessions.Any());
        }

        [TestMethod()]
        public void AddSession_ExistingSession_UserIsNotValid()
        {
            //Arrange
            User? user       = new(new NameVO("Vitor"), new LoginVO("123"), new PasswordVO("111111"));
            Session? sessionToBeAdded = new Session(false, user);
            Session? sessionNotToBeAdded = sessionToBeAdded;
            user.AddSession(sessionToBeAdded);

            //Act
            user.AddSession(sessionNotToBeAdded);

            //Assert
            Assert.Fail();
            Assert.IsFalse(user.IsValid);
        }

        [TestMethod()]
        public void RemoveProfile_RemoveNonexistentProfile_ThrowsException()
        {
            //Arrange

            //Act

            //Assert
            Assert.Fail();
        }

        [TestMethod()]
        public void AddSession_AddValidSession_SessionIsAdded()
        {
            //Arrange

            //Act

            //Assert
            Assert.Fail();
        }

        [TestMethod()]
        public void AddProfile_AddValidProfile_ProfileIsAdded()
        {
            //Arrange

            //Act

            //Assert
            Assert.Fail();
        }

        [TestMethod()]
        public void RemoveProfile_RemoveProfile_ProfileIsRemoved()
        {
            //Arrange

            //Act

            //Assert
            Assert.Fail();
        }
    }
}