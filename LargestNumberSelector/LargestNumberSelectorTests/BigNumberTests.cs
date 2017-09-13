using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BigNumberFinder;

namespace LargestNumberSelectorTests
{
    [TestClass]
    public class BigNumberTests
    {
        [TestMethod]
        public void ShouldSelect100AsLargestNumber()
        {
            // Arrange
            int[] nums = { 10, 9, 55, 21, 100, 2 };

            // Act and Assert
            Assert.AreEqual(100, BigNumber.FindBiggestNumber(nums));
        }

        [TestMethod]
        public void ShouldSelect200AsLargestNumber()
        {
            // Arrange
            int[] nums = { 10, 9, 200, 55, 21, 100, 2 };

            // Act and Assert
            Assert.AreEqual(200, BigNumber.FindBiggestNumber(nums));
        }

        [TestMethod]
        public void ShouldSelect1000And1500AsLargerThan900()
        {
            // Arrange
            int[] nums = { 25, 1000, 789, 1500, 1, 129, 303 };

            // Act
            int[] selectedNums = BigNumber.FindNumbersLargerThanN(nums, 900);

            // Assert
            CollectionAssert.AreEquivalent(new[] { 1000, 1500}, selectedNums);
        }

        /*
         * To support defensive programming we should consider edge case
         * unit tests too
         */
         [TestMethod]
         [ExpectedException(typeof(ArgumentNullException))] // This is the implied Assert
         public void NullListArgShouldThrowNullException()
        {
            // Arrange
            int[] nums = null;

            // Act
            int biggestNum = BigNumber.FindBiggestNumber(nums);
        }
    }
}
