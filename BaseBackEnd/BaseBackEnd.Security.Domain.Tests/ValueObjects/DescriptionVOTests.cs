using BaseBackEnd.Security.Domain.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BaseBackEnd.Security.Domain.ValueObjects.Tests
{
    [TestClass()]
    public class DescriptionVOTests
    {
        [TestMethod()]
        public void Constructor_LongDescription_VOIsNotValid()
        {
            //Arrange
            string description = string.Concat(Enumerable.Repeat("d", DescriptionVORules.MAX_LENGTH + 1));

            //Act
            DescriptionVO descriptionVO = new(description);

            //Assert
            Assert.IsFalse(descriptionVO.IsValid);
        }

        [TestMethod()]
        [DataRow(null)]
        public void Constructor_NullDescription_VOIsValid(string description)
        {
            //Arrange
            string nullDescription = description;

            //Act
            DescriptionVO descriptionVO = new(nullDescription);

            //Assert
            Assert.IsTrue(descriptionVO.IsValid);
        }

        [TestMethod()]
        [DataRow("d")]
        [DataRow("d d")]
        [DataRow("")]
        public void Constructor_CorrectDescriptionLength_VOIsValid(string description)
        {
            //Arrange
            string correctDescription = description;

            //Act
            DescriptionVO descriptionVO = new(correctDescription);

            //Assert
            Assert.IsTrue(descriptionVO.IsValid);
        }
    }
}