# orleans-error-example

Steps taken to create solution:
1. Create empty solution
2. Add grains project, set framework version to v4.6.1
3. Add interfaces project, set framework version to v4.6.1
4. Add reference to interfaces project from grains project
5. Add dummy interface and grain
6. Add Microsoft.Orleans.OrleansCodeGenerator.Build to both projects
7. Add Microsoft.Orleans.Server to grains project
8. Add OrleansConfiguration.xml to grains project, set action to copy if newer
9. Set grains project's start action to bin/Debug/OrleansHost.exe

When running in VS2015 the silo will start, but there are a lot of errors, the first being:

```
[2017-02-27 13:59:02.177 GMT     1	WARNING	101723	AssemblyProcessor	127.0.0.1:11111]	AssemblyLoader encountered an exception loading types from assembly 'Microsoft.CodeAnalysis, Version=1.3.1.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35': System.Reflection.ReflectionTypeLoadException: Unable to load one or more of the requested types. Retrieve the LoaderExceptions property for more information.
   at System.Reflection.RuntimeModule.GetTypes(RuntimeModule module)
   at System.Reflection.RuntimeAssembly.get_DefinedTypes()
   at Orleans.Runtime.TypeUtils.GetDefinedTypes(Assembly assembly, Logger logger)	
Exc level 0: System.Reflection.ReflectionTypeLoadException: Unable to load one or more of the requested types. Retrieve the LoaderExceptions property for more information.
   at System.Reflection.RuntimeModule.GetTypes(RuntimeModule module)
   at System.Reflection.RuntimeAssembly.get_DefinedTypes()
   at Orleans.Runtime.TypeUtils.GetDefinedTypes(Assembly assembly, Logger logger)
```

Followed by a lot of these:

```
Exc level 1: System.IO.FileLoadException: Could not load file or assembly 'System.Reflection.Metadata, Version=1.2.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a' or one of its dependencies. The located assembly's manifest definition does not match the assembly reference. (Exception from HRESULT: 0x80131040)
```

Followed by more `AssemblyLoader` errors.

After updating all NuGet packages via the Visual Studio UI the silo exits immediately with type loader errors around `Microsoft.Extensions.DependencyInjection`.

The `System.Reflection.Metadata` errors seemed to be caused because `Microsoft.Orleans.Core` requires v1.2 but `Microsoft.Orleans.OrleansCodeGenerator`,
via `Microsoft.CodeAnalysis.CSharp`, requires v1.3.

