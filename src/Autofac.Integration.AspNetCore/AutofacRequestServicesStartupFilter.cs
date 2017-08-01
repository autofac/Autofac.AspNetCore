using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace Autofac.Integration.AspNetCore
{
    internal class AutofacRequestServicesStartupFilter : IStartupFilter
    {
        public AutofacRequestServicesStartupFilter(Func<ILifetimeScope> rootScopeAccessor)
        {
            this.RootScopeAccessor = rootScopeAccessor;
        }

        public Func<ILifetimeScope> RootScopeAccessor { get; private set; }

        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return builder =>
            {
                builder.UseMiddleware<AutofacRequestServicesMiddleware>(this.RootScopeAccessor);
                next(builder);
            };
        }
    }
}
