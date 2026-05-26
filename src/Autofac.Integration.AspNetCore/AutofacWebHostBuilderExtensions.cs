// Copyright (c) Autofac Project. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.AspNetCore.Hosting;

/// <summary>
/// Extension methods for the <see cref="IWebHostBuilder"/> interface.
/// </summary>
public static class AutofacWebHostBuilderExtensions
{
    /// <summary>
    /// Adds the Autofac <see cref="IServiceProviderFactory{TContainerBuilder}"/> implementation to the <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="builder">The <see cref="IWebHostBuilder"/> instance being configured.</param>
    /// <param name="configurationAction">An option action used to configure the container.</param>
    /// <returns>The existing <see cref="IWebHostBuilder"/> instance.</returns>
    public static IWebHostBuilder UseAutofac(this IWebHostBuilder builder, Action<ContainerBuilder>? configurationAction = null)
    {
        ArgumentNullException.ThrowIfNull(builder);

        return builder.ConfigureServices(services => services.AddAutofac(configurationAction));
    }
}
