using BookWorm.Hub.Sql;
using BookWorm.Shared.Entity;
using Dapper;

namespace BookWorm.Hub.Service;

public class EstudianteSrv(CFactory factory)
{
    public async Task Create(EstudianteMdl estudiante)
    {
        using var connection = factory.GetConnection();
        await connection.ExecuteAsync(EstudianteSql.Insert, estudiante);
    }

    public async Task Read()
    {
        using var connection = factory.GetConnection();
        await connection.QueryAsync<EstudianteMdl>(EstudianteSql.Select);
    }

    public async Task ReadOne(int Id)
    {
        using var connection = factory.GetConnection();
        await connection.QueryAsync<EstudianteMdl>(EstudianteSql.SelectbyId, new { Id });
    }

    public async Task Update(EstudianteMdl estudiante)
    {
        using var connection = factory.GetConnection();
        await connection.ExecuteAsync(EstudianteSql.Update, estudiante);
    }

    public async Task Delete(int Id)
    {
        using var connection = factory.GetConnection();
        await connection.ExecuteAsync(EstudianteSql.Delete, new { Id });
    }
}
