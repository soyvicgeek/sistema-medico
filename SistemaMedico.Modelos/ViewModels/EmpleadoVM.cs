using Microsoft.AspNetCore.Mvc.Rendering;

namespace SistemaMedico.Modelos.ViewModels
{
    public class EmpleadoVM
    {
        public Empleado Empleado { get; set; }
        public IEnumerable<SelectListItem> AreaLista { get; set; }
        public IEnumerable<SelectListItem> PuestoLista { get; set; }
    }
}