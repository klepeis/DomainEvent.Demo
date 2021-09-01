namespace DomainEvent.Infrastructure.Interfaces
{
    public interface IHandles<TEvent> where TEvent : IDomainEvent
    {
        void Handle(TEvent args);
    }
}
