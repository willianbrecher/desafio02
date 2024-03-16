using Desafio.Application.Interfaces;
using Desafio.Domain.Models;

namespace Desafio.Application.Queries
{
    public class PageablePeopleListQuery : IApplicationQuery<PageableResult<PersonModel>>
    {
    }
}
