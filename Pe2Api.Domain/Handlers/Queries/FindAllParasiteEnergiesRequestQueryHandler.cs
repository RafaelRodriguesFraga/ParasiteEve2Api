using MediatR;
using Pe2Api.Domain.Entities;
using Pe2Api.Domain.Pagination;
using Pe2Api.Domain.Queries.Request;
using Pe2Api.Domain.Queries.Response;
using Pe2Api.Domain.Repositories;

namespace Pe2Api.Domain.Handlers.Queries
{
    public class FindAllParasiteEnergiesRequestQueryHandler : IRequestHandler<FindAllParasiteEnergiesRequestQuery, PaginationResponse<ParasiteEnergy>>
    {
        private readonly IParasiteEnergyReadRepository _parasiteEnergyReadRepository;

        public FindAllParasiteEnergiesRequestQueryHandler(IParasiteEnergyReadRepository parasiteEnergyReadRepository)
        {
            _parasiteEnergyReadRepository = parasiteEnergyReadRepository;
        }

        public async Task<PaginationResponse<ParasiteEnergy>> Handle(FindAllParasiteEnergiesRequestQuery request, CancellationToken cancellationToken)
        {
            var result = await _parasiteEnergyReadRepository.FindAllAsync(request.Page, request.QuantityPerPage);
            
            return new PaginationResponse<ParasiteEnergy>(result.Data, result.CurrentPage, result.TotalPages, result.TotalRecords);
        }     
    }
}
