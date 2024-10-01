using CardsService.Sdk;
using Grpc.Core;

namespace CardsService.Api.Infrastructure.Services
{
    public class InMemoryCardsService : ICardsService
    {
        private static List<Database.Entities.Card> _cards = new();
        private static Dictionary<int, string> _cardTypes = new()
        {
            { 1, "Без банка" },
            { 2, "От Уралсиб" },
            { 3, "От Сбер" },
            { 4, "От ПСБ" },
        };
        public Task<Card> Add(AddCardRequest request, CancellationToken cancellationToken = default)
        {
            if (!_cardTypes.ContainsKey(request.CardTypeId))
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, $"Неизвестный тип карты [{request.CardTypeId}]"));
            }
            var card = new Database.Entities.Card()
            {
                Id = _cards.Count + 1,
                CardTypeId = request.CardTypeId,
                Sn = Guid.NewGuid().ToString().Replace("-", null)[..8]
            };
            _cards.Add(card);
            return Task.FromResult(new Card()
            {
                Id = card.Id,
                Sn = card.Sn,
                Type = new()
                {
                    Id = card.CardTypeId,
                    Name = _cardTypes[card.CardTypeId]
                }
            });
        }

        public Task<Card> GetById(GetCardByIdRequest request, CancellationToken cancellationToken = default)
        {
            var card = _cards.FirstOrDefault(x => x.Id == request.Id)
                ?? throw new RpcException(new(StatusCode.NotFound, $"Card [{request.Id}] not found"));
            return Task.FromResult(new Card()
            {
                Id = card.Id,
                Sn = card.Sn,
                Type = new CardType()
                {
                    Id = card.CardTypeId,
                    Name = _cardTypes[card.CardTypeId]
                }
            });
        }

        public Task<Card[]> GetCards(GetCardsRequest request, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(_cards
                .Skip(request.Skip)
                .Take(request.Take)
                .Select(x => new Card()
                {
                    Id = x.Id,
                    Type = new()
                    {
                        Id = x.CardTypeId,
                        Name = _cardTypes[x.CardTypeId]
                    },
                    Sn = x.Sn
                })
                .ToArray());
        }

        public Task<CardType[]> GetCardTypes(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(_cardTypes
                .Select(x => new CardType() { Id = x.Key, Name = x.Value })
                .ToArray());
        }
    }
}
