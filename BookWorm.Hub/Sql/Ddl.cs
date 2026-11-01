namespace BookWorm.Hub.Sql;

public class Ddl
{
    private const string CreateEstudianteTable = @"
        CREATE TABLE Estudiante (
            IdEstudiante INT PRIMARY KEY,
            Nombre NVARCHAR(100),
            Apellido NVARCHAR(100),
            Matricula NVARCHAR(50),
            Cedula NVARCHAR(20)
        );";

    private const string CreateLibroTable = @"
        CREATE TABLE Libro (
            IdLibro INT PRIMARY KEY,
            Titulo NVARCHAR(100),
            Autor NVARCHAR(100),
            ISBN NVARCHAR(20)
        );";

    private const string CreatePrestamoTable = @"
        CREATE TABLE Prestamo (
            IdPrestamo INT PRIMARY KEY,
            IdEstudiante INT,
            IdLibro INT,
            FechaPrestamo DATETIME,
            FechaVencimiento DATETIME,
            FOREIGN KEY (IdEstudiante) REFERENCES Estudiante(IdEstudiante),
            FOREIGN KEY (IdLibro) REFERENCES Libro(IdLibro)
        );";

    private const string CreateDevolucionTable = @"
        CREATE TABLE Devolucion (
            IdDevolucion INT PRIMARY KEY,
            IdPrestamo INT,
            FechaDevolucion DATETIME,
            Observaciones NVARCHAR(255),
            FOREIGN KEY (IdPrestamo) REFERENCES Prestamo(IdPrestamo)
        );";

    private static readonly string[] ConcatStrings =
    {
        CreateDevolucionTable,
        CreateEstudianteTable,
        CreateLibroTable,
        CreatePrestamoTable
    };
    public static readonly string TablesCreate = string.Join("\n", ConcatStrings);
}
