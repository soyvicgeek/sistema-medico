using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaMedico.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMedido.AccesoDatos.Configuracion
{
    public class PuestoConfiguracion : IEntityTypeConfiguration<Puesto>
    {
        public void Configure(EntityTypeBuilder<Puesto> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Tipo).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Salario).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Horario).IsRequired().HasMaxLength(60);
        }
    }
}
