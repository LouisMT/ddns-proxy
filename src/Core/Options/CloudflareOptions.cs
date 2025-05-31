using System.ComponentModel.DataAnnotations;

namespace Core.Options;

public record CloudflareOptions
{
    public const string Cloudflare = "Cloudflare";

    [Required]
    public string ApiToken { get; set; } = null!;
}
