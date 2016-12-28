using System;

namespace Striker.Hockey.Domain
{
    public class PlayerSnapshot
    {
        public int Version { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Goals { get; set; }

        public int Passes { get; set; }

        public Guid Id { get; set; }
    }
}