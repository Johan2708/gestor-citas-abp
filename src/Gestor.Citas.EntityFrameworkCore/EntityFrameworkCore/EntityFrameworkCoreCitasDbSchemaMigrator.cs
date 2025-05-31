using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Gestor.Citas.Data;
using Volo.Abp.DependencyInjection;

namespace Gestor.Citas.EntityFrameworkCore;

public class EntityFrameworkCoreCitasDbSchemaMigrator
    : ICitasDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreCitasDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the CitasDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<CitasDbContext>()
            .Database
            .MigrateAsync();
    }
}
