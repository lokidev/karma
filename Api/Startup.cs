using System;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KarmaManagement.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using KarmaManagement.Messaging.Configurations;
using KarmaManagement.Messaging.Interfaces;
using KarmaManagement.Messaging.Services;
using KarmaManagement.Services.Interfaces;
using KarmaManagement.Models;
using Microsoft.EntityFrameworkCore;
using KarmaManagement.Configurations;

namespace KarmaManagement
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = GetDbConnectionString();

            services.AddDbContext<KarmaManagementContext>(options =>
            {
                options.UseSqlServer(connectionString,
                sqlServerOptionsAction: sqlOptions =>
                {
                    //Configuring Connection Resiliency:
                    sqlOptions.
                        EnableRetryOnFailure(maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null);
                });
            });

            services.ConfigureRepositories()
                    .ConfigureBusiness()
                    .ConfigureServices()
                    .ConfigureUtilities()
                    .AddCorsConfiguration();

            services.AddControllers();

            services.Configure<RabbitMQSettings>(Configuration.GetSection(nameof(RabbitMQSettings)));
            services.AddSingleton<IRabbitMqService, RabbitMqService>();
            services.AddSingleton<IKarmaListenerService, KarmaListenerService>();
            services.AddScoped<IKarmaService, KarmaService>();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Karma Management API",
                    Description = "A simple example ASP.NET Core Web API",
                    Contact = new OpenApiContact
                    {
                        Name = "Josh French",
                    },
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            InstantiateRmqServices(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            if (env.IsProduction())
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseHttpsRedirection();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Karma API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseCors(MyAllowSpecificOrigins);

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private string GetDbConnectionString()
        {
            string connectionString = Configuration.GetValue<string>("SqlConnection");

            return connectionString;
        }

        /// <summary>
        /// This forces any RabbitMQ services to instantiate and begin 
        /// their services immediately
        /// </summary>
        /// <param name="app"></param>
        private void InstantiateRmqServices(IApplicationBuilder app)
        {
            app.ApplicationServices.GetService(typeof(IRabbitMqService));
            app.ApplicationServices.GetService(typeof(IKarmaListenerService));
        }
    }
}
