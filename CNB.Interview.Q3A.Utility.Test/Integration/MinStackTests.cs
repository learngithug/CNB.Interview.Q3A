using NUnit.Framework;


namespace CNB.Interview.Q3A.Utility.Test.Integration
{
    [TestFixture]
    [Category("Integration")]
    public class MinStackTests
    {
        private IMinStack minStack;

        [SetUp]
        public void Setup()
        {
            minStack = new MinStack();
        }

        [Test]
        public void SampleTestShouldGiveExpectedValue()
        {
            //Arrange           
            int[] values = { -2, 0, -3 };
            foreach (var value in values)
            {
                minStack.Push(value);
            }

            //Act
            var minValue1 = minStack.GetMin();

            //Assert
            Assert.AreEqual(-3, minValue1);

            //Act
            minStack.Pop();
            var actualTopValue = minStack.Top();

            //Assert
            Assert.AreEqual(0, actualTopValue);

            //Act
            var minValue2 = minStack.GetMin();

            //Assert
            Assert.AreEqual(-2, minValue2);
        }
    }
}