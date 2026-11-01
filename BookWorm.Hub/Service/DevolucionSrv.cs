using BookWorm.Hub.Sql;
using BookWorm.Shared.Entity;
using Dapper;

namespace BookWorm.Hub.Service;

public class DevolucionSrv(CFactory factory)
{
    public async Task<DevolucionMdl> Create(DevolucionMdl devolucion)
    {
        using var connection = factory.GetConnection();
        int Id = await connection.ExecuteScalarAsync<int>(DevolucionSql.Insert, devolucion);
        
        return devolucion with { IdDevolucion = Id };
    }

    public async Task<IEnumerable<DevolucionMdl>> Read()
    {
        using var connection = factory.GetConnection();
        return await connection.QueryAsync<DevolucionMdl>(DevolucionSql.Select);
    }

    public async Task<DevolucionMdl> ReadOne(int Id)
    {
        using var connection = factory.GetConnection();
        return await connection.QueryFirstOrDefaultAsync<DevolucionMdl>(DevolucionSql.SelectbyId, new { Id });
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
