using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Data.Config
{
    internal class LugarConfiguration : IEntityTypeConfiguration<Lugar>
    {
        public void Configure(EntityTypeBuilder<Lugar> builder)
        {
            builder.Property(l => l.Id).IsRequired();
            builder.Property(l => l.Nombre).IsRequired().HasMaxLength(120);
            builder.Property(l => l.Descripcion).IsRequired();
            builder.Property(l => l.GastoAproximado).IsRequired();

            //Relaciones
           builder.HasOne(c=>c.Categoria).WithMany().HasForeignKey(l=>l.CategoriaID);
           builder.HasOne(p => p.Pais).WithMany().HasForeignKey(l => l.PaisID);

        }
    }
}
