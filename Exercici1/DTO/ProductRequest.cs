using Botiga.Model;

namespace Botiga.DTO;

public record ProductRequest(string Nom, string Descripcio, decimal Preu, decimal Descompte, Guid IdFamilia)
{
    // Converteix un ProductRequest al model Product
    public Product ToProduct(Guid id)
    {
        return new Product
        {
            Id = id,
            Nom = Nom,
            Descripcio = Descripcio,
            Preu = Preu,
            Descompte = Descompte,
            IdFamilia = IdFamilia
        };
    }
}
