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
    /// <summary>
    /// This represents the view of a Square.
    /// </summary>
    public class SquareView : Button
    {
        // styling
        private static readonly Brush HighlightColor = Brushes.LightGreen;

        private bool isHighlighted;

        public Brush SquareColor { get; set; }
        public PieceView PieceView { get; private set; }

        public SquareView()
        {
            Background = Brushes.White;
            BorderBrush = Brushes.Black;
            BorderThickness = new Thickness(3);

            // default color, but should never be visible unless something didn't setup correctly
            SquareColor = Brushes.Magenta;
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
                    squareView.SquareColor = Brushes.Gray;
                    break;
                case Checkers.Model.Color.Red:
                    squareView.SquareColor = Brushes.White;
                    break;
            }
            squareView.Background = squareView.SquareColor;
            return squareView;
        }
        public void ToggleHighlight()
        {
            // toggle flag
            isHighlighted = isHighlighted ? false : true;

            // update background style
            Background = isHighlighted ? HighlightColor : SquareColor;
        }

        public void ClearHighlight()
        {
            isHighlighted = false;
            Background = SquareColor;
        }
    }
}
