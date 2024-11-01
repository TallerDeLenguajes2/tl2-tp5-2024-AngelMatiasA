using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tp5Tienda.Models;
using Tp5Tienda.Repositorio;

namespace Tp5Tienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresupuestosController : ControllerBase
    {

        private readonly PresupuestosRepository _presupuestoRepo;

        public PresupuestosController(PresupuestosRepository presupuestoRepositorio)
        {
            _presupuestoRepo = presupuestoRepositorio;
        }

        [HttpGet("ListarPresupuestos")]
        public ActionResult<List<Presupuestos>> ListarPresupuestos()
        {
            var presupuesto = _presupuestoRepo.MostrarPresupuestos();
            if (presupuesto == null )
            {
                return BadRequest("No hay presupuesto");
            }
            return Ok(presupuesto);
        }
    }
}
