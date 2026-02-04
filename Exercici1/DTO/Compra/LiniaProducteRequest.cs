using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Botiga.Domain.Entities;

namespace Botiga.DTO.Compras;

public record LiniaProducteRequest(Guid IdProducte, int Quantitat)
{
   public LiniaProducte ToEntity()
   {
       return new LiniaProducte(IdProducte, Quantitat);
   }
}