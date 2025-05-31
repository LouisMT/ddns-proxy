using System.ComponentModel.DataAnnotations;
using Core.Clients;
using Core.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Core.Handlers;

public static class UpdateHandler
{
    public static async Task<IResult> Handle(
        CloudflareClient cloudflareClient,
        IOptions<List<RecordOptions>> recordOptions,
        [FromQuery, Required] string key,
        [FromQuery, Required] string ipv4
    )
    {
        var record = recordOptions.Value.Single(r => r.Key == key);

        await cloudflareClient.UpdateDnsRecord(record.ZoneId, record.DnsRecordId, ipv4);

        return Results.Ok();
    }
}
