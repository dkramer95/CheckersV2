using Checkers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CheckersGUI
{
    public class SquareView : Button
    {
        public PieceView PieceView { get; private set; }

        public SquareView()
        {
            Background = Brushes.White;
            BorderBrush = Brushes.Black;
            BorderThickness = new Thickness(3);
        }

        public void SetPieceView(PieceView pieceView)
        {
            Content = pieceView;
        }

        public static SquareView FromColor(Checkers.Model.Color color)
        {
            SquareView squareView = new SquareView();

            switch (color)
            {
                case Checkers.Model.Color.Black:
                    squareView.Background = Brushes.Gray;
                    break;
                case Checkers.Model.Color.Red:
                    squareView.Background = Brushes.White;
                    break;
            }
            return squareView;
        }
    }
}
