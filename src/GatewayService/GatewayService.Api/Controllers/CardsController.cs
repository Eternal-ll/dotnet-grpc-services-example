using CardsService.Sdk;
using Grpc.Core;
using Microsoft.AspNetCore.Mvc;

namespace GatewayService.Controllers
{
    [ApiController]
    [Route("cards")]
    public class CardsController : ControllerBase
    {
        private readonly ICardsService _cardsService;

        public CardsController(ICardsService cardsService)
        {
            _cardsService = cardsService;
        }
        [HttpGet]
        public async Task<IActionResult> Get(int skip = 0, int take = 20, CancellationToken cancellationToken = default)
        {
            return await HandleRpcRequest(_cardsService.GetCards(new(skip, take), cancellationToken));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByid(int id, CancellationToken cancellationToken = default)
        {
            return await HandleRpcRequest(_cardsService.GetById(new() { Id = id }, cancellationToken));
        }
        [HttpPost]
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
            catch (RpcException ex)
            {
                int statusCode = ex.StatusCode == Grpc.Core.StatusCode.NotFound ? 404 : 400;
                return Problem(ex.Status.Detail,
                    statusCode: statusCode);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        private async Task<IActionResult> HandleRpcRequest(Task task)
        {
            try
            {
                await task;
                return Created();
            }
            catch (RpcException ex)
            {
                return Problem(ex.Status.Detail);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
