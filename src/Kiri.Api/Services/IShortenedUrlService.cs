using Kiri.Api.Models;

namespace Kiri.Api.Services;

public interface IShortenedUrlService
{
    Task<ShortenedUrl?> GetByCodeAsync(string code);
}
