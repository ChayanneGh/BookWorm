using BookWorm.Hub.Sql;
using BookWorm.Shared.Entity;
using Dapper;

namespace BookWorm.Hub.Service;

public class PrestamoSrv(CFactory factory)
{
    public async Task<PrestamoMdl> Create(PrestamoMdl prestamo)
    {
        using var connection = factory.GetConnection();
        int Id = await connection.ExecuteScalarAsync<int>(PrestamoSql.Insert, prestamo);

        return prestamo with { IdPrestamo = Id };
    }

    public async Task<IEnumerable<PrestamoMdl>> Read()
    {
        using var connection = factory.GetConnection();
        return await connection.QueryAsync<PrestamoMdl>(PrestamoSql.Select);
    }

    public async Task<PrestamoMdl> ReadOne(int Id)
    {
        using var connection = factory.GetConnection();
        return await connection.QueryFirstOrDefaultAsync<PrestamoMdl>(PrestamoSql.SelectbyId, new { Id });
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
