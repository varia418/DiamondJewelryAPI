using DiamondJewelryAPI.Contracts.Common;

namespace DiamondJewelryAPI.Contracts.Contacts.Responses;

public record GetContactDetailsResponse(
    ContactData Contact
);