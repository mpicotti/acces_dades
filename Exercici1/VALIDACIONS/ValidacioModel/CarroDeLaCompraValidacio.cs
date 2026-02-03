using Botiga.COMMON;
using Botiga.Model;
using System;
using System.Collections.Generic;

namespace Botiga.VALIDACIONS.ValidacioModel
{
    public static class CarroDeLaCompraValidacio
    {
        public static Result Validate(CarroDeLaCompra req)
        {
            if (req.IdCarro == Guid.Empty)
                return Result.Failure("L'ID del carro és obligatori", "IDCARRO_INVALID");

            if (req.IdProduct == Guid.Empty)
                return Result.Failure("L'ID del producte és obligatori", "IDPRODUCT_INVALID");

            if (req.Quantitat <= 0)
                return Result.Failure("La quantitat ha de ser major que 0", "QUANTITAT_INVALID");

            return Result.Ok();
        }

    }
}
