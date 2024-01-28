
using Kiri.Api.Models;
using Kiri.Api.Repositories;

namespace Kiri.Api.Services;

public class UrlShortenerService : IUrlShortenerService
{
    private const string Chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

    private const int CodeLength = 7;

    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IShortenedUrlRepo _shortenedUrlRepo;

    public UrlShortenerService(IDateTimeProvider dateTimeProvider, IShortenedUrlRepo shortenedUrlRepo)
    {
        _dateTimeProvider = dateTimeProvider;
        _shortenedUrlRepo = shortenedUrlRepo;
    }

    public async Task<string> ShortenAsync(string url)
    {
        while (true)
        {
            var code = GenerateCode();
            if (!await _shortenedUrlRepo.ExistsAsync(code))
            {
                await _shortenedUrlRepo.CreateAsync(new ShortenedUrl
                {
                    Id = Guid.NewGuid(),
                    Code = code,
                    LongUrl = url,
                    CreatedAtUtc = _dateTimeProvider.UtcNow
                });
                return code;
            }
        }
    }

    private static string GenerateCode()
    {
        var random = new Random();
        var code = new char[CodeLength];
        for (var i = 0; i < CodeLength; i++)
        {
            code[i] = Chars[random.Next(Chars.Length)];
        }

        return new string(code);
    }
}
