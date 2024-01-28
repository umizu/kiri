
using Kiri.Api.Models;
using Kiri.Api.Repositories;

namespace Kiri.Api.Services;

public class ShortenedUrlService : IShortenedUrlService
{
    private readonly IShortenedUrlRepo _shortenedUrlRepo;

    public ShortenedUrlService(IShortenedUrlRepo shortenedUrlRepo) =>
        _shortenedUrlRepo = shortenedUrlRepo;

    public async Task<ShortenedUrl?> GetByCodeAsync(string code) =>
        await _shortenedUrlRepo.GetByCodeAsync(code);

}
