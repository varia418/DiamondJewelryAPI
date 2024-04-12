using DiamondJewelryAPI.Contracts.Common;

namespace DiamondJewelryAPI.Contracts.Contacts.Responses;

public record GetContactsResponse(
    ContactData[] Contacts
);