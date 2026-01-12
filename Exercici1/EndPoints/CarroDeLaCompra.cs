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
            Product producte = ProductADO.GetById(dbConn, req.IdProduct)!;
            CarroDeLaCompra carroCompra = new CarroDeLaCompra
            {
                Id = Guid.NewGuid(),
                IdCarro = req.IdCarro,
                IdProduct = req.IdProduct,
                Preu = producte.Preu,
                Quantitat = req.Quantitat
            };

            CarroDeLaCompraADO.Insert(dbConn, carroCompra);
            return Results.Created($"/carrodelacompra/{carroCompra.Id}", carroCompra);
        });


        app.MapGet("/carrodelacompra/{id}/import", (Guid IdCarro) =>
        {
            List<CarroDeLaCompra> llista = CarroDeLaCompraADO.GetAllProductsCarro(dbConn, IdCarro)!;



            return Results.Ok(llista);    // ??????








            //return carroCompra is not null
            //    ? Results.Ok(carroCompra)
            //    : Results.NotFound(new { message = $"Carro de la compra amb Id {id} no trobat." });


        });
    }
}

public record CarroDeLaCompraRequest(Guid IdCarro, Guid IdProduct, int Quantitat);
