namespace Core.Options;

public record DdnsOptions
{
    public const string Ddns = "DDNS";

    public required IList<RecordOptions> Records { get; set; }
}
