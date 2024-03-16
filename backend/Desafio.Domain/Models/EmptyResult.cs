using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.Models
{
    public class EmptyResult
    {
        public static EmptyResult New => new EmptyResult();

        public static Task<EmptyResult> NewTask => Task.FromResult(new EmptyResult());
    }
}
