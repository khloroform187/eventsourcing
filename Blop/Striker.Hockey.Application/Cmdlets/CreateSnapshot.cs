using System;
using System.Management.Automation;
using System.Net;
using EventStore.ClientAPI;
using Striker.Hockey.Infrastructure;

namespace Striker.Hockey.Application.Cmdlets
{
    [Cmdlet(VerbsCommon.Add, "Snapshot")]
    public class CreateSnapshot : PSCmdlet
    {
        [Parameter(Position = 0, Mandatory = true)]
        public Guid PlayerId { get; set; }

        protected override void BeginProcessing()
        {
            var endpoint = new IPEndPoint(IPAddress.Loopback, 1113);

            using (var connection = EventStoreConnection.Create(endpoint))
            {
                connection.ConnectAsync().Wait();
                var eventStore = new GetEventStore(connection);
                var repository = new PlayerRepository(eventStore);
                var service = new BusinessUseCases.CreateSnapshot(repository);

                service.Execute(PlayerId);
            }
        }
    }
}