namespace Task4
{
    public class Defender : PlayerRole
    {
        public Defender(Player player) : base(player) { }

        public void Defend()
        {
            Console.WriteLine("Defender is defending ...");
        }
    }
}
