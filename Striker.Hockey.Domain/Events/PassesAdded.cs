using System;

namespace Striker.Hockey.Domain.Events
{
    public class PassesAdded : DomainEvent
    {
        public PassesAdded(Guid id, int passes) : base(id)
        {
            Passes = passes;
        }

        public int Passes { get; private set; }
    }
}