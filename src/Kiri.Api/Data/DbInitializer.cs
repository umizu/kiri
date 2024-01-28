using Dapper;

namespace Kiri.Api.Data;

public class DbInitializer
{
    private readonly IDbConnectionFactory _dbConnFactory;

    public DbInitializer(IDbConnectionFactory dbConnFactory) =>
        _dbConnFactory = dbConnFactory;

    public async Task InitializeAsync()
    {
        using var connection = await _dbConnFactory.CreateConnectionAsync();

        await connection.ExecuteAsync("""
            CREATE TABLE IF NOT EXISTS shortened_url (
            Id UUID PRIMARY KEY,
            LongUrl TEXT NOT NULL,
            Code TEXT NOT NULL,
            CreatedAtUtc TIMESTAMP NOT NULL);
            """
        );

    }
}
