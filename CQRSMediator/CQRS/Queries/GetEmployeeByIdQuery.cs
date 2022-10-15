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
        public class GetProductByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, AddEmplyeeDetails>
        {
            private EmployeeContext context;
            public GetProductByIdQueryHandler(EmployeeContext context)
            {
                this.context = context;
            }
            public async Task<AddEmplyeeDetails> Handle(GetEmployeeByIdQuery query, CancellationToken cancellationToken)
            {
                var product = await context.Product.Where(a => a.Id == query.Id).FirstOrDefaultAsync();
                return product;
            }
        }
    }
}
