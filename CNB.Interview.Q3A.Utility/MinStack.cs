using System.Collections.Generic;

namespace CNB.Interview.Q3A.Utility
{
    /// <summary>
    /// stack that supports push, pop, top, and retrieving the minimum element in constant time.
    /// </summary>
    public class MinStack : IMinStack
    {
        //Maximum size possible for min stack to have operation in constant time
        private const int MaxSize = 3 * 10000;

        // this stack hold all values inserted
        private readonly Stack<int> interanalActualStack;

        //this stack hold minimum value seen so far
        private readonly Stack<int> interanalMinValueStack;
        public MinStack()
        {
            interanalActualStack = new Stack<int>(MaxSize);
            interanalMinValueStack = new Stack<int>(MaxSize);
        }

        /// <summary>
        /// Return value at the top of the minstack
        /// </summary>
        /// <returns></returns>
        public int Top()
        {
            return interanalActualStack.Peek();
        }

        /// <summary>
        /// Insert value at the top of the stack
        /// </summary>
        /// <param name="valueToInsert">Value to insert</param>
        public void Push(int valueToInsert)
        {
            //value being inserted is equal or less than top value of min value stack
            //if yes, insert into min value stact as well
            if (interanalMinValueStack.Count == 0 || interanalMinValueStack.Peek() >= valueToInsert )
            {
                interanalMinValueStack.Push(valueToInsert);
            }

            interanalActualStack.Push(valueToInsert);
        }

        /// <summary>
        /// Remove value from top of the stack
        /// </summary>
        public void Pop()
        {

            var value = interanalActualStack.Pop();

            //if value being remove is equal to top of min value stack, 
            //remove value from min value to stay consistent with actual stack holding all values
            if (interanalMinValueStack.Peek() == value)
            {
                interanalMinValueStack.Pop();
            }           
        }

        /// <summary>
        /// Return minimum value of values in the minstack
        /// </summary>
        /// <returns></returns>
        public int GetMin()
        {
            //return current minimum value from top of min value stack
            return interanalMinValueStack.Peek();
        }

    }
}
