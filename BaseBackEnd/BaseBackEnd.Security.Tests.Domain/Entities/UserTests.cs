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
            NameVO? nameVO = null;
            LoginVO loginVO = FakeLoginVOData.GetLoginVO();
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
            NameVO name = new("Vitor");
            LoginVO? login = null;
            PasswordVO password = new("111111");

            //Act
            User newUser = new User(name, login, password);

            //Assert
            Assert.IsFalse(newUser.IsValid);
        }

        [TestMethod()]
        public void Constructor_NullPassword_UserIsNotValid()
        {
            //Arrange
            NameVO name = new("Vitor");
            LoginVO login = new("123");
            PasswordVO? password = null;

            //Act
            User newUser = new User(name, login, password);

            //Assert
            Assert.IsFalse(newUser.IsValid);
        }

        [TestMethod()]
        public void AddProfile_NullProfile_ThrowsException()
        {
            //Arrange
            User user = new(new NameVO("Vitor"), new LoginVO("123"), new PasswordVO("111111"));
            Profile? profile = null;

            //Act
            Action addsProfile = () => user.AddProfile(profile);

            //Assert
            Assert.ThrowsException<ArgumentNullException>(addsProfile);
        }

        [TestMethod()]
        public void AddSession_NullSession_ThrowsException()
        {
            //Arrange
            User user = new(new NameVO("Vitor"), new LoginVO("123"), new PasswordVO("111111"));
            Session? session = null;

            //Act
            Action addsSession = () => user.AddSession(session);

            //Assert
            Assert.ThrowsException<ArgumentNullException>(addsSession);
        }

        [TestMethod()]
        public void AddSession_ExistingSession_SessionIsNotAdded()
        {
            //Arrange
            User user = new(new NameVO("Vitor"), new LoginVO("123"), new PasswordVO("111111"));
            Session sessionToBeAdded = new (false, user);
            user.AddSession(sessionToBeAdded);

            //Act
            user.AddSession(sessionToBeAdded);

            //Assert
            Assert.IsFalse(user.Sessions.Count == 2);
        }

        [TestMethod()]
        public void RemoveProfile_RemoveNullProfile_ThrowsException()
        {
            //Arrange
            User user = new(new NameVO("Vitor"), new LoginVO("123"), new PasswordVO("111111"));
            Profile? profile = null;

            //Act
            Action removesProfile = () => user.RemoveProfile(profile);

            //Assert
            Assert.ThrowsException<ArgumentNullException>(removesProfile);
        }

        [TestMethod()]
        public void AddSession_AddValidSession_SessionIsAdded()
        {
            //Arrange
            User user = new(new NameVO("Vitor"), new LoginVO("123"), new PasswordVO("111111"));
            Session session = new(false, user);

            //Act
            user.AddSession(session);

            //Assert
            Assert.IsTrue(user.Sessions.Contains(session));
        }

        [TestMethod()]
        public void AddProfile_AddValidProfile_ProfileIsAdded()
        {
            //Arrange
            User user = new(new NameVO("Vitor"), new LoginVO("123"), new PasswordVO("111111"));
            Profile profile = new(new NameVO("profile"), new DescriptionVO("desc"));

            //Act
            user.AddProfile(profile);

            //Assert
            Assert.IsTrue(user.UserProfiles.Contains(profile));
        }

        [TestMethod()]
        public void RemoveProfile_RemoveProfile_ProfileIsRemoved()
        {
            //Arrange
            User user = new(new NameVO("Vitor"), new LoginVO("123"), new PasswordVO("111111"));
            Profile profile = new(new NameVO("profile"), new DescriptionVO("desc"));
            user.AddProfile(profile);

            //Act
            user.RemoveProfile(profile);

            //Assert
            Assert.IsTrue(!user.UserProfiles.Contains(profile));
        }
    }
}