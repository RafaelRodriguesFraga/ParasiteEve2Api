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

        /// <summary>
        /// Insert an armor in the database
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Returns a valid armor</returns>
        /// <response code="201">Returns Created if an armor is succefully inserted</response>
        /// <response code="400">Returns BadRequest if there's any validation errors</response>
        [HttpPost]
        public async Task<IActionResult> InsertAsync(CreateArmorRequestCommand command)
        {
            var result = await _mediator.Send(command);

            return ResponseCreated(result);
        }

        /// <summary>
        ///  Get all armors from the database
        /// </summary>
        /// <returns>Returns all armors</returns>
        /// <response code="200">Returns Success</response>
        [HttpGet]
        public async Task<IActionResult> FindAllAsync()
        {
            var result = await _mediator.Send(new FindAllArmorsRequestQuery());

            return ResponseOk(result);
        }

        /// <summary>
        /// Get an armor by id from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a valid armor</returns>
        /// <response code="200">Returns Success</response>
        /// <response code="400">Returns BadRequest if the armor is not found</response> 
        [HttpGet("{id}")]
        public async Task<IActionResult> FindByIdAsync(Guid id)
        {
            var result = await _mediator.Send(new FindArmorByIdRequestQuery(id));

            return ResponseOk(result);
        }
    }
}