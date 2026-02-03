using Botiga.DTO.Compra;

namespace Botiga.Domain.Entities;

public class Compra
{
    public Guid Id { get; set; }
    public Guid IdClient { get; set; }
    public List<LiniaProducteRequest> Productes { get; set; }

    public Compra(Guid idClient, List<LiniaProducteRequest> productes)
    {
        Id = Guid.NewGuid();
        IdClient = idClient;
        Productes = productes;
    }
}
