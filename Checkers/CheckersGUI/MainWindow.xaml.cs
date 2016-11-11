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
using Checkers.Controller;
using Checkers.Model;

namespace CheckersGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameController GameController { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            CreateGame();
        }

        private void CreateGame()
        {
            GameController = new GameController();
            InitView();
            GameController.StartGame();
        }

        private void InitView()
        {
            // add view to this window
            boardPanel.Children.Add(GameController.ViewController.BoardView);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
}
