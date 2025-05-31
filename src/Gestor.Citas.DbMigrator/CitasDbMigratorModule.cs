using Gestor.Citas.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Gestor.Citas.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(CitasEntityFrameworkCoreModule),
    typeof(CitasApplicationContractsModule)
)]
public class CitasDbMigratorModule : AbpModule
{
}
