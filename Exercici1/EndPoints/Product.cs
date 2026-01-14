using Botiga.Repository;
using Botiga.Services;
using Botiga.Model;
using Botiga.DTO;

namespace Botiga.EndPoints;

public static class EndpointsProduct
{
    public static void MapProductEndpoints(this WebApplication app, DatabaseConnection dbConn)
    {
        // GET /product
        app.MapGet("/product", () =>
        {
            List<ProductResponse> productResponses = new List<ProductResponse>();
            List<Product> productes = ProductADO.GetAll(dbConn);

            foreach (Product p in productes )
            {
                productResponses.Add(ProductResponse.FromProduct(p)); //FromProduct a partir del DTO i amb al bucle anar posant a cada producte
            }

            return Results.Ok(productResponses);
        });

        // GET /product/{id}
        app.MapGet("/product/{id}", (Guid id) =>
        {
            Product producte = ProductADO.GetById(dbConn, id)!;

            return producte is not null
                ? Results.Ok(ProductResponse.FromProduct(producte)) //FromProduct a partir del DTO
                : Results.NotFound(new { message = $"Producte amb Id {id} no trobat." });
        });

        // POST /product
        app.MapPost("/product", (ProductRequest req) =>
        {

            Guid id = Guid.NewGuid();
            Product producte = req.ToProduct(id);

            ProductADO.Insert(dbConn, producte);
            return Results.Created($"/product/{producte.Id}", producte);

        });
    }
}

