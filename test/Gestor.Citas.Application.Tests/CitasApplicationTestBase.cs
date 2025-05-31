using Volo.Abp.Modularity;

namespace Gestor.Citas;

public abstract class CitasApplicationTestBase<TStartupModule> : CitasTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
