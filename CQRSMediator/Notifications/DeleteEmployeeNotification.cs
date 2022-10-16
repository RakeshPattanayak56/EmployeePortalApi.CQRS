using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSMediator.Notifications
{
    public class DeleteEmployeeNotification : INotification
    {
        public int EmployeeId { get; set; }
    }

    public class EmailHandler : INotificationHandler<DeleteEmployeeNotification>
    {
        public Task Handle(DeleteEmployeeNotification notification, CancellationToken cancellationToken)
        {
            int id = notification.EmployeeId;
            // send email to customers
            return Task.CompletedTask;
        }
    }

    public class SMSHandler : INotificationHandler<DeleteEmployeeNotification>
    {
        public Task Handle(DeleteEmployeeNotification notification, CancellationToken cancellationToken)
        {
            int id = notification.EmployeeId;
            //send sms to sales team
            return Task.CompletedTask;
        }
    }
}
