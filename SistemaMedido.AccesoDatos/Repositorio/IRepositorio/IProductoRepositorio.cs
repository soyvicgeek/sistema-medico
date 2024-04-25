using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaMedico.Modelos;

namespace SistemaMedido.AccesoDatos.Repositorio.IRepositorio
{
    public interface IProductoRepositorio : IRepositorio<Producto>
    {
        void Actualizar(Producto producto);
        IEnumerable<SelectListItem> ObtenerTodosDropDownList(string obj);
    }
}
