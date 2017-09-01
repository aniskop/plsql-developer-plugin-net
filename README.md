# plsql-developer-plugin-net
A demo PL/SQL Developer plug-in written in C# and a tutorial on writing plug-ins in C#. It is a C# class library (dll file), exporting API required by the Allround Automations PL/SQL Developer IDE.

The goal of the project is to provide documentation, tips & hints, and demonstrate how plug-ins for PL/SQL Developer IDE can be created using C#.

Tools used
=====
* Microsoft Visual Studio 2015 Community edition
* [UnmanagedExports by Robert Giesecke](https://www.nuget.org/packages/UnmanagedExports) (NuGet package)

Building
====
* Open the solution in Visual Studio.
* Make sure platform is not AnyCPU, because AnyCPU assemblies cannot export functions.
* Build the solution.

Installing and running the demo plug-in
==============
* Just copy the DemoPluginNet.dll to <PL/SQL Developer home>\plugins or to plug-ins directory set in PL/SQL Developer preferences.
* Restart the PL/SQL Developer.
 
If everything went correct, you see "Demo plug-in in C#" entry in the Plug-in Manager (Tools > Configure Plug-Ins...) and a new menu  item "Demo plug-in in C#" under Tools menu.
