using System.Data;
using Npgsql;

namespace Kiri.Api.Data;

public class PgsqlConnectionFactory : IDbConnectionFactory
{
    private readonly string _connectionString;

    public PgsqlConnectionFactory(string connectionString) => 
        _connectionString = connectionString;

    public async Task<IDbConnection> CreateConnectionAsync()
    {
        var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();
        return connection;
    }
}
