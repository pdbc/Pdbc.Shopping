using System.Threading.Tasks;
using Pdbc.Shopping.Api.Contracts.Requests.Health;

namespace Pdbc.Shopping.Api.Contracts.Services
{
    /// <summary>
    /// Service for verifying the health of the api
    /// </summary>
    public interface IHealthCheckService
    {

        /// <summary>
        /// Verifies if the service is running correctly by calling a lifeline (ping) request.  This operation goes through the entire pipeline infrastructure verifying all internal dependencies are setup correctly
        /// </summary>
        /// <param name="request">The messageRequest.</param>
        /// <returns></returns>
        Task<LifelineCheckResponse> LifelineCheck(LifelineCheckRequest request);

    }
}
