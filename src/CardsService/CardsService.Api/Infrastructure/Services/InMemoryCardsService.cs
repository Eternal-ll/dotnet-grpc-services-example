using CardsService.Database.Context;
using CardsService.Sdk;
using CardsService.Sdk.Exceptions;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace CardsService.Api.Infrastructure.Services
{
    public class InMemoryCardsService : ICardsService
    {
        private readonly CardsContext _context;
        private readonly IMapper _mapper;

        public InMemoryCardsService(CardsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CardDto> Add(AddCardRequest request, CancellationToken cancellationToken = default)
        {
            var cardType = await _context.CardTypes.FirstOrDefaultAsync(x => x.Id == request.CardTypeId, cancellationToken) ?? throw new ServiceException(ErrorCode.CardTypeNotFound);
            var card = new CardEntity()
            {
                Sn = Guid.NewGuid().ToString().Replace("-", null)[..8].ToUpper(),
                CardTypeId = request.CardTypeId,
                CardType = cardType
            };
            _context.Cards.Add(card);
            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<CardDto>(card);
        }

        public async Task<CardDto> GetById(GetCardByIdRequest request, CancellationToken cancellationToken = default)
        {
            var card = await _context.Cards
                .Include(x => x.CardType)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                ?? throw new ServiceException(ErrorCode.CardNotFound);
            return _mapper.Map<CardDto>(card);
        }

        public async Task<CardDto[]> GetCards(GetCardsRequest request, CancellationToken cancellationToken = default)
        {
            var data = await _context.Cards
                .Include(x => x.CardType)
                .Skip(request.Skip)
                .Take(request.Take)
                .ToArrayAsync(cancellationToken);
            return data
                .Select(x => _mapper.Map<CardDto>(x))
                .ToArray();
        }

        public async Task<CardTypeDto[]> GetCardTypes(CancellationToken cancellationToken = default)
        {
            var data = await _context.CardTypes.ToArrayAsync(cancellationToken);
            return data
                .Select(x => _mapper.Map<CardTypeDto>(x))
                .ToArray();
        }
    }
}
