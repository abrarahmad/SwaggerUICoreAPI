using Microsoft.Extensions.DependencyInjection;
using Persistance.CosmosDbRepositories;
using Persistance.Interfaces;

namespace ApplicationService.Bootstrap
{
    public abstract class UnityRegistror
    {
        public static void Register(IServiceCollection services)
        {
            //services.AddTransient<ICustomerRepository, CosmosDbCustomerRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ISupplierRepository, SupplierRepository>();
        }
    }
}
