using System;

namespace Striker.Hockey.Domain.Events
{
    public abstract class DomainEvent
    {
        protected DomainEvent(Guid aggregateId)
        {
            Id = aggregateId;
        }

        public Guid Id { get; private set; }
    }
}