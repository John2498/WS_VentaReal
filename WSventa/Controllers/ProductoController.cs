using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WSventa.Models;
using WSventa.Models.Response;
using WSventa.Models.Request;

namespace WSventa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();
            oRespuesta.Exito = 0;
            try
            {
                using (VentaRealContext db = new VentaRealContext())
                {
                    var lst = db.Productos.OrderByDescending(d => d.Id).ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = lst;
                }
            }
            catch (Exception e)
            {
                oRespuesta.Mensaje = e.Message; ;
            }
            return Ok(oRespuesta);
        }

        [HttpPost]
        public IActionResult Add(ProductoRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                using (VentaRealContext db = new VentaRealContext())
                {
                    Producto oProducto = new Producto();

                    oProducto.Id = oModel.Id;
                    oProducto.Nombre = oModel.Nombre;
                    oProducto.PrecioUnitario = oModel.PrecioUnitario;
                    oProducto.Costo = oModel.Costo;
                    oProducto.Cantidad = oModel.Cantidad;
                    oProducto.Importe = oModel.Importe;
                    db.Productos.Add(oProducto);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception e)
            {
                oRespuesta.Mensaje = e.Message;
            }

            return Ok(oRespuesta);
        }

        [HttpPut]
        public IActionResult Edit(ProductoRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (VentaRealContext db = new VentaRealContext())
                {
                    Producto oProducto = db.Productos.Find(oModel.Id);

                    oProducto.Nombre = oModel.Nombre;
                    oProducto.PrecioUnitario = oModel.PrecioUnitario;
                    oProducto.Costo = oModel.Costo;
                    oProducto.Cantidad = oModel.Cantidad;
                    oProducto.Importe = oModel.Importe;
                    db.Entry(oProducto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception e)
            {
                oRespuesta.Mensaje = e.Message;
            }

            return Ok(oRespuesta);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (VentaRealContext db = new VentaRealContext())
                {
                    Producto oProdcuto = db.Productos.Find(Id);
                    db.Remove(oProdcuto);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception e)
            {
                oRespuesta.Mensaje = e.Message;
            }

            return Ok(oRespuesta);
        }

        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (VentaRealContext db = new VentaRealContext())
                {
                    var oProdcuto = db.Productos.Find(Id);

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
