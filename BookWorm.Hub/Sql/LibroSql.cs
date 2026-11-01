namespace BookWorm.Hub.Sql;

public class LibroSql
{
    public const string Insert =
        "INSERT INTO Libros (Titulo, Autor, ISBN) " +
        "VALUES (@Titulo, @Autor, @ISBN)";

    public const string Select =
        "SELECT * FROM Libros";

    public const string SelectbyId =
        "SELECT * FROM Libros WHERE IdLibro = @IdLibro";

    public const string Update =
        "UPDATE Libros SET Titulo = @Titulo, Autor = @Autor, ISBN = @ISBN WHERE IdLibro = @IdLibro";

    public const string Delete =
        "DELETE FROM Libros WHERE IdLibro = @IdLibro";
}
