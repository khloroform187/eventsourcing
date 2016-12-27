using System;

namespace Striker.Hockey.Domain
{
    public interface IPlayerRepository
    {
        Player Find(Guid id);

        void Add(Player player);

        void Save(Player player);
    }
}
