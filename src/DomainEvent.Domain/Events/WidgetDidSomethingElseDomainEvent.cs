using DomainEvent.Domain.Aggregate;
using DomainEvent.Infrastructure.Interfaces;

namespace DomainEvent.Domain.Events
{
    public class WidgetDidSomethingElseDomainEvent : IDomainEvent
    {
        public Widget Widget { get; set; }

        public WidgetDidSomethingElseDomainEvent()
        {

        }
    }
}
