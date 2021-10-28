using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.BCEL.DataAndEntity
{
    public abstract class EntityBase<TId> where TId : IComparable
    {
        public TId Id { get; set; }
    }
}
