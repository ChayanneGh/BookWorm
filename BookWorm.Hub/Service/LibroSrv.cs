using BookWorm.Hub.Sql;
using BookWorm.Shared.Entity;
using Dapper;

namespace BookWorm.Hub.Service;

public class LibroSrv(CFactory factory)
{
    public async Task Create(LibroMdl libro)
    {
        using var connection = factory.GetConnection();
        await connection.ExecuteAsync(LibroSql.Insert, libro);
    }

    public async Task Read()
    {
        using var connection = factory.GetConnection();
        await connection.QueryAsync<LibroMdl>(LibroSql.Select);
    }

    public async Task ReadOne(int Id)
    {
        using var connection = factory.GetConnection();
        await connection.QueryAsync<LibroMdl>(LibroSql.SelectbyId, new { Id });
    }

    public async Task Update(LibroMdl libro)
    {
        using var connection = factory.GetConnection();
        await connection.ExecuteAsync(LibroSql.Update, libro);
    }

    public async Task Delete(int Id)
    {
        using var connection = factory.GetConnection();
        await connection.ExecuteAsync(LibroSql.Delete, new { Id });
    }
}
