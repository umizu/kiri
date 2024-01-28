namespace Kiri.Api.Models;

public class ShortenedUrl
{
    public Guid Id { get; init; }
    public string LongUrl { get; set; } = null!;
    public string Code { get; set; } = null!;
    public DateTime CreatedAtUtc { get; init; }
}
