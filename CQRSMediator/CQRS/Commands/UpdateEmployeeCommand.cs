using CQRSMediator.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSMediator.CQRS.Commands
{
    public class UpdateEmployeeCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNo { get; set; }
        public string EmailAddress { get; set; }

        public class UpdateProductCommandHandler : IRequestHandler<UpdateEmployeeCommand, int>
        {
            private EmployeeContext context;
            public UpdateProductCommandHandler(EmployeeContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(UpdateEmployeeCommand command, CancellationToken cancellationToken)
            {
                var product = context.Product.Where(a => a.Id == command.Id).FirstOrDefault();

                if (product == null)
                {
                    return default;
                }
                else
                {
                    product.Name = command.Name;
                    product.Price = command.Price;
                    product.FirstName = command.FirstName;
                    product.LastName = command.LastName;
                    product.FullName = command.FullName;
                    product.PresentAddress = command.PresentAddress;
                    product.PermanentAddress = command.PermanentAddress;
                    product.City = command.City;
                    product.State = command.State;
                    product.PostalCode = command.PostalCode;
                    product.PhoneNo = command.PhoneNo;
                    product.EmailAddress = command.EmailAddress;
                    await context.SaveChangesAsync();
                    return product.Id;
                }
            }
        }
    }
}
