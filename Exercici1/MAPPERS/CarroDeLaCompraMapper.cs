using Botiga.Domain.Entities;
using Botiga.DOMAIN.Entities;
using Botiga.Model;

namespace Botiga.Infraestructure.Mappers;

public static class CarroDeLaCompraMapper
{
    public static CarroDeLaCompraEntity ToEntity(Guid idCarroDeLaCompra,Guid idCarro, LiniaProducte liniaProducte, Preus preu)
        => new CarroDeLaCompraEntity
        {
            Id = idCarroDeLaCompra,
            IdCarro = idCarro,
            IdProduct = Guid.Parse(liniaProducte.producte.Codi),
            Quantitat = liniaProducte.Quantitat,
            Preu = preu.Preu
           
        };
}

