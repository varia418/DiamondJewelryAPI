namespace DiamondJewelryAPI.Contracts.Common;

public record Contact(
    string Id,
    string SenderName,
    string SenderEmail,
    string Content
);