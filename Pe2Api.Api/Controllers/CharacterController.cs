using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pe2Api.Domain.Commands.Request;
using Pe2.Api.Controllers.Base;
using Pe2.Api.Controllers.Responses;
using Pe2Api.Domain.Queries.Request;

namespace Pe2.Api.Controllers
{
    [ApiController]
    [Route("api/characters")]
    public class CharacterController : ApiControllerBase
    {

        private IMediator _mediator;

        public CharacterController(IResponseFactory responseFactory, IMediator mediator) : base(responseFactory)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync(CreateCharacterRequestCommand command)
        {
            var result = await _mediator.Send(command);

            return ResponseCreated(result);
        }

        [HttpGet]
        public async Task<IActionResult> FindAllAsync()
        {
            var result = await _mediator.Send(new FindAllCharactersRequestQuery());

            return ResponseOk(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindByIdAsync([FromRoute]FindCharacterByIdRequestQuery query)
        {
            var result = await _mediator.Send(query);

            return ResponseOk(result);
        }
    }
}