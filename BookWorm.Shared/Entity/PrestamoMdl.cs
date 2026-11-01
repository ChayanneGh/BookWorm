namespace BookWorm.Shared.Entity;

public record PrestamoMdl(
    int IdPrestamo,
    int IdEstudiante,
    int IdLibro,
    string FechaPrestamo,
    string FechaVencimiento
    );
