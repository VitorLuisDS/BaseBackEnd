using BaseBackEnd.Security.Domain.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseBackEnd.Security.Domain.ValueObjects.Tests
{
    [TestClass()]
    public class NameVOTests
    {
        [TestMethod()]
        public void Constructor_NullName_VOIsNotValid()
        {
            //Arrange
            string name = null;

            //Act
            NameVO nameVO = new NameVO(name);

            //Assert
            Assert.IsFalse(nameVO.IsValid);
        }

        [TestMethod()]
        public void Constructor_ShortName_VOIsNotValid()
        {
            //Arrange
            string name = "d";

            //Act
            NameVO nameVO = new NameVO(name);

            //Assert
            Assert.IsFalse(nameVO.IsValid);
        }

        [TestMethod()]
        public void Constructor_LongName_VOIsNotValid()
        {
            //Arrange
            string name = string.Concat(Enumerable.Repeat("d", NameVORules.MAX_LENGTH + 1));

            //Act
            NameVO nameVO = new NameVO(name);

            //Assert
            Assert.IsFalse(nameVO.IsValid);
        }

        [TestMethod()]
        public void Constructor_SpaceInEndOfName_VOIsNotValid()
        {
            //Arrange
            string name = "dev dev ";

            //Act
            NameVO nameVO = new NameVO(name);

            //Assert
            Assert.IsFalse(nameVO.IsValid);
        }

        [TestMethod()]
        public void Constructor_InvalidCharsInName_VOIsNotValid()
        {
            //Arrange
            string name = "dev-dev";

            //Act
            NameVO nameVO = new NameVO(name);

            //Assert
            Assert.IsFalse(nameVO.IsValid);
        }

        [TestMethod()]
        public void Constructor_CorrectNameLengthWithValidChars_VOIsValid()
        {
            //Arrange
            string name = "Jack Dev Junior";

            //Act
            NameVO nameVO = new NameVO(name);

            //Assert
            Assert.IsTrue(nameVO.IsValid);
        }
    }
}