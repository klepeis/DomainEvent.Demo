using DomainEvent.Domain.Events;
using DomainEvent.Infrastructure;

namespace DomainEvent.Domain.Aggregate
{
    public class Widget
    {
        public void DoSomething()
        {
            DomainEvents.Raise(new WidgetDidSomethingDomainEvent());
        }
    }
}
