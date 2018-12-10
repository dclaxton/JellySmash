using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JewelMatching
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameModel model;
        private GameView view;

        public MainWindow()
        {
            InitializeComponent();
            world.Focus();
            
            this.model = new GameModel(12, 10);
            this.view = new GameView(world, model);
            this.view.Update();
        }

        private void world_MouseDown(object sender, MouseButtonEventArgs e)
        {
            double x = e.GetPosition(this).X;
            double y = e.GetPosition(this).Y;
            model.RegisterClick(x, y);
            view.Update();
        }
    }
}
