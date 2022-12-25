using MediatR;
using Pe2Api.Domain.Entities;
using Pe2Api.Domain.Pagination;

namespace Pe2Api.Domain.Queries.Request
{
    public class FindAllParasiteEnergiesRequestQuery : IRequest<PaginationResponse<ParasiteEnergy>>
    {
        public FindAllParasiteEnergiesRequestQuery()
        {

        }

        public FindAllParasiteEnergiesRequestQuery(int page, int quantityPerPage)
        {
            Page = page;
            QuantityPerPage = quantityPerPage;
        }

        public int Page { get; set; }
        public int QuantityPerPage { get; set; }

    }
}
