using Gestor.Citas.Books;
using Xunit;

namespace Gestor.Citas.EntityFrameworkCore.Applications.Books;

[Collection(CitasTestConsts.CollectionDefinitionName)]
public class EfCoreBookAppService_Tests : BookAppService_Tests<CitasEntityFrameworkCoreTestModule>
{

}