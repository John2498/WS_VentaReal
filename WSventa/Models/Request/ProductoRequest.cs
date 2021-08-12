using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSventa.Models.Request
{
    public class ProductoRequest
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Costo { get; set; }
        public int Cantidad { get; set; }
        public decimal Importe { get; set; }
    }
}
