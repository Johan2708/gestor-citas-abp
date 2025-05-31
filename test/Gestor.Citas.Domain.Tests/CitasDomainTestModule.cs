using Volo.Abp.Modularity;

namespace Gestor.Citas;

[DependsOn(
    typeof(CitasDomainModule),
    typeof(CitasTestBaseModule)
)]
public class CitasDomainTestModule : AbpModule
{

}
