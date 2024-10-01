using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;

namespace CardsService.Sdk
{
    [ServiceContract]
    public interface ICardsService
    {
        [OperationContract]
        Task<CardType[]> GetCardTypes(CancellationToken cancellationToken = default);
        [OperationContract]
        Task<Card[]> GetCards(GetCardsRequest request, CancellationToken cancellationToken = default);
        [OperationContract]
        Task<Card> GetById(GetCardByIdRequest request, CancellationToken cancellationToken = default);
        [OperationContract]
        Task Add(AddCardRequest request, CancellationToken cancellationToken = default);
    }
}
