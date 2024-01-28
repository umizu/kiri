using Kiri.Api.Models;

namespace Kiri.Api.Repositories;

public interface IShortenedUrlRepo
{
    Task<bool> CreateAsync(ShortenedUrl shortenedUrl);
    Task<ShortenedUrl?> GetByCodeAsync(string code);
    Task<bool> ExistsAsync(string longUrl);
}
