using CQRSMediator.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSMediator.CQRS.Commands
{
    public class UpdateEmployeeCommand : AddEmplyeeDetails, IRequest<int>
    {
        public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, int>
        {
            private EmployeeContext context;
            public UpdateEmployeeCommandHandler(EmployeeContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(UpdateEmployeeCommand command, CancellationToken cancellationToken)
            {
                var employee = context.Employee.Where(a => a.Id == command.Id).FirstOrDefault();

                if (employee == null)
                {
                    return default;
                }
                else
                {
                    employee.FirstName = command.FirstName;
                    employee.LastName = command.LastName;
                    employee.PresentAddress = command.PresentAddress;
                    employee.PermanentAddress = command.PermanentAddress;
                    employee.City = command.City;
                    employee.State = command.State;
                    employee.PostalCode = command.PostalCode;
                    employee.PhoneNo = command.PhoneNo;
                    employee.EmailAddress = command.EmailAddress;
                    await context.SaveChangesAsync();
                    return employee.Id;
                }
            }
        }
    }
}
