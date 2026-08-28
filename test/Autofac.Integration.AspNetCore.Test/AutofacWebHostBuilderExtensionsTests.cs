// Copyright (c) Autofac Project. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;

namespace Autofac.Integration.AspNetCore.Test;

public class AutofacWebHostBuilderExtensionsTests
{
    [Fact]
    public void UseAutofacAddsFactoryProviderToServiceCollection()
    {
        var webHostBuilder = Substitute.For<IWebHostBuilder>();

        Action<IServiceCollection>? serviceAction = null;
        webHostBuilder.ConfigureServices(Arg.Do<Action<IServiceCollection>>(s => serviceAction = s));

        webHostBuilder.UseAutofac(b => b.RegisterInstance("Foo"));

        var services = new ServiceCollection();
        serviceAction?.Invoke(services);

        var serviceProvider = services.BuildServiceProvider();
        var factory = serviceProvider.GetService<IServiceProviderFactory<ContainerBuilder>>();

        Assert.IsType<AutofacServiceProviderFactory>(factory);

        var containerBuilder = factory.CreateBuilder(services);
        var container = containerBuilder.Build();

        Assert.Equal("Foo", container.Resolve<string>());
    }
}
