using Gestor.Citas.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace Gestor.Citas.Permissions;

public class CitasPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(CitasPermissions.GroupName);

        var booksPermission = myGroup.AddPermission(CitasPermissions.Books.Default, L("Permission:Books"));
        booksPermission.AddChild(CitasPermissions.Books.Create, L("Permission:Books.Create"));
        booksPermission.AddChild(CitasPermissions.Books.Edit, L("Permission:Books.Edit"));
        booksPermission.AddChild(CitasPermissions.Books.Delete, L("Permission:Books.Delete"));
        //Define your own permissions here. Example:
        //myGroup.AddPermission(CitasPermissions.MyPermission1, L("Permission:MyPermission1"));

        var clientesPermission = myGroup.AddPermission(CitasPermissions.Clientes.Default, L("Permission:Clients"));
        clientesPermission.AddChild(CitasPermissions.Clientes.Create, L("Permission:Clients.Create"));
        clientesPermission.AddChild(CitasPermissions.Clientes.Edit, L("Permission:Clients.Edit"));
        clientesPermission.AddChild(CitasPermissions.Clientes.Delete, L("Permission:Clients.Delete"));

        var citasPermission = myGroup.AddPermission(CitasPermissions.Citas.Default, L("Permission:Appointments"));
        citasPermission.AddChild(CitasPermissions.Citas.Create, L("Permission:Appointments.Create"));
        citasPermission.AddChild(CitasPermissions.Citas.Edit, L("Permission:Appointments.Edit"));
        citasPermission.AddChild(CitasPermissions.Citas.Delete, L("Permission:Appointments.Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<CitasResource>(name);
    }
}
