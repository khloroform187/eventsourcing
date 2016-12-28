using System;
using Striker.Hockey.Domain;

namespace Striker.Hockey.Application.BusinessUseCases
{
    public class CreatePlayer
    {
        private readonly IPlayerRepository _playerRepository;

        public CreatePlayer(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public void Execute(Guid playerId, string firstName, string lastName)
        {
            var player = new Player(playerId, new PlayerName(firstName, lastName));

            _playerRepository.Add(player);
        }
    }
}