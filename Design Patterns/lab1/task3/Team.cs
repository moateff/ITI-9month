using System.Runtime.InteropServices;

namespace Task3
{
    public class Team
    {
        private TeamStrategy _strategy;

        public Team(TeamStrategy strategy)
        {
            _strategy = strategy;
        }

        public void SetStrategy(TeamStrategy strategy)
        {
            _strategy = strategy;
        }

        public void PlayGame()
        {
            Console.Write("Team players are ");
            _strategy.play();
        }
    }
}