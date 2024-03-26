using Integrate.IServices.Components;
using Integrate.Services.Components;
using Microsoft.Extensions.DependencyInjection;

namespace Integrate
{
    public static class IntegrateScopeProvider
    {
        public static void IntegrationServices(this IServiceCollection services)
        {
            // Components
            services.AddTransient<IRenderRazorService, RenderRazorService>();
        }

        public static void IntegrationServicesBuilder(this IServiceCollection services)
        {
            var integrationProviderTypes = System.Reflection.Assembly.GetExecutingAssembly()
                .GetTypes().Where(t => t.Namespace != null && t.Namespace.Contains("sc.Integration"));

            // TODO: Need to check if the 2 class extend from same interface. Auto builder.
            foreach (var intfc in integrationProviderTypes.Where(t => t.IsInterface)) {
                var implementation = integrationProviderTypes.FirstOrDefault(c => c.IsClass && intfc.IsAssignableFrom(c) && !c.IsAbstract);
                if (implementation != null)
                    services.AddTransient(intfc, implementation);
            }
        }
    }
}
