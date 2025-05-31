using Volo.Abp.Modularity;

namespace Gestor.Citas;

[DependsOn(
    typeof(CitasApplicationModule),
    typeof(CitasDomainTestModule)
)]
public class CitasApplicationTestModule : AbpModule
{

}
