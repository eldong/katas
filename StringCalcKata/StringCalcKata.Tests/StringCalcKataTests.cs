using StringCalcKata;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.SymbolStore;

namespace StringCalcKata.Tests
{
    [TestClass]
    public class StringCalcKataTests
    {
        [TestMethod]
        public void Add_EmptyString_ReturnsZero()
        {
            StringCalcKata skc = new StringCalcKata();

            skc.Add("");

            Assert.AreEqual(0, skc.Result());
        }

        [TestMethod]
        public void Add_SingleOne_ResultIsOne()
        {
            StringCalcKata skc = new StringCalcKata();

            skc.Add("1");

            Assert.AreEqual(1, skc.Result());
        }

        [TestMethod]
        public void Add_OnePlus4_ResultIsFive()
        {
            StringCalcKata skc = new StringCalcKata();

            skc.Add("1,4");

            Assert.AreEqual(5, skc.Result());
        }

        [TestMethod]
        public void Add_MultipleDelimitersOneThreeFive_ResultIsNine()
        {
            StringCalcKata skc = new StringCalcKata();

            skc.Add("1\n3,5");

            Assert.AreEqual(9, skc.Result());
        }

        [TestMethod]
        public void Add_ChangeDelimitedTheePlusThree_ResultIsSix()
        {
            StringCalcKata skc = new StringCalcKata();

            skc.Add("//;\n3;5");

            Assert.AreEqual(8, skc.Result());
        }

        [TestMethod]
        public void Add_NegativeNumbersNotAllowed_ResultIsExecptionThrown()
        {
            StringCalcKata skc = new StringCalcKata();

            try
            {
                skc.Add("2,-500");
            }
            catch (Exception e)
            {
                StringAssert.Contains(e.Message,skc.m_ErrorMessage);
                return;
            }

            Assert.Fail("Expected exception but no exception was thrown.");
        }

        [TestMethod]
        public void Add_MulipleNegativeNumbersNotAllowed_ResultIsExecptionThrown()
        {
            StringCalcKata skc = new StringCalcKata();

            try
            {
                skc.Add("2,-500,-600");
            }
            catch (Exception e)
            {
                StringAssert.Contains(e.Message, skc.m_ErrorMessage);
                return;
            }

            Assert.Fail("Expected exception but no exception was thrown.");
        }

        [TestMethod]
        public void GetCalledCount_HowManyTimesAddCalled_ResultIsFive()
        {
            int result;
            // Arrange
            StringCalcKata skc = new StringCalcKata();

            // Acct 
            skc.Add("2,3");
            result = skc.GetAddCallCount();

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Add_NumbersOver1000Ignored_ResultIs50()
        {
            // Arrange
            StringCalcKata sck = new StringCalcKata();

            // Act
            sck.Add("25,2000,25");

            // Assert
            Assert.AreEqual(50, sck.Result());

        }

    }
}
