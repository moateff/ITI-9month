namespace Task2
{
    public class FootBall : Ball
    {
        private Position myposition;

        public Position GetBallPosition()
        {
            return myposition;
        }

        public void SetBallPosition(Position p)
        {
            myposition = p;
            NotifyObservers(); // notify all observers
        }
    }
}