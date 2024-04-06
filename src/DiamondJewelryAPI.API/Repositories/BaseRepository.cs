using DiamondJewelryAPI.API.Interfaces.Persistence;

using MongoDB.Driver;

namespace DiamondJewelryAPI.API.Repositories;

public abstract class BaseRepository<TModel> : IRepository<TModel> where TModel : class
{
    protected readonly IMongoDatabase Database;
    protected readonly IMongoCollection<TModel> DbSet;

    protected BaseRepository(IMongoContext context)
    {
        Database = context.Database;
        DbSet = Database.GetCollection<TModel>(typeof(TModel).Name.ToLower() + "s");
    }

    public virtual async Task<TModel> Add(TModel obj)
    {
        await DbSet.InsertOneAsync(obj);
        return obj;
    }

    public virtual async Task<TModel> GetById(string id)
    {
        var data = await DbSet.Find(FilterId(id)).SingleOrDefaultAsync();
        return data;
    }

    public virtual async Task<IEnumerable<TModel>> GetAll()
    {
        var all = await DbSet.FindAsync(Builders<TModel>.Filter.Empty);
        return all.ToList();
    }

    public async virtual Task<TModel> Update(string id, TModel obj)
    {
        await DbSet.ReplaceOneAsync(FilterId(id), obj);
        return obj;
    }

    public async virtual Task<bool> Remove(string id)
    {
        var result = await DbSet.DeleteOneAsync(FilterId(id));
        return result.IsAcknowledged;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
    private static FilterDefinition<TModel> FilterId(string key)
    {
        return Builders<TModel>.Filter.Eq("Id", key);
    }

    public Task<List<TModel>> Get()
    {
        throw new NotImplementedException();
    }

    public Task<TModel> Create(TModel model)
    {
        throw new NotImplementedException();
    }

    public Task Delete(string id)
    {
        throw new NotImplementedException();
    }
}
