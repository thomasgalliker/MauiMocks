# MauiMocks
MauiMocks helps mocking services in unit tests of .NET MAUI test projects.

### Download and Install MauiMocks
This library is available on NuGet: https://www.nuget.org/packages/Mocks.Maui
Use the following command to install MauiMocks using NuGet package manager console:

    PM> Install-Package Mocks.Maui

You can use this library in any .NET MAUI test project from .NET 8 and later.

### API Usage
Many UI classes in a .NET MAUI project can be used in unit tests without taking any special measures.
However, there are classes that depend on services that were registered in the DI container or were initialized when the app was started.
This library is intended to help mock-up all the necessary services from .NET MAUI to satisfy that unit test code can run without having to fully launch the app on a real device.

#### Initialize MauiMocks
The following line of code is executed in the setup section of a unit test to prepare .NET MAUI for unit testing.

```csharp
MauiMocks.Init();
```

Make sure that unit tests that use this code are not executed in parallel against each other. This could have unpredictable consequences.


### Issues & Questions
If you find a bug or you want to propose a new feature, feel free to do so by opening a new issue [here](https://github.com/thomasgalliker/MauiMocks/issues).