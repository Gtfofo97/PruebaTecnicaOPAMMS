using DataPersistence;
using Repository.Servicios;
using System.Threading.Tasks;

namespace Repository
{
    public class UnitOfWork
    {
        private readonly FacturaContext db;
        public UnitOfWork(FacturaContext context)
        {
            db = context;
        }

        public async Task<Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction> Transaccion()
        {
            return await db.Database.BeginTransactionAsync();
        }
        public async Task<int> SaveChangeAsync()
        {
            return await db.SaveChangesAsync();
        }
        public RepositorioAuto RepositorioAuto
        {
            get
            {
                return new RepositorioAuto(db);
            }
        }
        public RepositorioDetalleFactura RepositorioDetalleFactura
        {
            get
            {
                return new RepositorioDetalleFactura(db);
            }
        }
        public RepositorioFactura RepositorioFactura
        {
            get
            {
                return new RepositorioFactura(db);
            }
        }
    }
}
