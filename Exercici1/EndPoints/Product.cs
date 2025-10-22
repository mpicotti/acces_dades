using Botiga.Repository;
using Botiga.Services;
using Botiga.Model;

namespace Botiga.EndPoints;

public static class EndpointsProduct
{
    public static void MapProductEndpoints(this WebApplication app, DatabaseConnection dbConn)
    {
        // GET /product
        app.MapGet("/product", () =>
        {
            List<Product> productes = ProductADO.GetAll(dbConn);
            return Results.Ok(productes);
        });

        // GET /product/{id}
        app.MapGet("/product/{id}", (Guid id) =>
        {
            Product producte = ProductADO.GetById(dbConn, id)!;

            return producte is not null
                ? Results.Ok(producte)
                : Results.NotFound(new { message = $"Producte amb Id {id} no trobat." });
        });

        // POST /product
        app.MapPost("/product", (ProductRequest req) =>
        {
            Product producte = new Product
            {
                Id = Guid.NewGuid(),
                Nom = req.Nom,
                Descripcio = req.Descripcio,
                Preu = req.Preu,
                Descompte = req.Descompte,
                IdFamilia = req.IdFamilia
            };

            ProductADO.Insert(dbConn, producte);
            return Results.Created($"/product/{producte.Id}", producte);
        });
    }
}

public record ProductRequest(string Nom, string Descripcio, decimal Preu, int Descompte, Guid IdFamilia);
