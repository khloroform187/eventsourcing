using System;
using System.Diagnostics;
using Striker.Hockey.Domain;

namespace Striker.Hockey.Application.BusinessUseCases
{
    public class GetStats
    {
        private readonly IPlayerRepository _playerRepository;

        public GetStats(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public Stats Execute(Guid playerId)
        {
            var start = new Stopwatch();
            start.Start();
            var player = _playerRepository.Find(playerId);
            start.Stop();

            var stats = new Stats
            {
                Goals = player.Goals,
                Passes = player.Passes,
                Points = player.Points,
                FirstName = player.Name.FirstName,
                LastName = player.Name.LastName,
                TimeInMsToFetchData = start.ElapsedMilliseconds
            };

            return stats;
        }
    }
}