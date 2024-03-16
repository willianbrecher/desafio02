using Autofac;
using Desafio.Domain.DataTransferObjects;
using Desafio.Domain.Enums;
using Desafio.Domain.Models;
using Desafio.Domain.Repositories;
using Desafio.EntityFramework.Common;
using Desafio.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.EntityFramework.Repositories
{
    public class PersonRepository : CommonRepository<PersonEntity, PersonModel>, IPersonRepository
    {
        public PersonRepository(IComponentContext context) : base(context)
        {
        }

        public PageableResult<PersonModel> PageableList(PersonPageableListParams searchParams)
        {
            var query = Queryable.Where(e => string.IsNullOrEmpty(searchParams.Filter) || e.Name == null || e.Name.ToLower().Contains(searchParams.Filter.ToLower()));

            query = searchParams.OrderBy switch
            {
                PersonPageableListOrderOptions.NAME_DESC => query.OrderByDescending(e => e.Name),
                _ => query.OrderBy(e => e.Name),
            };

            var results = query.Skip(searchParams.Skip).Take(searchParams.PageSize).ToList();

            return new PageableResult<PersonModel>(
                pageSize: searchParams.PageSize,
                currentPage: searchParams.CurrentPage,
                results: results.Select(a => Mapper.Map<PersonModel>(a)).ToList());
        }
    }
}
