using System.Threading.Tasks;

namespace Gestor.Citas.Data;

public interface ICitasDbSchemaMigrator
{
    Task MigrateAsync();
}
