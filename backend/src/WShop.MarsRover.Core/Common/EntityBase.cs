
using System;

namespace WShop.MarsRover.Core.Common
{
    public abstract class EntityBase
    {
        /// <summary>
        ///     Primary key
        /// </summary>
        public virtual Guid Id { get; set; }

        protected virtual object Actual => this;

        public DateTime? DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as EntityBase;

            if (other is null)
                return false;

            if (ReferenceEquals(this, other)) return true;

            if (Actual.GetType() != other.Actual.GetType())
                return false;
            if (Id == default || other.Id == default)
                return false;
            return Id.Equals(other.Id);
        }

        public static bool operator ==(EntityBase a, EntityBase b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(EntityBase a, EntityBase b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (Actual.GetType().ToString() + Id).GetHashCode();
        }
    }
}
