using System;

namespace Striker.Hockey.Domain.Events
{
    public class GoalsAdded : DomainEvent
    {
        public GoalsAdded(Guid id, int goals) : base(id)
        {
            Goals = goals;
        }

        public int Goals { get; private set; }
    }
}