using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pe2.Api.Controllers.Base;
using Pe2.Api.Controllers.Responses;
using Pe2Api.Domain.Commands.Request;
using Pe2Api.Domain.Queries.Request;

namespace Pe2.Api.Controllers
{
    [Route("api/parasite-energies")]
    [ApiController]
    public class ParasiteEnergyController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public ParasiteEnergyController(IResponseFactory responseFactory, IMediator mediator) : base(responseFactory)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync(CreateParasiteEnergyRequestCommand command)
        {
            var result = await _mediator.Send(command);

            return ResponseCreated(result);
        }

        [HttpGet]
        public async Task<IActionResult> FindAllAsync([FromQuery] FindAllParasiteEnergiesRequestQuery query)
        {
            var result = await _mediator.Send(query);

            return ResponseOk(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindOneAsync([FromRoute]FindParasiteEnergyByIdRequestQuery query)
        {
            var result = await _mediator.Send(query);

            return ResponseOk(result);
        }

        [HttpGet("separated-by-type")]
        public async Task<IActionResult> FindParasiteEnergySeparatedByTypeAsync()
        {
            var result = await _mediator.Send(new FindParasiteEnergyByTypeRequestQuery());

            return ResponseOk(result);
        }
    }
}
