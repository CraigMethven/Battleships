using System;
using System.Windows.Forms;

//Alina Craig Andres
//AC22005
//Project Battleship
//Team 12

namespace BattleshipsGame
{
    public partial class FrmOptions : Form
    {
        public int X = 10;
        public int Y = 10;
        public int length = 5;
        public bool dif = false;
        public FrmOptions()
        {
            InitializeComponent();
        }

        public void setLbl(string tempS)
        {
            lblError.Text = "Please enter a valid " + tempS;
        }

        private bool textToInt()
        {
            if (btnX.Text.Equals("") && btnY.Text.Equals("") && btnLength.Text.Equals("") && !CkBxDif.Checked)
            {
                return true;
            }
            try
            {
                X = Int32.Parse(btnX.Text);
            }
            catch (FormatException)
            {
                setLbl("width");
                return false;
            }
            try
            {
                Y = Int32.Parse(btnY.Text);
            }
            catch (FormatException)
            {
                setLbl("height");
                return false;
            }
            try
            {
                length = Int32.Parse(btnLength.Text);
            }
            catch (FormatException)
            {
                setLbl("number of ships");
                return false;
            }
            if(X<0 || Y<0 || length < 0)
            {
                setLbl("positive interger");
                return false;
            }
            if (X < 5 || X > 20)
            {
                setLbl("width between 5 and 20");
                return false;
            }
            if (Y < 5 || Y > 20)
            {
                setLbl("height between 5 and 20");
                return false;
            }
            if(length < 3 || length > X || length > Y)
            {
                setLbl("number of ships \nbetween 3 and the smaller width or height");
                return false;
            }

            dif = CkBxDif.Checked;

            return true;
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {

            if (textToInt())
            {
                this.Hide();
                MenuForm gameForm = new MenuForm(X, Y, length, dif);
                gameForm.Closed += (s, args) => this.Close();
                gameForm.Show();
            }
            
        }
    }
}
