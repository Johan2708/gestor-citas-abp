using Gestor.Citas.Localization;
using Volo.Abp.Application.Services;

namespace Gestor.Citas;

/* Inherit your application services from this class.
 */
public abstract class CitasAppService : ApplicationService
{
    protected CitasAppService()
    {
        LocalizationResource = typeof(CitasResource);
    }
}
