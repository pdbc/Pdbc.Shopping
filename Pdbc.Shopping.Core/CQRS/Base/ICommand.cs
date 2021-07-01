using MediatR;

namespace Pdbc.Shopping.Core.CQRS
{
    public interface ICommand : IRequest
    {
    }

    public interface ICommand<T> : IRequest<T>
    {
    }


}