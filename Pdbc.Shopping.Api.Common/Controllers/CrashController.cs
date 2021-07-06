using System;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Pdbc.Shopping.Common.Exceptions;
using Pdbc.Shopping.I18N;
using Pdbc.Shopping.Services.Cqrs.Interfaces;

namespace Pdbc.Shopping.Api.Common.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CrashController : ShoppingBaseController
    {
        private readonly ICrashCqrsService _crashService;

        public CrashController(ICrashCqrsService crashService)
        {
            _crashService = crashService;
        }

        /// <summary>
        /// Crashes the API and allows application to test on unexpected API errors
        /// </summary>
        /// <param name="exceptionType">The type of crash you want to be simulate.
        /// <ul>
        ///   <li>0 : ShoppingException </li>
        ///   <li>1 : NullReferenceException </li>
        /// </ul>
        /// </param>
        [HttpGet("{exceptionType}")]
        public void CrashGet([FromRoute] int exceptionType)
        {
            _crashService.CrashGet(exceptionType);
        }

        /// <summary>
        /// Crashes the API and allows application to test on unexpected API errors
        /// </summary>
        [HttpPost()]
        public void CrashPost([FromBody] int exceptionType)
        {
            _crashService.CrashPost(exceptionType);
        }

        

    }
}