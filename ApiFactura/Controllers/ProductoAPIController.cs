using ApiFactura.Model;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System.Threading.Tasks;

namespace ApiFactura.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoAPIController : ControllerBase
    {
        private readonly UnitOfWork unitOfWork;
        public ProductoAPIController(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        [HttpGet]
        public async Task<ApiResult> GetAll()
        {
            try
            {
                return new ApiResult(await unitOfWork.RepositorioAuto.ObtenerTodos());
            }
            catch (System.Exception)
            {
                return new ApiResult(null, "Ócurrio un error al obtener la lista de productos");
            }
        }
    }
}
