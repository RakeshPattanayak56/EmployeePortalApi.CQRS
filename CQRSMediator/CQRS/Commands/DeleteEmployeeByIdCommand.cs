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
    public class DeleteEmployeeByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteEmployeeByIdCommand, int>
        {
            private EmployeeContext context;
            public DeleteProductByIdCommandHandler(EmployeeContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(DeleteEmployeeByIdCommand command, CancellationToken cancellationToken)
            {
                var product = await context.Product.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                context.Product.Remove(product);
                await context.SaveChangesAsync();
                return product.Id;
            }
        }
    }
}
