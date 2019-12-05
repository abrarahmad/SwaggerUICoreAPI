using Infrastructure.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Bootstrap
{
    public abstract class InfrastructureBootstrap
    {
        public static void Initialize(IServiceCollection services)
        {
            MapperInitializer.Initialize(services);

        }
    }
}
