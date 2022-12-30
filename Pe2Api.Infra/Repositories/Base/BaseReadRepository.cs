using System.Linq.Expressions;
using MongoDB.Bson;
using MongoDB.Driver;
using Pe2Api.Domain.Entities.Base;
using Pe2Api.Domain.Repositories.Base;
using Pe2Api.Infra.DbSettings;

namespace Pe2Api.Infra.Repositories.Base
{
    public class BaseReadRepository<TEntity> : IBaseReadRepository<TEntity> where TEntity : class, IBaseEntity
    {
        protected readonly IMongoCollection<TEntity> _collection;
        public BaseReadRepository(IMongoSettings settings)
        {
            var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);

            _collection = database.GetCollection<TEntity>(typeof(TEntity).Name);
        }
      
        public IQueryable<TEntity> AsQueryable()
        {
            return _collection.AsQueryable();
        }

        public TEntity FindById(Guid id)
        {
            var filter = Builders<TEntity>.Filter.Eq(doc => doc.Id, id);

            return _collection.Find(filter).SingleOrDefault();

        }

        public async Task<TEntity> FindByIdAsync(Guid id)
        {
            var filter = Builders<TEntity>.Filter.Eq(doc => doc.Id, id);

            return await _collection.Find(filter).SingleOrDefaultAsync();   

        }

        public TEntity FindOne(Expression<Func<TEntity, bool>> filterExpression)
        {
            return _collection.Find(filterExpression).FirstOrDefault();
        }

        public async Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>> filterExpression)
        {
            return await _collection.Find(filterExpression).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> FindAllAsync()
        {
            var filter = Builders<TEntity>.Filter.Empty;

            return await _collection.Find(filter).ToListAsync();
        }  
        
        public IEnumerable<TEntity> FindAll()

        {
            var filter = Builders<TEntity>.Filter.Empty;

            return _collection.Find(filter).ToList();
        }  
    }
}