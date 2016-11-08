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

            for (int j = 0; j < 64; ++j)
            {
                SquareView square = new SquareView();
                PieceView piece = new PieceView();
                piece.SetImagePath("res/BLACK_KING.png");
                square.SetPieceView(piece);
                Squares.Add(square);
                Children.Add(square);
            }
        }
    }
}
