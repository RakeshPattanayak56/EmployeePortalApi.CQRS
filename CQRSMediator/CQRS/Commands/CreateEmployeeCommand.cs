using CQRSMediator.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSMediator.CQRS.Commands
{
    public class CreateEmployeeCommand : AddEmplyeeDetails,IRequest<int>
    {
        public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, int>
        {
            private EmployeeContext context;
            public CreateEmployeeCommandHandler(EmployeeContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(CreateEmployeeCommand command, CancellationToken cancellationToken)
            {
                var employee = new AddEmplyeeDetails();
                employee.FirstName = command.FirstName;
                employee.LastName = command.LastName;
                employee.PresentAddress = command.PresentAddress;
                employee.PermanentAddress = command.PermanentAddress;
                employee.City = command.City;
                employee.State = command.State;
                employee.PostalCode = command.PostalCode;
                employee.PhoneNo = command.PhoneNo;
                employee.EmailAddress = command.EmailAddress;

                context.Employee.Add(employee);
                await context.SaveChangesAsync();
                return employee.Id;
            }
        }
    }
}
