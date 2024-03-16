using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.Models
{
    public class PersonModel : EntityModel
    {
        public PersonModel(string name, string cPF, DateTime birthday, DateTimeOffset? disabled, List<PhoneModel>? phones, Guid? id = default) : base(id)
        {
            Name = name;
            CPF = cPF;
            Birthday = birthday;
            Disabled = disabled;
            Phones = phones;
        }

        public string Name { get; private set; }

        public string CPF { get; private set; }

        public DateTime Birthday { get; private set; }

        public DateTimeOffset? Disabled { get; private set; }

        public List<PhoneModel>? Phones { get; private set; }
    }
}
