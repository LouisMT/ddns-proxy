using System.ComponentModel.DataAnnotations;

namespace Core.Options;

public record DdnsRecord
{
    [Required]
    public string Key { get; set; } = null!;

    [Required]
    public string ZoneId { get; set; } = null!;

    [Required]
    public string DnsRecordId { get; set; } = null!;
}
