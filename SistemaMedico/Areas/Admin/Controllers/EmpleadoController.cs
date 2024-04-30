using Microsoft.AspNetCore.Mvc;
using SistemaMedido.AccesoDatos.Repositorio.IRepositorio;
using SistemaMedico.Modelos;
using SistemaMedico.Modelos.ViewModels;
using SistemaMedico.Utilidades;

namespace SistemaMedico.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmpleadoController : Controller
    {
        private readonly IUnidadTrabajo _unidadTrabajo;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public EmpleadoController(IUnidadTrabajo unidadTrabajo, IWebHostEnvironment webHostEnvironment)
        {
            _unidadTrabajo = unidadTrabajo;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Método Upsert GET
        public async Task<IActionResult> Upsert(int? id)
        {
            EmpleadoVM empleadoVM = new EmpleadoVM()
            {
                Empleado = new Empleado(),
                AreaLista = _unidadTrabajo.Empleado.ObtenerTodosDropDownList("Area"),
                PuestoLista = _unidadTrabajo.Empleado.ObtenerTodosDropDownList("Puesto")
            };

            if (id == null)
            {
                return View(empleadoVM);
            }
            else
            {
                empleadoVM.Empleado = await _unidadTrabajo.Empleado
                    .Obtener(id.GetValueOrDefault());
                if (empleadoVM.Empleado == null)
                {
                    return NotFound();
                }
                return View(empleadoVM);
            }
        }

        // Región API
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(EmpleadoVM empleadoVM)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                string webRootPath = _webHostEnvironment.WebRootPath;

                if (empleadoVM.Empleado.Id == 0)
                {
                    await _unidadTrabajo.Empleado.Agregar(empleadoVM.Empleado);
                }
                else
                {
                    //Actualizar el empleado
                    var objEmp = await _unidadTrabajo.Empleado
                                     .ObtenerPrimero(p => p.Id == empleadoVM.Empleado.Id
                                      , isTracking: false);
                    _unidadTrabajo.Empleado.Actualizar(empleadoVM.Empleado);
                }
                TempData[DS.Exitosa] = "Empleado Registrado";
                await _unidadTrabajo.Guardar();
                return View("Index");
            }
            empleadoVM.AreaLista = _unidadTrabajo.Empleado.ObtenerTodosDropDownList("Area");
            empleadoVM.PuestoLista = _unidadTrabajo.Empleado.ObtenerTodosDropDownList("Puesto");
            return View(empleadoVM);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var todos = await _unidadTrabajo.Empleado.ObtenerTodos(incluirPropiedades: "Area,Puesto");
            return Json(new { data = todos });
        }

        [ActionName("ValidarNombre")]
        public async Task<IActionResult> ValidarNombre(string nombre, int id = 0)
        {
            bool valor = false;
            var lista = await _unidadTrabajo.Empleado.ObtenerTodos();

            if (id == 0)
            {
                valor = lista.Any(b => b.Nombre.ToLower().Trim() == nombre.ToLower().Trim());
            }
            else
            {
                valor = lista.Any(b => b.Nombre.ToLower().Trim()
                                    == nombre.ToLower().Trim()
                                    && b.Id != id);
            }
            if (valor)
            {
                return Json(new { data = true });
            }
            return Json(new { data = false });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var empDB = await _unidadTrabajo.Empleado.Obtener(id);
            if (empDB == null)
            {
                return Json(new { success = false, message = "Error al borrar el registro en la base de datos" });
            }
            _unidadTrabajo.Empleado.Remover(empDB);
            await _unidadTrabajo.Guardar();
            return Json(new { success = true, message = "Empleado eliminado con éxito" });
        }
        // End Región
    }
}