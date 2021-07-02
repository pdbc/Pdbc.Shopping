using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Pdbc.Music.Core.CQRS.ErrorMessages.Get;
using Pdbc.Shopping.Common.Extensions;
using Pdbc.Shopping.I18N;

namespace Pdbc.Shopping.Core.CQRS.Resources.Errors.Get
{
    public class GetErrorMessageQueryHandler : IRequestHandler<GetErrorMessageQuery, GetErrorMessageViewModel>
    {
        public Task<GetErrorMessageViewModel> Handle(GetErrorMessageQuery request, CancellationToken cancellationToken)
        {
            var result = new GetErrorMessageViewModel()
            {
                Message = ErrorResources.ResourceManager.GetResourceByKey(request.Key, request.Language)
            };

            return Task.FromResult(result);
        }
    }
}