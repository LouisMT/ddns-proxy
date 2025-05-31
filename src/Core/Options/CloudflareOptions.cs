namespace Core.Options;

public record CloudflareOptions
{
    public const string Cloudflare = "Cloudflare";

    public required string ApiToken { get; set; }
}
