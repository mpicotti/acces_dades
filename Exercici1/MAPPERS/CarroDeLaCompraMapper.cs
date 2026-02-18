using Botiga.Domain.Entities;
using Botiga.DOMAIN.Entities;
using Botiga.Model;

namespace Botiga.Infraestructure.Mappers;

public static class CarroDeLaCompraMapper
{
    public static CarroDeLaCompraEntity ToEntity(Guid idCarroDeLaCompra,Guid idCarro, Compra compra)
        => new CarroDeLaCompraEntity
        {
            Id = idCarroDeLaCompra,
            IdCarro = idCarro,
            IdProduct = compra.Productes,
            Quantitat = product.Price
            Preu = product.Price
        };
}



//public Guid Id { get; set; }
//public Guid IdCarro { get; set; }
//public Guid IdProduct { get; set; }
//public int Quantitat { get; set; }
//public decimal Preu { get; set; }