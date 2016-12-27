using System;

namespace Striker.Hockey.Domain.Events
{
    public class PassesAdded : DomainEvent
    {
        public PassesAdded(Guid aggregateId, int passes) : base(aggregateId)
        {
            Passes = passes;
        }

        public int Passes { get; private set; }
    }
}