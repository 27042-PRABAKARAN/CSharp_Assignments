using MemoryManagement.Tasks;

namespace MemoryManagement;

/// <summary>
/// The main entry point of the application
/// </summary>
internal class Program
{
    private static void Main(string[] args)
    {
        GcCollector gcCollector = new ();
        FileHandler fileHandler = new ();
        ReferenceAndValueType referenceAndValueType = new ();
        StackAndHeap stackAndHeap = new ();
        MemoryHandler memoryHandler = new (referenceAndValueType, fileHandler, gcCollector, stackAndHeap);
        memoryHandler.ExecuteMemoryOperation();
    }
}