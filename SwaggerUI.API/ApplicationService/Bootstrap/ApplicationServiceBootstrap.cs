using ApplicationService.Mappers;
using Infrastructure.Mappers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistance.Bootstrap;

namespace ApplicationService.Bootstrap
{
    public abstract class ApplicationServiceBootstrap
    {
        public static void Initialize(IServiceCollection services, IHostEnvironment env)
        {
            PersistanceBootstrap.Initialize(services, env);
            UnityRegistror.Register(services);
            MapperInitializer.AddProfile(new CustomerMapper());
            MapperInitializer.AddProfile(new SupplierMapper());

        }
    }
}
