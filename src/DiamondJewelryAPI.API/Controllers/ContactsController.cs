using BuberDinner.Api.Controllers;

using DiamondJewelryAPI.API.Interfaces.Services;
using DiamondJewelryAPI.API.Models;
using DiamondJewelryAPI.Contracts.Common;

using ErrorOr;

using MapsterMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiamondJewelryAPI.API.Controllers;

public class ContactsController : ApiController
{
    private readonly IContactService _contactService;
    private readonly IMapper _mapper;

    public ContactsController(IContactService contactService, IMapper mapper)
    {
        _contactService = contactService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetContacts()
    {
        ErrorOr<IEnumerable<Contact>> getContactsResult = await _contactService.GetContacts();

        return getContactsResult.Match(
            contacts => Ok(_mapper.Map<IEnumerable<ContactData>>(contacts)),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetContactDetails(string id)
    {
        ErrorOr<Contact> getContactDetailsResult = await _contactService.GetContact(id);

        return getContactDetailsResult.Match(
            contact => Ok(contact),
            errors => Problem(errors)
        );
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> CreateContact(ContactData request)
    {
        Contact contact = _mapper.Map<Contact>(request);
        ErrorOr<Contact> createContactResult = await _contactService.CreateContact(contact);

        return createContactResult.Match(
            contact => Ok(_mapper.Map<ContactData>(contact)),
            errors => Problem(errors));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateContact(ContactData request)
    {
        Contact contact = _mapper.Map<Contact>(request);

        if (contact.Id is null) return BadRequest();

        ErrorOr<Contact> updateContactResult = await _contactService.UpdateContact(contact.Id, contact);

        return updateContactResult.Match(
            contact => Ok(_mapper.Map<ContactData>(contact)),
            errors => Problem(errors));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteContact(string id)
    {
        ErrorOr<Deleted> deleteContactsResult = await _contactService.DeleteContact(id);

        return deleteContactsResult.Match(
            deleted => NoContent(),
            errors => Problem(errors));
    }
}