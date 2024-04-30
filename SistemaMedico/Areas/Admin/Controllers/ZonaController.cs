using Microsoft.AspNetCore.Mvc;
using SistemaMedico.Modelos;
using SistemaMedido.AccesoDatos.Repositorio.IRepositorio;

namespace SistemaMedico.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ZonaController : Controller
    {
        private readonly IUnidadTrabajo _unidadTrabajo;
        public ZonaController(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }
        public IActionResult Index()
        {
            return View();
        }

        // Método Upsert GET
        public async Task<IActionResult> Upsert(int? id)
        {
            Area zona = new Area();
            if (id == null)
            {
                //creamos un nuevo registro
                return View(zona);
            }

            zona = await _unidadTrabajo.Area.Obtener(id.GetValueOrDefault());
            if (zona == null)
            {
                return NotFound();
            }
            return View(zona);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Area zona)
        {
            if (ModelState.IsValid)
            {
                if (zona.Id == 0)
                {
                    await _unidadTrabajo.Area.Agregar(zona);
                }
                else
                {
                    _unidadTrabajo.Area.Actualizar(zona);
                }
                await _unidadTrabajo.Guardar();
                return RedirectToAction(nameof(Index));
            }
            return View(zona);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var areaDB = await _unidadTrabajo.Area.Obtener(id);
            if (areaDB == null)
            {
                return Json(new { success = false, message = "Error al borrar el registro en la base de datos" });
            }
            _unidadTrabajo.Area.Remover(areaDB);
            await _unidadTrabajo.Guardar();
            return Json(new { success = true, message = "Area eliminada con exito" });
        }

        // Región API
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var todos = await _unidadTrabajo.Area.ObtenerTodos();
            return Json(new { data = todos });
        }

        [ActionName("ValidarNombre")]
        public async Task<IActionResult> ValidarNombre(string turno, int id = 0)
        {
            bool valor = false;
            var lista = await _unidadTrabajo.Area.ObtenerTodos();

            if (id == 0)
            {
                valor = lista.Any(b => b.Turno.ToLower().Trim() == turno.ToLower().Trim());
            }
            else
            {
                valor = lista.Any(b => b.Turno.ToLower().Trim()
                                    == turno.ToLower().Trim()
                                    && b.Id != id);
            }
            if (valor)
            {
                return Json(new { data = true });
            }
            return Json(new { data = false });
        }
        // End Región
    }
}