# plsql-developer-plugin-net
A demo PL/SQL Developer plug-in written in C# and a tutorial on writing plug-ins in C#. It is a C# class library (dll file), exporting API required by the Allround Automations PL/SQL Developer IDE.

The goal of the project is to provide documentation, tips & hints, and demonstrate how plug-ins for PL/SQL Developer IDE can be created using C#. Visit [project's wiki](https://github.com/aniskop/plsql-developer-plugin-net/wiki) for more info.

# Tools used

* Microsoft Visual Studio 2019 Community edition (on Windows 10 Pro x64)
* [UnmanagedExports.Repack](https://www.nuget.org/packages/UnmanagedExports.Repack) NuGet package. Mandatory. Used for exporting DLL functions from managed code to the native applications.
* [Costura.Fody](https://www.nuget.org/packages/Costura.Fody/) NuGet package. Optional. Used to merge dependencies (external assemblies), if any, into a single assembly.

# Building

* Open the solution in Visual Studio.
* Make sure platform is not AnyCPU, because AnyCPU assemblies cannot export functions.
* Build the solution.

# Troubleshooting build errors

**Could not load file or assembly 'Microsoft.Build.Utilities, Version=2.0.0.0**  

Install .NET Framework 3.5. The recommended way is using VS installer:
1. Launch VS installer.
2. Select the installed VS, click "Modify" and go to "Individual components" tab.
3. In the list find ".NET Framework 3.5 development tools". Click it.
4. Click "Modify".

[Alternative way](https://docs.microsoft.com/en-us/dotnet/framework/install/dotnet-35-windows-10) to install .NET 3.5 is by enabling it via Windows Features.

After the installation is complete, clean the solution and rebuild it.

**The "DllExportAppDomainIsolatedTask" task failed unexpectedly.  
System.ArgumentException: Requested value 'Version46' was not found.**  

Probably, your project uses original version of UnmanagedExports by Robert Giesecke. Uninstall this NuGet package and install UnmanagedExports.Repack. Clean the solution and rebuild it.

# Installing and running the demo plug-ins

The solution contains several plug-ins, each demonstrating specific aspect of the PL/SQL Developer plug-in creation.  
Just copy the *.dll files to `<PL/SQL Developer home>\plugins` or plug-ins directory set in PL/SQL Developer preferences. Restart the PL/SQL Developer.

If everything went correct, you see "Demo plug-ins .NET" tab in the ribbon menu. Also there will be entries in the Plug-in Manager (Configure > Plug-Ins...) for each demo plug-in.
