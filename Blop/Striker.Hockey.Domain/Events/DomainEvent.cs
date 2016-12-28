using System;

namespace Striker.Hockey.Domain.Events
{
    public abstract class DomainEvent
    {
        protected DomainEvent(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}