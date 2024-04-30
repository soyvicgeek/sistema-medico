using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaMedico.Modelos;

namespace SistemaMedido.AccesoDatos.Repositorio.IRepositorio
{
    public interface IEmpleadoRepositorio : IRepositorio<Empleado>
    {
        void Actualizar(Empleado empleado);
        IEnumerable<SelectListItem> ObtenerTodosDropDownList(string obj);
    }
}
