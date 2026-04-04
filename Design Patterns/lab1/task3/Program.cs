using System;

namespace Task3
{
    public class Program
    {
        public static void Main()
        {
            Team team = new Team(new AttackStrategy());
            team.PlayGame();
            
            team.SetStrategy(new DefendStrategy());
            team.PlayGame();
        }
    }
}