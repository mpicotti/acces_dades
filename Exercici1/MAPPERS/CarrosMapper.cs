using Botiga.Domain.Entities;
using Botiga.DOMAIN.Entities;
using Botiga.Model;

namespace Botiga.Infraestructure.Mappers;

public static class CarrosMapper
{
    public static CarrosEntity ToEntity(Guid idCarro, Compra compra)
        => new CarrosEntity
        {
            Id = idCarro,
            Nom = idCarro.ToString(),
            data = compra.data,
            idClient = Guid.Parse(compra.client.codi)
        };
  
}