using Desafio.EntityFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.EntityFramework.Common
{
    public class CommonEntity : ICommonEntity
    {
        [Key] 
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
