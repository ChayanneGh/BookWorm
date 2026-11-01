namespace BookWorm.Hub.Sql;

public class PrestamoSql
{
    public const string Insert =
    "INSERT INTO Prestamos (EstudianteId, LibroId, FechaPrestamo) " +
    "VALUES (@EstudianteId, @LibroId, @FechaPrestamo)";

    public const string Select =
        "SELECT * FROM Prestamos";

    public const string SelectbyId =
        "SELECT * FROM Prestamos WHERE IdPrestamo = @IdPrestamo";

    public const string Update =
        "UPDATE Prestamos SET EstudianteId = @EstudianteId, LibroId = @LibroId, FechaPrestamo = @FechaPrestamo WHERE IdPrestamo = @IdPrestamo";

    public const string Delete =
        "DELETE FROM Prestamos WHERE IdPrestamo = @IdPrestamo";
}
