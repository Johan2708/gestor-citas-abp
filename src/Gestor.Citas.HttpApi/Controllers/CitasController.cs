using Gestor.Citas.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Gestor.Citas.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class CitasController : AbpControllerBase
{
    protected CitasController()
    {
        LocalizationResource = typeof(CitasResource);
    }
}
