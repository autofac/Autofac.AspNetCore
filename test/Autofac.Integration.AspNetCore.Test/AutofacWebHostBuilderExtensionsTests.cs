// <copyright file="AutofacWebHostBuilderExtensionsTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Autofac.Integration.AspNetCore.Test;

using System;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using Xunit;

public class AutofacWebHostBuilderExtensionsTests
{
    [Fact]
    public void UseAutofacAddsFactoryProviderToServiceCollection()
    {
        var webHostBuilder = Substitute.For<IWebHostBuilder>();

        Action<IServiceCollection> serviceAction = null;
        webHostBuilder.ConfigureServices(Arg.Do<Action<IServiceCollection>>(s => serviceAction = s));

        webHostBuilder.UseAutofac(b => b.RegisterInstance("Foo"));

        var services = new ServiceCollection();
        serviceAction(services);

        var serviceProvider = services.BuildServiceProvider();
        var factory = serviceProvider.GetService<IServiceProviderFactory<ContainerBuilder>>();

        Assert.IsType<AutofacServiceProviderFactory>(factory);

        var containerBuilder = factory.CreateBuilder(services);
        var container = containerBuilder.Build();

        Assert.Equal("Foo", container.Resolve<string>());
    }
}
