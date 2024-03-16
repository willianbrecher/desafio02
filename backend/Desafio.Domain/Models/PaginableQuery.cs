using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.Models
{
    public class PaginableQuery<TOrderBy> : Paginable where TOrderBy : Enum
    {
        public TOrderBy OrderBy { get; set; }
    }
}
