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
                FirstX = (int)x + ImageSelector.IMAGE_WIDTH / 2;
                FirstY = (int)y + ImageSelector.IMAGE_HEIGHT / 2;
                IsFirstClick = false;
            }
            else
            {
                foreach (var tile in Board.GetTiles())
                {
                     if( FirstX < tile.X + ImageSelector.IMAGE_WIDTH && FirstX > tile.X
                         && FirstY < tile.Y + ImageSelector.IMAGE_HEIGHT && FirstY > tile.Y)
                     {
                         foreach(var t in Board.GetTiles())
                         {
                             if ((int)x < t.X + ImageSelector.IMAGE_WIDTH && (int)x > t.X
                             && (int)y < t.Y + ImageSelector.IMAGE_HEIGHT && (int)y > t.Y)
                             {
                                 MessageBox.Show("found both.");
                                 Board.Swap();
                                 break;
                             }
                         }
                     }
                }
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