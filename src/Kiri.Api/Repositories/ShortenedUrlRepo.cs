using Dapper;
using Kiri.Api.Data;
using Kiri.Api.Models;

namespace Kiri.Api.Repositories;

public class ShortenedUrlRepo : IShortenedUrlRepo
{
    private const string TableName = "shortened_url";
    private readonly IDbConnectionFactory _connFactory;

    public ShortenedUrlRepo(IDbConnectionFactory connFactory) =>
        _connFactory = connFactory;

    public async Task<bool> CreateAsync(ShortenedUrl shortenedUrl)
    {
        using var conn = await _connFactory.CreateConnectionAsync();
        var sql = $"""
            INSERT INTO {TableName} (Id, Code, LongUrl, CreatedAtUtc)
            VALUES (@Id, @Code, @LongUrl, @CreatedAtUtc)
        """;
        var results = await conn.ExecuteAsync(sql, shortenedUrl);
        return results == 1;
    }

    public async Task<bool> ExistsAsync(string longUrl)
    {
        using var conn = await _connFactory.CreateConnectionAsync();
        var sql = $"""
            SELECT EXISTS(SELECT 1 FROM {TableName} WHERE LongUrl = @LongUrl)
        """;
        var exists = await conn.ExecuteScalarAsync<bool>(sql, new { LongUrl = longUrl });
        return exists;
    }

    public async Task<ShortenedUrl?> GetByCodeAsync(string code)
    {
        using var conn = await _connFactory.CreateConnectionAsync();

        var sql = $"""
            SELECT Id, Code, LongUrl, CreatedAtUtc
            FROM {TableName}
            WHERE Code = @Code
        """;

        return await conn.QuerySingleOrDefaultAsync<ShortenedUrl>(
            sql, new { Code = code });
    }
}
