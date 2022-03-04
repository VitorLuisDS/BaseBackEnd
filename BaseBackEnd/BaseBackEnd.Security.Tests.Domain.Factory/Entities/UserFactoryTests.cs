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
        [DataRow("dev", "Jack Junior Dev", null)]
        public void CreateUser_NullPassword_UserIsNotValid(string login, string name, string password)
        {
            //Arrange
            NameVO     nameVOExpected         = new(name);
            LoginVO    loginVOExpected        = new(login);
            PasswordVO passwordVOExpected     = new(password);

            Mock<INameVOFactory>     mockNameVoFactory         = new();
            Mock<ILoginVOFactory>    mockLoginVoFactory        = new();
            Mock<IPasswordVOFactory> mockPasswordVoFactory     = new();

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
        [DataRow("dev", null, "dev-password")]
        public void CreateUser_NullName_UserIsNotValid(string login, string name, string password)
        {
            //Arrange
            NameVO     nameVOExpected         = new(name);
            LoginVO    loginVOExpected        = new(login);
            PasswordVO passwordVOExpected     = new(password);

            Mock<INameVOFactory>     mockNameVoFactory         = new();
            Mock<ILoginVOFactory>    mockLoginVoFactory        = new();
            Mock<IPasswordVOFactory> mockPasswordVoFactory     = new();

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
        [DataRow(null, "Jack Dev Junior", "dev-password")]
        public void CreateUser_NullLogin_UserIsNotValid(string login, string name, string password)
        {
            //Arrange
            NameVO     nameVOExpected         = new(name);
            LoginVO    loginVOExpected        = new(login);
            PasswordVO passwordVOExpected     = new(password);

            Mock<INameVOFactory>     mockNameVoFactory         = new();
            Mock<ILoginVOFactory>    mockLoginVoFactory        = new();
            Mock<IPasswordVOFactory> mockPasswordVoFactory     = new();

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
        [DataRow("dev", "Jack Dev Junior", "dev-password")]
        public void CreateUser_ValidInformation_UserIsValid(string login, string name, string password)
        {
            //Arrange
            NameVO     nameVOExpected         = new(name);
            LoginVO    loginVOExpected        = new(login);
            PasswordVO passwordVOExpected     = new(password);

            Mock<INameVOFactory>     mockNameVoFactory         = new();
            Mock<ILoginVOFactory>    mockLoginVoFactory        = new();
            Mock<IPasswordVOFactory> mockPasswordVoFactory     = new();

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