
namespace Kiri.Api.Services;

public class UrlShortenerService : IUrlShortenerService
{
    private readonly IDateTimeProvider _dateTimeProvider;

    public UrlShortenerService(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }

    private const string _chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

    public Task<string> GenerateCodeAsync(string url)
    {
        throw new NotImplementedException();
    }

    private string GenerateCode => Guid.NewGuid().ToString("N").Substring(0, 8);
}
