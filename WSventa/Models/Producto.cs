using System;
using System.Collections.Generic;

#nullable disable

namespace WSventa.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Conceptos = new HashSet<Concepto>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal? PrecioUnitario { get; set; }
        public decimal? Costo { get; set; }
        public int? Cantidad { get; set; }
        public decimal? Importe { get; set; }

        public virtual ICollection<Concepto> Conceptos { get; set; }
    }
}
