using Botiga.COMMON;
using Botiga.Domain.Entities;
using Botiga.Domain.Validators;
using Botiga.DOMAIN.Entities;
using Botiga.DTO;
using Botiga.DTO.Compras;
using Botiga.Infraestructure.Mappers;
using Botiga.Model;
using Botiga.Repository;
using Botiga.Services;


namespace Botiga.EndPoints;

public static class EndpointsCompra
{
    public static void MapCompraEndpoints(this WebApplication app, DatabaseConnection dbConn)
    {

        // POST /compra/CompraRequest fet amb DTO
        app.MapPost("/compra", (CompraRequest req) =>
        {
            // Console.WriteLine(req);

            Compra compra = req.ToCompra();
            Result result = CompraValidator.Validate(compra);
            // LiniaProducte liniaProducte = req.ToProducte();
            if (!result.IsOk)
            {
                return Results.BadRequest(new 
                {
                    error = result.ErrorCode,
                    message = result.ErrorMessage
                });
            }

            Guid idCarroDeLaCompra = Guid.NewGuid();
            Guid idCarros = Guid.NewGuid();


            //FER BUCLE PER PODER RECORRE ELS PRODUCTES I ACONSEGUIR idProducte i Quantitat per despres poder fer l'INSERT
            List<LiniaProducte> productResponses = new List<LiniaProducte>();
            List<Product> productes = ProductADO.GetAll(dbConn);

            foreach (Product p in productes)
            {
                productResponses.Add(LiniaProducte.FromProduct(p));
            }





            //CarroDeLaCompraEntity carroDeLaCompraEntity = CarroDeLaCompraMapper.ToEntity(idCarroDeLaCompra, compra);

            CarrosEntity carrosEntity = CarrosMapper.ToEntity(idCarros, compra);

            CarrosADO.InsertCarrosEntity(dbConn, carrosEntity);





            //return Results.Ok(compra);
            return Results.Ok(carrosEntity); //per provar que surti idClient

        });
    }
}




//  {
//   "idClient": "BF3137AB-85DF-4DD8-942C-25F7286FDA41",
//   "Data": "2026-02-02",     
//   "Productes":[ {id:"7D90DA36-773D-45F0-8CDD-785631C79B09", quantitat: 3},
//                  { id: "AAF527F6-7AB2-408C-9A56-7DF8359155E2", quantitat: 1} ] 
//  }
 









