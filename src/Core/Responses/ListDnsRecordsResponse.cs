namespace Core.Responses;

public record ListDnsRecordsResponse
{
    public required bool Success { get; set; }

    public required IList<DnsRecordResponse> Result { get; set; }
};
