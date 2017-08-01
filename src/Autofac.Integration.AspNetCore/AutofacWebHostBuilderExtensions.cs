// This software is part of the Autofac IoC container
// Copyright © 2017 Autofac Contributors
// http://autofac.org
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.

using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Integration.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.AspNetCore.Hosting
{
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
        public static IWebHostBuilder UseAutofac(this IWebHostBuilder builder, Action<ContainerBuilder> configurationAction = null)
        {
            return builder.ConfigureServices(services => services.AddAutofac(configurationAction));
        }

        /// <summary>
        /// Adds the Autofac-specific request services middleware, which ensures request lifetimes come from the root container.
        /// Helpful when working with multitenancy to ensure proper tenant identification occurs.
        /// </summary>
        /// <param name="builder">The <see cref="IWebHostBuilder"/> instance being configured.</param>
        /// <param name="rootScopeAccessor">A function that will access the application container / root lifetime scope from which request lifetimes should be generated.</param>
        /// <returns>The existing <see cref="IWebHostBuilder"/> instance.</returns>
        public static IWebHostBuilder UseAutofacRequestServices(this IWebHostBuilder builder, Func<ILifetimeScope> rootScopeAccessor)
        {
            var descriptor = new ServiceDescriptor(typeof(IStartupFilter), sp => new AutofacRequestServicesStartupFilter(rootScopeAccessor), ServiceLifetime.Transient);
            return builder.ConfigureServices(services =>
            {
                services.Insert(0, descriptor);
                services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            });
        }
    }
}
