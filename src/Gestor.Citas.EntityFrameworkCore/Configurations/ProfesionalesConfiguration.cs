using Gestor.Citas.Modules.Profesionales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Gestor.Citas.Configurations;

public class ProfesionalesConfiguration: IEntityTypeConfiguration<Profesional>
{
    public void Configure(EntityTypeBuilder<Profesional> builder)
    {
        builder.ToTable(CitasConsts.DbTablePrefix + "Profesionales", CitasConsts.DbSchema);
        builder.ConfigureByConvention();
        builder.Property(x => x.Nombre).IsRequired().HasMaxLength(250);
        builder.Property(x => x.Especializacion).IsRequired().HasMaxLength(250);
        builder.Property(x => x.Direccion).HasMaxLength(500);
        builder.Property(x => x.Telefono).IsRequired().HasMaxLength(15);
    }
}