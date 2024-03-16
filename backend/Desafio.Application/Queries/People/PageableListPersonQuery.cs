using Desafio.Application.Interfaces;
using Desafio.Domain.DataTransferObjects;
using Desafio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Application.Queries.People
{
    public class PageableListPersonQuery : PersonPageableListParams, IApplicationQuery<PageableResult<PersonModel>>
    {
    }
}
