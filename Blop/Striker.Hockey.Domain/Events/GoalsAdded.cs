using System;

namespace Striker.Hockey.Domain.Events
{
    public class GoalsAdded : DomainEvent
    {
        public GoalsAdded(Guid aggregateId, int goals) : base(aggregateId)
        {
            Goals = goals;
        }

        public int Goals { get; private set; }
    }
}