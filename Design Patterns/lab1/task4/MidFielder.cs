namespace Task4
{
    public class MidFielder : PlayerRole
    {
        public MidFielder(Player player) : base(player) { }

        public void Dribble()
        {
            Console.WriteLine("Midfielder is dribbling ...");
        }
    }
}
