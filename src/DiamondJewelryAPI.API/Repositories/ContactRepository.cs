using DiamondJewelryAPI.API.Interfaces.Persistence;
using DiamondJewelryAPI.API.Interfaces.Persistence.Repositories;
using DiamondJewelryAPI.API.Models;

namespace DiamondJewelryAPI.API.Repositories;

public class ContactRepository : BaseRepository<Contact>, IContactRepository
{
    public ContactRepository(IMongoContext context) : base(context)
    {
    }
}