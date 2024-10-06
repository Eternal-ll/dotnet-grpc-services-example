using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationsService.Sdk
{
    /// <summary>
    /// Сервис приёма заявлений
    /// </summary>
    [ServiceContract]
    public interface IApplicationsService
    {
        /// <summary>
        /// Отправить заявление
        /// </summary>
        /// <param name="application">Заявление</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [OperationContract]
        Task<Application> Submit(ApplicationSubmission application, CancellationToken cancellationToken = default);
    }
}
