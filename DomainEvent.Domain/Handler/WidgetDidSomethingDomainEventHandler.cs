﻿using DomainEvent.Domain.Events;
using DomainEvent.Infrastructure.Interfaces;
using System;

namespace DomainEvent.Domain.Handler
{
    public class WidgetDidSomethingDomainEventHandler : IHandles<WidgetDidSomethingDomainEvent>
    {
        public void Handle(WidgetDidSomethingDomainEvent args)
        {
            //TODO: Do work.
            throw new NotImplementedException();
        }
    }
}
