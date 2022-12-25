using MediatR;
using Pe2Api.Domain.Entities;

namespace Pe2Api.Domain.Queries.Request
{
    public class FindArmorByIdRequestQuery : IRequest<Armor>
    {
        public FindArmorByIdRequestQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id {get; set;}
    }
}
