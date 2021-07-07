using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Pdbc.Shopping.Data.Repositories;
using Pdbc.Shopping.Domain.Model;
using Pdbc.Shopping.DTO.Articles;

namespace Pdbc.Shopping.Core.CQRS.Articles.Create
{
    public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, CreateArticleResult>
    {
        private readonly IFactory<IArticleCreateDto, Article> _factory;
        private readonly IArticleRepository _repository;

        public CreateArticleCommandHandler(IFactory<IArticleCreateDto, Article> factory, 
                                           IArticleRepository repository)
        {
            _factory = factory;
            _repository = repository;
        }

        public Task<CreateArticleResult> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
        {
            var entity = _factory.Create(request.Article);
            _repository.Insert(entity);

            return Task.FromResult(new CreateArticleResult
            {
                //TODO - how are we going to return the value? Should we return a value?
                //Article = _mapper.MapFrom(entity)
            });
        }
    }
}
