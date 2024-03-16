using AutoMapper;
using Desafio.Application.Interfaces;
using Desafio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Application.Commands
{
    [AutoMap(typeof(PersonModel))]
    public class CreatePersonCommand : IApplicationCommand<PersonModel>
    {
 
        public string Name { get; set; }

        public string CPF { get; set; }

        public DateTime Birthday { get; set; }

        public DateTimeOffset? Disabled { get; set; }

        public List<PhoneModel>? Phones { get; set; }
    }
}
