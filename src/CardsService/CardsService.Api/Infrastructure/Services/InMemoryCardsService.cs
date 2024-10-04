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

        public async Task<Card> Add(AddCardRequest request, CancellationToken cancellationToken = default)
        {
            var cardType = await _context.CardTypes.FirstOrDefaultAsync(x => x.Id == request.CardTypeId, cancellationToken) ?? throw new ServiceException(ErrorCode.CardTypeNotFound);
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
                    Name = cardType.Name
                }
            };
        }

        public async Task<Card> GetById(GetCardByIdRequest request, CancellationToken cancellationToken = default)
        {
            var card = await _context.Cards
                .Include(x => x.CardType)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                ?? throw new ServiceException(ErrorCode.CardNotFound);
            return new Card()
            {
                Id = card.Id,
                Sn = card.Sn,
                Type = new CardType()
                {
                    Id = card.CardTypeId,
                    Name = card.CardType.Name
                }
            };
        }

        public async Task<Card[]> GetCards(GetCardsRequest request, CancellationToken cancellationToken = default)
        {
            var data = await _context.Cards
                .Include(x => x.CardType)
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
                        Name = x.CardType.Name
                    },
                    Sn = x.Sn
                })
                .ToArray();
        }

        public async Task<CardType[]> GetCardTypes(CancellationToken cancellationToken = default)
        {
            var data = await _context.CardTypes.ToArrayAsync(cancellationToken);
            return data
                .Select(x => new CardType() { Id = x.Id, Name = x.Name })
                .ToArray();
        }
    }
}
