using System.Collections;
using XcaInteropService.Commons.Models.Custom;
using XcaInteropService.Source.Services;
using XcaInteropService.WebService.Middleware;
using XcaInteropService.WebService.Services;
using XcaXds.WebService.Startup;

namespace XcaInteropService.WebService;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers(options =>
        {
            options.ModelBinderProviders.Insert(0, new SoapEnvelopeModelBinderProvider());
        })
        .AddXmlSerializerFormatters();

        builder.Services.AddControllers();

        var applicationConfig = new ApplicationConfig();

        // If we are running in a container, override appsettings.json and environment variables for configuration
        if (bool.Parse(Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") ?? "false"))
        {
            var envVars = Environment.GetEnvironmentVariables().Cast<DictionaryEntry>().ToDictionary(entry => (string)entry.Key, entry => (string)entry.Value);
            var xdsConfigEnvVars = envVars.Where(n => n.Key.StartsWith("XdsConfiguration")).ToList();
            applicationConfig = ConfigBinder.BindKeyValueEnvironmentVariablesToXdsConfiguration(xdsConfigEnvVars);

            builder.Configuration.Bind(applicationConfig);
            Environment.SetEnvironmentVariable("TMP", @"/mnt/data/tmp", EnvironmentVariableTarget.Process);
            Environment.SetEnvironmentVariable("TEMP", @"/mnt/data/tmp", EnvironmentVariableTarget.Process);
            Environment.SetEnvironmentVariable("TMPDIR", @"/mnt/data/tmp", EnvironmentVariableTarget.Process);

            Console.WriteLine(Path.GetTempPath()); // now returns /mnt/data/tmp/
        }
        else
        {
            builder.Configuration.GetSection("XdsConfiguration").Bind(applicationConfig);
        }

        builder.Services.AddSingleton(applicationConfig);

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddSingleton<TargetCommunitiesService>();
        builder.Services.AddSingleton<TargetCommunitiesWrapper>();
        builder.Services.AddSingleton<InitiatingGatewayService>();
        builder.Services.AddSingleton<ValueSetRepositoryService>();
        builder.Services.AddSingleton<ValueSetRepositoryWrapper>();

        builder.Services.AddHttpClient();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        // Log thread and traceid and other stuff
        //app.UseMiddleware<ThreadLoggingScopeMiddleware>();

        app.UseMiddleware<SessionIdTraceMiddleware>();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
