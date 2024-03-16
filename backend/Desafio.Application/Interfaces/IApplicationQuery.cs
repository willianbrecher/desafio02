﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Application.Interfaces
{
    public interface IApplicationQuery<TRequest> : IRequest<TRequest>
    {
    }
}
