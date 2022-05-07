using DataPersistence;
using Model;
using System.Threading.Tasks;

namespace Repository.Servicios
{
    public class RepositorioDetalleFactura
    {
        private readonly FacturaContext db;
        public RepositorioDetalleFactura(FacturaContext context)
        {
            db = context;
        }
        public async Task Insertar(DetalleFactura model)
        {
            await db.DetalleFactura.AddAsync(model);
        }
    }
}
