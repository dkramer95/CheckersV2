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
        private ViewController ViewController { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            CreateGame();
        }

        private void CreateGame()
        {
            //TODO:: this should be moved elsewhere, later

            // this should be selected through a menu system, later
            List<Player> players = new List<Player>() { new HumanPlayer(), new HumanPlayer() };
            Board.Reset();
            Board.Populate(players[0].Pieces, players[1].Pieces);
            InitView();
        }

        private void InitView()
        {
            ViewController = new ViewController();
            ViewController.AddPiecesToView(Board.GridSquares);
            // add view to this window
            boardPanel.Children.Add(ViewController.BoardView);
        }
    }
}
