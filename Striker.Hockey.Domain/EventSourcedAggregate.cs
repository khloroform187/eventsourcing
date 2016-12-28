using System;
using System.Collections.Generic;
using Striker.Hockey.Domain.Events;

namespace Striker.Hockey.Domain
{
    public abstract class EventSourcedAggregate
    {
        protected EventSourcedAggregate()
        {
            Changes = new List<DomainEvent>();
        }

        public Guid Id { get; protected set; }

        public List<DomainEvent> Changes { get; private set; }

        public int Version { get; protected set; }

        public abstract void Apply(DomainEvent changes);
    }
}