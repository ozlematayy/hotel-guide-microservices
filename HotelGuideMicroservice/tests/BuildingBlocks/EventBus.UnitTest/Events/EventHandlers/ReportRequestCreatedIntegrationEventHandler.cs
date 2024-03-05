using EventBus.Base.Abstraction;
using EventBus.UnitTest.Events.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.UnitTest.Events.EventHandlers
{
    public class ReportRequestCreatedIntegrationEventHandler : IIntegrationEventHandler<ReportRequestCreatedIntegrationEvent>
    {
        public Task Handle(ReportRequestCreatedIntegrationEvent @event)
        {
            Console.WriteLine("Handle method worked with id: " + @event.Id);
            return Task.CompletedTask;
        }
    }
}
