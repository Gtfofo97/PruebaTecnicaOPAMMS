namespace Model.ViewModels
{
    public class vmDetalleVenta
    {
        public int txtIdProducto { get; set; }
        public string txtNombreProducto { get; set; }
        public decimal txtPrecioProducto { get; set; }
        public int txtCantidad { get; set; }
        public int txtPorcentaje { get; set; }
        public decimal txtTotalDescuento { get; set; }
        public decimal txtSubTotal { get; set; }
    }
}
