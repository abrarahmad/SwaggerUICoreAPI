using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistance.Context;
using Persistance.Settings;
using System.IO;

namespace Persistance.Bootstrap
{
    internal abstract class UnityRegistror
    {

        public static void Register(IServiceCollection services, IHostEnvironment env)
        {
            //register your db context as per your need sql db/mongo db / cosmos db

            var builder = new ConfigurationBuilder()
           .SetBasePath(env.ContentRootPath)
           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            //for azure cosmos db un-comment below code and comment bottom code

            //services.Configure<CosmosDatabaseSettings>(_ =>
            // {
            //     var keys = configuration.GetSection(nameof(CosmosDatabaseSettings)).Get<CosmosDatabaseSettings>();
            //     _.ConnectionString = keys.ConnectionString;
            //     _.DatabaseName = keys.DatabaseName;
            // });
            //services.AddSingleton<ICosmosDatabaseSettings>(sp =>
            //  sp.GetRequiredService<IOptions<CosmosDatabaseSettings>>().Value);
            //services.AddSingleton<CosmosDbContext>();


            if (env.IsDevelopment())
            {
                var contentPath = env.ContentRootPath;
                var rootPath = Path.Combine(contentPath.Substring(0, contentPath.LastIndexOf("\\")), @"REPOSITORY\LOCALDB\LOCALDB.MDF");
                services.AddDbContext<ProductDbContext>(e => e.UseSqlServer(@"data source=(LocalDB)\MSSQLLocalDB;database=" + rootPath + "; integrated security=True;MultipleActiveResultSets=True;"));
            }
            else
            {
                // azure sql db 
                var settings = configuration.GetSection(nameof(AzureSqlDatabaseSettings)).Get<AzureSqlDatabaseSettings>();
                services.AddDbContext<ProductDbContext>(db => db.UseSqlServer(settings.ConnectionString));
            }

        }
    }
}
