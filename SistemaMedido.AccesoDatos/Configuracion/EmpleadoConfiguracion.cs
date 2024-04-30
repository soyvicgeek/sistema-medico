using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SistemaMedico.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMedido.AccesoDatos.Configuracion
{
    public class EmpleadoConfiguracion : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(60);
            builder.Property(x => x.APaterno).IsRequired().HasMaxLength(60);
            builder.Property(x => x.AMaterno).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Direccion).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Telefono).IsRequired().HasMaxLength(20);
            builder.Property(x => x.AreaId).IsRequired();
            builder.Property(x => x.PuestoId).IsRequired();

            //Hagamos las relaciones en Fluent API
            builder.HasOne(x => x.Area).WithMany()
                .HasForeignKey(x => x.AreaId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Puesto).WithMany()
                .HasForeignKey(x => x.PuestoId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
