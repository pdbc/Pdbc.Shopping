using MediatR;

namespace Pdbc.Shopping.Core.CQRS
{
    public interface IQuery
    {

    }

    public interface IQuery<T> : IRequest<T>, IQuery
    {
    }
}