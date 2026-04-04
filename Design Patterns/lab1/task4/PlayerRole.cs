namespace Task4
{
    public class PlayerRole : Player
    {
        protected Player _player;
        
        public PlayerRole(Player player)
        {
            _player = player;
        }

        public override void PassBall() {
            _player.PassBall();
        }

        public void AssignPlayer(Player player) {
            _player = player;
        }
    }
}