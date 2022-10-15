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
        public class GetAllProductQueryHandler : IRequestHandler<GetAllEmployeeQuery, IEnumerable<AddEmplyeeDetails>>
        {
            private EmployeeContext context;
            public GetAllProductQueryHandler(EmployeeContext context)
            {
                this.context = context;
            }
            public async Task<IEnumerable<AddEmplyeeDetails>> Handle(GetAllEmployeeQuery query, CancellationToken cancellationToken)
            {
                var productList = await context.Product.ToListAsync();
                return productList;
            }
        }
    }
}
