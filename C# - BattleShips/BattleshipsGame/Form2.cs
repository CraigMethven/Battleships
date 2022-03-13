using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;


//Alina Craig Andres
//AC22005
//Project Battleship
//Team 12

namespace BattleshipsGame
{
    public partial class Battleship : Form
    {
        //GLOBAL VARIABLES!!
        private int maxX = 10;
        private int maxY = 10;
        public int startingShipSize = 5;
        private int squareSize;
        private gridSquare[,] myGrid;
        private gridSquare[,] enemyGrid;
        private Random r;
        public static int fontSize = 55;
        public static string font = "Courier New";
        public static int timepassed = 0;
        public static int movesCount = 0;
        //Class for grid squares
        public class gridSquare
        {
            //Class Variables
            /*
             * Static Variables
            */
            //Default Colours
            public static Color colourEmptySquare = Color.Blue;
            public static Color colourHitEmptySquare = Color.Black;
            public static Color colourShipSquare = Color.Gray;
            public static Color colourHitShipSquare = Color.Red;
            public static Color colourHover = Color.Green;
            //Keeps track of what turn it is
            public static string turn;

            //Square size in pixels
            public static int squareSize;
            //The current ship, that's to be placed, length
            public static int currentShipSize;
            //How many ships have been killded
            public static int enemyShipsLeft;
            //How many of our ships have been killed
            public static int allyShipsLeft;
            //How many tries so far
            public static int NumberOfTries = 0;            //TODO implement counter for highscore
            //The height & width of the grid
            public static int maxY;
            public static int maxX;
            //The name of the ship currently being placed (so that I know when it's been destroyed) (sadnly I cant name it "Sinking Bottom")

            public static int tempShipname = 1;
            //Says if the ship is to go horizontal or verticle
            public static bool rotated;
            //To see if the second 3 long one has been placed
            public static bool secondY;
            public static int startingShipSize;
            public static bool easyMode;
            public static string filePath = Directory.GetCurrentDirectory() + @"\..\..\Resources\";
            public static System.Media.SoundPlayer explode = new System.Media.SoundPlayer(filePath + "explode.wav");
            public static System.Media.SoundPlayer splash = new System.Media.SoundPlayer(filePath + "sploosh.wav");

            //Form stuff
            public static Label msgBx;
            public static Form myForm;
            public static Panel rotateBtn;
            public static Label scoreLbl;
            public static ProgressBar scoreBox;
            public static Label lblcounter;
            public static Label moves;

            /*
             * Non Static variables
            */
            //If this is an enemy square
            private bool enemy = false;
            //The x and & of this square
            private int x;
            private int y;
            //The visable square
            Label lbl = new Label();
            //If the space has been shot with a ball
            private bool hit = false;
            //If the space contains a ship
            private bool shipspace = false;
            //Name of the current ship
            private int shipName;
            //A local version of the grid it is in and the opposite grid
            private gridSquare[,] grid;
            private gridSquare[,] oppositeGrid;

            //Constructor
            public gridSquare(int tempX, int tempY, bool tempEnemy, gridSquare[,] tempGrid, gridSquare[,] tempGridEnemy, int tempWidth = 0, int tempHeight = 0)
            {
                //Setting class variables
                this.enemy = tempEnemy;
                this.x = tempX;
                this.y = tempY;
                this.grid = tempGrid;
                this.oppositeGrid = tempGridEnemy;
                //Adding the visable label
                lbl.BackColor = colourEmptySquare;
                lbl.SetBounds(tempWidth + (squareSize + 1) * x, tempHeight + (squareSize + 1) * y, squareSize, squareSize);
                myForm.Controls.Add(lbl);
                lbl.Click += new EventHandler(this.lblEvent_Click);
                lbl.MouseEnter += new EventHandler(this.lblEvent_OnMouseEnter);
                lbl.MouseLeave += new EventHandler(this.lblEvent_OnMouseLeave);
            }

            /*
             * Getters and Setters 
            */

            //Returns ship name
            public int getShipname()
            {
                return (shipName);
            }

            //Returns if the space has been hit
            public bool getHit()
            {
                return (hit);
            }

            //Returns if the space is a ship space
            public bool getShip()
            {
                return shipspace;
            }

            //Used to grab the label
            public Label getLabel()
            {
                return lbl;
            }

            //Sets the name of the ship
            public void setShipName(int tempInt)
            {
                this.shipName = tempInt;
            }

            //Used when placing ships on the board it sets shipspace and changes the colour of the grid space
            public void setShip(bool tempBool)
            {
                this.shipspace = tempBool;
                this.shipName = tempShipname;
                if (this.hit == true)
                {
                    //Play "metal clanky noise" noise
                    lbl.BackColor = colourShipSquare;
                }
            }

            //Sets if the space on the grid has been hit and if so changes the colour in accordance to what sorta space it hit
            //Returns true if ship was hit, else returns false
            public bool setHit(bool tempBool)
            {

                //Sets hit variable
                this.hit = tempBool;
                //If it hits a ship
                if (this.hit == true && this.shipspace == true)
                {
                    
                    //Play "Bangy explody" noise TOOOOOOOOOOOOOOOOOOOOOOOOOOOO DOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                    //Set colour
                    lbl.BackColor = colourHitShipSquare;
                    //Check if ship hasn't been destroyed && the player destroyed it
                    if (checkIfShipDestroyed(true) == false && enemy == true)
                    {
                        //Print the message for 1 second
                        msgBx.Visible = true;
                        msgBx.Text = "SHIP HIT";
                        setTimerMessage(1000);
                    }
                    return true;
                }
                //Is space wasn't a ship set the colour
                else if (this.shipspace == false && this.hit == true)
                {
                    splash.Play();
                    lbl.BackColor = colourHitEmptySquare;
                }
                
                return false;
            }

            //Checks if the game is to end and if so who won it
            public void checkIfGameEnd()
            {
                bool done = false;
                string hitMessage = "Why are you looking here? Go away!";
                //If ally has no ships left
                if (allyShipsLeft == 0)
                {
                    hitMessage = "BOOOOOOOOO";
                    done = true;
                }
                //If enemy has no ships left
                else if(enemyShipsLeft == 0)
                {
                    hitMessage = "WOO HOO!";
                    done = true;
                }
                //If game is to end
                if (done == true)
                {
                    //Setting the msgBx to the correct stuff
                    gridSquare.msgBx.SetBounds((myForm.Size.Width - hitMessage.Length * fontSize) / 2, (myForm.Size.Height - 15) / 5 * 2, fontSize * hitMessage.Length, fontSize * 3 / 2);
                    msgBx.Text = hitMessage;
                    msgBx.Visible = true;
                    //Timer for when game is to end. The timer is needed so that the screen updates to give the win message before the thread freezes
                    var timer = new System.Windows.Forms.Timer();
                    timer.Interval = 700;
                    timer.Tick += (s, b) =>
                    {
                        //save the scores on a file
                        //"U:\Documents\Battleships\BattleshipsGame\scores.txt
                        StreamWriter w = new StreamWriter(filePath + "scores.txt", true);
                        w.WriteLine(movesCount + "\t" + "\t" + timepassed + " seconds");
                        w.Write(w.NewLine);
                        /*w.WriteLine("Sobreescribe."); // Write to file*/
                        w.Close();

                        Thread.Sleep(4000);
                        myForm.Close();
                        timer.Stop();
                    };
                    timer.Start();
                }


            }

            //Sets a timer for the time given which flips the visability of the msgBx to false
            public void setTimerMessage(int time)
            {
                msgBx.Visible = true;
                //Sets size of the box
                gridSquare.msgBx.SetBounds((myForm.Size.Width - msgBx.Text.Length * fontSize) / 2, (myForm.Size.Height - 15) / 5 * 2, fontSize * msgBx.Text.Length, fontSize * 3 / 2);
                //Sets a timer for the time given which flips the visability of the msgBx to false
                var timer = new System.Windows.Forms.Timer();
                timer.Interval = time;
                timer.Tick += (s, e) =>
                {
                    msgBx.Visible = false;
                    timer.Stop();
                };
                timer.Start();
            }

            //Check to see if a ship has been destroyed
            public bool checkIfShipDestroyed(bool actualCheck)
            {
                //For all grid squares 
                for (int i = 0; i < maxX; i++)
                {
                    for (int counter = 0; counter < maxY; counter++)
                    {
                        // check if the name of the ship of the current square exists anywhere else & if so if it hasn't been it.
                        if (grid[i, counter].getShipname() == shipName && grid[i, counter].getHit() == false)
                        {
                            //If so say the ship still exists
                            return false;
                        }
                    }
                }

                if (actualCheck)
                {
                    //If it is an enemy ship that was destroyed print ship destroyed
                    if (enemy == true)
                    {
                        Console.WriteLine("Ship Destroyed(YAY)");
                        msgBx.Text = "SHIP DESTROYED";
                        gridSquare.scoreBox.Value += 100 / startingShipSize;

                        setTimerMessage(2000);
                        //Minus 1 from the enemy ships
                        enemyShipsLeft--;
                        checkIfGameEnd();
                    }
                    else
                    {
                        Console.WriteLine("Ship Destroyed(BOO)");
                        //Minus 1 from the enemy ships
                        allyShipsLeft--;
                        checkIfGameEnd();
                    }
                    explode.Play();
                }
                
                return true;
            }

            //method for enemy turn
            //hits random spaces until player ship hit
            public void enemyTurn()
            {
                Random r = new Random();
                bool done = false;
                while (done == false)
                {
                    int tempX = r.Next(maxX);
                    int tempY = r.Next(maxY);
                    if (oppositeGrid[tempX, tempY].getHit() == false)
                    {
                        oppositeGrid[tempX, tempY].setHit(true);
                        done = true;
                    }
                }
            }

            static int savedX = 0;
            static int savedY = 0;
            static bool randomShoot = false;
            static int oldX = 0;
            static int oldY = 0;

            public void randomAI()
            {
                //if previous hit has been a ship
                if (randomShoot == true)
                {
                    //check above previous hit
                    //check if it is a valid tile and has not been shot
                    if ((savedY + 1) < maxY && oppositeGrid[savedX, savedY + 1].getHit() == false)
                    {
                        oppositeGrid[savedX, savedY + 1].setHit(true);

                        //check if you hit a ship
                        if (oppositeGrid[savedX, savedY + 1].getShip() == true)
                        {
                            //check if you destroyed the ship
                            if (oppositeGrid[savedX, savedY + 1].checkIfShipDestroyed(false) == false)
                            {
                                savedY++;
                            }
                            else
                            {
                                randomShoot = false;
                            }
                        }
                        else
                        {
                            savedX = oldX;
                            if (oldY != 0)
                            {
                                savedY = --oldY;
                            }
                            else
                            {
                                savedY = oldY;
                            }
                        }
                        return;
                    }
                    //check below previous hit
                    //check if it is a valid tile and has not been shot
                    if ((savedY) > 0 && oppositeGrid[savedX, savedY - 1].getHit() == false)
                    {
                        oppositeGrid[savedX, savedY - 1].setHit(true);
                        //check if you hit a ship
                        if (oppositeGrid[savedX, savedY - 1].getShip() == true)
                        {
                            //check if you destroyed the ship
                            //if you didnt destroyed the ship save the direction to keep shooting that way
                            if (oppositeGrid[savedX, savedY-1].checkIfShipDestroyed(false) == false)
                            {
                                savedY--;
                            }
                            //if you destroyed the ship go back to shoot randomly
                            else
                            {
                                randomShoot = false;
                            }
                        }
                        else
                        {
                            savedX = oldX;
                            if (oldY != maxY - 1)
                            {
                                savedY = ++oldY;
                            }
                            else
                            {
                                savedY = oldY;
                            }
                        }
                        return;
                    }
                    //check to the right of previous hit
                    //check if it is a valid tile and has not been shot
                    if ((savedX + 1) < maxX && oppositeGrid[savedX + 1, savedY].getHit() == false)
                    {
                        oppositeGrid[savedX + 1, savedY].setHit(true);
                        //check if you hit a ship
                        if (oppositeGrid[savedX + 1, savedY].getShip() == true)
                        {
                            //check if you destroyed the ship
                            //if you didnt destroyed the ship save the direction to keep shooting that way
                            if (oppositeGrid[savedX + 1, savedY].checkIfShipDestroyed(false) == false)
                            {
                                savedX++;
                            }
                            //if you destroyed the ship go back to shoot randomly
                            else
                            {
                                randomShoot = false;
                            }
                        }
                        else
                        {
                            savedY = oldY;
                            if (oldX != 0)
                            {
                                savedX = --oldX;
                            }
                            else
                            {
                                savedX = oldX;
                            }
                        }
                        return;
                    }
                    //check to the left of previous hit
                    //check if it is a valid tile and has not been shot
                    if ((savedX) > 0 && oppositeGrid[savedX - 1, savedY].getHit() == false)
                    {
                        oppositeGrid[savedX - 1, savedY].setHit(true);
                        //check if you hit a ship
                        if (oppositeGrid[savedX - 1, savedY].getShip() == true)
                        {
                            //check if you destroyed the ship
                            //if you didnt destroyed the ship save the direction to keep shooting that way
                            if (oppositeGrid[savedX - 1, savedY].checkIfShipDestroyed(false) == false)
                            {
                                savedX--;
                            }
                            //if you destroyed the ship go back to shoot randomly
                            else
                            {
                                randomShoot = false;
                            }

                        }
                        else
                        {
                            savedY = oldY;
                            if (oldX != maxX - 1)
                            {
                                savedX = ++oldX;
                            }
                            else
                            {
                                savedX = oldX;
                            }

                        }
                        return;
                    }
                }

                Random r = new Random();
                bool available = false;
                while (available == false)
                {
                    int tempX = r.Next(maxX);
                    int tempY = r.Next(maxY);
                    //check if the tile is hittable
                    if (oppositeGrid[tempX, tempY].getHit() == false)
                    {
                        oppositeGrid[tempX, tempY].setHit(true);
                        available = true;
                    }
                    //if the random shoot hits something, save the coordinate and modify the boolean to change the future behaviour of the method
                    if (oppositeGrid[tempX, tempY].getShip() == true && checkIfShipDestroyed(false) == false)
                    {
                        randomShoot = true;
                        savedX = tempX;
                        savedY = tempY;

                        oldX = savedX;
                        oldY = savedY;
                    }
                }
            }

            //When the square is clicked
            public void lblEvent_Click(object sender, EventArgs e)
            {
                //Add to number of tries for score

                //If it is the placement turn && it is the ally's turn && it is a possible space to click (as found by it being the hover colour)
                if (turn.Equals("Placement") && enemy == false && lbl.BackColor == colourHover)
                {
                    //For going verticle place ship
                    if (rotated == false)
                    {
                        for (int i = 0; i < currentShipSize; i++)
                        {
                            grid[x, i + y].setShip(true);
                            grid[x, i + y].getLabel().BackColor = colourShipSquare;
                        }
                    }
                    //For going horizontal place ship
                    else
                    {
                        for (int i = 0; i < currentShipSize; i++)
                        {
                            grid[x + i, y].setShip(true);
                            grid[x + i, y].getLabel().BackColor = colourShipSquare;
                        }
                    }
                    //Setting the next ships size
                    if (currentShipSize > 3 || (currentShipSize == 3 && secondY == true))
                    {
                        currentShipSize--;
                    }
                    //Since we want 2, 3 sizes just set this variable to say that it's been done
                    else if (currentShipSize == 3)
                    {
                        secondY = true;
                    }
                    //Set the turn to destroy if we just placed a 2.
                    else if (currentShipSize == 2)
                    {
                        turn = "Destroy";
                        NumberOfTries = 0;
                        //Hide rotate button
                        rotateBtn.Visible = false;
                        //display moves counter
                        gridSquare.moves.Visible = true;
                        //start timer
                        //timer1.Start();                                               //TODO timer start later
                    }
                    //Add 1 to the ship name so each ship has a unique identifier
                    tempShipname++;
                }

                /*
                If the turn is destroyed && the user clicks on the enemy grid
                */

                else if (turn.Equals("Destroy") && enemy == true)
                {
                    //If it is an avaliable space (hence if the hover colour)
                    if (lbl.BackColor == colourHover)
                    {
                        //Set hit
                        setHit(true);                        
                        //Time between your turn and the enemies
                        var timer = new System.Windows.Forms.Timer();
                        timer.Interval = 50;
                        timer.Tick += (s, b) =>
                        {
                            Thread.Sleep(200);

                            if(easyMode == false)
                            {
                                randomAI();
                            }
                            else
                            {
                                enemyTurn();
                            }
                            
                            movesCount++;
                            gridSquare.moves.Text = "Total moves: " + movesCount.ToString();
                            Console.WriteLine(movesCount);
                            timer.Stop();
                        };
                        timer.Start();
                    }
                }                
            }

            //When the square is hovered over
            public void lblEvent_OnMouseEnter(object sender, EventArgs e)
            {
                //For placing phase
                if (turn.Equals("Placement") && enemy == false)
                {
                    //For verticle
                    if (rotated == false)
                    { 
                        //If wouldn't overhang the map
                        if (y <= maxY - currentShipSize)
                        {
                            //Check to see if the square is already taken
                            bool empty = true;
                            for (int i = 0; i < currentShipSize; i++)
                            {
                                if (grid[x, i + y].getShip() == true)
                                {
                                    empty = false;
                                }

                            }
                            //if not paint square
                            if (empty == true)
                            {
                                for (int i = 0; i < currentShipSize; i++)
                                {
                                    grid[x, i + y].getLabel().BackColor = colourHover;
                                }
                            }
                        }
                    }
                    //for horizontal
                    else
                    {
                        //If wouldn't overhang the map
                        if (x <= maxX - currentShipSize)
                        {
                            //Check to see if the square is already taken
                            bool empty = true;
                            for (int i = 0; i < currentShipSize; i++)
                            {
                                if (grid[x + i, y].getShip() == true)
                                {
                                    empty = false;
                                }

                            }
                            //if not paint square
                            if (empty == true)
                            {
                                for (int i = 0; i < currentShipSize; i++)
                                {
                                    grid[x + i, y].getLabel().BackColor = colourHover;
                                }
                            }
                        }
                    }
                }

                //For the destroying phase
                else if (turn.Equals("Destroy") && enemy == true)
                {
                    //If hasn't been hit before set the back colour
                    if (hit == false)
                    {
                        lbl.BackColor = colourHover;
                    }
                }
            }

            //When we no longer hover over
            private void lblEvent_OnMouseLeave(object sender, EventArgs e)
            {
                //For placement phase
                if (turn.Equals("Placement") && enemy == false)
                {
                    //For verticle
                    if (rotated == false)
                    {
                        //If not overhanging
                        if (y <= maxY - currentShipSize)
                        {
                            //Set everything to the correct colour
                            for (int i = 0; i < currentShipSize; i++)
                            {
                                if (grid[x, i + y].getShip() == false)
                                {
                                    grid[x, i + y].getLabel().BackColor = colourEmptySquare;
                                }
                                else
                                {
                                    grid[x, i + y].getLabel().BackColor = colourShipSquare;
                                }
                            }
                        }
                    }
                    //Same but for horizontal
                    else
                    {
                        if (x <= maxX - currentShipSize)
                        {
                            for (int i = 0; i < currentShipSize; i++)
                            {
                                if (grid[x + i, y].getShip() == false)
                                {
                                    grid[x + i, y].getLabel().BackColor = colourEmptySquare;
                                }
                                else
                                {
                                    grid[x + i, y].getLabel().BackColor = colourShipSquare;
                                }
                            }
                        }
                    }
                }

                //If in destroying phase, set the colour back to empty square
                else if (turn.Equals("Destroy") && enemy == true)
                {
                    if (hit == false)
                    {
                        lbl.BackColor = colourEmptySquare;
                    }
                }
            }
        }
        //END of grid square class



        //Adds action to the rotate button
        public void rotateBtnEvent_Click(object sender, EventArgs e)
        {
            if (gridSquare.rotated)
            {
                gridSquare.rotated = false;
            }
            else
            {
                gridSquare.rotated = true;
            }

        }

        //Maximises window
        public void fullScreen()
        {
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
        }

        //Sets the grids up.
        public void initialiseGrids()
        {
            //Calculate central positions of the grids
            int gridWidth = maxX * (squareSize + 1);
            int gridHeight = maxY * (squareSize + 1);
            int myGridStartingWidth = (this.Size.Width / 4) - (gridWidth / 2);
            int enemyGridStartingWidth = 3 * (this.Size.Width / 4) - (gridWidth / 2);
            int gridStartingHeight = (this.Size.Height / 2) - (gridHeight / 2);

            //Initialising grids
            myGrid = new gridSquare[maxX, maxY];
            enemyGrid = new gridSquare[maxX, maxY];
            //Making grids have their grid squares
            for (int i = 0; i < maxX; i++)
            {
                for (int counter = 0; counter < maxY; counter++)
                {
                    //Call grids with their constructs
                    myGrid[i, counter] = new gridSquare(i, counter, false, myGrid, enemyGrid, myGridStartingWidth, gridStartingHeight);
                    enemyGrid[i, counter] = new gridSquare(i, counter, true, enemyGrid, myGrid, enemyGridStartingWidth, gridStartingHeight);
                }
            }
        }

        //Places enemies ships in random places
        public void setUpEnemyGrid()
        {
            r = new Random();
            bool used3 = false;
            //For all the ships needed
            while (gridSquare.currentShipSize != 1)
            {
                //For non rotated
                if (r.Next(2) == 1)
                {
                    //Set x and y
                    int y = r.Next(maxY - gridSquare.currentShipSize);
                    int x = r.Next(maxX);
                    //Check to see if any of the squares is already taken
                    bool empty = true;
                    for (int i = 0; i < gridSquare.currentShipSize; i++)
                    {
                        if (enemyGrid[x, i + y].getShip() == true)
                        {
                            empty = false;
                        }
                    }
                    //Set The square as ship square
                    if (empty == true)
                    {
                        for (int i = 0; i < gridSquare.currentShipSize; i++)
                        {
                            enemyGrid[x, i + y].setShip(true);
                            enemyGrid[x, i + y].setShipName(gridSquare.tempShipname);
                        }
                        gridSquare.tempShipname++;
                        //Goes to next Ship (if 3 just set used 3)
                        if (used3 == false && gridSquare.currentShipSize == 3){
                            used3 = true;
                        }
                        else{
                            gridSquare.currentShipSize--;
                        }
                    }
                }
                //For rotated (basically the same)
                else
                {
                    //Set x and y
                    int y = r.Next(maxY);
                    int x = r.Next(maxX - gridSquare.currentShipSize);
                    //Check to see if the square is already taken
                    bool empty = true;
                    for (int i = 0; i < gridSquare.currentShipSize; i++)
                    {
                        if (enemyGrid[x + i, y].getShip() == true)
                        {
                            empty = false;
                        }

                    }
                    //Paint square
                    if (empty == true)
                    {
                        for (int i = 0; i < gridSquare.currentShipSize; i++)
                        {
                            enemyGrid[x + i, y].setShip(true);
                            enemyGrid[x + i, y].setShipName(gridSquare.tempShipname);
                        }
                        gridSquare.tempShipname++;
                        //Goes to next ship
                        if (used3 == false && gridSquare.currentShipSize == 3)
                        {
                            used3 = true;
                        }
                        else
                        {
                            gridSquare.currentShipSize--;
                        }
                    }
                }
            }
            gridSquare.currentShipSize = startingShipSize;
            gridSquare.rotated = false;
        }

        //Makes things the correct size & initialises things
        public void initialise()
        {
            //Sets the form to the correct sizes
            fullScreen();
            timer1.Stop();
            timer1.Start();

            //Initialise grid square componants
            squareSize = (this.Size.Width / (maxX * 2)) * 9 / 10;
            gridSquare.turn = "Placement";
            gridSquare.secondY = false;
            gridSquare.NumberOfTries = 0;
            gridSquare.startingShipSize = this.startingShipSize;
            gridSquare.squareSize = squareSize;
            gridSquare.currentShipSize = startingShipSize;
            gridSquare.allyShipsLeft = startingShipSize;
            gridSquare.enemyShipsLeft = startingShipSize;
            gridSquare.myForm = this;
            gridSquare.maxX = maxX;
            gridSquare.maxY = maxY;

            //Setting up label for grogress bar
            gridSquare.scoreLbl = new Label();
            gridSquare.scoreLbl.SetBounds(this.Size.Width/2 - squareSize*3/2, squareSize/4, squareSize*3, squareSize/3);
            gridSquare.scoreLbl.BackColor = Color.Yellow;
            gridSquare.scoreLbl.ForeColor = Color.Black;
            gridSquare.scoreLbl.TextAlign = ContentAlignment.MiddleCenter;
            gridSquare.scoreLbl.Font = new Font(font, 15);
            gridSquare.scoreLbl.Text = "Ships destroyed";
            Controls.Add(gridSquare.scoreLbl);

            //Setting up the progress bar
            gridSquare.scoreBox = new ProgressBar();
            gridSquare.scoreBox.SetBounds(this.Size.Width/2 - squareSize*3/2, squareSize*2/3, squareSize*3, squareSize/4);
            gridSquare.scoreBox.Minimum = 0;
            gridSquare.scoreBox.Maximum = 100;
            gridSquare.scoreBox.Value = 0;
            Controls.Add(gridSquare.scoreBox);

            //Setting up the rotate button
            gridSquare.rotateBtn = new Panel();
            gridSquare.rotateBtn.SetBounds(0, 0, squareSize, squareSize);
            gridSquare.rotateBtn.BackColor = Color.Silver;
            Image rotate = Image.FromFile(gridSquare.filePath + "rotate.png");
            gridSquare.rotateBtn.BackgroundImage = rotate;
            gridSquare.rotateBtn.BackgroundImageLayout = ImageLayout.Stretch;
            gridSquare.rotateBtn.Click += new EventHandler(this.rotateBtnEvent_Click);
            Controls.Add(gridSquare.rotateBtn);

            //Setting the "ship destroyed label"
            gridSquare.msgBx = new Label();
            gridSquare.msgBx.Visible = false;
            gridSquare.msgBx.BackColor = Color.Transparent;
            gridSquare.msgBx.ForeColor = Color.Black;
            gridSquare.msgBx.TextAlign = ContentAlignment.MiddleCenter;
            gridSquare.msgBx.Font = new Font(font, fontSize);
            Controls.Add(gridSquare.msgBx);
            
            //setting up moves counter
            gridSquare.moves = new Label();
            gridSquare.moves.Font = new Font(font, 18);
            gridSquare.moves.SetBounds(this.Size.Width/6 - squareSize*3/2, squareSize/2, squareSize*3, squareSize/2);
            gridSquare.moves.TextAlign = ContentAlignment.MiddleCenter;
            gridSquare.moves.Text = "Total moves: " + movesCount.ToString();
            Controls.Add(gridSquare.moves);
            gridSquare.moves.Visible = false;
            gridSquare.moves.Update();


            //setting up timer
            gridSquare.lblcounter = new Label();
            gridSquare.lblcounter.Font = new Font(font, 18);
            gridSquare.lblcounter.SetBounds(this.Size.Width/4, squareSize/2, squareSize*3, squareSize/2);
            gridSquare.lblcounter.TextAlign = ContentAlignment.MiddleCenter;

            Controls.Add(gridSquare.lblcounter);

            //Initialises Grids
            initialiseGrids();

            //Let the enemy place their blocks
            setUpEnemyGrid();
        }
        //makes the timer work
        private void timer1_Tick(object sender, EventArgs e)
        {
            timepassed+=1;
            gridSquare.lblcounter.Text = TimeSpan.FromSeconds(timepassed).ToString();
            
        }

        //Constructors for the form
        public Battleship(int tempX, int tempY, int tempLength, bool tempDif)
        {
            InitializeComponent();
            this.maxX = tempX;
            this.maxY = tempY;
            this.startingShipSize = tempLength;
            gridSquare.easyMode = tempDif;
        }

            //When form loads (so start of game)
            private void BattleshipsGame_Load(object sender, EventArgs e)
        {
            //Initialise the grids
            initialise();
            //The rest is done from in the class with label hovers / clicks
        }

        //For top bar
        //exit menu item
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        //rules menu item
        private void RulesToolStripMenuItem_Click(object sender, EventArgs e)
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
    }
}