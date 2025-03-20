
**Goal:**    
Create a C# solution and projects that provides functionality for generating and testing prime numbers. This project should include a class library for the prime number logic and a unit test project to validate that logic.  
   
**Context:**    
The purpose of this project is for demonstration purposes, showcasing how to structure C# solutions, implement unit testing.  
   
**Expectations:**    
- The solution should consist of the following two projects:  
  - A class library project named `PrimeService` that contains the logic for prime number operations.  
  - An xUnit test project named `PrimeService.Tests` that tests the functionality of `PrimeService`.  
- Proper project dependencies should be established between the class library and the test project.  
- The test project should use xUnit's `Theory` and `InlineData` attributes for parameterized testing.  
- The solution should be fully functional, with all tests passing successfully.  
- The latest .NET SDK is already in place and the dotnet command is available. No new installation is required.
- Be sure to choose appropriate names for files, classes, methods and variables.
- This solution is for demo demonstration only, so keep it as simple as possible.

**Source:**    
Follow these steps to create the solution:  
   
1. Use the dotnet command to create the solution and projects:  
   - `dotnet new sln -n PrimeServiceSolution`  
   - `dotnet new classlib -n PrimeService`  
   - `dotnet new xunit -n PrimeService.Tests`  
   
2. Add the projects to the solution:  
   - `dotnet sln add PrimeService/PrimeService.csproj`  
   - `dotnet sln add PrimeService.Tests/PrimeService.Tests.csproj`  
   
3. Add a reference from the test project to the class library project:  
   - `dotnet add PrimeService.Tests reference PrimeService`  
   
4. Write the prime number logic in the `PrimeService` project. For example, create a static method called `IsPrime` that determines whether a given number is prime.  Negative numbers, 0, and 1 are not prime numbers, and the judgement will be correct including these.
   
5. Write unit tests in the `PrimeService.Tests` project using xUnit. As a test case, we will use IsPrime to check integers from -1 to 15. Use the `Theory` and `InlineData` attributes for parameterized testing.  
   
6. Verify that all tests pass successfully by running:  
   - `dotnet test`  
