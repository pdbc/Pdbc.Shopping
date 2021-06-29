namespace Pdbc.Shopping.Domain.Model
{
    public abstract class BaseEntity : AuditableIdentifiable // Identifiable, ICreatable
    {
        public override string ToString()
        {
            return $"{this.GetType().Name} - {Id}";
        }
    }
}