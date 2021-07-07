namespace Pdbc.Shopping.Core.CQRS
{
    public interface IChangesHandler<TModel, TEntity>
    {
        void ApplyChanges(TEntity entity, TModel model);
    }
}