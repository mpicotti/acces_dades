using Botiga.Model;

namespace Botiga.DTO;

public record CarroDeLaCompraRequest(Guid IdCarro, Guid IdProduct, int Quantitat)
{
    public CarroDeLaCompra ToCarroDeLaCompra(Guid id)
    {
        return new CarroDeLaCompra
        {
            Id = id,
            IdCarro = IdCarro,
            IdProduct = IdProduct,
            Quantitat = Quantitat
        };
    }
}
