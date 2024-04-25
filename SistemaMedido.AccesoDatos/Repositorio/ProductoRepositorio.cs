using SistemaMedico.AccesoDatos.Data;
using SistemaMedico.Modelos;
using SistemaMedido.AccesoDatos.Repositorio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMedido.AccesoDatos.Repositorio
{
    public class ProductoRepositorio : Repositorio<Producto>, IProductoRepositorio
    {
        private readonly ApplicationDbContext _db;

        public ProductoRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(Producto producto)
        {
            var productoDB = _db.Productos.FirstOrDefault(b => b.Id == producto.Id);
            if (productoDB != null)
            {
                if (producto.ImagenUrl != null)
                {
                    productoDB.ImagenUrl = producto.ImagenUrl;
                }

                productoDB.NumeroSerie = producto.NumeroSerie;
                productoDB.Descripcion = producto.Descripcion;
                productoDB.Precio = producto.Precio;
                productoDB.Costo = productoDB.Costo;
                productoDB.CategoriaId = productoDB.CategoriaId;
                productoDB.MarcaId = productoDB.MarcaId;
                productoDB.PadreId = productoDB.PadreId;
                productoDB.Estado = producto.Estado;

                _db.SaveChanges();
            }
        }
    }
}
