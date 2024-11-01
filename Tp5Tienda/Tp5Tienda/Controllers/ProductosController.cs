using Microsoft.AspNetCore.Mvc;
using Tp5Tienda.Models;
using Tp5Tienda.Repositorio;

namespace Tp5Tienda.Controllers
{
    public class ProductosController : Controller
    {

        private readonly ProductosRepositorio _productosRepo;

        public ProductosController(ProductosRepositorio productosRepositorio)
        {
            _productosRepo = productosRepositorio;
        }

        [HttpGet("ListarProd")]
        public ActionResult<List<Productos>> MostrarProductos()
        {
            var productos = _productosRepo.MostrarProductos();
            if (productos == null || productos.Count == 0)
            {
                return BadRequest("No hay productos");
            }
            return Ok(productos);
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost("Crear")]
        public ActionResult<string> CrearTablero(PostProducto nuevoProd)
        {

            if (nuevoProd != null)
            {
                var producto = _productosRepo.CrearProductos(nuevoProd);
                if (producto == null)
                {
                    return BadRequest("No se pudo Guardar en la Base de Datos");
                }
                return Ok("Se creo correctamente.");
            }
            else
            {
                return BadRequest("El Tablero recibido no es valido");
            }
        }
    }
}
