using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaseBackEnd.Security.Domain.Factory.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseBackEnd.Security.Domain.Factory.ValueObjects;
using Moq;
using BaseBackEnd.Security.Domain.Factory.ValueObjects.Interfaces;
using BaseBackEnd.Security.Domain.Factory.Entities.Interfaces;
using BaseBackEnd.Security.Domain.ValueObjects;
using BaseBackEnd.Security.Domain.Entities;

namespace BaseBackEnd.Security.Domain.Factory.Entities.Tests
{
    [TestClass()]
    public class UserFactoryTests
    {
        [TestMethod()]
        public void CreateUser_ValidInformation_UserIsValid()
        {
            //Arrange
            string login = "dev";
            string name = "Jack Dev Junior";
            string password = "dev-password";
            NameVO nameVOExpected = new NameVO(name);
            LoginVO loginVOExpected = new LoginVO(login);
            PasswordVO passwordVOExpected = new PasswordVO(password);

            Mock<INameVOFactory> mockNameVoFactory = new Mock<INameVOFactory>();
            Mock<ILoginVOFactory> mockLoginVoFactory = new Mock<ILoginVOFactory>();
            Mock<IPasswordVOFactory> mockPasswordVoFactory = new Mock<IPasswordVOFactory>();

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