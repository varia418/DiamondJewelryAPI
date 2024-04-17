using DiamondJewelryAPI.API.Interfaces.Persistence.Repositories;
using DiamondJewelryAPI.API.Interfaces.Services;
using DiamondJewelryAPI.API.Models;

using ErrorOr;


namespace DiamondJewelryAPI.API.Services;

public class ContactService : IContactService
{
    private readonly IContactRepository _contactRepository;

    public ContactService(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public async Task<ErrorOr<Contact>> CreateContact(Contact contact)
    {
        return await _contactRepository.Create(contact);
    }

    public async Task<ErrorOr<Deleted>> DeleteContact(string id)
    {
        await _contactRepository.Delete(id);
        return Result.Deleted;
    }

    public async Task<ErrorOr<Contact>> GetContact(string id)
    {
        return await _contactRepository.GetById(id);
    }

    public async Task<ErrorOr<IEnumerable<Contact>>> GetContacts()
    {
        return await _contactRepository.GetAll();
    }

    public async Task<ErrorOr<Contact>> UpdateContact(string id, Contact contact)
    {
        return await _contactRepository.Update(id, contact);
    }
}