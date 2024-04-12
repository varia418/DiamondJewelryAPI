using System.Net;

namespace DiamondJewelryAPI.API.Common.Errors;

public interface IServiceException
{
    public HttpStatusCode StatusCode { get; }
    public string ErrorMessage { get; }
}