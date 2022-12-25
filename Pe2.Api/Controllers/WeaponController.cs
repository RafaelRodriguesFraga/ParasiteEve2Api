using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pe2.Api.Controllers.Base;
using Pe2.Api.Controllers.Responses;
using Pe2Api.Domain.Handlers.Commands;
using Pe2Api.Domain.Queries.Request;

namespace Pe2Api.Api.Controllers
{
    [Route("api/weapons")]
    [ApiController]
    public class WeaponController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        public WeaponController(IResponseFactory responseFactory, IMediator mediator) : base(responseFactory)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync(CreateWeaponRequestCommand command)
        {
            var result = await _mediator.Send(command);

            return ResponseCreated(result);
        }

        [HttpGet]
        public async Task<IActionResult> FindAllAsync([FromQuery] FindAllWeaponsRequestQuery query)
        {
            var result = await _mediator.Send(query);

            return ResponseOk(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindOneAsync([FromRoute] FindWeaponByIdRequestQuery query)
        {
            var result = await _mediator.Send(query);

            return ResponseOk(result);
        }
    }
}
