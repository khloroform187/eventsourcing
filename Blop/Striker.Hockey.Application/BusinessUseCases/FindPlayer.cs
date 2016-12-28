using System;
using Striker.Hockey.Domain;

namespace Striker.Hockey.Application.BusinessUseCases
{
    public class FindPlayer
    {
        private readonly IPlayerRepository _playerRepository;

        public FindPlayer(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public Player Execute(Guid playerId)
        {
            var player = _playerRepository.Find(playerId);

            return player;
        }
    }
}
