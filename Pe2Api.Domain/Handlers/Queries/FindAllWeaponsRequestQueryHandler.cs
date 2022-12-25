using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pe2Api.Domain.Entities;
using Pe2Api.Domain.Pagination;
using Pe2Api.Domain.Queries.Request;
using Pe2Api.Domain.Repositories;

namespace Pe2Api.Domain.Handlers.Queries
{
    public class FindAllWeaponsRequestQueryHandler : IRequestHandler<FindAllWeaponsRequestQuery, PaginationResponse<Weapon>>
    {
        private readonly IWeaponReadRepository _weaponReadRepository;

        public FindAllWeaponsRequestQueryHandler(IWeaponReadRepository weaponReadRepository)
        {
            _weaponReadRepository = weaponReadRepository;
        }

        public async Task<PaginationResponse<Weapon>> Handle(FindAllWeaponsRequestQuery request, CancellationToken cancellationToken)
        {
            var result = await _weaponReadRepository.FindAllAsync(request.Page, request.QuantityPerPage);

            return new PaginationResponse<Weapon>(result.Data, result.CurrentPage, result.TotalPages, result.TotalRecords);
        }
    }
}
