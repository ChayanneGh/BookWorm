using BookWorm.Hub.Sql;
using Dapper;
using Microsoft.Data.Sqlite;

namespace BookWorm.Hub.Service;

public class CFactory(IConfiguration configuration)
{
    private string _connection = configuration.GetConnectionString("BookWormDb");

    public SqliteConnection GetConnection()
    {
        return new SqliteConnection(_connection);
    }

    public async Task Initialize()
    {
        using var connection = GetConnection();
        await connection.ExecuteAsync(Ddl.TablesCreate);
    }
}
