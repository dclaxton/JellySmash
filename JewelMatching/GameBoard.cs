using System;
using System.Collections.Generic;

namespace JewelMatching
{
    internal class GameBoard : IViewable
    {
        private int height;
        private int width;
        private readonly Random rand;

        /// <summary>
        /// Given a height and a width, this will initialize the Jelly Game Board.
        /// </summary>
        /// <param name="width">the board width</param>
        /// <param name="height">the board height</param>
        public GameBoard(int width, int height)
        {
            this.width = width;
            this.height = height;
            this.rand = new Random();
            this.Board = new JellyCode[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    this.Board[i, j] = SelectJelly();
                }
            }
        }
        
        /// <summary>
        /// Swaps two jelly icons on the board if they are next to each other.
        /// Each coordinate needs to be an index position into the array and not
        /// a mouse click location (because that's different).
        /// 
        /// </summary>
        /// <param name="i">x coordinate of first jelly</param>
        /// <param name="j">y coordinate of first jelly</param>
        /// <param name="p">x coordinate of second jelly</param>
        /// <param name="q">y coordinate of second jelly</param>
        /// <returns>True if the two jellies are next to each other and the swap is successful, false otherwise</returns>
        public bool Swap(int i, int j, int p, int q)
        {
            int diffip = i - p;
            int diffjq = j - q;

            if ( (diffip == 0 && (diffjq == -1 || diffjq == 1)) || (diffjq == 0 && (diffip == -1 || diffip == 1)))
            {
                JellyCode temp = Board[i, j];
                Board[i, j] = Board[p, q];
                Board[p, q] = temp;
                return true;
            }

            return false;
        }
        

        /// <summary>
        /// this is the method that scans for runs of 3,4, or 5 and updates the score accordingly.
        /// if the run is found the jellies in a run are replaced with an "EMPTY" type of jelly.
        /// </summary>
        public void Update()
        {
            CheckForRuns();
        }

        /// <summary>
        ///  the method that contains the algorithm for checking the runs
        /// </summary>
        private void CheckForRuns()
        {

            for(int i = 0; i < Board.Length; i++)
            {
                for(int j = 0; j < Board.Length; j++)
                {
                    //horizontal run of 3
                    if(Board[i,j-1] == Board[i,j] && Board[i,j] == Board[i,j+1])
                    {
                        //horizontal run of 4
                        if(Board[i,j-2] == Board[i,j] || Board[i,j+2] == Board[i,j])
                        {
                            //horizontal run of 5
                            if(Board[i,j-3] == Board[i,j] || Board[i,j+3] == Board[i,j])
                            {

                            }
                        }
                    }

                    //horizontal run of 3
                }
            }
        }

        /// <summary>
        /// Gets the name of a image based on the JellyCode.
        /// </summary>
        /// <param name="code">A Jelly code</param>
        /// <returns>The string representation of the code.</returns>
        private String GetName(JellyCode code)
        {
            switch (code)
            {
                case JellyCode.BLACK: return "black";
                case JellyCode.BLUE: return "blue";
                case JellyCode.GREEN: return "green";
                case JellyCode.PINK: return "pink";
                case JellyCode.RED: return "red";
                case JellyCode.YELLOW: return "yellow";
            }

            return "empty";
        } 

        /// <summary>
        /// Given a number from 0 to 5, this will return a Jelly code
        /// for that number. If the code is anything other than from 0 to 5,
        /// the method will return a code of "EMPTY".
        /// </summary>
        /// <param name="x">a number from 0 to 5</param>
        /// <returns>A jelly code for the passed number.</returns>
        private JellyCode SelectJelly()
        {
            int r = Randomize();

            switch (r)
            {
                case 0: return JellyCode.BLACK;
                case 1: return JellyCode.BLUE;
                case 2: return JellyCode.GREEN;
                case 3: return JellyCode.PINK;
                case 4: return JellyCode.RED;
                case 5: return JellyCode.YELLOW;
            }

            return JellyCode.EMPTY;
        }

        /// <summary>
        /// Gets all of the tiles necessary to be placed on the screen.
        /// </summary>
        /// <returns>The list of tiles to display.</returns>
        public List<Tile> GetTiles()
        {
            List<Tile> tiles = new List<Tile>();

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    String name = GetName(Board[i, j]);
                    tiles.Add(new Tile(Board[i, j], i * ImageSelector.IMAGE_WIDTH, j * ImageSelector.IMAGE_HEIGHT, name));
                }
            }

            return tiles;
        }

        /// <summary>
        /// Random number generator to assist with selecting random jellies
        /// </summary>
        /// <returns>ints 1-6 representing a jelly</returns>
        public int Randomize()
        {
            int jellytoMake = rand.Next(6);

            return jellytoMake;
        }

        public JellyCode[,] Board { get; private set; }
    }
}