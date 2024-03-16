using Desafio.Application.Interfaces;
using Desafio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Application.Commands
{
    public class DeletePersonCommand : IApplicationCommand<EmptyResult>
    {
        public Guid Id { get; set; }
    }
}
