namespace AdvancedConcepts.Tasks
{
    internal class Types
    {
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
