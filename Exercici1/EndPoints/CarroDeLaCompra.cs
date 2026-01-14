using Botiga.Classes;
using Botiga.Descomptes;
using Botiga.Model;
using Botiga.Repository;
using Botiga.Services;

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

        // Tots els productes del carro
        app.MapGet("/carrodelacompra/{id}/import", (Guid id, string tipusClient) =>
        {
            List<CarroDeLaCompra> llista = CarroDeLaCompraADO.GetAllProductsCarro(dbConn, id)!;


            //Calcular import quantitat * preu
            decimal import = CalculsCarroDeLaCompra.CalcularImport(llista);

            //Calcular descompte //crear descompte per determinar
            IDescompteFactory dteFactory = tipusClient switch
            {
                "Estandard" => new DescompteEstandardFactory(),
                "Premium" => new DescomptePremiumFactory(),
                _ => throw new ArgumentException("Tipus de client desconegut.")
            };

            IDescompte descompte = dteFactory.CreateDescompte();
            
            decimal dte = descompte.CalcularDte(import);

            decimal importFinal = import - dte;
            
            //Retornar import, Descompte, Import amb descompte

            //return Results.Ok(importFinal);
            return Results.Ok(new
            {
                Import = import,
                Descompte = dte,
                ImportFinal = importFinal
            });

        });
    }
}

public record CarroDeLaCompraRequest(Guid IdCarro, Guid IdProduct, int Quantitat);
