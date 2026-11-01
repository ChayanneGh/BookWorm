namespace BookWorm.Shared.Entity;

public record LibroMdl(
    int IdLibro,
    string Titulo,
    string Autor,
    string ISBN,
    int CantidadTotal
    );
