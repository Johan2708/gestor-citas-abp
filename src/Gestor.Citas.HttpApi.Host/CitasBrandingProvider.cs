using Microsoft.Extensions.Localization;
using Gestor.Citas.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Gestor.Citas;

[Dependency(ReplaceServices = true)]
public class CitasBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<CitasResource> _localizer;

    public CitasBrandingProvider(IStringLocalizer<CitasResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
