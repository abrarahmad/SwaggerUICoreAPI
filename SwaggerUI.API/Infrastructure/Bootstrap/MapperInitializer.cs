using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Infrastructure.Mappers
{
    public class MapperInitializer
    {
        static ICollection<Profile> profiles = new List<Profile>();

        public static void Initialize(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfiles(profiles);
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        public static void AddProfile(Profile profile)
        {
            if (!profiles.Contains(profile))
                profiles.Add(profile);
        }
    }
}
