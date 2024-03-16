using Autofac;
using AutoMapper;
using Desafio.Domain.Models;
using Desafio.EntityFramework.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.EntityFramework.Common
{
    public class CommonRepository<TEntity, TDomain> where TEntity : class, ICommonEntity where TDomain : EntityModel
    {
        private readonly IQueryable<TEntity> _queryable;
        protected DbContext Context { get; set; }
        protected DbSet<TEntity> DbSet { get; set; }
        protected IQueryable<TEntity> Queryable => AddInclude(_queryable);
        protected virtual IQueryable<TEntity> AddInclude(IQueryable<TEntity> queryable) => queryable;
        protected IMapper Mapper { get; }

        public CommonRepository(IComponentContext context)
        {
            Context = context.Resolve<DbContext>();
            DbSet = Context.Set<TEntity>();
            Mapper = context.Resolve<IMapper>();

            _queryable = DbSet;
        }

        public TEntity GetTrackedEntity(Guid id)
        {
            return Queryable.Where(e => e.Id == id).AsTracking().FirstOrDefault();
        }

        public TDomain Get(Guid id)
        {
            TEntity dbEntity;

            dbEntity = Queryable.FirstOrDefault(e => e.Id == id);

            if (dbEntity != null) return Mapper.Map<TDomain>(dbEntity);

            return default;
        }

        public List<TDomain> List()
        {
            return Queryable.Select(e => Mapper.Map<TDomain>(e)).ToList();
        }

        public void InsertOrReplace(TDomain obj)
        {
            Save(obj);
        }

        public void Save(TDomain obj)
        {
            var db = GetTrackedEntity(obj.Id);

            if (db == null)
            {

                var e = Mapper.Map<TEntity>(obj);
                DbSet.Add(e);
            }
            else
            {
                var cEntity = Mapper.Map<TEntity>(obj);


                Context.Entry(db).CurrentValues.SetValues(cEntity);
            }

            Context.SaveChanges();
        }

        public void Insert(TDomain obj)
        {
            DbSet.Add(Mapper.Map<TEntity>(obj));
            Context.SaveChanges();
        }
        public void Delete(Guid id)
        {
            var dbObject = GetTrackedEntity(id);

            if (dbObject != null) Context.Entry(dbObject).State = EntityState.Deleted;

            Context.SaveChanges();
        }
    }
}
