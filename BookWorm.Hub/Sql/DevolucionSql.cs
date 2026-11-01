namespace BookWorm.Hub.Sql;

public class DevolucionSql
{
    public const string Insert =
        "INSERT INTO Devoluciones (EstudianteId, LibroId, FechaDevolucion) " +
        "VALUES (@EstudianteId, @LibroId, @FechaDevolucion)";

    public const string Select =
        "SELECT * FROM Devoluciones";

    public const string SelectbyId =
        "SELECT * FROM Devoluciones WHERE IdDevolucion = @IdDevolucion";

    public const string Update =
        "UPDATE Devoluciones SET EstudianteId = @EstudianteId, LibroId = @LibroId, " +
        "FechaDevolucion = @FechaDevolucion WHERE IdDevolucion = @IdDevolucion";

    public const string Delete =
        "DELETE FROM Devoluciones WHERE IdDevolucion = @IdDevolucion";
}
