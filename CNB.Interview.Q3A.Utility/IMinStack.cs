namespace CNB.Interview.Q3A.Utility
{
    /// <summary>
    /// Interface for Min Stack
    /// </summary>
    public interface IMinStack
    {
        /// <summary>
        /// Return minimum value of values in the minstack
        /// </summary>
        /// <returns></returns>
        int GetMin();

        /// <summary>
        /// Remove value from top of the stack
        /// </summary>
        void Pop();

        /// <summary>
        /// Insert value at the top of the stack
        /// </summary>
        /// <param name="valueToInsert">Value to insert</param>
        void Push(int valueToInsert);

        /// <summary>
        /// Return value at the top of the minstack
        /// </summary>
        /// <returns></returns>
        int Top();
    }
}