using Botiga.Model;

namespace Botiga.DTO;

public record CarrosRequest(string Nom)
{
    public Carros ToCarros(Guid id)
    {
        return new Carros
        {
            Id = id,
            Nom = Nom
        };
    }
}
