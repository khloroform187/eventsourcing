namespace Striker.Hockey.Domain
{
    public class PlayerName
    {
        public PlayerName(
            string firstName,
            string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }
    }
}