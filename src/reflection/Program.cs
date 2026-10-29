using System.Reflection;

namespace Reflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string currentAssemblyPath = Assembly.GetExecutingAssembly().Location;
            AssemblyInspector.InspectAssembly(currentAssemblyPath);
            Console.ReadLine();
        }
    }
}