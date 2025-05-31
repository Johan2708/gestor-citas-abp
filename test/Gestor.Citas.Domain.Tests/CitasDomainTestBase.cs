using Volo.Abp.Modularity;

namespace Gestor.Citas;

/* Inherit from this class for your domain layer tests. */
public abstract class CitasDomainTestBase<TStartupModule> : CitasTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
