using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EventStore.ClientAPI;
using Striker.Hockey.Infrastructure;

namespace Striker.Hockey.Application.Cmdlets
{
    [Cmdlet(VerbsCommon.Add, "Stats")]
    public class AddBatchStats : PSCmdlet
    {
        [Parameter(Position = 0, Mandatory = true)]
        public Guid PlayerId { get; set; }

        [Parameter(Position = 1, Mandatory = true)]
        public int Goals { get; set; }

        [Parameter(Position = 2, Mandatory = true)]
        public int Passes { get; set; }

        protected override void BeginProcessing()
        {
            var endpoint = new IPEndPoint(IPAddress.Loopback, 1113);

            using (var connection = EventStoreConnection.Create(endpoint))
            {
                connection.ConnectAsync().Wait();
                var eventStore = new GetEventStore(connection);
                var repository = new PlayerRepository(eventStore);
                var goalsService = new BusinessUseCases.AddGoals(repository);
                var passesService = new BusinessUseCases.AddPasses(repository);

                for (var i = 0; i < Goals; i++)
                {
                    goalsService.Execute(PlayerId, 1);
                }

                for (var i = 0; i < Passes; i++)
                {
                    passesService.Execute(PlayerId, 1);
                }
            }
        }
    }
}
