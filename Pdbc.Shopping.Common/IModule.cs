using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Pdbc.Shopping.Common
{
    public interface IModule
    {
        void Register(IServiceCollection serviceCollection, IConfiguration configuration);
    }
}