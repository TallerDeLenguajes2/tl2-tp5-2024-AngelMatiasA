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
            if (presupuesto == null)
            {
                return BadRequest("No hay presupuesto");
            }
            return Ok(presupuesto);
        }

       /* [HttpGet("ListarPresup")]
        public ActionResult<List<Presupuestos>> ListarPresupues()
        {
            var presupuesto = _presupuestoRepo.MostrarPresupuestosConMontos();
            if (presupuesto == null)
            {
                return BadRequest("No hay presupuesto");
            }
            return Ok(presupuesto);
        }*/

        [HttpGet("ListarPresupuestoConDetalle")]
        public ActionResult<List<PresupuestoViewModel>> ListarPresupuestosConDetalle()
        {
            List<PresupuestoViewModel> presupuestosVM = new List<PresupuestoViewModel>();
            var presupuestos = _presupuestoRepo.MostrarPresupuestosConMontos();

            foreach (var presupuest in presupuestos)
            {
                PresupuestoViewModel presupuestoVM = new PresupuestoViewModel
                {
                    IdPresupuesto = presupuest.IdPresupuesto,
                    NombreDestinatario = presupuest.NombreDestinatario,
                    FechaCreacion = presupuest.FechaCreacion,
                    SubTotal = presupuest.MontoPresupuesto(),
                    Total = presupuest.MontoPresupuestoConIva()


                };
                presupuestoVM.Detalles = new List<PresupuestoDetalle>();
                foreach (var detail in presupuest.Detalle)
                {
                    presupuestoVM.Detalles.Add(detail);
                        

                };
                presupuestosVM.Add(presupuestoVM);
                
            }

            if (presupuestos == null)
            {
                return BadRequest("No hay presupuesto");
            }
            return Ok(presupuestosVM);
        }

        [HttpPost("Crear")]
        public ActionResult<string> CrearPresupuesto(Presupuestos nuevoPresup)
        {

            if (nuevoPresup != null)
            {
                var producto = _presupuestoRepo.CrearPresupuesto(nuevoPresup);
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

        [HttpPost("AgregarDetalle")]
        public ActionResult<string> AgregarDetalle(PresupuestoDetalle nuevoDetalle, int idPresupuesto)
        {

            if (nuevoDetalle != null)
            {
                var producto = _presupuestoRepo.AgregarDetalle(nuevoDetalle, idPresupuesto);
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

        [HttpGet("ObtenerPresupuesto/{Id}")]
        public ActionResult<List<Presupuestos>> ObtenerPresupuesto(int idPres)
        {
            var presupuesto = _presupuestoRepo.ObtenerPresupuestoPorId( idPres);
            if (presupuesto == null)
            {
                return BadRequest("No se encontro el presupuesto");
            }
            return Ok(presupuesto);
        }



    }
}
