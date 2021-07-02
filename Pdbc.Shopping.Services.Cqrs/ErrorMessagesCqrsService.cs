using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Pdbc.Shopping.Api.Contracts.Requests.Errors;
using Pdbc.Shopping.Api.Contracts.Requests.Resources.Errors;
using Pdbc.Shopping.Api.Contracts.Services;
using Pdbc.Shopping.Common.Validation;
using Pdbc.Shopping.Core.CQRS.Resources.Errors.Get;
using Pdbc.Shopping.Core.CQRS.Resources.Errors.List;
using Pdbc.Shopping.Services.Cqrs.Base;
using Pdbc.Shopping.Services.Cqrs.Interfaces;

namespace Pdbc.Shopping.Services.Cqrs
{
    public class ErrorMessagesCqrsService : CqrsService, IErrorMessagesCqrsService, IErrorMessagesService
    {
        public ErrorMessagesCqrsService(IMediator mediator, IMapper mapper, ValidationBag validationBag) 
            : base(mediator, mapper, validationBag)
        {
        }

        public async Task<ListErrorMessagesResponse> ListErrorMessages(ListErrorMessagesRequest request)
        {
            return await Query<ListErrorMessagesRequest, ListErrorMessagesQuery, 
                               ListErrorMessagesViewModel, ListErrorMessagesResponse>(request);
         
        }

        public async Task<GetErrorMessageResponse> GetErrorMessage(GetErrorMessageRequest messageRequest)
        {
            return await Query<GetErrorMessageRequest, GetErrorMessageQuery,
                               GetErrorMessageViewModel, GetErrorMessageResponse>(messageRequest);
        }
    }
}
