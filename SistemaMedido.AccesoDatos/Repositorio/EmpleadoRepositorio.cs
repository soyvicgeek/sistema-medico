using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaMedico.AccesoDatos.Data;
using SistemaMedico.Modelos;
using SistemaMedido.AccesoDatos.Repositorio.IRepositorio;

namespace SistemaMedido.AccesoDatos.Repositorio
{
    public class EmpleadoRepositorio : Repositorio<Empleado>, IEmpleadoRepositorio
    {
        private readonly ApplicationDbContext _db;
        public EmpleadoRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(Empleado empleado)
        {
            var empleadoDB = _db.Empleados.FirstOrDefault(b => b.Id == empleado.Id);
            if (empleadoDB != null)
            {

                empleadoDB.Nombre = empleado.Nombre;
                empleadoDB.APaterno = empleado.APaterno;
                empleadoDB.AMaterno = empleado.AMaterno;
                empleadoDB.Direccion = empleado.Direccion;
                empleadoDB.Telefono = empleado.Telefono;
                empleadoDB.AreaId = empleado.AreaId;
                empleado.PuestoId = empleado.PuestoId;

                _db.SaveChanges();
            }
        }

        public IEnumerable<SelectListItem> ObtenerTodosDropDownList(string obj)
        {
            if (obj == "Area")
            {
                return _db.Areas.Select(c => new SelectListItem
                {
                    Text = c.Turno,
                    Value = c.Id.ToString()
                });
            }
            if (obj == "Puesto")
            {
                return _db.Puestos.Select(c => new SelectListItem
                {
                    Text = c.Nombre,
                    Value = c.Id.ToString()
                });
            }
            return null;
        }
    }
}