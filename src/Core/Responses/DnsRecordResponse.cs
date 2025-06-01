namespace Core.Responses;

public record DnsRecordResponse
{
    public required string Id { get; init; }

    public required string Name { get; init; }

    public required string Type { get; init; }
}
