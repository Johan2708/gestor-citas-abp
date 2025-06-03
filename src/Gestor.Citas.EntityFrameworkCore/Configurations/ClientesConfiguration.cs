using Gestor.Citas.Modules.Clientes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Gestor.Citas.Configurations;

public class ClientesConfiguration: IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable(CitasConsts.DbTablePrefix + "Clientes", CitasConsts.DbSchema);
        builder.ConfigureByConvention();
        builder.Property(x => x.Nombre).IsRequired().HasMaxLength(250);
        builder.Property(x => x.Apellido).IsRequired().HasMaxLength(250);
        builder.Property(x => x.Telefono).IsRequired().HasMaxLength(15);
        builder.Property(x => x.Email).IsRequired().HasMaxLength(250);
        builder.Property(x => x.Direccion).IsRequired().HasMaxLength(500);
        builder.Property(x => x.FechaNacimiento)
            .HasColumnType("date");
        builder.HasIndex(x => x.Email).IsUnique();
        builder.HasIndex(x => x.Telefono).IsUnique();
        builder.HasIndex(x => new { x.Nombre, x.Apellido }).HasDatabaseName("IX_Clientes_Nombre_Apellido");
    }
}