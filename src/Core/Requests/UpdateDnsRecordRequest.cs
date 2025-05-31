namespace Core.Requests;

public record UpdateDnsRecordRequest
{
    public required string Content { get; init; }
}
