using DomainEvent.Domain.Events;
using DomainEvent.Infrastructure;

namespace DomainEvent.Domain.Aggregate
{
    public class Widget
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public Widget(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void DoSomething()
        {
            DomainEvents.Raise(new WidgetDidSomethingDomainEvent() { Widget = this });
        }

        public void DoSomethingElse()
        {
            DomainEvents.Raise(new WidgetDidSomethingElseDomainEvent() { Widget = this });
        }
    }
}
