using System;
using System.Collections.Generic;

#nullable disable

namespace WSventa.Models
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string UsuarioNombre { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string Tipo { get; set; }
    }
}
