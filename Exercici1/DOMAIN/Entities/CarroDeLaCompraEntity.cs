using Botiga.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botiga.DOMAIN.Entities
{
    public class CarroDeLaCompraEntity
    {
        public Guid Id { get; set; }
        public Guid IdCarro { get; set; }
        public Guid IdProduct { get; set; }
        public int Quantitat { get; set; }
        public decimal Preu { get; set; }
    }
}
