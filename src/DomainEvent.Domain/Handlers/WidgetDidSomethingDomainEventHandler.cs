using DomainEvent.Domain.Events;
using DomainEvent.Infrastructure.Interfaces;
using System;

namespace DomainEvent.Domain.Handlers
{
    public class WidgetDidSomethingDomainEventHandler : IHandles<WidgetDidSomethingDomainEvent>
    {
        public void Handle(WidgetDidSomethingDomainEvent args)
        {
            //TODO: Do work.
            string test = args.Widget.Name;
        }
    }
}
