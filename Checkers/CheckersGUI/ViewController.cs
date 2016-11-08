using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkers.Model;

namespace CheckersGUI
{
    /// <summary>
    /// This class will handle communication between the model and the view.
    /// </summary>
    public class ViewController
    {
        public BoardView BoardView { get; private set; }

        public ViewController()
        {
            Init();
        }


        private void Init()
        {
            BoardView = new BoardView();
        }

        public void AddPiecesToView(Dictionary<Position, Square> boardSquares)
        {
            foreach (Position p in boardSquares.Keys)
            {
                Square square = boardSquares[p];

                if (square.HasPiece())
                {
                    int index = SquareViewIndexFromPosition(p);
                    Piece piece = square.Piece;

                    string imgPath = GetImagePathFromPiece(piece);
                    PieceView pieceView = PieceView.FromPath(imgPath);
                    BoardView.Squares[index].SetPieceView(pieceView);
                }
            }
        }

        private string GetImagePathFromPiece(Piece piece)
        {
            string imgPath = string.Format("res/{0}{1}.png", piece.Color.ToString(), piece.IsKing ? "_KING" : "");
            return imgPath;
        }


        /// <summary>
        /// Maps the position to the correct index in the BoardView
        /// </summary>
        /// <param name="pos">Position to map to index</param>
        /// <returns>index int value</returns>
        private int SquareViewIndexFromPosition(Position pos)
        {
            int col = pos.Column - 'A';
            int row = 8 - pos.Row;
            int index = Math.Abs((8 * row + col));
            return index;
        }

    }
}
