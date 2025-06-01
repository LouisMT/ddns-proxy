using Core.Clients;
using Core.Handlers;
using Core.MessageHandlers;
using Core.Options;
using Core.OptionsValidators;
using Microsoft.Extensions.Options;

namespace Core;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateSlimBuilder(args);

        builder.Services.ConfigureHttpJsonOptions(options =>
        {
            options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
        });

        AddOptions(builder.Services, builder.Configuration);

        AddCloudflareClient(builder.Services);

        var app = builder.Build();

        app.MapGet("/update", UpdateHandler.Handle);
        app.MapGet("/list", ListHandler.Handle);

        app.Run();
    }

    private static void AddOptions(IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddOptionsWithValidateOnStart<CloudflareOptions>()
            .Bind(configuration.GetSection(CloudflareOptions.Cloudflare));
        services.AddSingleton<IValidateOptions<CloudflareOptions>, CloudflareOptionsValidator>();

        services.AddOptionsWithValidateOnStart<DdnsOptions>()
            .Bind(configuration.GetSection(DdnsOptions.Ddns));
        services.AddSingleton<IValidateOptions<DdnsOptions>, DdnsOptionsValidator>();
    }

    private static void AddCloudflareClient(IServiceCollection services)
    {
        services.AddTransient<CloudflareApiTokenMessageHandler>();

        services.AddHttpClient<CloudflareClient>(o =>
            {
                o.BaseAddress = new Uri("https://api.cloudflare.com/client/v4/");
            })
            .AddHttpMessageHandler<CloudflareApiTokenMessageHandler>();
    }
}
