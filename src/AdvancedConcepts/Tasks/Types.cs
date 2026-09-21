namespace AdvancedConcepts.Tasks
{
    /// <summary>
    /// Demonstrates the operational differences between implicitly typed variables (var) and dynamically typed variables (dynamic) in C#.
    /// </summary>
    internal class Types
    {
        /// <summary>
        /// Executes the type demonstration by showing compile-time type safety with 'var' and runtime type mutability with 'dynamic'.
        /// </summary>
        public void ExecuteTypes()
        {
            var variable = "This is a string";
            Console.WriteLine($"Initial value: {variable} (Type: {variable.GetType()})");

            // variable = 100;
            // this will throw an error - Cannot implicitly Convert type int to string
            dynamic dynamicVariable = "This is a string";
            Console.WriteLine($"Initial value: {dynamicVariable} (Type: {dynamicVariable.GetType()})");

            dynamicVariable = 1000;
            Console.WriteLine($"New value: {dynamicVariable} (Type: {dynamicVariable.GetType()})");
        }
    }
}
