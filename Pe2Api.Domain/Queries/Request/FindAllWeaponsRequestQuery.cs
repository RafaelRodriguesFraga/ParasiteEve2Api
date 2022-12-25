using MediatR;
using Pe2Api.Domain.Entities;
using Pe2Api.Domain.Pagination;

namespace Pe2Api.Domain.Queries.Request
{
    public class FindAllWeaponsRequestQuery : IRequest<PaginationResponse<Weapon>> 
    {
        public FindAllWeaponsRequestQuery()
        {

        }
        public FindAllWeaponsRequestQuery(int page, int quantityPerPage)
        {
            Page = page;
            QuantityPerPage = quantityPerPage;
        }

        public int Page { get; set; }
        public int QuantityPerPage { get; set; }
    }
}
