using ApplicationService.Bootstrap;
using Infrastructure.Mappers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SwaggerUI.API.Mappers;

namespace SwaggerUI.API.Bootstrap
{
    /// <summary>
    /// SwaggerUIAPIBootstrap
    /// </summary>
    public abstract class SwaggerUIAPIBootstrap
    {
        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="services"></param>
        /// <param name="env"></param>
        public static void Initialize(IServiceCollection services, IHostEnvironment env)
        {
            ApplicationServiceBootstrap.Initialize(services, env);
            SwaggerUIUnityRegistror.Register(services);
            MapperInitializer.AddProfile(new CustomerModelMapper());
            MapperInitializer.AddProfile(new SupplierModelMapper());

        }
    }
}
