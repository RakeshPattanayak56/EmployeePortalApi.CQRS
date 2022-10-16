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
    public class GetAllEmployeeQuery : IRequest<IEnumerable<AddEmplyeeDetails>>
    {
        public class GetAllEmployeeQueryHandler : IRequestHandler<GetAllEmployeeQuery, IEnumerable<AddEmplyeeDetails>>
        {
            private EmployeeContext context;
            public GetAllEmployeeQueryHandler(EmployeeContext context)
            {
                this.context = context;
            }
            public async Task<IEnumerable<AddEmplyeeDetails>> Handle(GetAllEmployeeQuery query, CancellationToken cancellationToken)
            {
                var employeeList = await context.Employee.ToListAsync();
                return employeeList;
            }
        }
    }
}
