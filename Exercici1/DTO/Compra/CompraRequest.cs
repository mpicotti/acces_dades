using Botiga.Domain.Entities;

namespace Botiga.DTO.Compras;

public record CompraRequest(Guid IdClient, List<LiniaProducteRequest> Productes)
{
    public Compra ToCompra()
    {
        
        Client client = new Client();
        client.codi =  IdClient.ToString();
        
        Compra compraDomain = new Compra();
        compraDomain.client = client;
        
        return  compraDomain;
    }
}
