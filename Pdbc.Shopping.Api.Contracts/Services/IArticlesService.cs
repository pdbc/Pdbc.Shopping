using System.Threading.Tasks;
using Pdbc.Shopping.Api.Contracts.Requests.Articles;

namespace Pdbc.Shopping.Api.Contracts.Services
{
    public interface IArticlesService
    {
        Task<CreateArticleResponse> Create(CreateArticleRequest request);
    }
}