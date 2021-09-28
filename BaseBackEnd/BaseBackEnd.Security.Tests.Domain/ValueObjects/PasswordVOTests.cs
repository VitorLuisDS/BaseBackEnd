using BaseBackEnd.Security.Domain.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BaseBackEnd.Security.Domain.ValueObjects.Tests
{
    [TestClass()]
    public class PasswordVOTests
    {
        [TestMethod()]
        public void Constructor_NullPassword_VOIsNotValid()
        {
            //Arrange
            string? password = null;

            //Act
            PasswordVO passwordVO = new(password);

            //Assert
            Assert.IsFalse(passwordVO.IsValid);
        }

        [TestMethod()]
        public void Constructor_ShortPassword_VOIsNotValid()
        {
            //Arrange
            string password = "d";

            //Act
            PasswordVO passwordVO = new(password);

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
        public void Constructor_CorrectPasswordLengthWithValidChars_VOIsValid()
        {
            //Arrange
            string password = "dev-password";

            //Act
            PasswordVO passwordVO = new(password);

            //Assert
            Assert.IsTrue(passwordVO.IsValid);
        }
    }
}