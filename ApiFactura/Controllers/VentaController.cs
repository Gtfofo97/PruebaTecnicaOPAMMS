using Microsoft.AspNetCore.Mvc;
namespace ApiFactura.Controllers
{
    public class VentaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
