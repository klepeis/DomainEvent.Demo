﻿using DomainEvent.Domain.Aggregate;
using DomainEvent.Infrastructure.Interfaces;

namespace DomainEvent.Domain.Events
{
    public class WidgetDidSomethingDomainEvent : IDomainEvent
    {
        public Widget Widget { get; set; }

        public WidgetDidSomethingDomainEvent()
        {

        }
    }
}
