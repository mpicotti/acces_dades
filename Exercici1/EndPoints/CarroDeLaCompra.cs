using Botiga.Repository;
using Botiga.Services;
using Botiga.Model;

namespace Botiga.EndPoints;

public static class EndpointsCarroDeLaCompra
{
    public static void MapCarroDeLaCompraEndpoints(this WebApplication app, DatabaseConnection dbConn)
    {
        // GET /carrodelacompra
        app.MapGet("/carrodelacompra", () =>
        {
            List<CarroDeLaCompra> llista = CarroDeLaCompraADO.GetAll(dbConn);
            return Results.Ok(llista);
        }); 

        // GET /carrodelacompra/{id}
        app.MapGet("/carrodelacompra/{id}", (Guid id) =>
        {
            CarroDeLaCompra carroCompra = CarroDeLaCompraADO.GetById(dbConn, id)!;

            return carroCompra is not null
                ? Results.Ok(carroCompra)
                : Results.NotFound(new { message = $"Carro de la compra amb Id {id} no trobat." });
        });

        // POST /carrodelacompra
        app.MapPost("/carrodelacompra", (CarroDeLaCompraRequest req) =>
        {
            CarroDeLaCompra carroCompra = new CarroDeLaCompra
            {
                Id = Guid.NewGuid(),
                IdCarro = req.IdCarro,
                IdProduct = req.IdProduct,
                Quantitat = req.Quantitat
            };

            CarroDeLaCompraADO.Insert(dbConn, carroCompra);
            return Results.Created($"/carrodelacompra/{carroCompra.Id}", carroCompra);
        });
    }
}

public record CarroDeLaCompraRequest(Guid IdCarro, Guid IdProduct, int Quantitat);
