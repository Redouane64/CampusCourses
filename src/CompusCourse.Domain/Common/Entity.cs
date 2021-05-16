using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompusCourse.Domain.Common
{
    public abstract class Entity : IEntity
    {
        public virtual string Id { get; protected set; }
    }
}
