using DomainEvent.Domain.Events;
using DomainEvent.Infrastructure.Interfaces;
using System;

namespace DomainEvent.Domain.Handlers
{
    public class WidgetDidSomethingElseDomainEventHandler : IHandles<WidgetDidSomethingElseDomainEvent>
    {
        public void Handle(WidgetDidSomethingElseDomainEvent args)
        {
            //TODO: Do work.
            string test = args.Widget.Name;
        }
    }
}
