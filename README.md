# Testing .NET Core RC2 using NUnit 3

`dotnet-test-nunit` is the unit test runner for .NET Core for running
unit tests with NUnit 3.

## Usage 

`dotnet-test-nunit` is still under development, so you will need to
add a `NuGet.Config` file to your solution to download NuGet packages
from the NUnit CI NuGet feeds.

### NuGet.Config

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <clear/>
    <add key="NUnit CI Builds (AppVeyor)" value="https://ci.appveyor.com/nuget/nunit" />
    <add key="dotnet-test-nunit CI Builds (AppVeyor)" value="https://ci.appveyor.com/nuget/dotnet-test-nunit" />
    <add key="nuget.org" value="https://api.nuget.org/v3/index.json" protocolVersion="3" />
  </packageSources>
</configuration>
```

Your `project.json` in your test project should look like the following;

### project.json

```json
{
    "version": "1.0.0-*",

    "dependencies": {
        "NUnitWithDotNetCoreRC2": "1.0.0-*",
        "NETStandard.Library": "1.5.0-rc2-24027",
        "NUnit": "3.2.1",
        "dotnet-test-nunit": "3.3.0.39-CI"
    },
    "testRunner": "nunit",

    "frameworks": {
        "netstandard1.5": {
            "imports": [
                "dnxcore50",
                "netcoreapp1.0",
                "portable-net45+win8"
            ]
        }
    },

    "runtimes": {
        "win10-x86": { },
        "win10-x64": { }
    }
}
```

The lines of interest here are the dependency on `dotnet-test-nunit`. Feel free to use the newest
pre-release version that ends in `-CI`, that is latest from the master branch. Note that the 
`NUnitWithDotNetCoreRC2` dependency is the project under test.

I have added `"testRunner": "nunit"` to specify NUnit 3 as the test adapter. I also had to add to the
imports for both the test adapter and NUnit to resolve. Lastly, I had to add the `runtimes`. If anyone can
explain why I need to do that, please let me know.

You can now run your tests using the Visual Studio Test Explorer, or by running `dotnet test` from the command
line.

```
# Restore the NuGet packages
dotnet restore

# Run the unit tests in the current directory
dotnet test

# Run the unit tests in a different directory
dotnet test .\test\NUnitWithDotNetCoreRC2.Test\
```

### Warning

As I said, this is still under development. `dotnet-test-nunit` version 3.3.0.39-CI listed
above has a bug where it will throw an `ArgumentException` when it tries to save out the
`TestResult.xml` file. That will be fixed shortly.

Also note that the `dotnet` command line swallows blank lines and does not work with color.
The NUnit test runner's output is in color, but you won't see it.