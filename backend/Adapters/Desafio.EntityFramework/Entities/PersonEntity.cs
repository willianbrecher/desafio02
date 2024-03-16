using AutoMapper;
using Desafio.Domain.Models;
using Desafio.EntityFramework.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.EntityFramework.Entities
{
    [AutoMap(typeof(PersonModel))]
    public class PersonEntity : AuditableEntity
    {
        public string Name { get; set; }

        public string CPF { get; set; }

        public DateTime Birthday { get; set; }

        public DateTimeOffset? Disabled { get; set; }

        public string PhonesJson { get; set; }

        [NotMapped]
        public List<PhoneModel> Phones {

            get { return string.IsNullOrEmpty(PhonesJson) ? null : JsonConvert.DeserializeObject<List<PhoneModel>>(PhonesJson); }
           
            set { PhonesJson = JsonConvert.SerializeObject(value) ;}

        }
    }
}
