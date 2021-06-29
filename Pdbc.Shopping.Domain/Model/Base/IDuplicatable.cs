namespace Pdbc.Shopping.Domain.Model
{
    public interface IDuplicatable<TEntity>
    {
        bool IsDuplicate { get; set; }

        //TEntity Master { get; set; }
        //IList<TEntity> Duplicates { get; set; }

        //void MarkAsDuplicate(TEntity masterEntity);
    }
}