using System.Text.Json;
using Core.Requests;

namespace Core.Clients;

public class CloudflareClient(
    HttpClient httpClient
)
{
    private static readonly AppJsonSerializerContext _context = new(new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
    });

    public async Task UpdateDnsRecord(string zoneId, string dnsRecordId, string ipAddress)
    {
        var request = new UpdateDnsRecordRequest
        {
            Content = ipAddress
        };

        using var requestMessage = new HttpRequestMessage(HttpMethod.Patch, $"zones/{zoneId}/dns_records/{dnsRecordId}")
        {
            Content = JsonContent.Create(request, _context.UpdateDnsRecordRequest)
        };

        using var responseMessage = await httpClient.SendAsync(requestMessage);

        responseMessage.EnsureSuccessStatusCode();

        var response = await responseMessage.Content.ReadFromJsonAsync(_context.UpdateDnsRecordResponse);

        if (response is not { Success: true })
        {
            throw new Exception("Received unsuccessful response from Cloudflare API");
        }
    }
}
