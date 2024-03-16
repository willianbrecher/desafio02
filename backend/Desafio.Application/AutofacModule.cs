using Autofac;
using Desafio.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Desafio.Domain.Repositories;
using Desafio.EntityFramework.Repositories;
using Desafio.Application.Interfaces;
using MediatR;
using Desafio.Application.Implementation;
using AutoMapper;
using Desafio.EntityFramework.Entities;
using Desafio.Domain.Models;
using Desafio.Application.Commands;

namespace Desafio.Application
{
    public class AutofacModule : Module
    {
        private readonly IConfiguration Configuration;

        public AutofacModule(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            var applicationAssembly = AppDomain.CurrentDomain.Load($"Desafio.Application");

            #region MediatR

            builder.RegisterType<ApplicationMediator>().As<IApplicationMediator>().InstancePerLifetimeScope();

            var openHandlersTypes = new[] { typeof(IRequestHandler<,>), typeof(INotificationHandler<>) };

            foreach (var openHandlerType in openHandlersTypes)
                builder
                    .RegisterAssemblyTypes(applicationAssembly)
                    .AsClosedTypesOf(openHandlerType)
                    .InstancePerDependency();

            builder.Register<ServiceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            #endregion

            #region Repositories

            builder.RegisterType<PersonRepository>().As<IPersonRepository>().InstancePerLifetimeScope();
            
            #endregion

            #region AutoMapper

            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap(typeof(CreatePersonCommand), typeof(PersonModel));
                cfg.CreateMap(typeof(UpdatePersonCommand), typeof(PersonModel));
                cfg.CreateMap(typeof(PersonModel), typeof(PersonEntity));
                cfg.CreateMap(typeof(PersonEntity), typeof(PersonModel));
                //cfg.CreateMap(typeof(PhoneModel), typeof(PhoneEntity));
                //cfg.CreateMap(typeof(PhoneEntity), typeof(PhoneModel));
            });

            builder.Register(c => mapperConfiguration.CreateMapper()).As<IMapper>().InstancePerLifetimeScope();

            #endregion

            #region EF
            DbContextOptionsBuilder<DesafioDbContext> optionsBuilder = new();

            optionsBuilder.UseSqlite(Configuration["ConnectionStrings:SQLDatabase"], x => x.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "application"));

            builder.Register(x =>
            {
                return new DesafioDbContext(optionsBuilder.Options);
            }).As<DbContext>().InstancePerDependency();
            #endregion
        }
    }
}
