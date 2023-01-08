using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pe2Api.Api.Controllers.Base;
using Pe2Api.Api.Controllers.Responses;
using Pe2Api.Domain.Commands.Request;
using Pe2Api.Domain.Queries.Request;

namespace Pe2Api.Api.Controllers
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


        /// <summary>
        /// Insert a Parasite Energy in the database
        /// </summary>
        /// <param name="command"></param>
        /// <returns>A valid Parasite Energy</returns>
        /// <response code="201">Returns Created if a Parasite Energy is succefully inserted</response>
        /// <response code="400">Returns BadRequest if there's any validation errors</response>
        [HttpPost]
        public async Task<IActionResult> InsertAsync(CreateParasiteEnergyRequestCommand command)
        {
            var result = await _mediator.Send(command);

            return ResponseCreated(result);
        }

        /// <summary>
        ///  Get all Parasite Energies from the database
        /// </summary>
        /// <returns>Returns all parasite energies</returns>
        /// <response code="200">Returns Success</response>
        [HttpGet]
        public async Task<IActionResult> FindAllAsync([FromQuery] FindAllParasiteEnergiesRequestQuery query)
        {
            var result = await _mediator.Send(query);

            return ResponseOk(result);
        }

        /// <summary>
        /// Get a parasite energy by id from the database
        /// </summary>
        /// <param name="query"></param>
        /// <returns>Returns a valid parasite energy</returns>
        /// <response code="200">Returns Success</response>
        /// <response code="400">Returns BadRequest if the parasite energy is not found</response> 
        [HttpGet("{id}")]
        public async Task<IActionResult> FindOneAsync([FromRoute] FindParasiteEnergyByIdRequestQuery query)
        {
            var result = await _mediator.Send(query);

            return ResponseOk(result);
        }
    }
}
