using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSventa.Models;
using WSventa.Models.Request;
using WSventa.Models.Response;
using WSventa.Services;

namespace WSventa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VentaController : ControllerBase
    {
        private IVentaService _venta;

        public VentaController(IVentaService venta)
        {
            this._venta = venta;
        }

        [HttpPost]
        public IActionResult Add(VentaRequest model)
        {
            Respuesta respuesta = new Respuesta();

            try
            {
                _venta.Add(model);
                respuesta.Exito = 1;

            }catch (Exception e)
            {
                respuesta.Mensaje = e.Message; 
            }

            return Ok(respuesta);
        }

    }
}
