using MongoDB.Driver;
using Pe2.Infra.DbSettings;
using Pe2.Infra.Repositories.Base;
using Pe2Api.Domain.Entities;
using Pe2Api.Domain.Pagination;
using Pe2Api.Domain.Queries.Response;
using Pe2Api.Domain.Repositories;

namespace Pe2.Infra.Repositories
{
    public class ParasiteEnergyReadRepository : BaseReadRepository<ParasiteEnergy>, IParasiteEnergyReadRepository
    {
        private readonly IMongoCollection<ParasiteEnergy> _collection;
        public ParasiteEnergyReadRepository(IMongoSettings settings) : base(settings)
        {
            var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);           

            _collection = database.GetCollection<ParasiteEnergy>("ParasiteEnergy");
        }

        public async Task<PaginationResponse<ParasiteEnergy>> FindAllAsync(int page, int quantityPerPage)
        {
            var filter = Builders<ParasiteEnergy>.Filter.Empty;
           var skip = (page - 1) * quantityPerPage;

            var parasiteEnergies = await _collection
                .Find(filter)
                .ToListAsync();                

            var orderedParasiteEnergies = parasiteEnergies
                .OrderBy(x => x.Type)
                .AsEnumerable()
                .Skip(skip)
                .Take(quantityPerPage);

            var currentPage = page;    
            var totalRecords = parasiteEnergies.Count;
            var totalPages = ((double)totalRecords / (double)quantityPerPage);
            var totalPagesCeiling = Math.Ceiling(totalPages);
            var totalPagesRounded = Convert.ToInt32(totalPagesCeiling);

            return new PaginationResponse<ParasiteEnergy>(orderedParasiteEnergies, currentPage, totalPagesRounded, totalRecords);
                
                
        }
    }
}
