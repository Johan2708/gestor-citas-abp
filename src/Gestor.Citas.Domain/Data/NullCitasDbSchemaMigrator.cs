using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Gestor.Citas.Data;

/* This is used if database provider does't define
 * ICitasDbSchemaMigrator implementation.
 */
public class NullCitasDbSchemaMigrator : ICitasDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
