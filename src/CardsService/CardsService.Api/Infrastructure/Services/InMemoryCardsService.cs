using CardsService.Database.Context;
using CardsService.Sdk;
using CardsService.Sdk.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CardsService.Api.Infrastructure.Services
{
    public class InMemoryCardsService : ICardsService
    {
        private readonly CardsContext _context;

        public InMemoryCardsService(CardsContext context)
        {
            _context = context;
        }

        private static Dictionary<int, string> _cardTypes = new()
        {
            { 1, "Без банка" },
            { 2, "От Уралсиб" },
            { 3, "От Сбер" },
            { 4, "От ПСБ" },
        };
        public async Task<Card> Add(AddCardRequest request, CancellationToken cancellationToken = default)
        {
            if (!_cardTypes.ContainsKey(request.CardTypeId))
            {
                throw new ServiceException(ErrorCode.CardTypeNotFound);
            }
            var card = new Database.Entities.Card()
            {
                CardTypeId = request.CardTypeId,
                Sn = Guid.NewGuid().ToString().Replace("-", null)[..8].ToUpper()
            };
            var entry = _context.Cards.Add(card);
            await _context.SaveChangesAsync();
            return new Card()
            {
                Id = entry.Entity.Id,
                Sn = card.Sn,
                Type = new()
                {
                    Id = card.CardTypeId,
                    Name = _cardTypes[card.CardTypeId]
                }
            };
        }

        public async Task<Card> GetById(GetCardByIdRequest request, CancellationToken cancellationToken = default)
        {
            var card = await _context.Cards.FirstOrDefaultAsync(x => x.Id == request.Id)
                ?? throw new ServiceException(ErrorCode.CardNotFound);
            return new Card()
            {
                Id = card.Id,
                Sn = card.Sn,
                Type = new CardType()
                {
                    Id = card.CardTypeId,
                    Name = _cardTypes[card.CardTypeId]
                }
            };
        }

        public async Task<Card[]> GetCards(GetCardsRequest request, CancellationToken cancellationToken = default)
        {
            var data = await _context.Cards
                .Skip(request.Skip)
                .Take(request.Take)
                .ToArrayAsync(cancellationToken);
            return data
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
                .ToArray();
        }

        public Task<CardType[]> GetCardTypes(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(_cardTypes
                .Select(x => new CardType() { Id = x.Key, Name = x.Value })
                .ToArray());
        }
    }
}
