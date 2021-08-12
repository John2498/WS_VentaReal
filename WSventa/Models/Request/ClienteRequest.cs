using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSventa.Models.Request
{
    public class ClienteRequest
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public int? Edad { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
    }
}
