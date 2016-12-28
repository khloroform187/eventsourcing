using System;
using Striker.Hockey.Domain;

namespace Striker.Hockey.Application.BusinessUseCases
{
    public class AddGoals
    {
        private readonly IPlayerRepository _playerRepository;

        public AddGoals(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public void Execute(Guid playerId, int numberOfGoals)
        {
            var player = _playerRepository.Find(playerId);

            player.AddGoalsToStatistics(numberOfGoals);

            _playerRepository.Save(player);
        }

        public void Execute(Player player, int numberOfGoals)
        {
            player.AddGoalsToStatistics(numberOfGoals);

            _playerRepository.Save(player);
        }
    }
}