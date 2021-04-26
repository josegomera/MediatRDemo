using DemoLib.Commads;
using DemoLib.Models;
using DemoLib.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<PersonModel>> Get()
            => await _mediator.Send(new GetPersonListQuery());

        [HttpGet("{id}")]
        public async Task<PersonModel> Get(int id) 
            => await _mediator.Send(new GetPersonByIdQuery(id));

        [HttpPost]
        public async Task<PersonModel> Post([FromBody] PersonModel person) 
            => await _mediator.Send(new InserPersonCommand(person.FirstName, person.LastName));
    }
}
