namespace Core.Options;

public record RecordOptions
{
    public string Key { get; set; } = null!;

    public string ZoneId { get; set; } = null!;

    public string DnsRecordId { get; set; } = null!;
}
