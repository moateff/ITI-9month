namespace Task4
{
    public class Forward : PlayerRole
    {
        public Forward(Player player) : base(player) { }

        public void ShootGoal()
        {
            Console.WriteLine("Forward is shooting ...");
        }
    }
}