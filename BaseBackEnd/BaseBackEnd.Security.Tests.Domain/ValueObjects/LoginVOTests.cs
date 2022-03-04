using BaseBackEnd.Security.Domain.RegexPatterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BaseBackEnd.Security.Domain.ValueObjects.Tests
{
    [TestClass()]
    public class LoginVOTests
    {
        [TestMethod()]
        [DataRow(null)]
        public void Constructor_NullLogin_VOIsNotValid(string login)
        {
            //Arrange
            string? nullLogin = login;

            //Act
            LoginVO loginVO = new(nullLogin);

            //Assert
            Assert.IsFalse(loginVO.IsValid);
        }

        [TestMethod()]
        [DataRow("d")]
        [DataRow("1")]
        [DataRow("")]
        public void Constructor_ShortLogin_VOIsNotValid(string login)
        {
            //Arrange
            string shortLogin = login;

            //Act
            LoginVO loginVO = new(shortLogin);

            //Assert
            Assert.IsFalse(loginVO.IsValid);
        }

        [TestMethod()]
        public void Constructor_LongLogin_VOIsNotValid()
        {
            //Arrange
            string login = string.Concat(Enumerable.Repeat("d", LoginVORules.MAX_LENGTH + 1));

            //Act
            LoginVO loginVO = new(login);

            //Assert
            Assert.IsFalse(loginVO.IsValid);
        }

        [TestMethod()]
        [DataRow("dev dev")]
        [DataRow(" devdev")]
        [DataRow("devdev ")]
        public void Constructor_SpaceInLogin_VOIsNotValid(string login)
        {
            //Arrange
            string invalidLogin = login;

            //Act
            LoginVO loginVO = new(invalidLogin);

            //Assert
            Assert.IsFalse(loginVO.IsValid);
        }

        [TestMethod()]
        [DataRow("dev-dev")]
        [DataRow("dev dev!\"")]
        public void Constructor_InvalidCharsInLogin_VOIsNotValid(string login)
        {
            //Arrange
            string invalidLogin = login;

            //Act
            LoginVO loginVO = new(invalidLogin);

            //Assert
            Assert.IsFalse(loginVO.IsValid);
        }

        [TestMethod()]
        [DataRow("dev")]
        public void Constructor_CorrectLoginLengthWithValidChars_VOIsValid(string login)
        {
            //Arrange
            string correctLogin = login;

            //Act
            LoginVO loginVO = new(correctLogin);

            //Assert
            Assert.IsTrue(loginVO.IsValid);
        }
    }
}