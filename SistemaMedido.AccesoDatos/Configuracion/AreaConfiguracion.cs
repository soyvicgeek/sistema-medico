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
    public class AreaConfiguracion : IEntityTypeConfiguration<Area>
    {
        public void Configure(EntityTypeBuilder<Area> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Descripcion).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Turno).IsRequired().HasMaxLength(60);
        }
    }
}
