namespace Core.Responses;

public record ListResponse
{
    public required IList<DnsRecordResponse> Records { get; init; }
}
