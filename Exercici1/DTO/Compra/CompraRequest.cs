using Botiga.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Botiga.Domain.Entities;

namespace Botiga.DTO.Compra
{
    public record CompraRequest(Guid IdClient, List<LiniaProducteRequest> Productes)
    {
        public Compra ToCompra()
        {
            return new Compra(IdClient, Productes);
        }
    }
}   