using Gestor.Citas.Samples;
using Xunit;

namespace Gestor.Citas.EntityFrameworkCore.Applications;

[Collection(CitasTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<CitasEntityFrameworkCoreTestModule>
{

}
