using System;

namespace Task2
{
    public class Program
    {
        public static void Main()
        {
            FootBall ball = new FootBall();

            Player player = new Player(ball);
            Referee referee = new Referee(ball);

            ball.SetBallPosition(new Position(1, 2, 3));
            ball.SetBallPosition(new Position(4, 5, 6));
        }
    }
}
