using Pe2Api.Domain.Entities;
using Pe2Api.Domain.Pagination;
using Pe2Api.Domain.Queries.Response;
using Pe2Api.Domain.Repositories.Base;

namespace Pe2Api.Domain.Repositories
{
    public interface IParasiteEnergyReadRepository : IBaseReadRepository<ParasiteEnergy>
    {
        Task<PaginationResponse<ParasiteEnergy>> FindAllAsync(int page, int quantityPerPage);
    }
}
