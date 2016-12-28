using System;
using System.Management.Automation;
using System.Net;
using EventStore.ClientAPI;
using Striker.Hockey.Infrastructure;

namespace Striker.Hockey.Application.Cmdlets
{
    [Cmdlet(VerbsCommon.Add, "Passes")]
    public class AddPasses : PSCmdlet
    {
        [Parameter(Position = 0, Mandatory = true)]
        public Guid PlayerId { get; set; }

        [Parameter(Position = 1, Mandatory = true)]
        public int Passes { get; set; }

        protected override void BeginProcessing()
        {
            var endpoint = new IPEndPoint(IPAddress.Loopback, 1113);

            using (var connection = EventStoreConnection.Create(endpoint))
            {
                connection.ConnectAsync().Wait();
                var eventStore = new GetEventStore(connection);
                var repository = new PlayerRepository(eventStore);
                var service = new BusinessUseCases.AddPasses(repository);

                service.Execute(PlayerId, Passes);
            }
        }
    }
}