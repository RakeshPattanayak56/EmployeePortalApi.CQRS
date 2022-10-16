using CQRSMediator.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSMediator.CQRS.Queries
{
    public class GetEmployeeByIdQuery : IRequest<AddEmplyeeDetails>
    {
        public int Id { get; set; }
        public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, AddEmplyeeDetails>
        {
            private EmployeeContext context;
            public GetEmployeeByIdQueryHandler(EmployeeContext context)
            {
                this.context = context;
            }
            public async Task<AddEmplyeeDetails> Handle(GetEmployeeByIdQuery query, CancellationToken cancellationToken)
            {
                var employee = await context.Employee.Where(a => a.Id == query.Id).FirstOrDefaultAsync();
                return employee;
            }
        }
    }
}
