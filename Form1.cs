using System;
using System.Windows.Forms;
using User;

namespace BattleshipTheGame
{
    public partial class Form1 : Form
    {
        public static Player Player { get; set; }
        public Form1()
        {
            InitializeComponent();
            Player = new Player();
            Button.Click += Button_Click;
        }
        private void Button_Click(object sender, EventArgs e)
        {
            Player.Username = TextBox.Text;
            Form2 Game = new Form2();
            Game.Show(this);
            this.Hide();
        }
    }
}
