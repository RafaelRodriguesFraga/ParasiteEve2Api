using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pe2Api.Api.Controllers.Base;
using Pe2Api.Api.Controllers.Responses;
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

        /// <summary>
        /// Insert a weapon in the database
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Returns a valid weapon</returns>
        /// <response code="201">Returns Created if a weapon is succefully inserted</response>
        /// <response code="400">Returns BadRequest if there's any validation errors</response>
        [HttpPost]
        public async Task<IActionResult> InsertAsync(CreateWeaponRequestCommand command)
        {
            var result = await _mediator.Send(command);

            return ResponseCreated(result);
        }

        /// <summary>
        ///  Get all weapons from the database
        /// </summary>
        /// <returns>Returns all weapons</returns>
        /// <response code="200">Returns Success</response>
        [HttpGet]
        public async Task<IActionResult> FindAllAsync([FromQuery] FindAllWeaponsRequestQuery query)
        {
            var result = await _mediator.Send(query);

            return ResponseOk(result);
        }


        /// <summary>
        /// Get an weapon by id from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a valid weapon</returns>
        /// <response code="200">Returns Success</response>
        /// <response code="400">Returns BadRequest if the weapon is not found</response> 
        [HttpGet("{id}")]
        public async Task<IActionResult> FindOneAsync([FromRoute] FindWeaponByIdRequestQuery query)
        {
            var result = await _mediator.Send(query);

            return ResponseOk(result);
        }
    }
}
