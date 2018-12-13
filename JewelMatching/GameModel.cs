using System;
using System.Collections.Generic;
using System.Windows;

namespace JewelMatching
{
    class GameModel : IViewable
    {
        public GameModel(int width, int height)
        {
            this.Board = new GameBoard(width, height);
            this.IsFirstClick = true;
            this.FirstX = 0;
            this.FirstY = 0;
        }

        public void RegisterClick(double x, double y)
        {
            if (IsFirstClick)
            {
                FirstX = (int)x / ImageSelector.IMAGE_WIDTH;
                FirstY = (int)y / ImageSelector.IMAGE_HEIGHT;
                IsFirstClick = false;
            }
            else
            {
                Board.Swap(FirstX, FirstY, (int)x / ImageSelector.IMAGE_WIDTH, (int)y / ImageSelector.IMAGE_HEIGHT);
                IsFirstClick = true;
                Board.Update();
            }
        }

        internal GameBoard Board { get; private set; }
        public bool IsFirstClick { get; private set; }
        public int FirstX { get; private set; }
        public int FirstY { get; private set; }

        public List<Tile> GetTiles()
        {
            return Board.GetTiles();
        }
    }
}