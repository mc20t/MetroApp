using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static MetroApp.ClassHelper.Validation;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void IsNameValid_Empty_false()
        {
            //Arrange
            string name = "";
            bool result = false;

            //Act
            bool act = IsNameValid(name);

            //Assert
            Assert.AreEqual(result, act);
        }

        [TestMethod]
        public void IsNameValid_Empty_true()
        {
            //Arrange
            string name = "QdD4d s&&*8";
            bool result = true;

            //Act
            bool act = IsNameValid(name);

            //Assert
            Assert.AreEqual(result, act);
        }
    }
}
