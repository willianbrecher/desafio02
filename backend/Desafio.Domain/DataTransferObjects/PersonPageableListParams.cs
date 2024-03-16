using Desafio.Domain.Enums;
using Desafio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.DataTransferObjects
{
    public class PersonPageableListParams : PaginableQuery<PersonPageableListOrderOptions>
    {
    }
}
