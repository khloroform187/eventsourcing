using System;

namespace Striker.Hockey.Domain.Events
{
    public class PlayerCreated : DomainEvent
    {
        public PlayerCreated(Guid id, PlayerName name) 
            : base(id)
        {
            Name = name;
        }

        public PlayerName Name { get; private set; }
    }
}