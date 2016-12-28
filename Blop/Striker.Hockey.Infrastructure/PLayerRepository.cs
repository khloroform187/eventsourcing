using System;
using Striker.Hockey.Domain;

namespace Striker.Hockey.Infrastructure
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly IEventStore _eventStore;

        public PlayerRepository(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public Player Find(Guid id)
        {
            var streamName = StreamNameFor(id);

            var fromEventNumber = 0;
            const int toEventNumber = int.MaxValue;

            var snapshot = _eventStore.GetLatestSnapshot<PlayerSnapshot>(streamName);
            if (snapshot != null)
            {
                fromEventNumber = snapshot.Version + 1; // load only events after snapshot
            }

            var stream = _eventStore.GetStream(streamName, fromEventNumber, toEventNumber);

            var player = snapshot != null ? new Player(snapshot) : new Player();

            foreach (var domaineEvent in stream)
            {
                player.Apply(domaineEvent);
            }

            return player;
        }

        public void Add(Player player)
        {
            var streamName = StreamNameFor(player.Id);

            _eventStore.CreateNewStream(streamName, player.Changes);
        }

        public void Save(Player player)
        {
            var streamName = StreamNameFor(player.Id);

            var expectedVersion = GetExpectedVersion(player.InitialVersion);
            _eventStore.AppendEventsToStream(streamName, player.Changes, expectedVersion);
        }

        private static string StreamNameFor(Guid id)
        {
            // Stream per-aggregate: {AggregateType}-{AggregateId}
            return $"{typeof (Player).Name}-{id}";
        }

        private static int? GetExpectedVersion(int expectedVersion)
        {
            if (expectedVersion == 0)
            {
                // first time the aggregate is stored there is no expected version
                return null;
            }
            return expectedVersion;
        }
    }
}