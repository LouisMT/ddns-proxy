using System.ComponentModel.DataAnnotations;

namespace Core.Options;

public record DdnsRecord
{
    [Required]
    public string Key { get; set; } = string.Empty;

    [Required]
    public string ZoneId { get; set; } = string.Empty;

    [Required]
    public string DnsRecordId { get; set; } = string.Empty;
}
