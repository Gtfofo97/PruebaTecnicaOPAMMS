using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class DetalleFactura
    {
        public int Id { get; set; }
        [ForeignKey("Factura")]
        public int IdFactura { get; set; }
        [ForeignKey("Producto")]
        public int IdProducto { get; set; }
        public decimal PrecioActualProducto { get; set; }
        public int CantidadProducto { get; set; }
        public int PorcentajeDescuento { get; set; }
        public decimal TotalDescuento { get; set; }
        public decimal SubTotal { get; set; }
        public Factura Factura { get; set; }
        public Auto Producto { get; set; }
    }
}
