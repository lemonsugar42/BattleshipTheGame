using BattleshipTheGame;

namespace User
{
    public class Player
    {
        public static readonly int X = Form2.CWidth / 2;
        public static readonly int Y = Form2.CHeight / 2;
        public const int Projectiles = 10;
        public string Username { get; set; }
        public int Score { get; set; }
        public int CurPrjct { get; set; }
        public Player()
        {
            Username = "Default username";
            Score = 0;
            CurPrjct = Projectiles;
        }
    }
}