using Abstraction.GenericModels.Configurations;
using Integrate;

namespace WebApp
{
    public static class ServiceExtension
    {
        /// <summary>
        /// Config file AppSettings.json bind
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <remarks>
        /// 05/05/2023, created by Orion
        /// </remarks>
        public static void ConfigureConfigFiles(this IServiceCollection services, IConfiguration configuration)
        {
            var appSetting = new AppSettings();
            configuration.GetSection("AppSettings").Bind(appSetting);
            services.AddSingleton(appSetting);

            var apiSetting = new ApiSettings();
            configuration.GetSection("ApiSettings").Bind(apiSetting);
            services.AddSingleton(apiSetting);
        }

        /// <summary>
        /// Custom Dependencies
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <remarks>
        /// 05/05/2023, created by Orion
        /// </remarks>
        public static void ConfigureCustomDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.IntegrationServices();
        }
    }
}
