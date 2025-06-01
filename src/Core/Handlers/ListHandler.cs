using Core.Clients;
using Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Core.Handlers;

public static class ListHandler
{
    public static async Task<IResult> Handle(
        CloudflareClient cloudflareClient,
        [FromQuery] string zoneId
    )
    {
        var records = await cloudflareClient.ListDnsRecords(zoneId);

        return Results.Ok(new ListResponse
        {
            Records = records
        });
    }
}
