using Infrastructure.Mappers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SwaggerUI.API.Authentication;
using SwaggerUI.API.Bootstrap;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace SwaggerUI.API
{

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        private readonly IHostEnvironment _env;

        public Startup(IHostEnvironment env)
        {

            _env = env;

        }
        public void ConfigureServices(IServiceCollection services)
        {
            //global level handle status code
            services.AddControllers(action =>
            {
                action.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status404NotFound));
                action.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status200OK));
                action.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status500InternalServerError));
                action.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status401Unauthorized));
                action.ReturnHttpNotAcceptable = true;
                action.Filters.Add(new AuthorizeFilter());
            }).AddNewtonsoftJson()
             .AddXmlSerializerFormatters();

            services.AddOptions();//Add functionality to inject IOptions<T>

            SwaggerUIAPIBootstrap.Initialize(services, _env);
            MapperInitializer.Initialize(services);

            //services.AddAuthentication("Basic")
            //    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("Basic", null);

            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = "API Key";
            //    options.DefaultChallengeScheme = "API Key";
            //});

            services.AddAuthentication("oauth")
                .AddScheme<AuthenticationSchemeOptions, ApiKeyAuthenticationHandler>("oauth", null);
            services.AddSwaggerGen(action =>
            {
                action.SwaggerDoc("CustomerApi", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Customer",
                    Version = "1",
                    Description = "Through this API can access customers information",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                    {
                        Name = "Abrar Ahmad Ansari",
                        Email = "test@gmail.com",
                        Url = new Uri("https://www.google.com"),
                    },
                    License = new Microsoft.OpenApi.Models.OpenApiLicense()
                    {
                        Name = "Abrar Ahmad Ansari",
                        Url = new Uri("https://www.google.com")
                    }
                });
                action.SwaggerDoc("SupplierApi", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Supplier",
                    Version = "1",
                    Description = "Through this API can access supplier information",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                    {
                        Name = "Abrar Ahmad Ansari",
                        Email = "test@gmail.com",
                        Url = new Uri("https://www.google.com"),
                    },
                    License = new Microsoft.OpenApi.Models.OpenApiLicense()
                    {
                        Name = "Abrar Ahmad Ansari",
                        Url = new Uri("https://www.google.com")
                    }
                });
                var xmlCommentFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlCommentPath = Path.Combine(AppContext.BaseDirectory, xmlCommentFile);
                action.IncludeXmlComments(xmlCommentPath);

                //authorization 
                //http basic authentication
                //action.AddSecurityDefinition("basicAuth", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
                //{
                //    Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
                //    Scheme = "basic",
                //    In = ParameterLocation.Header,//optional
                //    Description = "input yourname and password to access the api"
                //});
                //action.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement()
                //{
                //    {
                //        new OpenApiSecurityScheme
                //        {
                //            Reference = new OpenApiReference
                //            {
                //                Type = ReferenceType.SecurityScheme,
                //                Id = "basicAuth"
                //            }
                //        },new List<string>()
                //    }
                //});
                // api key
                action.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
                    In = ParameterLocation.Header,
                    Name = "X-Api-Key",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                action.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                 Id = "Bearer"
                            },
                            Name ="Bearer",
                            In = ParameterLocation.Header

                        },new List<string>()
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(action =>
            {


                action.SwaggerEndpoint("/swagger/CustomerApi/swagger.json", "Customer Api");
                //override index.html file
                //action.IndexStream = () => GetType().Assembly
                //.GetManifestResourceStream("SwaggerUI.API.EmbaddedAssets.index.html");
                // action.InjectStylesheet("/swagger-ui/custom.css"); //addeding custom css
                action.SwaggerEndpoint("/swagger/SupplierApi/swagger.json", "Supplier Api");
                action.RoutePrefix = string.Empty;
                //below additional setting for ui
                action.DefaultModelExpandDepth(2);
                action.DefaultModelRendering(Swashbuckle.AspNetCore.SwaggerUI.ModelRendering.Model);
                action.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
                action.EnableDeepLinking();
                action.DisplayOperationId();

            });
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
