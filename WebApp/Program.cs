using Structures.Trace_Log4net;
using WebApp;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;
IHostEnvironment environment = builder.Environment;
IServiceCollection services = builder.Services;

/**
 * Configure Services
 * Add services to the container.
 */

// Add services to the container.
services.AddControllersWithViews();

// Add services http context, access http context in razor pages
services.AddHttpContextAccessor();

// Add services session to stateless http, session and state management
services.AddSession();

// Add CSRF
services.AddAntiforgery();

// Config file AppSettings.json bind
ServiceExtension.ConfigureConfigFiles(services, configuration);
// Custom Dependencies
ServiceExtension.ConfigureCustomDependencies(services, configuration);

/*
 * End Configure Services
 */

await using WebApplication app = builder.Build();

/**
 * Configure the app.
 */

app.Services.GetRequiredService<ILoggerFactory>().AddLog4net("log4net.config", "log4net");

if (app.Environment.IsDevelopment()) {
    app.UseDeveloperExceptionPage();
} else {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

await app.RunAsync();

/*
 * End of Configure 
 */
