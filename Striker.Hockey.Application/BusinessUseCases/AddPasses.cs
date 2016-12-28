using System;
using Striker.Hockey.Domain;

namespace Striker.Hockey.Application.BusinessUseCases
{
    public class AddPasses
    {
        private readonly IPlayerRepository _playerRepository;

        public AddPasses(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public void Execute(Guid playerId, int numberOfPasses)
        {
            var player = _playerRepository.Find(playerId);

            player.AddPassesToStatistics(numberOfPasses);

            _playerRepository.Save(player);
        }
    }
}