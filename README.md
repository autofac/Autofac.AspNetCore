# Autofac.AspNetCore

ASP.NET Core support and helpers for Autofac.

[![Build status](https://ci.appveyor.com/api/projects/status/qua467e2o7kvgqqa/branch/develop?svg=true)](https://ci.appveyor.com/project/Autofac/autofac-aspnetcore/branch/develop)

## Get Packages

You can get started with `Autofac.AspNetCore` by [grabbing the latest NuGet package](https://www.nuget.org/packages/Autofac.AspNetCore).

If you're feeling adventurous, [continuous integration builds are on MyGet](https://www.myget.org/gallery/autofac).

## Get Help

**Need help with Autofac?** We have [a documentation site](http://autofac.readthedocs.io/) as well as [API documentation](http://autofac.org/apidoc/). We're ready to answer your questions on [Stack Overflow](http://stackoverflow.com/questions/tagged/autofac) or check out the [discussion forum](https://groups.google.com/forum/#forum/autofac).

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

Our [ASP.NET Core](http://docs.autofac.org/en/latest/integration/aspnetcore.html) integration documentation contains more information about using Autofac with ASP.NET Core.

## Project

Autofac is licensed under the MIT license, so you can comfortably use it in commercial applications (we still love [contributions](http://autofac.readthedocs.io/en/latest/contributors.html) though).

## Contributing / Pull Requests

Refer to the [Readme for Autofac Developers](https://github.com/autofac/Autofac/blob/master/developers.md)
for setting up and building Autofac source. We also have a [contributors guide](http://autofac.readthedocs.io/en/latest/contributors.html) to help you get started.

