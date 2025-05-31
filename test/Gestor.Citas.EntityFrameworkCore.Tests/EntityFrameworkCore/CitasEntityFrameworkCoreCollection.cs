using Xunit;

namespace Gestor.Citas.EntityFrameworkCore;

[CollectionDefinition(CitasTestConsts.CollectionDefinitionName)]
public class CitasEntityFrameworkCoreCollection : ICollectionFixture<CitasEntityFrameworkCoreFixture>
{

}
