using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Entities
{
    public class EntityBase
    {
        public EntityState State { get; set; } = EntityState.Unchanged;
    }
}
