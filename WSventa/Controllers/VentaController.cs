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
using Microsoft.EntityFrameworkCore;

namespace WSventa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();
            oRespuesta.Exito = 0;
            try
            {
                using (VentaRealContext db = new VentaRealContext())
                {
                    //var lst = db.Venta.OrderByDescending(d => d.Id).ToList();
                    //var lst = db.Conceptos.OrderByDescending(d => d.Id).ToList();

                    //var lst = db.Conceptos.Find((long)Id);

                    //var lst = db.Conceptos.Where(c => c.IdVenta == Id).ToList();

                    var lst = db.Venta.Include(c => c.Conceptos).OrderByDescending(v => v.Id).ToList();

                    oRespuesta.Exito = 1;
                    oRespuesta.Data = lst;
                    
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
