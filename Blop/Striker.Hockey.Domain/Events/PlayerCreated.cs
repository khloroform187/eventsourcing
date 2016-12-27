using System;

namespace Striker.Hockey.Domain.Events
{
    public class PlayerCreated : DomainEvent
    {
        public PlayerCreated(Guid aggregateId, PlayerName name) 
            : base(aggregateId)
        {
            Name = name;
        }

        public PlayerName Name { get; private set; }
    }
}