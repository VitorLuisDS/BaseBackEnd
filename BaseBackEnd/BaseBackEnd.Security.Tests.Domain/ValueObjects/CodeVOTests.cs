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
    public class CodeVOTests
    {
        [TestMethod()]
        public void Constructor_NullCode_VOIsNotValid()
        {
            //Arrange
            string code = null;

            //Act
            CodeVO codeVO = new CodeVO(code);

            //Assert
            Assert.IsFalse(codeVO.IsValid);
        }

        [TestMethod()]
        public void Constructor_ShortCode_VOIsNotValid()
        {
            //Arrange
            string code = "d";

            //Act
            CodeVO codeVO = new CodeVO(code);

            //Assert
            Assert.IsFalse(codeVO.IsValid);
        }

        [TestMethod()]
        public void Constructor_InvalidCharsInCode_VOIsNotValid()
        {
            //Arrange
            string code = "dev dev";

            //Act
            CodeVO codeVO = new CodeVO(code);

            //Assert
            Assert.IsFalse(codeVO.IsValid);
        }

        [TestMethod()]
        public void Constructor_LongCode_VOIsNotValid()
        {
            //Arrange
            string code = string.Concat(Enumerable.Repeat("d", CodeVORules.MAX_LENGTH + 1));

            //Act
            CodeVO codeVO = new CodeVO(code);

            //Assert
            Assert.IsFalse(codeVO.IsValid);
        }
    }
}