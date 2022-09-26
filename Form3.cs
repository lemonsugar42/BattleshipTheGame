using System.Windows.Forms;
using ExcelApp;

namespace BattleshipTheGame
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            Excel.Show(Form1.Player.Username, Form1.Player.Score.ToString(), out string[] usernames, out string[] scores);
            YourScore.Text = $"You scored {Form1.Player.Score}!";
            UNamesContent.Text = string.Concat<string>(usernames);
            USContent.Text = string.Concat<string>(scores);
        }
    }
}
