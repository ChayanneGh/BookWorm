namespace BookWorm.Shared.Entity;

public record DevolucionMdl(
    int IdDevolucion,
    int IdPrestamo,
    string FechaDevolucion,
    string Observaciones
    );
