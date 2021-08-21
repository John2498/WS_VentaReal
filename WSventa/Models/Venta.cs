using System;
using System.Collections.Generic;

#nullable disable

namespace WSventa.Models
{
    public partial class Venta
    {
        public Venta()
        {
            Conceptos = new HashSet<Concepto>();
            Conceptos = new List<Concepto>();
        }

        public long Id { get; set; }
        public int IdCliente { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public int? IdUsuario { get; set; }
        public decimal? Subtotal { get; set; }
        public string Estado { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual ICollection<Concepto> Conceptos { get; set; }
    }
}
