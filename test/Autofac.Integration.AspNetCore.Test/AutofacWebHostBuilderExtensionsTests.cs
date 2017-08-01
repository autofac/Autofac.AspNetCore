using System;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;

namespace Autofac.Integration.AspNetCore.Test
{
    public class AutofacWebHostBuilderExtensionsTests
    {
        [Fact]
        public void UseAutofacAddsFactoryProviderToServiceCollection()
        {
            var webHostBuilder = new Mock<IWebHostBuilder>();

            Action<IServiceCollection> serviceAction = null;
            webHostBuilder.Setup(x => x.ConfigureServices(It.IsAny<Action<IServiceCollection>>()))
                .Callback<Action<IServiceCollection>>(s => serviceAction = s);

            webHostBuilder.Object.UseAutofac(b => b.RegisterInstance("Foo"));

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
}
