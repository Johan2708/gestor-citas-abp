using Gestor.Citas.Samples;
using Xunit;

namespace Gestor.Citas.EntityFrameworkCore.Domains;

[Collection(CitasTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<CitasEntityFrameworkCoreTestModule>
{

}
