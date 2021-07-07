using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Pdbc.Shopping.Common.Extensions;
using Pdbc.Shopping.I18N;

namespace Pdbc.Shopping.Core.CQRS.Resources.Errors.List
{
    public class ListErrorMessagesQueryHandler : IRequestHandler<ListErrorMessagesQuery, ListErrorMessagesViewModel>
    {
        public Task<ListErrorMessagesViewModel> Handle(ListErrorMessagesQuery request, CancellationToken cancellationToken)
        {
            var result = new ListErrorMessagesViewModel()
            {
                Resources = ErrorResources.ResourceManager.GetResources(request.Language)
            };

            return Task.FromResult(result);
        }
    }
}