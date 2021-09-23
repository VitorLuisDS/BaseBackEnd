using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaseBackEnd.Security.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseBackEnd.Security.Tests.Domain.Fakes.ValueObjects;

namespace BaseBackEnd.Security.Domain.ValueObjects.Tests
{
    [TestClass()]
    public class LoginVOTests
    {
        [TestMethod()]
        public void Constructor_NullLogin_ThrowsException()
        {
            //Arrange
            string login = null;

            //Act
            LoginVO loginVO = new LoginVO(login);

            //Assert
            Assert.IsFalse(loginVO.IsValid);
        }

        [TestMethod()]
        public void Constructor_ShortLogin_VOIsNotValid()
        {
            //Arrange
            string login = "d";

            //Act
            LoginVO loginVO = new LoginVO(login);

            //Assert
            Assert.IsFalse(loginVO.IsValid);
        }

        [TestMethod()]
        public void Constructor_LongLogin_VOIsNotValid()
        {
            //Arrange
            string login = string.Concat(Enumerable.Repeat("dev", 50));

            //Act
            LoginVO loginVO = new LoginVO(login);

            //Assert
            Assert.IsFalse(loginVO.IsValid);
        }

        [TestMethod()]
        public void Constructor_SpaceInLogin_VOIsNotValid()
        {
            //Arrange
            string login = "dev dev";

            //Act
            LoginVO loginVO = new LoginVO(login);

            //Assert
            Assert.IsFalse(loginVO.IsValid);
        }

        [TestMethod()]
        public void Constructor_InvalidCharsInLogin_VOIsNotValid()
        {
            //Arrange
            string login = "dev-dev";

            //Act
            LoginVO loginVO = new LoginVO(login);

            //Assert
            Assert.IsFalse(loginVO.IsValid);
        }

        [TestMethod()]
        public void Constructor_CorrectLoginLengthWithValidChars_VOIsValid()
        {
            //Arrange
            string login = "dev.login";

            //Act
            LoginVO loginVO = new LoginVO(login);

            //Assert
            Assert.IsTrue(loginVO.IsValid);
        }
    }
}