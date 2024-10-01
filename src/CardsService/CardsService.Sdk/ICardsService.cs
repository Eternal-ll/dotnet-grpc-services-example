using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;

namespace CardsService.Sdk
{
    /// <summary>
    /// Сервис по работе с картами
    /// </summary>
    [ServiceContract]
    public interface ICardsService
    {
        /// <summary>
        /// Получить список типов карт
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [OperationContract]
        Task<CardType[]> GetCardTypes(CancellationToken cancellationToken = default);
        /// <summary>
        /// Получить список карт
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [OperationContract]
        Task<Card[]> GetCards(GetCardsRequest request, CancellationToken cancellationToken = default);
        /// <summary>
        /// Получить карту по Ид
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [OperationContract]
        Task<Card> GetById(GetCardByIdRequest request, CancellationToken cancellationToken = default);
        /// <summary>
        /// Добавить карту
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [OperationContract]
        Task<Card> Add(AddCardRequest request, CancellationToken cancellationToken = default);
    }
}
