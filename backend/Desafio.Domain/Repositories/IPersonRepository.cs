using Desafio.Domain.DataTransferObjects;
using Desafio.Domain.Models;
using Desafio.EntityFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.Repositories
{
    public interface IPersonRepository : ICommonRepository<PersonModel>
    {
        PageableResult<PersonModel> PageableList(PersonPageableListParams searchParams);
    }
}
