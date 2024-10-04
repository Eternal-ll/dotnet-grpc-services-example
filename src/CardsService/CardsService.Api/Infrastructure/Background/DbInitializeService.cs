using CardsService.Database.Context;

namespace CardsService.Api.Infrastructure.Background
{
    public class DbInitializeService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public DbInitializeService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return InitializeDatabaseAsync(stoppingToken);
        }

        private async Task InitializeDatabaseAsync(CancellationToken stoppingToken)
        {
            using var scope = _serviceProvider.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<CardsContext>();
            await context.Database.EnsureCreatedAsync(stoppingToken);
        }
    }
}
