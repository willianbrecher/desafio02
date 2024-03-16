using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Application.Interfaces
{
    public interface IApplicationCommandHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        new Task<TResponse> Handle(TRequest command, CancellationToken cancellationToken);
    }
}
