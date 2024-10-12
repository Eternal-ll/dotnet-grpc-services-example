using CardsService.Api.Infrastructure.Mapping;
using Mapster;
using MapsterMapper;

namespace CardsService.Api.Infrastructure.Extensions
{
    internal static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddMapsterMapping(this IServiceCollection services) => services
            .AddSingleton(TypeAdapterConfig.GlobalSettings)
            .AddSingleton(new MapsterConfig())
            .AddScoped<IMapper, ServiceMapper>();
    }
}
