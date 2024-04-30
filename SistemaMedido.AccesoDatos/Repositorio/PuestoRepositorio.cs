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
    public class PuestoRepositorio : Repositorio<Puesto>, IPuestoRepositorio
    {
        private readonly ApplicationDbContext _db;
        public PuestoRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(Puesto puesto)
        {
            var puestoBD = _db.Puestos.FirstOrDefault(b => b.Id == puesto.Id);
            if (puestoBD != null)
            {
                puestoBD.Nombre = puesto.Nombre;
                puestoBD.Tipo = puesto.Tipo;
                puestoBD.Salario = puesto.Salario;
                puestoBD.Horario = puesto.Horario;

                _db.SaveChanges();
            }
        }
    }
}
