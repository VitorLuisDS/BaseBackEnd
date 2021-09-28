using BaseBackEnd.Security.Domain.Entities;
using BaseBackEnd.Security.Domain.Factory.Entities.Interfaces;
using BaseBackEnd.Security.Domain.Factory.ValueObjects.Interfaces;
using BaseBackEnd.Security.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BaseBackEnd.Security.Domain.Factory.Entities.Tests
{
    [TestClass()]
    public class UserFactoryTests
    {
        [TestMethod()]
        public void CreateUser_NullPassword_UserIsNotValid()
        {
            //Arrange
            string login = "dev";
            string name = "Jack Dev Junior";
            string? password = null;
            NameVO nameVOExpected = new(name);
            LoginVO loginVOExpected = new(login);
            PasswordVO passwordVOExpected = new(password);

            Mock<INameVOFactory> mockNameVoFactory = new();
            Mock<ILoginVOFactory> mockLoginVoFactory = new();
            Mock<IPasswordVOFactory> mockPasswordVoFactory = new();

            mockNameVoFactory.Setup(f => f.CreateNameVO(name)).Returns(nameVOExpected);
            mockLoginVoFactory.Setup(f => f.CreateLoginVO(login)).Returns(loginVOExpected);
            mockPasswordVoFactory.Setup(f => f.CreatePasswordVO(password)).Returns(passwordVOExpected);

            IUserFactory userFactory = new UserFactory(mockNameVoFactory.Object, mockLoginVoFactory.Object, mockPasswordVoFactory.Object);

            //Act
            User user = userFactory.CreateUser(name, login, password);

            //Assert
            Assert.IsFalse(user.IsValid);
        }

        [TestMethod()]
        public void CreateUser_NullName_UserIsNotValid()
        {
            //Arrange
            string login = "dev";
            string? name = null;
            string password = "dev-password";
            NameVO nameVOExpected = new(name);
            LoginVO loginVOExpected = new(login);
            PasswordVO passwordVOExpected = new(password);

            Mock<INameVOFactory> mockNameVoFactory = new();
            Mock<ILoginVOFactory> mockLoginVoFactory = new();
            Mock<IPasswordVOFactory> mockPasswordVoFactory = new();

            mockNameVoFactory.Setup(f => f.CreateNameVO(name)).Returns(nameVOExpected);
            mockLoginVoFactory.Setup(f => f.CreateLoginVO(login)).Returns(loginVOExpected);
            mockPasswordVoFactory.Setup(f => f.CreatePasswordVO(password)).Returns(passwordVOExpected);

            IUserFactory userFactory = new UserFactory(mockNameVoFactory.Object, mockLoginVoFactory.Object, mockPasswordVoFactory.Object);

            //Act
            User user = userFactory.CreateUser(name, login, password);

            //Assert
            Assert.IsFalse(user.IsValid);
        }

        [TestMethod()]
        public void CreateUser_NullLogin_UserIsNotValid()
        {
            //Arrange
            string? login = null;
            string name = "Jack Dev Junior";
            string password = "dev-password";
            NameVO nameVOExpected = new(name);
            LoginVO loginVOExpected = new(login);
            PasswordVO passwordVOExpected = new(password);

            Mock<INameVOFactory> mockNameVoFactory = new();
            Mock<ILoginVOFactory> mockLoginVoFactory = new();
            Mock<IPasswordVOFactory> mockPasswordVoFactory = new();

            mockNameVoFactory.Setup(f => f.CreateNameVO(name)).Returns(nameVOExpected);
            mockLoginVoFactory.Setup(f => f.CreateLoginVO(login)).Returns(loginVOExpected);
            mockPasswordVoFactory.Setup(f => f.CreatePasswordVO(password)).Returns(passwordVOExpected);

            IUserFactory userFactory = new UserFactory(mockNameVoFactory.Object, mockLoginVoFactory.Object, mockPasswordVoFactory.Object);

            //Act
            User user = userFactory.CreateUser(name, login, password);

            //Assert
            Assert.IsFalse(user.IsValid);
        }

        [TestMethod()]
        public void CreateUser_ValidInformation_UserIsValid()
        {
            //Arrange
            string login = "dev";
            string name = "Jack Dev Junior";
            string password = "dev-password";
            NameVO nameVOExpected = new(name);
            LoginVO loginVOExpected = new(login);
            PasswordVO passwordVOExpected = new(password);

            Mock<INameVOFactory> mockNameVoFactory = new();
            Mock<ILoginVOFactory> mockLoginVoFactory = new();
            Mock<IPasswordVOFactory> mockPasswordVoFactory = new();

            mockNameVoFactory.Setup(f => f.CreateNameVO(name)).Returns(nameVOExpected);
            mockLoginVoFactory.Setup(f => f.CreateLoginVO(login)).Returns(loginVOExpected);
            mockPasswordVoFactory.Setup(f => f.CreatePasswordVO(password)).Returns(passwordVOExpected);

            IUserFactory userFactory = new UserFactory(mockNameVoFactory.Object, mockLoginVoFactory.Object, mockPasswordVoFactory.Object);

            //Act
            User user = userFactory.CreateUser(name, login, password);

            //Assert
            Assert.IsTrue(user.IsValid);
        }
    }
}