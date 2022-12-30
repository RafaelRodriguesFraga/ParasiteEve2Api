using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pe2Api.Domain.Commands.Request;
using Pe2Api.Api.Controllers.Base;
using Pe2Api.Api.Controllers.Responses;
using Pe2Api.Domain.Queries.Request;
using MongoDB.Bson;

namespace Pe2Api.Api.Controllers
{
    [ApiController]
    [Route("api/armors")]
    public class ArmorController : ApiControllerBase
    {

        private IMediator _mediator;

        public ArmorController(IResponseFactory responseFactory, IMediator mediator) : base(responseFactory)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync(CreateArmorRequestCommand command)
        {
            var result = await _mediator.Send(command);

            return ResponseCreated(result);
        }

        [HttpGet]
        public async Task<IActionResult> FindAllAsync()
        {
            var result = await _mediator.Send(new FindAllArmorsRequestQuery());

            return ResponseOk(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindByIdAsync(Guid id)
        {
            var result = await _mediator.Send(new FindArmorByIdRequestQuery(id));

            return ResponseOk(result);
        }
    }
}