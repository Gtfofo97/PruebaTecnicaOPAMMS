using System;

namespace Model
{
    public class Factura
    {
        public int Id { get; set; }
        public string NombreCliente { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public decimal Total { get; set; } = 0;
        public decimal TotalDescuento { get; set; } = 0;
        public decimal SubTotal { get; set; } = 0;
    }
}
