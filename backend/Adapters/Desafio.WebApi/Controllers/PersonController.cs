using Autofac;
using Desafio.Application.Commands;
using Desafio.Application.Queries.People;
using Desafio.Domain.Models;
using Desafio.WebApi.Commons;
using Microsoft.AspNetCore.Mvc;
using EmptyResult = Desafio.Domain.Models.EmptyResult;

namespace Desafio.WebApi.Controllers
{
    [ApiController]
    [Route("api/people")]
    public class PersonController : CommonController
    {
        public PersonController(IComponentContext context) : base(context) { }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(PersonModel), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 500)]
        public async Task<IActionResult> Find([FromRoute] Guid id, CancellationToken cancellationToken) =>
            Ok(await Mediator.Send(new DetailPersonQuery() { Id = id }, cancellationToken));

        [HttpPost]
        [ProducesResponseType(typeof(PersonModel), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 500)]
        public async Task<IActionResult> Insert([FromBody] CreatePersonCommand command, CancellationToken cancellationToken) =>
            Ok(await Mediator.Send(command, cancellationToken));

        [HttpPut]
        [ProducesResponseType(typeof(PersonModel), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 500)]
        public async Task<IActionResult> Update([FromBody] UpdatePersonCommand command, CancellationToken cancellationToken) =>
            Ok(await Mediator.Send(command, cancellationToken));

        [HttpDelete]
        [ProducesResponseType(typeof(EmptyResult), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 500)]
        public async Task<IActionResult> Delete([FromBody] DeletePersonCommand command, CancellationToken cancellationToken) =>
            Ok(await Mediator.Send(command, cancellationToken));

        [HttpPost]
        [Route("pageable-list")]
        [ProducesResponseType(typeof(PageableResult<PersonModel>), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 500)]
        public async Task<IActionResult> PageableList([FromBody] PageableListPersonQuery query, CancellationToken cancellationToken) =>
            Ok(await Mediator.Send(query, cancellationToken));
    }
}
