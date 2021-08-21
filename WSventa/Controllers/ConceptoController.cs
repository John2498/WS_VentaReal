using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSventa.Models;
using WSventa.Models.Response;
using Microsoft.EntityFrameworkCore;

namespace WSventa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConceptoController : ControllerBase
    {
        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (VentaRealContext db = new VentaRealContext())
                {
                    var oProdcuto = db.Conceptos.Where(c => c.IdVenta == Id).ToList();

                    oRespuesta.Exito = 1;
                    oRespuesta.Data = oProdcuto;
                }
            }
            catch (Exception e)
            {
                oRespuesta.Mensaje = e.Message;
            }

            return Ok(oRespuesta);
        }
    }
}
