namespace DiamondJewelryAPI.API.Models;

public interface IDiamondJewelryDBSettings
{
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
}

public class DiamondJewelryDBSettings : IDiamondJewelryDBSettings
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
}