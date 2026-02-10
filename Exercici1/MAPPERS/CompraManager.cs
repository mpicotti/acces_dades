using Botiga.Domain.Entities;
using Botiga.Model;

namespace Botiga.Infraestructure.Mappers;

public static class CompraMapper
{
    public static Compra ToDomain(CarroDeLaCompra entity)
        => new Compra(
            entity.Id,
            entity.Code,
            entity.Name,
            entity.Price
        );

    public static Carros ToEntity(Product product, string? imagePath = null)
        => new CarroDeLaCompra
        {
            Id = product.Id,
            Code = product.Code,
            Name = product.Name,
            Price = product.Price,
        };
}

