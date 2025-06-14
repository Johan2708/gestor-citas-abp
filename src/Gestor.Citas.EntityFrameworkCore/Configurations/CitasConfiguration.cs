using Gestor.Citas.Modules.Cita;
using Gestor.Citas.Modules.Profesionales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;
namespace Gestor.Citas.Configurations;

public class CitasConfiguration : IEntityTypeConfiguration<Cita>
{
    public void Configure(EntityTypeBuilder<Cita> builder)
    {
        builder.ToTable(CitasConsts.DbTablePrefix + "Citas", CitasConsts.DbSchema);
        builder.ConfigureByConvention();
        builder.Property(x => x.FechaCita).IsRequired().HasColumnType("date");
        builder.Property(x => x.Motivo).IsRequired().HasMaxLength(250);
        
        builder.HasOne(x => x.Profesional)
            .WithMany()
            .HasForeignKey("ProfesionalId")
            .IsRequired();
        builder.HasOne(x => x.Cliente)
            .WithMany()
            .HasForeignKey("ClienteId")
            .IsRequired();

    }
}
