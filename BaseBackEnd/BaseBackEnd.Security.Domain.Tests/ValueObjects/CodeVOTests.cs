using BaseBackEnd.Security.Domain.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BaseBackEnd.Security.Domain.ValueObjects.Tests
{
    [TestClass()]
    public class CodeVOTests
    {
        [TestMethod()]
        [DataRow(null)]
        public void Constructor_NullCode_VOIsNotValid(string code)
        {
            //Arrange
            string nullCode = code;

            //Act
            CodeVO codeVO = new(nullCode);

            //Assert
            Assert.IsFalse(codeVO.IsValid);
        }

        [TestMethod()]
        [DataRow("d")]
        [DataRow("")]
        public void Constructor_ShortCode_VOIsNotValid(string code)
        {
            //Arrange
            string invalidCode = code;

            //Act
            CodeVO codeVO = new(invalidCode);

            //Assert
            Assert.IsFalse(codeVO.IsValid);
        }

        [TestMethod()]
        [DataRow("dev dev")]
        [DataRow("dev!!dev")]
        public void Constructor_InvalidCharsInCode_VOIsNotValid(string code)
        {
            //Arrange
            string invalidCode = code;

            //Act
            CodeVO codeVO = new(invalidCode);

            //Assert
            Assert.IsFalse(codeVO.IsValid);
        }

        [TestMethod()]
        public void Constructor_LongCode_VOIsNotValid()
        {
            //Arrange
            string code = string.Concat(Enumerable.Repeat("d", CodeVORules.MAX_LENGTH + 1));

            //Act
            CodeVO codeVO = new(code);

            //Assert
            Assert.IsFalse(codeVO.IsValid);
        }

        [TestMethod()]
        [DataRow("dev")]
        [DataRow("dev-dev")]
        public void Constructor_CorrectCodeLengthWithValidChars_VOIsValid(string code)
        {
            //Arrange
            string validCode = code;

            //Act
            CodeVO codeVO = new(validCode);

            //Assert
            Assert.IsTrue(codeVO.IsValid);
        }
    }
}