using BookWorm.Hub.Sql;
using BookWorm.Shared.Entity;
using Dapper;

namespace BookWorm.Hub.Service;

public class LibroSrv(CFactory factory)
{
    public async Task<LibroMdl> Create(LibroMdl libro)
    {
        using var connection = factory.GetConnection();
        int Id = await connection.ExecuteScalarAsync<int>(LibroSql.Insert, libro);

        return libro with { IdLibro = Id };
    }

    public async Task<IEnumerable<LibroMdl>> Read()
    {
        using var connection = factory.GetConnection();
        return await connection.QueryAsync<LibroMdl>(LibroSql.Select);
    }

    public async Task<LibroMdl> ReadOne(int Id)
    {
        using var connection = factory.GetConnection();
        return await connection.QueryFirstOrDefaultAsync<LibroMdl>(LibroSql.SelectbyId, new { Id });
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
