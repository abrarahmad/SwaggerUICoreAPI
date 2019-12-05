using ApplicationService.Interfaces;
using ApplicationService.Services;
using Microsoft.Extensions.DependencyInjection;

namespace SwaggerUI.API.Bootstrap
{
    /// <summary>
    /// SwaggerUIUnityRegistror
    /// </summary>
    public abstract class SwaggerUIUnityRegistror
    {
        /// <summary>
        /// Register
        /// </summary>
        /// <param name="services"></param>
        public static void Register(IServiceCollection services)
        {

            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<ISupplierService, SupplierService>();
        }
    }
}
