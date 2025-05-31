using Core.Clients;
using Core.Handlers;
using Core.MessageHandlers;
using Core.Options;

namespace Core;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateSlimBuilder(args);

        builder.Services.AddOptions<CloudflareOptions>()
            .Bind(builder.Configuration.GetSection(CloudflareOptions.Cloudflare));

        builder.Services.AddOptions<List<RecordOptions>>()
            .Bind(builder.Configuration.GetSection(RecordOptions.Records));

        builder.Services.AddTransient<CloudflareApiTokenMessageHandler>();

        builder.Services.AddHttpClient<CloudflareClient>(o =>
            {
                o.BaseAddress = new Uri("https://api.cloudflare.com/client/v4/");
            })
            .AddHttpMessageHandler<CloudflareApiTokenMessageHandler>();

        var app = builder.Build();

        app.MapGet("/update", UpdateHandler.Handle);

        app.Run();
    }
}
