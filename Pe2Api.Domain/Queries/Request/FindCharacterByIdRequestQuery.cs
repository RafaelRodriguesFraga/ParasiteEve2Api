using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pe2Api.Domain.Entities;
using Pe2Api.Domain.Queries.Response;

namespace Pe2Api.Domain.Queries.Request
{
    public class FindCharacterByIdRequestQuery : IRequest<Character>
    {
        public FindCharacterByIdRequestQuery()
        {

        }
        public FindCharacterByIdRequestQuery(Guid id)
        {
            Id = id;
        }

        [FromRoute(Name = "id")]
        public Guid Id { get; set; }
    }
}
