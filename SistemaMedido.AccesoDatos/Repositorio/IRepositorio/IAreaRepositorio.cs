using SistemaMedico.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMedido.AccesoDatos.Repositorio.IRepositorio
{
    public interface IAreaRepositorio : IRepositorio<Area>
    {
        void Actualizar(Area area);
    }
}
