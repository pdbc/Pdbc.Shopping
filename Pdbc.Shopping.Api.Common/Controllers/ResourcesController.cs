using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pdbc.Shopping.Api.Contracts.Requests.Errors;
using Pdbc.Shopping.Api.Contracts.Requests.Resources.Errors;
using Pdbc.Shopping.Api.Contracts.Services;
using Pdbc.Shopping.Services.Cqrs.Interfaces;

namespace Pdbc.Shopping.Api.Common.Controllers
{
    /// <summary>
    /// Controller for REST API for Diagnostics
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("[controller]")]
    [ApiController]
    public class ResourcesController : ShoppingBaseController
    {
        private readonly IErrorMessagesCqrsService _errorMessagesService;

        public ResourcesController(IErrorMessagesCqrsService errorMessagesService)
        {
            _errorMessagesService = errorMessagesService;
        }


        /// <summary>
        /// Gets the translations for the errors in the specific language.
        /// </summary>
        /// <param name="request">The Request.</param>
        /// <returns>Returns a dictionary with all possible error keys and translations in the chosen language</returns>
        [HttpGet("errors/{Language}")]
        [ProducesResponseType(typeof(ListErrorMessagesResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ListErrorMessagesResponse>> ListErrorMessages([FromRoute] ListErrorMessagesRequest request)
        {
            var response = await _errorMessagesService.ListErrorMessages(request);
            return base.Ok(response);
        }

        /// <summary>
        /// Gets the translations for a specific error key in the specific language.
        /// </summary>
        /// <param name="request">The messageRequest.</param>
        /// <returns>Returns the translated full text of the error code if found or null.</returns>
        [HttpGet("errors/{Language}/{Key}")]
        [ProducesResponseType(typeof(GetErrorMessageResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetErrorMessageResponse>> GetErrorMessage([FromRoute] GetErrorMessageRequest request)
        {
            var response = await _errorMessagesService.GetErrorMessage(request);
            return base.Ok(response);
        }
    }
}