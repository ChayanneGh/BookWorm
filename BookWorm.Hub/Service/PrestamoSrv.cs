using BookWorm.Hub.Sql;
using BookWorm.Shared.Entity;
using Dapper;

namespace BookWorm.Hub.Service;

public class PrestamoSrv(CFactory factory)
{
    public async Task Create(PrestamoMdl prestamo)
    {
        using var connection = factory.GetConnection();
        await connection.ExecuteAsync(PrestamoSql.Insert, prestamo);
    }

    public async Task Read()
    {
        using var connection = factory.GetConnection();
        await connection.QueryAsync<PrestamoMdl>(PrestamoSql.Select);
    }

    public async Task ReadOne(int Id)
    {
        using var connection = factory.GetConnection();
        await connection.QueryAsync<PrestamoMdl>(PrestamoSql.SelectbyId, new { Id });
    }

    public async Task Update(PrestamoMdl prestamo)
    {
        using var connection = factory.GetConnection();
        await connection.ExecuteAsync(PrestamoSql.Update, prestamo);
    }

    public async Task Delete(int Id)
    {
        using var connection = factory.GetConnection();
        await connection.ExecuteAsync(PrestamoSql.Delete, new { Id });
    }
}
