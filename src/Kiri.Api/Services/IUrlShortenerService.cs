namespace Kiri.Api.Services;

public interface IUrlShortenerService {
    Task<string> ShortenAsync(string code);
}
