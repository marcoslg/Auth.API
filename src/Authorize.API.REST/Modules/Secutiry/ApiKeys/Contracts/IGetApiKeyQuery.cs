using Authorize.API.REST.Modules.Secutiry.ApiKeys.Models;
using System.Threading.Tasks;

namespace Authorize.API.REST.Modules.Secutiry.ApiKeys.Contracts
{
    public interface IGetApiKeyQuery
    {
        Task<ApiKey> Execute(string providedApiKey);
    }

}
