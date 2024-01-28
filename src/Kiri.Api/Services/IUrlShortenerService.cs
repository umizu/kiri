namespace Kiri.Api.Services;

public interface IUrlShortenerService {
    Task<string> GenerateCodeAsync(string url);
}
