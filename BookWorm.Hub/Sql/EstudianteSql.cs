namespace BookWorm.Hub.Sql;

public class EstudianteSql
{
    public const string Insert =
        "INSERT INTO Estudiantes (Nombre, Email, Telefono) " +
        "VALUES (@Nombre, @Email, @Telefono)";

    public const string Select =
        "SELECT * FROM Estudiantes";

    public const string SelectbyId =
        "SELECT * FROM Estudiantes WHERE IdEstudiante = @IdEstudiante";

    public const string Update =
        "UPDATE Estudiantes SET Nombre = @Nombre, Email = @Email, Telefono = @Telefono WHERE IdEstudiante = @IdEstudiante";

    public const string Delete =
        "DELETE FROM Estudiantes WHERE IdEstudiante = @IdEstudiante";
}
