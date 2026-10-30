namespace Reflection
{
    /// <summary>
    /// Main entry point of the application
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
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

            //Console.WriteLine("Invoking 'SayHello'...");
            //DynamicMethodInvoker.InvokeMethod(testUser, "SayHello");

            //Console.WriteLine("\nInvoking 'GetProfileSummary'...");
            //DynamicMethodInvoker.InvokeMethod(testUser, "GetProfileSummary");

            //Console.WriteLine("\nPress any key to exit...");
            //Console.ReadKey();

            //Console.WriteLine("\n--- Task 4: Generating Dynamic Type at Runtime ---");
            //if (DynamicTypeBuilder.BuildCustomType() is Type runtimeType)
            //{
            //    Console.WriteLine($"Successfully baked type: {runtimeType.FullName}");
            //    object? dynamicInstance = Activator.CreateInstance(runtimeType);

            //    if (dynamicInstance != null)
            //    {
            //        Console.WriteLine("Setting dynamic property value...");
            //        runtimeType.GetProperty("CustomStatus")?.SetValue(dynamicInstance, "Runtime Generation Active!");

            //        Console.WriteLine("Invoking dynamically built method:");
            //        runtimeType.GetMethod("PrintStatus")?.Invoke(dynamicInstance, null);
            //    }
            //    else
            //    {
            //        Console.WriteLine("Warning: Could not create an instance of the dynamic type.");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Warning: The dynamic type builder returned null.");
            //}
            //Console.WriteLine("\nPress any key to exit...");
            //Console.ReadKey();

            Console.WriteLine("\n--- Task 5: Running Dynamic Image Plugin System ---");
            string pluginPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins");
            if (!Directory.Exists(pluginPath))
            {
                Directory.CreateDirectory(pluginPath);
            }

            string mockUserImage = "gallery_upload_vacation.jpg";
            Console.WriteLine($"Place your compiled plugin .dll files into: {pluginPath}");
            Console.WriteLine("Running media pipeline diagnostics...");
            ImagePluginEngine.DiscoverAndProcess(pluginPath, mockUserImage);
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}