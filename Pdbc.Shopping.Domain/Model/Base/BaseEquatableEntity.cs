using System;
using Pdbc.Shopping.Domain.Model;

namespace Pdbc.Shopping.Domain.Model
{
    public abstract class BaseEquatableEntity<TEntity> : AuditableIdentifiable, IEquatable<TEntity> where TEntity : Identifiable
    {
        #region Equals
        public virtual bool Equals(TEntity other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(GetHashCode(), other.GetHashCode());
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((TEntity)obj);
        }

        public override int GetHashCode()
        {
            return (Id != null ? Id.GetHashCode() : 0);
        }

        #endregion
    }
}