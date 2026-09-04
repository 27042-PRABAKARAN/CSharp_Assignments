# Error Handling in C#

## Overview

I have demonstrated exception-handling concepts in C#.

Each task focuses on a specific exception-handling approach.

---

## Task 1 - DivideByZeroException

### Approach

- Created a simple division operation using integers.

- Used a `try` block to perform the division.

- Set the divisor to 0 to intentionally cause a `DivideByZeroException`.

- Used a specific `catch` block to handle the `DivideByZeroException`.

- Displayed a error message when the exception occurs.

- Used a `finally` block to indicate that the block has been executed.

---

## Task 2 - IndexOutOfRangeException

### Approach

- Created an integer array.

- Displayed the elements of the array.

- Intentionally attempted to access an index outside the valid range.

- This causes an `IndexOutOfRangeException`.

- Caught the exception using a specific `catch` block.

- Created a new `InvalidOperationException` with a custom message.

- Passed the original exception as the `InnerException`.

- Allowed the new exception to trace to the calling method.

- Caught the new exception in the parent code and displayed its type and message.

The original exception identifies the actual error that occurred.A new exception is thrown with a more meaningful message for the parent method.The original exception is preserved as the InnerException.

---

## Task 3 - Custom Exception

### Approach

- Created a custom exception named `InvalidUserInputException`.

- The custom exception inherits from the base `Exception` class.

- Requested two integer values from the user.

- Used `int.TryParse()` to validate the input.

- If the input is invalid, explicitly threw `InvalidUserInputException`.

- Added a meaningful message to the custom exception.

- Caught `InvalidUserInputException` separately.

- Displayed the exception type and message.

---

## Task 4 - Global Unhandled Exception

### Approach

- Created a method that intentionally throws an `InvalidOperationException`.

- Did not handle this exception using a local `try-catch` block.

- Registered an `AppDomain.UnhandledException` event handler.

- Used the global handler to observe the unhandled exception.

- Displayed the exception type and message.

- Displayed the stack trace.

- Displayed whether the application is terminating.

Local `try-catch` blocks handle exceptions at a specific level.If an exception remains unhandled, it can reach the application's global unhandled-exception handler.`AppDomain.UnhandledException` allows information about the unhandled exception to be observed.

---

## Task 5 - Exception Stack Trace

### Approach

- Created a method named `ExceptionThrower()`.

- Intentionally threw an `InvalidOperationException` from this method.

- Called `ExceptionThrower()` from `TraceStack()`.

- Caught the exception in `TraceStack()`.

- Printed the exception type.

- Printed the exception message.

- Printed the exception's stack trace.

The stack trace shows the sequence of method calls that led to the exception.The exception originates in `ExceptionThrower()`.`ExceptionThrower()` is called by `TraceStack()`.The exception propagates back to `TraceStack()`.`TraceStack()` catches the exception.The stack trace helps identify where the exception originated.It also helps identify the execution path that led to the exception.When debugging information is available, the stack trace can include the source file and line number.

### Exception Flow

```
TraceStack()
     |   
ExceptionThrower()
     |
InvalidOperationException
     |
catch in TraceStack()
     |
Print Stack Trace
```

---

## Overall Interpretation

* **Task 1:** Demonstrates basic exception handling using try, catch, and finally.
* **Task 2:** Demonstrates catching an exception, throwing a new exception, and preserving the original exception.
* **Task 3:** Demonstrates creating and using an application-specific custom exception.
* **Task 4:** Demonstrates observing exceptions that remain unhandled at the application level.
* **Task 5:** Demonstrates how a stack trace can be used to understand the origin and execution path of an exception.

