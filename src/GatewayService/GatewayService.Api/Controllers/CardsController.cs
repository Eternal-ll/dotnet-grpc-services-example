using CardsService.Sdk;
using Grpc.Core;
using Microsoft.AspNetCore.Mvc;

namespace GatewayService.Controllers
{
    /// <summary>
    /// Карты
    /// </summary>
    [ApiController]
    [Route("cards")]
    public class CardsController : ControllerBase
    {
        private readonly ICardsService _cardsService;

        public CardsController(ICardsService cardsService)
        {
            _cardsService = cardsService;
        }
        /// <inheritdoc cref="ICardsService.GetCards(GetCardsRequest, CancellationToken)"/>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Card[]), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int skip = 0, int take = 20, CancellationToken cancellationToken = default)
        {
            return await HandleRpcRequest(_cardsService.GetCards(new(skip, take), cancellationToken));
        }
        /// <inheritdoc cref="ICardsService.GetById(GetCardByIdRequest, CancellationToken)"/>
        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Card), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken = default)
        {
            return await HandleRpcRequest(_cardsService.GetById(new() { Id = id }, cancellationToken));
        }
        /// <inheritdoc cref="ICardsService.Add(AddCardRequest, CancellationToken)"/>
        [HttpPost]
        [ProducesResponseType(typeof(Card), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add(AddCardRequest model, CancellationToken cancellationToken = default)
        {
            return await HandleRpcRequest(_cardsService.Add(model, cancellationToken));
        }

        private async Task<IActionResult> HandleRpcRequest<TResult>(Task<TResult> task)
        {
            try
            {
                var result = await task;
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: StatusCodes.Status400BadRequest);
            }
        }
    }
}
