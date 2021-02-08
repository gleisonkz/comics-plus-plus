using System;
using System.Threading;
using System.Threading.Tasks;
using ComicStore.Infra.EFRepository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ComicStoreWebAPI
{
    public class MigrationWorker : IHostedService
    {
        readonly IServiceProvider provider;
        public MigrationWorker(IServiceProvider provider)
        {
            this.provider = provider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = provider.CreateScope();
            using var identityContext = scope.ServiceProvider.GetRequiredService<ComicStoreIdentityDbContext>();
            using var context = scope.ServiceProvider.GetRequiredService<ComicStoreDbContext>();
            await identityContext.Database.MigrateAsync();
            await context.Database.MigrateAsync();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}