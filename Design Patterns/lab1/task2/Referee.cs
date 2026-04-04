namespace Task2
{
    public class Referee : IObserver
    {
        private Position ballPosition;
        private FootBall ball;

        public Referee(FootBall ball)
        {
            this.ball = ball;
            ball.AttachObserver(this);
        }

        public void Update()
        {
            ballPosition = ball.GetBallPosition();
            Console.WriteLine($"Referee updated: Ball at {ballPosition}");
        }
    }
}