using Botiga.Domain.Entities;
using Botiga.COMMON;

namespace Botiga.Domain.Validators;

public static class ClientValidator
{
     public static Result Validate(Compra compra)
    {
        if (compra.client == null)
            return Result.Failure("El client no pot ser null", "CLIENT_NULL");

        if (string.IsNullOrEmpty(compra.client.codi))
            return Result.Failure("El codi del client és obligatori", "CLIENT_CODI_INVALID");

        return Result.Ok();
    }
}