using DiamondJewelryAPI.API.Models;

using ErrorOr;

namespace DiamondJewelryAPI.API.Interfaces.Services;

public interface IContactService
{
    Task<ErrorOr<IEnumerable<Contact>>> GetContacts();
    Task<ErrorOr<Contact>> GetContact(string id);
    Task<ErrorOr<Contact>> CreateContact(Contact contact);
    Task<ErrorOr<Contact>> UpdateContact(string id, Contact contact);
    Task<ErrorOr<Deleted>> DeleteContact(string id);
}