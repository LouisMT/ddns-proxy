using Core.Clients;
using Core.Options;
using Core.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Core.Handlers;

public static class ListHandler
{
    public static async Task<IResult> Handle(
        CloudflareClient cloudflareClient,
        IOptions<DdnsOptions> ddnsOptions,
        [FromQuery] string zoneId
    )
    {
        if (!ddnsOptions.Value.EnableList)
        {
            return Results.NotFound();
        }

        var records = await cloudflareClient.ListDnsRecords(zoneId);

        return Results.Ok(new ListResponse
        {
            Records = records
        });
    }
}
