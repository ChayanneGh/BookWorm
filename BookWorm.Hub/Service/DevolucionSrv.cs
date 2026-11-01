using BookWorm.Hub.Sql;
using BookWorm.Shared.Entity;
using Dapper;

namespace BookWorm.Hub.Service;

public class DevolucionSrv(CFactory factory)
{
    public async Task Create(DevolucionMdl devolucion)
    {
        using var connection = factory.GetConnection();
        await connection.ExecuteAsync(DevolucionSql.Insert, devolucion);
    }

    public async Task Read()
    {
        using var connection = factory.GetConnection();
        await connection.QueryAsync<DevolucionMdl>(DevolucionSql.Select);
    }

    public async Task ReadOne(int Id)
    {
        using var connection = factory.GetConnection();
        await connection.QueryAsync<DevolucionMdl>(DevolucionSql.SelectbyId, new { Id });
    }

    public async Task Update(DevolucionMdl devolucion)
    {
        using var connection = factory.GetConnection();
        await connection.ExecuteAsync(DevolucionSql.Update, devolucion);
    }

    public async Task Delete(int Id)
    {
        using var connection = factory.GetConnection();
        await connection.ExecuteAsync(DevolucionSql.Delete, new { Id });
    }
}
