using Botiga.Domain.Entities;
using Botiga.COMMON;

namespace Botiga.Domain.Validators;

public static class ProducteValidator
{
     public static Result Validate(Compra compra)
    {
        foreach (var linia in compra.Productes)
        {
            if (linia.Quantitat <= 0)
                return Result.Failure("La quantitat ha de ser superior a 0", "QUANTITAT_INVALIDA");

            if (linia.producte == null)
                return Result.Failure("El producte no pot ser null", "PRODUCTE_NULL");
        }

        return Result.Ok();
    }
}