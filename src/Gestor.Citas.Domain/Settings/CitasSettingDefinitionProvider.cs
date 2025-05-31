using Volo.Abp.Settings;

namespace Gestor.Citas.Settings;

public class CitasSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(CitasSettings.MySetting1));
    }
}
