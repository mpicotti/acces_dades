using Botiga.Domain.Entities;
using Botiga.DOMAIN.Entities;
using Botiga.Model;

namespace Botiga.Infraestructure.Mappers;

public static class CarrosMapper
{
    public static CarrosEntity ToEntity(Guid idCarros, Compra compra)
        => new CarrosEntity
        {
            Id = idCarros,
            Nom = compra.client.nom,
            data = compra.data,
            idClient = Guid.Parse(compra.client.codi)
        };
  
}