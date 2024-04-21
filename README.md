# MauiMocks

MauiMocks facilitates service mocking in unit tests for .NET MAUI test projects.

### Download and Installation
This library is available on NuGet: https://www.nuget.org/packages/Mocks.Maui
To install MauiMocks via NuGet package manager console, use the following command:

```bash
PM> Install-Package Mocks.Maui
```

This library is compatible with any .NET MAUI test project running on .NET 8 and newer.

### API Usage
While many UI classes in a .NET MAUI project are readily usable in unit tests, certain classes rely on services registered in the DI container or initialized during app startup.
MauiMocks aids in mocking all essential services from .NET MAUI, enabling unit test execution without the need to fully deploy the app on a device/simulator.

#### Initializing MauiMocks
In the setup section of your unit test, execute the following code to prepare .NET MAUI for testing:

```csharp
MauiMocks.Init();
```

Ensure that unit tests utilizing this code are not executed concurrently, as this may lead to unpredictable outcomes.

### Issues & Inquiries
If you encounter a bug or wish to propose a new feature, please feel free to do so by opening a new issue [here](https://github.com/thomasgalliker/MauiMocks/issues).