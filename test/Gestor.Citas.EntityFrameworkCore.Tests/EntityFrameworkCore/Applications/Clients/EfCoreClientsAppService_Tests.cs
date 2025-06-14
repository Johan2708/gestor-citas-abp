using Gestor.Citas.Modules.Clients;
using Xunit;

namespace Gestor.Citas.EntityFrameworkCore.Applications.Clients;

[Collection(CitasTestConsts.CollectionDefinitionName)]
public class EfCoreClientsAppService_Tests: ClientAppService_Tests<CitasEntityFrameworkCoreTestModule>
{
    
}