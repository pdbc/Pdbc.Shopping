using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Pdbc.Shopping.Api.Contracts.Requests.Articles;
using Pdbc.Shopping.Api.Contracts.Requests.Resources.Errors;
using Pdbc.Shopping.Common.Validation;
using Pdbc.Shopping.Core.CQRS.Articles.Create;
using Pdbc.Shopping.Core.CQRS.Resources.Errors.List;
using Pdbc.Shopping.Services.Cqrs.Base;
using Pdbc.Shopping.Services.Cqrs.Interfaces;

namespace Pdbc.Shopping.Services.Cqrs
{
    public class ArticlesCqrsService : CqrsService, IArticlesCqrsService
    {
        public ArticlesCqrsService(IMediator mediator, IMapper mapper, ValidationBag validationBag) : base(mediator, mapper, validationBag)
        {
        }

        public async Task<CreateArticleResponse> Create(CreateArticleRequest request)
        {
            return await Query<CreateArticleRequest, CreateArticleCommand,
                               CreateArticleResult, CreateArticleResponse>(request);
        }
    }
}