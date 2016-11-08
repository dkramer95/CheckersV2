using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace CheckersGUI
{
    public class BoardView : UniformGrid
    {
        public List<SquareView> Squares { get; private set; }

        public BoardView()
        {
            Columns = 8;
            Rows = 8;
            AddSquares();
        }

        private void AddSquares()
        {
            Squares = new List<SquareView>();
            SquareView square = null;

            // vertical columns
            for (int j = 0; j < 8; ++j)
            {
                // horizontal rows
                for (int k = 0; k < 8; ++k)
                {
                    // alternate between colors
                    square = ((k + j) % 2 == 0) ?
                             SquareView.FromColor(Checkers.Model.Color.Black) :
                             SquareView.FromColor(Checkers.Model.Color.Red);

                    // TODO add pieces later
                    //PieceView piece = PieceView.FromPath("res/BLACK_KING.png"); 
                    //square.SetPieceView(piece);
                    AddSquare(square);
                }
            }
        }

        private void AddSquare(SquareView square)
        {
            Squares.Add(square);
            Children.Add(square);
        }
    }
}
