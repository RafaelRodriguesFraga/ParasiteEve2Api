using Pe2Api.Domain.Entities;
using Pe2Api.Domain.Pagination;
using Pe2Api.Domain.Repositories.Base;

namespace Pe2Api.Domain.Repositories
{
    public interface IWeaponReadRepository : IBaseReadRepository<Weapon>
    {
        Task<PaginationResponse<Weapon>> FindAllAsync(int page, int quantityPerPage);
    }
}
