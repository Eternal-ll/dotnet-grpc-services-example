using CardsService.Sdk;
using Microsoft.AspNetCore.Mvc;

namespace GatewayService.Controllers
{
    /// <summary>
    /// Типы карт
    /// </summary>
    [ApiController]
    [Route("cards/types")]
    public class CardTypesController : ControllerBase
    {
        private readonly ICardsService _cardsService;

        public CardTypesController(ICardsService cardsService)
        {
            _cardsService = cardsService;
        }
        [HttpGet]
        [ProducesResponseType(typeof(CardType[]), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var cardTypes = await _cardsService.GetCardTypes(cancellationToken);
            return Ok(cardTypes);
        }
    }
}
