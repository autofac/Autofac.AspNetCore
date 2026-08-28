# Autofac.AspNetCore

ASP.NET Core support and helpers for Autofac.

[![Build status](https://github.com/autofac/Autofac.AspNetCore/actions/workflows/main.yml/badge.svg)](https://github.com/autofac/Autofac.AspNetCore/actions/workflows/main.yml) [![codecov](https://codecov.io/gh/Autofac/Autofac.AspNetCore/branch/develop/graph/badge.svg)](https://codecov.io/gh/Autofac/Autofac.AspNetCore)

Please file issues and pull requests for this package [in this repository](https://github.com/autofac/Autofac.AspNetCore/issues) rather than in the Autofac core repo.

- [Contributing](https://autofac.readthedocs.io/en/latest/contributors.html)
- [Open in Visual Studio Code](https://open.vscode.dev/autofac/Autofac.AspNetCore)

## Quick Start

**This package is not officially published yet.**

If you're feeling adventurous, [continuous integration builds are on MyGet](https://www.myget.org/gallery/autofac). As it is currently very small there is no value in publishing it yet. It may never be published. **YOU HAVE BEEN WARNED.**

## Get Started

### Using the Autofac implementation of IServiceProviderFactory with WebHostBuilder

The Autofac implementation of the `IServiceProviderFactory` [interface](https://docs.microsoft.com/en-us/aspnet/core/api/microsoft.extensions.dependencyinjection.iserviceproviderfactory-1) can be used by calling the `UseAutofac` extension method on an `IWebHostBuilder` instance.

```C#
var host = new WebHostBuilder()
 .UseAutofac()
 .UseKestrel()
 .UseContentRoot(Directory.GetCurrentDirectory())
 .UseIISIntegration()
 .UseStartup<Startup>()
 .Build();

host.Run();
```

Our [ASP.NET Core](https://autofac.readthedocs.io/en/latest/integration/aspnetcore.html) integration documentation contains more information about using Autofac with ASP.NET Core.

## Get Help

**Need help with Autofac?** We have [a documentation site](https://autofac.readthedocs.io/) as well as [API documentation](https://autofac.org/apidoc/). We're ready to answer your questions on [Stack Overflow](https://stackoverflow.com/questions/tagged/autofac) or check out the [discussion forum](https://groups.google.com/forum/#forum/autofac).
