using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.EntityFramework.Interfaces
{
    public interface ICommonEntity
    {
        public Guid Id { get; set; }
    }
}
