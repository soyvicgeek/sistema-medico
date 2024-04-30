using SistemaMedico.AccesoDatos.Data;
using SistemaMedido.AccesoDatos.Repositorio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMedido.AccesoDatos.Repositorio
{
    public class UnidadTrabajo : IUnidadTrabajo
    {
        private readonly ApplicationDbContext _db;
        public IBodegaRepositorio Bodega { get; set; }
        public ICategoriaRepositorio Categoria { get; set; }
        public IMarcaRepositorio Marca { get; set; }
        public IProductoRepositorio Producto { get; set; }
        public IAreaRepositorio Area { get; set; }
        public IPuestoRepositorio Puesto { get; set; }
        public IEmpleadoRepositorio Empleado { get; set; }
        public UnidadTrabajo(ApplicationDbContext db)
        {
            _db = db;
            Bodega = new BodegaRepositorio(_db);
            Categoria = new CategoriaRepositorio(_db);
            Marca = new MarcaRepositorio(_db);
            Producto = new ProductoRepositorio(_db);
            Area = new AreaRepositorio(_db);
            Puesto = new PuestoRepositorio(_db);
            Empleado = new EmpleadoRepositorio(_db);
        }
        public void Dispose()
        {
            _db.Dispose();
        }
        public async Task Guardar()
        {
            await _db.SaveChangesAsync();
        }
    }
}
