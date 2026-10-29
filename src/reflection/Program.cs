namespace Reflection
{
    /// <summary>
    /// Main entry point of the application
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            //string currentAssemblyPath = Assembly.GetExecutingAssembly().Location;
            //AssemblyInspector.InspectAssembly(currentAssemblyPath);
            //Console.ReadLine();

            User account = new User("Alice", 25, false);
            Console.WriteLine("Initial State:");
            DynamicObjectInspector.InspectObject(account);
            Console.WriteLine("Modifying object values dynamically...");
            DynamicObjectInspector.TrySetPropertyValue(account, "Username", "Alice_Modified");
            DynamicObjectInspector.TrySetPropertyValue(account, "Age", "30");
            DynamicObjectInspector.TrySetPropertyValue(account, "IsAdmin", true);
            Console.WriteLine("\nUpdated State:");
            DynamicObjectInspector.InspectObject(account);
            Console.ReadLine();
        }
    }
}