using System;

namespace Task4
{
    public class Program
    {
        public static void Main()
        {
            // Base player
            Player player = new FieldPlayer();

            // Add Forward role
            Forward forwardPlayer = new Forward(player);
            forwardPlayer.PassBall();
            forwardPlayer.ShootGoal();

            Console.WriteLine();

            // Add Midfielder role on top of Forward
            MidFielder midPlayer = new MidFielder(forwardPlayer);
            midPlayer.PassBall();
            midPlayer.Dribble();

            Console.WriteLine();

            // Add Defender role dynamically
            Defender fullPlayer = new Defender(midPlayer);
            fullPlayer.PassBall();
            fullPlayer.Defend();
        }
    }
}