using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSventa.Models;
using WSventa.Models.Request;

namespace WSventa.Services
{
    public class VentaService : IVentaService
    {
        public void Add(VentaRequest model)
        {
                using (VentaRealContext db = new VentaRealContext())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            var venta = new Venta();

                            venta.Total = model.Conceptos.Sum(d => (d.Cantidad * d.PrecioUnitario) + d.Importe);
                            venta.Fecha = DateTime.Now;
                            venta.IdCliente = model.IdCliente;
                            venta.IdUsuario = model.IdUsuario;
                            venta.Subtotal = model.Conceptos.Sum(d => d.Cantidad * d.PrecioUnitario);
                            venta.Estado = model.Estado;
                            
                            db.Venta.Add(venta);
                            db.SaveChanges();

                            foreach (var modelConcepto in model.Conceptos)
                            {
                                var concepto = new Models.Concepto();
                                concepto.Cantidad = modelConcepto.Cantidad;
                                concepto.IdProducto = modelConcepto.IdProducto;
                                concepto.PrecioUnitario = modelConcepto.PrecioUnitario;
                                concepto.Importe = modelConcepto.Importe;
                                concepto.IdVenta = venta.Id;
                                db.Conceptos.Add(concepto);
                                db.SaveChanges();
                            }
                            transaction.Commit();
                        }
                        catch (Exception e)
                        {
                            transaction.Rollback();
                            throw new Exception("Ocurrio un error en la insercion");
                        }
                    }
                }
        }
    }
}
