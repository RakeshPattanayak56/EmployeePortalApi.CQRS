using CQRSMediator.CQRS.Commands;
using CQRSMediator.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSMediator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddEmployeeController : ControllerBase
    {
        private IMediator mediator;
        public AddEmployeeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // URL - https://localhost:44378/api/Employee type POST
        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        // URL - https://localhost:44378/api/Employee type GET
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await mediator.Send(new GetAllEmployeeQuery()));
        }

        // URL - https://localhost:44378/api/Employee/{id} type GET
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await mediator.Send(new GetEmployeeByIdQuery { Id = id }));
        }

        // URL - https://localhost:44378/api/Employee/{id} type PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateEmployeeCommand command)
        {
            command.Id = id;
            return Ok(await mediator.Send(command));
        }

        // URL - https://localhost:44378/api/Employee/{id} type Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await mediator.Publish(new Notifications.DeleteEmployeeNotification { EmployeeId = id });
            return Ok(await mediator.Send(new DeleteEmployeeByIdCommand { Id = id }));
        }
    }
}
