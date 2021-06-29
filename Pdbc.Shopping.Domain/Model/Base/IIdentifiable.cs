namespace Pdbc.Shopping.Domain.Model
{
    public interface IIdentifiable<TId>
    {
        TId Id { get; set; }
    }

    public abstract class Identifiable : IIdentifiable<long>
    {
        public long Id { get; set; }
    }
}