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

            User testUser = new User("Alice", 25, false);
            //Console.WriteLine("Initial State:");
            //DynamicObjectInspector.InspectObject(testUser);
            //Console.WriteLine("Modifying object values dynamically...");
            //DynamicObjectInspector.TrySetPropertyValue(testUser, "Username", "Alice_Modified");
            //DynamicObjectInspector.TrySetPropertyValue(testUser, "Age", "30");
            //DynamicObjectInspector.TrySetPropertyValue(testUser, "IsAdmin", true);
            //Console.WriteLine("\nUpdated State:");
            //DynamicObjectInspector.InspectObject(testUser);
            //Console.ReadLine();

            Console.WriteLine("Invoking 'SayHello'...");
            DynamicMethodInvoker.InvokeMethod(testUser, "SayHello");

            Console.WriteLine("\nInvoking 'GetProfileSummary'...");
            DynamicMethodInvoker.InvokeMethod(testUser, "GetProfileSummary");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}