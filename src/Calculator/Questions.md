# 1. Explain what the .NET platform is and its primary purpose?. 

.NET is an open-source developer platform created by Microsoft. Key components of .NET include multiple programming languages, CLR – common language runtime which handles (memory management, Security, Exception Handling and Thread management) and BCL – base class library which contains a large collection of prebuilt functionalities. 

It is an execution and developer platform consist of CLR, a type System JIT compilation, Garbage collection, a large standard library and development and build tooling, allowing managed code such as C# to be compiled into IL and executed as native machine code 

The Main Purpose of .NET is  

- The code compiles into IL rather than being tightly coupled to one CPU, where the runtime handles architecture-specific execution. 
- Resource and runtime management 
  - memory is managed – Garbage Collector 
  - Types – Common Type System 
  - Code is converted by JIT 
  - Errors – Exceptional handling 
  - Concurrency – Threading 

 

# 2. What are the key components of the .NET platform? 

The Key components .Net are 

- Common Language Runtime 
- Common Type System 
- Common Language Specification 
- Base Class Library 
- Just in Time Compiler 
- Garbage Collector 
- SDK – provides build infrastructure 

 

# 3. Differentiate between the Common Language Runtime (CLR) and the Common Type System (CTS) in .NET. 

### Common Language Runtime:  
.NET provided runtime environment is called Common Language Runtime (CLR). 

Common Language Runtime helps to allocate and manage memory, and the codes written with the help of compiler that targets the runtime are called Managed Code. 

Garbage Collector manages the memory of Managed Code and collects de-referenced objects and performs defragmentation of the application's memory. 

### Common Type System:  
Common Type System defines how the data is defined and managed in the Common Language Runtime. 

It helps the Cross-Language integration by providing complete implementation of programming languages. 

It provides libraries with primitive datatypes which help in application development. 

 

# 4. What is the role of the Global Assembly Cache (GAC) in .NET? 

GAC is designed to provide a central location where shared .NET Framework assemblies could be installed once and used by multiple application. 

GAC is a System wide Repository 

GAC is Strongly named – assembly identity includes name, versioning, culture and public key token 

 

# 5. Explain the difference between value types and reference types in C#. 

| VALUE TYPE | REFRENCE TYPE |
| :--- | :--- |
| Stores the actual value of the variable | Stores the reference to the object |
| When assigned to another variable the value is copied | When assigned to another variable the reference is copied |
| Multiple variables will have multiple values | Multiple variables can have same reference to a single object |
| Cannot be normally null | Can be null |
| Cannot be shared | Can be shared |
| int double struct Enum are some of the examples | Classes string array delegate and interfaces |

 

# 6. Describe the concept of garbage collection on .NET and its advantages. 

Garbage Collection is an automatic memory management system handled by CLR. 

It reclaims memory occupied by objects that are no longer accessible, preventing memory leaks and optimizing allocation 

Managed Heap has 3 generation 
- Generation 0 – Newly allocated, short-lived objects 
- Generation 1 – Medium-lived objects 
- Generation 2 – Long-lived objects 

### Advantages of GC are 
- Automatic Memory Management 
- Optimized allocation 
- Prevents memory leaks 
- Non-deterministic– exact time of collection is not predictable 

 

# 7. What is the purpose of the Globalization and Localization features in .NET? 

### Globalization: 
In the World, each region uses different formats of Calendar, date representation, number and currency representations. 

Globalization is used to perform formatting and coding based on the particular region. 

“System.Globalization” library is used to achieve region-specific formatting. 

### Localization: 
Localization is the process of converting your application to support multiple cultures and different languages by converting translating resources into executable codes. 

It helps to achieve multiple culture adaptability, and local culture can also be customized by the developer. 

 

# 8. Explain the role of the Common Intermediate Language (CIL) and Just-In-Time (JIT) compilation in the .NET framework. 

### Common Intermediate Language: 
In C#, the high-level code written is not directly compiled in a machine code. 

Instead, it is converted into another type known as Common Intermediate Language (CIL). 

The C#, F# and VB.NET codes are converted into Common Intermediate Language, whereas the syntactical format of CIL is common for .NET supported programming languages. Such that it provides cross-language reference without any problem. 

### Just-In-Time Compiler: 
The Common Language Runtime (CLR) converts the Common Intermediate Language into machine code with the help of a specific compiler known as Just-In-Time Compiler 

In recent .NET version JIT uses registers for quick memory access. 

In modern days, AOT (Ahead-Of-Time) compilation is performed, which converts the CIL into machine code before the execution of program itself, for quicker access. 
