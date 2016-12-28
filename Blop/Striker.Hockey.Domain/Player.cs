using System;
using Striker.Hockey.Domain.Events;

namespace Striker.Hockey.Domain
{
    public class Player : EventSourcedAggregate
    {
        private SeasonStatistics _stats;

        public Player()
        {
        }

        public Player(PlayerSnapshot snapshot)
        {
            Version = snapshot.Version;
            //InitialVersion = snapshot.Version;
            Name = new PlayerName(snapshot.FirstName, snapshot.LastName);
            _stats = new SeasonStatistics(snapshot.Goals, snapshot.Passes);
        }

        public Player(Guid id, PlayerName name)
        {
            var playerCreatedEvent = new PlayerCreated(id, name);

            Causes(playerCreatedEvent);
        }

        //public int InitialVersion { get; private set; }

        public PlayerName Name { get; private set; }

        public int Goals => _stats.Goals;

        public int Passes => _stats.Passes;

        public int Points => _stats.Points;

        public void AddGoalsToStatistics(int numberOfGoals)
        {
            var goalsAddedEvent = new GoalsAdded(Id, numberOfGoals);

            Causes(goalsAddedEvent);
        }

        public void AddPassesToStatistics(int numberOfPasses)
        {
            var passesAddedEvent = new PassesAdded(Id, numberOfPasses);

            Causes(passesAddedEvent);
        }

        public override void Apply(DomainEvent changes)
        {
            When((dynamic) changes);
            Version = Version + 1;
        }

        public PlayerSnapshot GetPlayerSnaphot()
        {
            var snapshot = new PlayerSnapshot
            {
                Version = Version,
                FirstName = Name.FirstName,
                LastName = Name.LastName,
                Goals = Goals,
                Passes = Passes
            };

            return snapshot;
        }

        private void Causes(DomainEvent domainEvent)
        {
            Changes.Add(domainEvent);
            Apply(domainEvent);
        }

        private void When(PlayerCreated playerCreatedEvent)
        {
            Id = playerCreatedEvent.Id;
            Name = playerCreatedEvent.Name;
            this._stats = new SeasonStatistics();
        }

        private void When(GoalsAdded goalsAddedEvent)
        {
            if (_stats == null)
            {
                _stats = new SeasonStatistics();
            }

            _stats.AddGoals(goalsAddedEvent.Goals);
        }

        private void When(PassesAdded passesAddedEvent)
        {
            if (_stats == null)
            {
                _stats = new SeasonStatistics();
            }

            _stats.AddPasses(passesAddedEvent.Passes);
        }
    }
}