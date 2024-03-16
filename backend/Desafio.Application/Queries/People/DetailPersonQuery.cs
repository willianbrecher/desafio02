using Desafio.Application.Interfaces;
using Desafio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Application.Queries.People
{
    public class DetailPersonQuery : IApplicationQuery<PersonModel>
    {
        public Guid Id { get; set; }
    }
}
