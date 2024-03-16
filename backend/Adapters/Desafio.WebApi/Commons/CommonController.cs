using Autofac;
using Desafio.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.WebApi.Commons
{
    public abstract class CommonController : ControllerBase
    {
        protected IApplicationMediator Mediator { get; }
        protected IComponentContext Context { get; }

        protected CommonController(IComponentContext context)
        {
            Mediator = context.Resolve<IApplicationMediator>();
        }
    }
}
