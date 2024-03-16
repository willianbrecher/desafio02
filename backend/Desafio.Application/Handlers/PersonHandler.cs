using AutoMapper;
using Desafio.Application.Commands;
using Desafio.Application.Interfaces;
using Desafio.Application.Queries.People;
using Desafio.Domain.Models;
using Desafio.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Application.Handlers
{
    public class PersonHandler : IApplicationCommandHandler<CreatePersonCommand, PersonModel>,
        IApplicationCommandHandler<UpdatePersonCommand, PersonModel>,
        IApplicationCommandHandler<DeletePersonCommand, EmptyResult>,
        IApplicationQueryHandler<DetailPersonQuery, PersonModel>,
        IApplicationQueryHandler<PageableListPersonQuery, PageableResult<PersonModel>>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonHandler(IMapper mapper, IPersonRepository personRepository)
        {
            _mapper = mapper;
            _personRepository = personRepository;
        }

        public Task<PersonModel> Handle(CreatePersonCommand command, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<PersonModel>(command);

            _personRepository.Save(model);

            return Task.FromResult(model);
        }

        public Task<PersonModel> Handle(UpdatePersonCommand command, CancellationToken cancellationToken)
        {
            
            var model = _mapper.Map<PersonModel>(command);

            PersonModel dbPerson = _personRepository.Get(model.Id);
            
            if (dbPerson != null)
            {
                _personRepository.Save(model);
            }

            return Task.FromResult(model);
        }

        public Task<EmptyResult> Handle(DeletePersonCommand command, CancellationToken cancellationToken)
        {
            PersonModel dbPerson = _personRepository.Get(command.Id);

            if (dbPerson != null)
            {
                _personRepository.Delete(command.Id);
            }

            return Task.FromResult(new EmptyResult());
        }

        public Task<PersonModel> Handle(DetailPersonQuery query, CancellationToken cancellationToken)
        {
            PersonModel dbPerson = _personRepository.Get(query.Id);

            return Task.FromResult(dbPerson);
        }

        public Task<PageableResult<PersonModel>> Handle(PageableListPersonQuery query, CancellationToken cancellationToken)
        {
            PageableResult<PersonModel> results = _personRepository.PageableList(query);

            var result = new PageableResult<PersonModel>(
                pageSize: query.PageSize,
                currentPage: query.CurrentPage,
                results: results.Results
            );

            return Task.FromResult(result);
        }
    }
}
