using CardsService.Sdk;
using Microsoft.AspNetCore.Mvc;

namespace GatewayService.Controllers
{
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
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var cardTypes = await _cardsService.GetCardTypes(cancellationToken);
            return Ok(cardTypes);
        }
    }
}
