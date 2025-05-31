using Core.Clients;
using Core.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Core.Handlers;

public static class UpdateHandler
{
    public static async Task<IResult> Handle(
        CloudflareClient cloudflareClient,
        IOptions<DdnsOptions> ddnsOptions,
        [FromQuery] string key,
        [FromQuery] string ipv4
    )
    {
        var record = ddnsOptions.Value.Records.Single(r => r.Key == key);

        await cloudflareClient.UpdateDnsRecord(record.ZoneId, record.DnsRecordId, ipv4);

        return Results.Ok();
    }
}
