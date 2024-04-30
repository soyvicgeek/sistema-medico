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
    public class AreaRepositorio : Repositorio<Area>, IAreaRepositorio
    {
        private readonly ApplicationDbContext _db;
        public AreaRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(Area area)
        {
            var areaBD = _db.Areas.FirstOrDefault(b => b.Id == area.Id);
            if (areaBD != null)
            {
                areaBD.Descripcion = area.Descripcion;
                areaBD.Turno = area.Turno;

                _db.SaveChanges();
            }
        }
    }
}
