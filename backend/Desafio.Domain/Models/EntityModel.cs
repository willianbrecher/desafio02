using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.Models
{
    public abstract class EntityModel
    {
        protected EntityModel(Guid? id)
        {
            if (id == null || id == Guid.Empty)
            {
                id = Guid.NewGuid();
            }

            Id = id.Value;
        }

        public virtual Guid Id { get; protected set; }
    }
}
