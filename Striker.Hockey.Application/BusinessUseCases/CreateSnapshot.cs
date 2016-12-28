using System;
using Striker.Hockey.Domain;

namespace Striker.Hockey.Application.BusinessUseCases
{
    public class CreateSnapshot
    {
        private readonly IPlayerRepository _playerRepository;

        public CreateSnapshot(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public void Execute(Guid playerId)
        {
            var player = _playerRepository.Find(playerId);

            var snapshot = player.GetPlayerSnaphot();

            _playerRepository.SaveSnapshot(snapshot);
        }
    }
}