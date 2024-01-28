namespace Kiri.Api.Services;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}
