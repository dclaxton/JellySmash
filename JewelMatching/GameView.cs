using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace JewelMatching
{
    class GameView
    {

        TextBlock Score;
        /// <summary>
        /// Sets up the GameView by connecting the GameModel to
        /// the Canvas which is where the GameModel will be drawn.
        /// </summary>
        /// <param name="canvas">The canvas used for drawing.</param>
        /// <param name="model">The model that will be repersented.</param>
        public GameView(Canvas canvas, GameModel model, TextBlock score)
        {
            if (canvas == null)
            {
                throw new ArgumentNullException("canvas is null");
            }

            if (model == null)
            {
                throw new ArgumentNullException("model is null");
            }

            Score = score;
            Images = new ImageSelector();
            Canvas = canvas;
            Model = model;
        }

        /// <summary>
        /// Refreshes the canvas and redraws all of the tiles.
        /// </summary>
        public void Update()
        {
            Canvas.Children.Clear();
            Model.Board.Randomize();
            Model.GetTiles().ForEach(tile => WriteImageToCanvas(tile));
            Canvas.UpdateLayout();
        }

        /// <summary>
        /// Writes an image to the screen.
        /// </summary>
        /// <param name="tile">The image to write</param>
        private void WriteImageToCanvas(Tile tile)
        {
            Image image = new Image();

            image.Source = Images.Get(tile.Name);
            Canvas.SetTop(image, tile.Y);
            Canvas.SetLeft(image, tile.X);
            int test = Model.Board.Score;
            Score.Text = "Score: " + test;
            Canvas.Children.Add(image);
        }

        public Canvas Canvas { get; private set; }
        public TextBlock Block { get; private set; }
        public ImageSelector Images { get; private set; }
        public GameModel Model { get; private set; }
    }
}
