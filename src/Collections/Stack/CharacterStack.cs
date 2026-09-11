namespace Collections.Stack
{
    /// <summary>
    /// Demonstrates the usage of a generic stack collection.
    /// </summary>
    internal class CharacterStack
    {
        /// <summary>
        /// Pushes the characters of a string onto a stack, pops them off to reverse the string.
        /// </summary>
        public void ExecuteStack()
        {
            GenericStack<char> stack = new ();
            string word = "Stack Array";
            Console.WriteLine("Original Word: " + word);
            string reversedWord = string.Empty;
            foreach (char c in word)
            {
                stack.Push(c);
            }

            while (stack.Count() > 0)
            {
                reversedWord += stack.Pop();
            }

            Console.WriteLine("Reversed Word: " + reversedWord);
        }
    }
}
