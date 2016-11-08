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
        private static readonly int COLUMN_COUNT = 8;
        private static readonly int ROW_COUNT = 8;

        public List<SquareView> Squares { get; private set; }

        public BoardView()
        {
            Init();
        }

        private void Init()
        {
            Columns = COLUMN_COUNT; 
            Rows = ROW_COUNT;
            Squares = new List<SquareView>();
            CreateSquares();
        }

        private void CreateSquares()
        {
            // vertical columns
            for (int col = 0; col < COLUMN_COUNT; ++col)
            {
                // horizontal rows
                for (int row = 0; row < ROW_COUNT; ++row)
                {
                    // alternate between colors
                    SquareView square = ((row + col) % 2 == 0) ?
                                         SquareView.FromColor(Checkers.Model.Color.Black) :
                                         SquareView.FromColor(Checkers.Model.Color.Red);
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
