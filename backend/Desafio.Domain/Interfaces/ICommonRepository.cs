using Desafio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.EntityFramework.Interfaces
{
    public interface ICommonRepository<T> where T : EntityModel
    {
        public void Insert(T obj);

        public void Save(T obj);

        //public void Save(List<T> objs);

        public void InsertOrReplace(T obj);

        public void Delete(Guid id);

        public T Get(Guid id);

        //public List<T> Get(List<Guid> ids);

        public List<T> List();

        //public bool Exists(Guid id);
    }
}
