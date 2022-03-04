using BaseBackEnd.Security.Domain.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BaseBackEnd.Security.Domain.ValueObjects.Tests
{
    [TestClass()]
    public class PasswordVOTests
    {
        [TestMethod()]
        [DataRow(null)]
        public void Constructor_NullPassword_VOIsNotValid(string password)
        {
            //Arrange
            string? nullPassword = password;

            //Act
            PasswordVO passwordVO = new(nullPassword);

            //Assert
            Assert.IsFalse(passwordVO.IsValid);
        }

        [TestMethod()]
        [DataRow("d")]
        [DataRow("1")]
        [DataRow("")]
        public void Constructor_ShortPassword_VOIsNotValid(string password)
        {
            //Arrange
            string shortPassword = password;

            //Act
            PasswordVO passwordVO = new(shortPassword);

            //Assert
            Assert.IsFalse(passwordVO.IsValid);
        }

        [TestMethod()]
        public void Constructor_LongPassword_VOIsNotValid()
        {
            //Arrange
            string password = string.Concat(Enumerable.Repeat("d", PasswordVORules.MAX_LENGTH + 1));

            //Act
            PasswordVO passwordVO = new(password);

            //Assert
            Assert.IsFalse(passwordVO.IsValid);
        }

        [TestMethod()]
        [DataRow("dev-password")]
        [DataRow("dev-12345678786")]
        public void Constructor_CorrectPasswordLengthWithValidChars_VOIsValid(string password)
        {
            //Arrange
            string correctPassword = password;

            //Act
            PasswordVO passwordVO = new(correctPassword);

            //Assert
            Assert.IsTrue(passwordVO.IsValid);
        }
    }
}