namespace Task2
{
    public class Player : IObserver
    {
        private Position ballPosition;
        private FootBall ball;

        public Player(FootBall ball)
        {
            this.ball = ball;
            ball.AttachObserver(this);
        }

        public void Update()
        {
            ballPosition = ball.GetBallPosition();
            Console.WriteLine($"Player updated: Ball at {ballPosition}");
        }
    }
}