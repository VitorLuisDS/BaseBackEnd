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
    public class NameVOTests
    {
        [TestMethod()]
        public void Constructor_NullName_ThrowsException()
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
            string name = string.Concat(Enumerable.Repeat("dev", 50));

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