using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

//Alina Craig Andres
//AC22005
//Project Battleship
//Team 12

namespace BattleshipsGame
{
    public partial class MenuForm : Form
    {
        public int X = 10;
        public int Y = 10;
        public int length = 5;
        public bool dif = false;
        public MenuForm()
        {
            InitializeComponent();
        }

        public MenuForm(int maxX, int maxY, int tempLength, bool tempDif)
        {
            InitializeComponent();
            if (maxX < maxY)
            {
                int tempInt = maxX;
                maxX = maxY;
                maxY = tempInt;
            }
            this.X = maxX;
            this.Y = maxY;
            this.length = tempLength;
            this.dif = tempDif;
        }

        private void BtnStartGame_Click(object sender, EventArgs e)
        {
            Battleship gameForm = new Battleship(X, Y, length, dif);
            gameForm.Show();
        }

        private void ExitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Battleships in C# by Craig, Alina & Andres (c) 2020","About",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void BtnRules_Click(object sender, EventArgs e)
        {
            DialogResult result;
            string textRules;
            textRules = "Battleship Rules: \n\nGame Objective: \nThe object of Battleship is to try and sink all of the other player's before they sink all of your ships. " +
                "All of the other player's ships are somewhere on his/ her board. \nYou try and hit them by clicking on the coordinates of one of the squares on the opponent's board.  " +
                "The other player also tries to hit your ships. Neither you nor the other player can see the other's board so you must try to guess where they are. " +
                "Each board in the physical game has two grids:  the left one for the player's ships and the right for recording the player's guesses. " +
                "\n\nStarting a New Game: \nEach player places the ships somewhere on their board. The ships can only be placed vertically or horizontally. " +
                "The ships can be rotated by clicking on the rotate button in the top left corner." +
                "Ships may not overlap each other. No ships may be placed on another ship. " +
                "\nThe 5 ships for the default version are: " +
                "\n\nCarrier (5 spaces), \nBattleship (4), \nCruiser (3), \nSubmarine (3), and \nDestroyer (2). \n\n" +
                "Playing the Game Player's take turns guessing." +
                "Both players boards are marked:  red for hit, black for miss. " +
                "When all of the squares that one your ships occupies have been hit, the ship will be sunk.";


            result = MessageBox.Show(textRules, "Battleship Rules", MessageBoxButtons.OK);
        }
        private void MenuForm_Load(object sender, EventArgs e)
        {
            System.Media.SoundPlayer constantSea = new System.Media.SoundPlayer(Directory.GetCurrentDirectory() + @"\..\..\Resources\" + "constantSea.wav");
            constantSea.PlayLooping();
            this.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + @"\..\..\Resources\" + "jeff.jpg");
        }

        private void HighscoresBtn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Directory.GetCurrentDirectory() + @"\..\..\Resources\" + "scores.txt");
        }

        private void BtnOptions_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmOptions options = new FrmOptions();
            options.Closed += (s, args) => this.Close();
            options.Show();
            /*
            FrmOptions options = new FrmOptions();
            options.Show();
            Thread.Sleep(50);
            this.Close();
            */
        }
    }
}
