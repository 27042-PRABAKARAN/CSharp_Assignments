# Memory Management in C#
 
## Overview
 
This Assignment demonstrates important memory management concepts in C# through practical examples.
 
Tasks are: 
- Value types and reference types
- Stack and heap memory
- Garbage collection
- `IDisposable` and the `using` statement
- Boxing and unboxing 
---
 
## Task 1: Value Types and Reference Types
 
To objective is to understand the difference between value types and reference types and observe how modifications behave when they are passed to methods.

The program creates variables representing value types and reference types and passes them to methods.
 
When a value type is passed to a method, its value is copied. Therefore, modifying the parameter does not modify the original variable.
 
When a reference type is passed to a method, a copy of the reference is passed. Both the original reference and the copied reference can refer to the same object. Therefore, modifying the object's properties affects the original object.
 
### Value Types
 
Examples of value types include:
 
- `int`
- `double`
- `decimal`
- `bool`
- `struct`
 
If `number` is passed to a method, the method receives a copy of `10`.
 
### Reference Types
 
Examples of reference types include:
 
- `class`
- `array`
- `List<T>`
- `object`
 
A reference-type variable contains a reference to an object.
 
The variable `employee` refers to an object.
 
If the object's property is modified inside a method, the change can be observed through the original reference.
 
### Observation
 
The main difference observed is:
 
| Value Type | Reference Type |
|---|---|
| Contains the actual value | Contains a reference to an object |
| A copy of the value is passed | A copy of the reference is passed |
| Modifying the parameter normally does not affect the original | Modifying the object's data can affect the original object |
| Examples: `int`, `double`, `struct` | Examples: `class`, `array`, `List<T>` |
 
---
 
## Task 2: Stack and Heap

To understand how memory is allocated and used in stack and heap-related scenarios.
 
### Heap Allocation
The `CreateHeapMemory()` method creates multiple large integer arrays.
 
```csharp
int[] array = new int[5_000_000];
```
 
An array is a reference type, and its elements are stored in managed heap memory.
 
Each array contains:
 
- 5,000,000 integers
 
The arrays are added to a list:
 
```csharp
heapList.Add(array);
```
 
The list maintains references to the arrays, keeping them reachable.
 
Therefore, the garbage collector cannot reclaim those arrays while the list still references them.
 
### Local Value-Type Calculation
 
The `CalculateValueTypes()` method performs calculations using value types such as:
 
- `int`
- `double`
- `decimal`
 
Local value types contain their data directly which is performed in stack.

---
 
## Task 3: Garbage Collection
To understand how garbage collection identifies unreachable objects and reclaims managed memory.

The application creates a large number of `Student` objects inside a loop.
 
```csharp
for (int i = 0; i < 100_000; i++)
{
    Student student = new Student();
}
```
 
After an iteration finishes, many `Student` objects are no longer referenced.
 
These objects become eligible for garbage collection.
 
Some objects are intentionally stored in a list:
 
```csharp
if (i % 5000 == 0)
{
    _students.Add(student);
}
```
 
Because the `_students` list still contains references to these objects, they remain reachable.
 
The garbage collector cannot reclaim objects that are still reachable.
 
### Manual Garbage Collection
 
This manually requests garbage collection using:
 
```csharp
GC.Collect();
```
 
It also waits for pending finalizers:
 
```csharp
GC.WaitForPendingFinalizers();
```
 
This task periodically performs these operations during the loop. 
Garbage collection can reclaim memory used by managed objects that are no longer reachable.
 
The objects stored in `_students` remain reachable and therefore cannot be reclaimed.
  

- The .NET runtime should normally be allowed to manage garbage collection automatically.

 

---
 
## Task 4: IDisposable and Using Statement
 
To understand how `IDisposable` is used to release resources and how the `using` statement automatically calls `Dispose()`.
 
### Approach
 
A `FileWriter` class is used to write data to a file.
 
The class implements the `IDisposable` interface and releases its file-related resources inside the `Dispose()` method.
 


 
When execution leaves the `using` block, `Dispose()` is automatically called.
 
It ensures that `Dispose()` is called even if an exception occurs.
 
After leaving the `using` block:
 
1. The `FileWriter` is disposed.
2. The file resource is released.
3. The same file can be opened for reading.
4. The application can safely access the file without keeping the writer resource open.
 
---
 