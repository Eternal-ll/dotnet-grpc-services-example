using CardsService.Sdk;
using CardsService.Sdk.Interceptors;
using ProtoBuf.Grpc.ClientFactory;

namespace GatewayService.Api.Infrastructure.Extensions
{
    internal static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Add cards-service and configure grpc client
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddCardsService(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddTransient<DomainExceptionInterceptor>()
                .AddCodeFirstGrpcClient<ICardsService>(x =>
                {
                    x.Address = configuration.GetValue<Uri>("Services:CardsService:Url");
                })
                .AddInterceptor<DomainExceptionInterceptor>();
            return services;
        }
    }
}
