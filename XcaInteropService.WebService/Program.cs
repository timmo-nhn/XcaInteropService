using XcaInteropService.Commons.Models.Custom;
using XcaInteropService.Source.Services;
using XcaInteropService.WebService.Middleware;
using XcaInteropService.WebService.Services;

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
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddSingleton<TargetCommunitiesService>();
        builder.Services.AddSingleton<TargetCommunitiesWrapper>();
        builder.Services.AddSingleton<InitiatingGatewayService>();

        builder.Services.AddHttpClient();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseMiddleware<SessionIdTraceMiddleware>();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
