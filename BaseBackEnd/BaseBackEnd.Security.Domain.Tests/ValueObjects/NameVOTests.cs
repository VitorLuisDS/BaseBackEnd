using BaseBackEnd.Security.Domain.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BaseBackEnd.Security.Domain.ValueObjects.Tests
{
    [TestClass()]
    public class NameVOTests
    {
        [TestMethod()]
        [DataRow(null)]
        public void Constructor_NullName_VOIsNotValid(string name)
        {
            //Arrange
            string? nullName = name;

            //Act
            NameVO nameVO = new(nullName);

            //Assert
            Assert.IsFalse(nameVO.IsValid);
        }

        [TestMethod()]
        [DataRow("d")]
        [DataRow("1")]
        [DataRow("")]
        public void Constructor_ShortName_VOIsNotValid(string name)
        {
            //Arrange
            string shortName = name;

            //Act
            NameVO nameVO = new(shortName);

            //Assert
            Assert.IsFalse(nameVO.IsValid);
        }

        [TestMethod()]
        public void Constructor_LongName_VOIsNotValid()
        {
            //Arrange
            string name = string.Concat(Enumerable.Repeat("d", NameVORules.MAX_LENGTH + 1));

            //Act
            NameVO nameVO = new(name);

            //Assert
            Assert.IsFalse(nameVO.IsValid);
        }

        [TestMethod()]
        [DataRow("dev dev ")]
        public void Constructor_SpaceInEndOfName_VOIsNotValid(string name)
        {
            //Arrange
            string invalidName = name;

            //Act
            NameVO nameVO = new(invalidName);

            //Assert
            Assert.IsFalse(nameVO.IsValid);
        }

        [TestMethod()]
        [DataRow("dev-dev")]
        [DataRow("dev dev!\"")]
        public void Constructor_InvalidCharsInName_VOIsNotValid(string name)
        {
            //Arrange
            string invalidName = name;

            //Act
            NameVO nameVO = new(invalidName);

            //Assert
            Assert.IsFalse(nameVO.IsValid);
        }

        [TestMethod()]
        [DataRow("Jack Junior Dev")]
        [DataRow("Phil Senior Dev")]
        public void Constructor_CorrectNameLengthWithValidChars_VOIsValid(string name)
        {
            //Arrange
            string correctName = name;

            //Act
            NameVO nameVO = new(correctName);

            //Assert
            Assert.IsTrue(nameVO.IsValid);
        }
    }
}