using CQRSMediator.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSMediator.CQRS.Commands
{
    public class DeleteEmployeeByIdCommand : AddEmplyeeDetails,IRequest<int>
    {
        public class DeleteEmployeeByIdCommandHandler : IRequestHandler<DeleteEmployeeByIdCommand, int>
        {
            private EmployeeContext context;
            public DeleteEmployeeByIdCommandHandler(EmployeeContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(DeleteEmployeeByIdCommand command, CancellationToken cancellationToken)
            {
                var employee = await context.Employee.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                context.Employee.Remove(employee);
                await context.SaveChangesAsync();
                return employee.Id;
            }
        }
    }
}
