using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.Models
{
    public class PageableResult<TResult>
    {
        public PageableResult(int pageSize, int currentPage, List<TResult> results)
        {
            PageSize = pageSize;
            CurrentPage = currentPage;
            Results = results ?? throw new ArgumentNullException(nameof(results));
        }

        public int PageSize { get; }

        public int CurrentPage { get; }

        public List<TResult> Results { get; }
    }
}
