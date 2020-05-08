using System;

namespace Authorize.Application.UT.Common
{
    using Microsoft.Extensions.DependencyInjection;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class BaseTest
    {
        public IServiceProvider ServiceProvider { get; private set; }
        public IServiceScopeFactory ServiceScopeProvider { get; private set; }
        public IServiceScope ServiceScope { get; private set; }
        public BaseTest()
        {
            //var factory = new DefaultServiceProviderFactory(new ServiceProviderOptions());
            //var services = factory.CreateBuilder(new ServiceCollection());
            var services = new ServiceCollection();
            services.AddMocks()
                .AddApplication();

            ServiceProvider = services.BuildServiceProvider();
            ServiceScopeProvider = ServiceProvider.GetService<IServiceScopeFactory>();
            
                //factory.CreateServiceProvider(services);
            //ServiceProvider.GetService<>
        }


    }
}
