using System;

namespace Striker.Hockey.Domain
{
    public class SeasonStatistics
    {
        public SeasonStatistics(int goals = 0, int passes = 0)
        {
            Goals = goals;
            Passes = passes;

            Points = Goals + Passes;
        }

        public int Goals { get; }

        public int Passes { get; }

        public int Points { get; }

        public SeasonStatistics AddGoals(int numberOfGoals)
        {
            if (numberOfGoals < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(numberOfGoals));
            }

            return new SeasonStatistics(Goals + numberOfGoals, Passes);
        }

        public SeasonStatistics AddPasses(int numberOfPasses)
        {
            if (numberOfPasses < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(numberOfPasses));
            }

            return new SeasonStatistics(Goals, Passes + numberOfPasses);
        }
    }
}