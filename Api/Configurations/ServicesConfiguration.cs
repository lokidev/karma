using Microsoft.Extensions.DependencyInjection;
using KarmaManagement.Repos;
using KarmaManagement.Services;
using KarmaManagement.Services.Interfaces;
using KarmaManagement.Repos.Interfaces;

namespace KarmaManagement.Configurations
{
    /// <summary>
    /// Services configuration for business and repository objects.
    /// </summary>
    public static class ServicesConfiguration
    {
        /// <summary>
        /// Extension method to include repositories for use in dependency injection.
        /// </summary>
        /// <param name="services">[in] The extended services object.</param>
        /// <returns>The static services object.</returns>
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IKarmaRepo, KarmaRepo>();

            return services;
        }

        /// <summary>
        /// Extension method to include business objects for use in dependency injection.
        /// </summary>
        /// <param name="services">[in] The extended services object.</param>
        /// <returns>The static services object.</returns>
        public static IServiceCollection ConfigureBusiness(this IServiceCollection services)
        {
            //services.AddScoped<IAssetsBusiness, AssetsBusiness>();

            return services;
        }

        /// <summary>
        /// Extension method to include service objects for use in dependency injection.
        /// </summary>
        /// <param name="services">[in] The extended services object.</param>
        /// <returns>The static services object.</returns>
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IKarmaService, KarmaService>();

            return services;
        }

        /// <summary>
        /// Registers scoped utilitys and interfaces.
        /// </summary>
        ///
        /// <param name="utilities">
        /// The service collection for which the scoped utilities should be
        /// registered. Must not be null.
        /// </param>
        ///
        /// <returns>
        /// The utilities collection.
        /// </returns>
        public static IServiceCollection ConfigureUtilities(this IServiceCollection utilities)
        {
            //utilities.AddScoped<IS3Client, S3Client>();

            return utilities;
        }

        /// <summary>
        /// Extention method to include Cors settings for web requests. This allows requests
        /// to come from ANY origin. We will want to set ours up to whitelist the deployed
        /// client(s) + MADEAs
        /// </summary>
        /// <param name="services">[in] The extended services object</param>
        /// <returns>The static services object.</returns>
        public static IServiceCollection AddCorsConfiguration(this IServiceCollection services)
        {
            string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin();
                    });
            });

            return services;
        }
    }
}
