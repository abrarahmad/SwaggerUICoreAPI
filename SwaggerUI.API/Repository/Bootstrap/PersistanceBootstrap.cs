using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Persistance.Bootstrap
{
    public abstract class PersistanceBootstrap
    {
        public static void Initialize(IServiceCollection services, IHostEnvironment env)
        {
            UnityRegistror.Register(services, env);
        }
    }
}
