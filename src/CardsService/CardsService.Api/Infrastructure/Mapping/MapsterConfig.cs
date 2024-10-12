using Mapster;

namespace CardsService.Api.Infrastructure.Mapping
{
    public class MapsterConfig : TypeAdapterConfig
    {
        public MapsterConfig()
        {
            TypeAdapterConfig<CardTypeEntity, CardTypeDto>
                .NewConfig()
                .Map(dst => dst.Id, src => src.Id)
                .Map(dst => dst.Name, src => src.Name);
            TypeAdapterConfig<CardEntity, CardDto>
                .NewConfig()
                .Map(dst => dst.Id, src => src.Id)
                .Map(dst => dst.Sn, src => src.Sn)
                .Map(dst => dst.Type, src => src.CardType);
        }
    }
}
