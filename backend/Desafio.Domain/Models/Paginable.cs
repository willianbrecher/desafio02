using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.Models
{
    public class Paginable
    {
        public string Filter { get; set; }

        public int PageSize { get; set; }

        public int CurrentPage { get; set; }

        public int Skip => (CurrentPage - 1) * PageSize;
    }
}
