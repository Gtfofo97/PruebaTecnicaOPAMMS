using ApiFactura.Model;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.ViewModels;
using Newtonsoft.Json;
using Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiFactura.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaControllerAPIController : ControllerBase
    {
        private readonly UnitOfWork unitOfWork;
        public VentaControllerAPIController(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        [HttpPost]
        //[Route("GuardarVenta")]
        public async Task<ApiResult> GuardarVenta(vmVenta venta)
        {
            using(var transaction = await unitOfWork.Transaccion())
            {
                try
                {
                    var lista = JsonConvert.DeserializeObject<List<vmDetalleVenta>>(venta.lstSerializadaDetalleVenta);
                    var facturaNueva = new Factura { NombreCliente = venta.NombreCliente };
                    await unitOfWork.RepositorioFactura.Insertar(facturaNueva);
                    int result = await unitOfWork.SaveChangeAsync();
                    decimal totalDescuento = 0, total = 0, subTotal = 0;
                    foreach (var detalle in lista)
                    {
                        var detalleFacturaNueva = new DetalleFactura
                        {
                            IdFactura = facturaNueva.Id,
                            IdProducto = detalle.txtIdProducto,
                            PrecioActualProducto = detalle.txtPrecioProducto,
                            CantidadProducto = detalle.txtCantidad,
                            PorcentajeDescuento = detalle.txtPorcentaje,
                            TotalDescuento = detalle.txtTotalDescuento,
                            SubTotal = detalle.txtSubTotal
                        };
                        await unitOfWork.RepositorioDetalleFactura.Insertar(detalleFacturaNueva);
                        result += await unitOfWork.SaveChangeAsync();
                        totalDescuento += detalle.txtTotalDescuento;
                        total += (detalle.txtPrecioProducto * detalle.txtCantidad);
                        subTotal += detalle.txtSubTotal;
                    }
                    facturaNueva.TotalDescuento = totalDescuento;
                    facturaNueva.Total = total;
                    facturaNueva.SubTotal = subTotal;
                    unitOfWork.RepositorioFactura.Actualizar(facturaNueva);
                    result += await unitOfWork.SaveChangeAsync();
                    transaction.Commit();
                    return new ApiResult(result);
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return new ApiResult(0, "Ocurrio un error al guardar");
                }
            }
        }
    }
}
