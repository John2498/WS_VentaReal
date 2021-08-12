using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSventa.Models.Request;

namespace WSventa.Services
{
    public interface IVentaService
    {
        public void Add(VentaRequest model);
    }
}
