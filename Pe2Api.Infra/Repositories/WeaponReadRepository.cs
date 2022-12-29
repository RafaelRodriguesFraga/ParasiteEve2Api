using MongoDB.Driver;
using Pe2.Infra.DbSettings;
using Pe2.Infra.Repositories.Base;
using Pe2Api.Domain.Entities;
using Pe2Api.Domain.Pagination;
using Pe2Api.Domain.Repositories;

namespace Pe2Api.Infra.Repositories
{
    public class WeaponReadRepository : BaseReadRepository<Weapon>, IWeaponReadRepository
    {
        private readonly IMongoCollection<Weapon> _collection;
        public WeaponReadRepository(IMongoSettings settings) : base(settings)
        {
            var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);

            _collection = database.GetCollection<Weapon>("Weapon");
        }

        public async Task<PaginationResponse<Weapon>> FindAllAsync(int page, int quantityPerPage)
        {
            var filter = Builders<Weapon>.Filter.Empty;
            var skip = (page - 1) * quantityPerPage;

            var weapons = await _collection
                .Find(filter)
                .ToListAsync();

            var orderedWeapons = weapons
                .OrderBy(x => x.Type)
                .AsEnumerable()
                .Skip(skip)
                .Take(quantityPerPage);

            var currentPage = page;
            var totalRecords = weapons.Count;
            var totalPages = ((double)totalRecords / (double)quantityPerPage);
            var totalPagesCeiling = Math.Ceiling(totalPages);
            var totalPagesRounded = Convert.ToInt32(totalPagesCeiling);

            return new PaginationResponse<Weapon>(orderedWeapons, currentPage, totalPagesRounded, totalRecords);
        }
    }
}
