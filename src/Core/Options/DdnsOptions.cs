using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace Core.Options;

public record DdnsOptions
{
    public const string Ddns = "DDNS";

    public bool EnableList { get; set; } = true;

    [Required]
    [ValidateEnumeratedItems]
    public IList<DdnsRecord> Records { get; set; } = [];
}
