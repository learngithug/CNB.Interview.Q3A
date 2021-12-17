using System;
using NUnit.Framework;


namespace CNB.Interview.Q3A.Utility.Test.Unit
{
    [TestFixture]
    [Category("UnitTest")]
    public class MinStackTests
    {
        private IMinStack minStack;

        [SetUp]
        public void Setup()
        {
            minStack = new MinStack();
        }


        #region Top
        [Test]
        public void TopShouldThrowInvalidOperationExceptionWhenMinStackIsEmpty()
        {
            //Arrange          
            //Act
            //Assert
            Assert.Throws<InvalidOperationException>(() => minStack.Top());
        }


        [Test]
        [TestCase(-3,-1,-2,-3)]
        [TestCase(-1,-3,-2,-1)]
        [TestCase(1,3,2,1)]
        [TestCase(3,1,2,3)]
        [TestCase(-3,-2,0,-3)]
        [TestCase(0,0,0,0)]
        [TestCase(1,1,1,1)]
        [TestCase(-1,-1,-1,-1)]
        public void TopShouldReturnValidValue(int expectedValue, params int[] values)
        {
            //Arrange           
            foreach (var value in values)
            {
                minStack.Push(value);
            }
            //Act
            var topValue = minStack.Top();
            //Assert
            Assert.AreEqual(expectedValue, topValue);            
        }
        #endregion

        #region Push
        [Test]
        [TestCase(-1)]
        [TestCase(-1, -2)]
        [TestCase( -1, -2, -3)]
        [TestCase( -3, -2, -1)]
        [TestCase( 3, 2, 1)]
        [TestCase(1, 2, 3)]
        [TestCase( -2, 0, -3)]
        [TestCase( 0, 0, 0)]
        [TestCase( 1, 1, 1)]
        [TestCase( -1, -1, -1)]
        public void PushShouldSuccessfullyAddValueToMinStack(params int[] values)
        {
            //Arrange/Act           
            for (int i = 0; i < values.Length; i++)
            {
                minStack.Push(values[i]);
            }

            //Assert                    
            for (int i = values.Length-1; i > 0; i--)
            {
                var actualValue = minStack.Top();
                minStack.Pop();
                Assert.AreEqual(values[i], actualValue);
            }
            
        }
        #endregion

        #region Pop
        [Test]
        public void PopShouldRemoveValueInsertedLast()
        {
            //Arrange
            var value1 = 10;
            minStack.Push(value1);

            var value2 = 20;
            minStack.Push(value2);

            //Act
            minStack.Pop();
            
            //Assert
            Assert.AreNotEqual(value2, minStack.Top());
            Assert.AreEqual(value1, minStack.Top());
        }

        [Test]
        public void PopShouldThrowInvalidOperationExceptionWhenMinStackIsEmpty()
        {
            //Arrange          
            //Act
            //Assert
            Assert.Throws<InvalidOperationException>(() => minStack.Pop());
        }
        #endregion

        #region GetMin
        [Test]
        public void GetMinShouldThrowInvalidOperationExceptionWhenMinStackIsEmpty()
        {
            //Arrange          
            //Act
            //Assert
            Assert.Throws<InvalidOperationException>(() => minStack.GetMin());
        }        

        [TestCase(-2,-1,-2,-3)]
        [TestCase(-3,-3,-2,-1)]
        [TestCase(2,3,2,1)]
        [TestCase(1,1,2,3)]
        [TestCase(-2,-2,0,-3)]
        [TestCase(0,0,0,0)]
        [TestCase(1,1,1,1)]
        [TestCase(-1,-1,-1,-1)]
        public void GetMinShouldReturnMinValueAfterFirstPop(int expectedValue, params int[] values)
        {
            //Arrange           
            foreach (var value in values)
            {
                minStack.Push(value);
            }
            minStack.Pop();

            //Act
            var minValue = minStack.GetMin();
            
            //Assert
            Assert.AreEqual(expectedValue, minValue);
        }

        [TestCase(-1,-1,-2,-3)]
        [TestCase(-3,-3,-2,-1)]
        [TestCase(3,3,2,1)]
        [TestCase(1,1,2,3)]
        [TestCase(-2,-2,0,-3)]
        [TestCase(0,0,0,0)]
        [TestCase(1,1,1,1)]
        [TestCase(-1,-1,-1,-1)]
        public void GetMinShouldReturnMinValueAfterSecondPop(int expectedValue, params int[] values)
        {
            //Arrange           
            foreach (var value in values)
            {
                minStack.Push(value);
            }
            minStack.Pop();
            minStack.Pop();

            //Act
            var minValue = minStack.GetMin();

            //Assert
            Assert.AreEqual(expectedValue, minValue);
        }

        [TestCase(-3,-1,-2,-3)]
        [TestCase(-3,-3,-2,-1)]
        [TestCase(1,3,2,1)]
        [TestCase(1,1,2,3)]
        [TestCase(-3,-2,0,-3)]
        [TestCase(0,0,0,0)]
        [TestCase(1,1,1,1)]
        [TestCase(-1,-1,-1,-1)]
        [Test]
        public void GetMinShouldReturnMinValue(int expectedValue, params int[] values)
        {
            //Arrange           
            foreach (var value in values)
            {
                minStack.Push(value);
            }

            //Act
            var minValue = minStack.GetMin();
            //Assert
            Assert.AreEqual(expectedValue, minValue);
        }

        #endregion
    }
}