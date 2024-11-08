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
        public ActionResult<string> CrearProducto(PostProducto nuevoProd)
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
                return BadRequest("El Producto recibido no es valido");
            }
        } 

        [HttpPut("Modificar{Id}")]
        public ActionResult<string> ModificarTablero(int idProducto, PostProducto nuevoProd)
        {

            if (nuevoProd != null)
            {
                var producto = _productosRepo.ModificarProductos(idProducto, nuevoProd);
                if (producto == null)
                {
                    return BadRequest("No se pudo Guardar en la Base de Datos");
                }
                return Ok(producto.ToString());
            }
            else
            {
                return BadRequest("El Producto recibido no es valido");
            }
        }

        [HttpDelete("Eliminar{Id}")]
        public ActionResult<string> EliminarProducto(int Id)
        {
            var resultado = _productosRepo.EliminarProducto(Id);
            if (resultado)
            {
                return Ok("Producto eliminado correctamente");
            }
            else
            {
                return BadRequest("No se pudo eliminar el producto de la Base de Datos");
            }
        }

    }
}
