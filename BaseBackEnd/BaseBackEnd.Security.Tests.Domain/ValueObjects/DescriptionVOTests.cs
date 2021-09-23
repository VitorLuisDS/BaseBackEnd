using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaseBackEnd.Security.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseBackEnd.Security.Domain.Rules;

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
            DescriptionVO descriptionVO = new DescriptionVO(description);

            //Assert
            Assert.IsFalse(descriptionVO.IsValid);
        }

        [TestMethod()]
        public void Constructor_NullDescription_VOIsValid()
        {
            //Arrange
            string description = null;

            //Act
            DescriptionVO descriptionVO = new DescriptionVO(description);

            //Assert
            Assert.IsTrue(descriptionVO.IsValid);
        }

        [TestMethod()]
        public void Constructor_CorrectDescriptionLength_VOIsValid()
        {
            //Arrange
            string description = "d";

            //Act
            DescriptionVO descriptionVO = new DescriptionVO(description);

            //Assert
            Assert.IsTrue(descriptionVO.IsValid);
        }
    }
}