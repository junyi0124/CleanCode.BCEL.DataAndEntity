using System;

namespace CleanCode.BCEL.BaseEntity
{
    public abstract class EntityBase<TId> where TId : IEquatable<TId>
    {
        public TId Id { get; set; }
    }
}
