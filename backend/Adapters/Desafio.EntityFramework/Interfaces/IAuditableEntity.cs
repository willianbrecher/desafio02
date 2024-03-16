using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.EntityFramework.Interfaces
{
    public interface IAuditableEntity
    {
        DateTimeOffset CreatedAt { get; set; }
        //Guid CreatedBy { get; set; }
        DateTimeOffset? UpdatedAt { get; set; }
        //Guid? UpdatedBy { get; set; }
        DateTimeOffset? IsDeleted { get; set; }
    }
}
