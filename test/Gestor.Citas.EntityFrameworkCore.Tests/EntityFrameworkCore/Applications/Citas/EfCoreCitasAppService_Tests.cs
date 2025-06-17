using Gestor.Citas.Modules.Citas;
using Xunit;

namespace Gestor.Citas.EntityFrameworkCore.Applications.Citas;

[Collection(CitasTestConsts.CollectionDefinitionName)]
public class EfCoreCitasAppService_Tests : CitaAppService_Tests<CitasEntityFrameworkCoreTestModule>
{
    
}