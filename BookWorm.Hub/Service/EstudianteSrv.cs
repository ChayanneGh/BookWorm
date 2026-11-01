using BookWorm.Hub.Sql;
using BookWorm.Shared.Entity;
using Dapper;

namespace BookWorm.Hub.Service;

public class EstudianteSrv(CFactory factory)
{
    public async Task<EstudianteMdl> Create(EstudianteMdl estudiante)
    {
        using var connection = factory.GetConnection();
        int Id = await connection.ExecuteScalarAsync<int>(EstudianteSql.Insert, estudiante);

        return estudiante with { IdEstudiante = Id };
    }

    public async Task<IEnumerable<EstudianteMdl>> Read()
    {
        using var connection = factory.GetConnection();
        return await connection.QueryAsync<EstudianteMdl>(EstudianteSql.Select);
    }

    public async Task<EstudianteMdl> ReadOne(int Id)
    {
        using var connection = factory.GetConnection();
        return await connection.QueryFirstOrDefaultAsync<EstudianteMdl>(EstudianteSql.SelectbyId, new { Id });
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
