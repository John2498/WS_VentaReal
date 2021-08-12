using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

using WSventa.Models;
using WSventa.Models.Response;
using WSventa.Models.Request;

namespace WSventa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();
            oRespuesta.Exito = 0;
            try { 
                using(VentaRealContext db = new VentaRealContext()){
                    var lst = db.Clientes.OrderByDescending(d => d.Id).ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = lst;
                }   
            }catch (Exception e)
            {
                oRespuesta.Mensaje = e.Message; ;
            }
            return Ok(oRespuesta);
        }

        [HttpPost]
        public IActionResult Add(ClienteRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using(VentaRealContext db = new VentaRealContext())
                {
                    Cliente oCliente = new Cliente();
                    oCliente.Nombre = oModel.Nombre;
                    oCliente.Cedula = oModel.Cedula;
                    oCliente.Edad = oModel.Edad;
                    oCliente.Telefono = oModel.Telefono;
                    oCliente.Direccion = oModel.Direccion;
                    oCliente.Email = oModel.Email;
                    db.Clientes.Add(oCliente);
                    db.SaveChanges(); 
                    oRespuesta.Exito = 1;
                }
            }catch (Exception e)
            {
                oRespuesta.Mensaje = e.Message;
            }

            return Ok(oRespuesta);
        }

        [HttpPut]
        public IActionResult Edit(ClienteRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (VentaRealContext db = new VentaRealContext())
                {
                    Cliente oCliente = db.Clientes.Find(oModel.Id);
                    oCliente.Nombre = oModel.Nombre;
                    oCliente.Cedula = oModel.Cedula;
                    oCliente.Edad = oModel.Edad;
                    oCliente.Telefono = oModel.Telefono;
                    oCliente.Direccion = oModel.Direccion;
                    oCliente.Email = oModel.Email;
                    db.Entry(oCliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    Cliente oCliente = db.Clientes.Find(Id);
                    db.Remove(oCliente);
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
    }
}
