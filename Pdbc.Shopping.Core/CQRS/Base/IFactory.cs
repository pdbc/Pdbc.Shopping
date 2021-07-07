namespace Pdbc.Shopping.Core.CQRS
{
    public interface IFactory<TModel, TEntity>
    {
        TEntity Create(TModel model);
    }
}