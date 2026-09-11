namespace Collections
{
    internal class CharacterStack
    {
        public void ExecuteStack()
        {
            Stack<char> stack = new();
            string word = "Stack Array";
            Console.WriteLine("Original Word: " + word);
            string reversedWord = string.Empty;
            foreach (char c in word)
            {
                stack.Push(c);
            }
            while(stack.Count > 0)
            {
                reversedWord += stack.Pop();
            }
            Console.WriteLine("Reversed Word: " + reversedWord);
        }
    }
}
