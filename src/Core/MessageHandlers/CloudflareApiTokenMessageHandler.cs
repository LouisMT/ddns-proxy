
using Core.Options;
using Microsoft.Extensions.Options;

namespace Core.MessageHandlers;

public class CloudflareApiTokenMessageHandler(
    IOptions<CloudflareOptions> cloudflareOptions
) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        request.Headers.Add("Authorization", $"Bearer {cloudflareOptions.Value.ApiToken}");

        return await base.SendAsync(request, cancellationToken);
    }
}
