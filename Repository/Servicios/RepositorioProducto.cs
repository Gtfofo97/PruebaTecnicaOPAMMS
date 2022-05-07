using DataPersistence;
using Microsoft.EntityFrameworkCore;
using Model.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Servicios
{
    public class RepositorioAuto
    {
        private readonly FacturaContext db;
        public RepositorioAuto(FacturaContext context)
        {
            db = context;
        }
        public async Task<List<vmAuto>> ObtenerTodos()
        {
            return await db.vmAuto.FromSqlRaw("EXEC sp_GetAuto").ToListAsync();
        }
    }
}
