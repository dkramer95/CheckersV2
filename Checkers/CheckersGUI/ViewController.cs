using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkers.Model;
using System.Windows;
using System.Windows.Media;
using System.Threading;

namespace CheckersGUI
{
    /// <summary>
    /// This class will handle communication between the model and the view.
    /// </summary>
    public class ViewController
    {
        public GameController GameController { get; private set; }

        public BoardView BoardView { get; private set; }

        // Starting square we clicked on
        public SquareView StartSquare { get; private set; }

        // Ending square we clicked on
        public SquareView EndSquare { get; private set; }


        public ViewController(GameController gameController)
        {
            GameController = gameController;
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
                int viewIndex = SquareViewIndexFromPosition(p);
                SquareView squareView = BoardView.Squares[viewIndex];

                AddClickEvents(square, squareView);

                if (square.HasPiece())
                {
                    Piece piece = square.Piece;
                    string imgPath = GetImagePathFromPiece(piece);
                    PieceView pieceView = PieceView.FromPath(imgPath);
                    BoardView.Squares[viewIndex].SetPieceView(pieceView);
                }
            }
        }

        public void UpdateView(Dictionary<Position, Square> boardSquares)
        {
            foreach (Position p in boardSquares.Keys)
            {
                Square square = boardSquares[p];
                int viewIndex = SquareViewIndexFromPosition(p);
                SquareView squareView = BoardView.Squares[viewIndex];

                squareView.DataContext = square;

                if (square.HasPiece())
                {
                    Piece piece = square.Piece;
                    string imgPath = GetImagePathFromPiece(piece);
                    PieceView pieceView = PieceView.FromPath(imgPath);
                    BoardView.Squares[viewIndex].SetPieceView(pieceView);
                }
                else
                {
                    squareView.ClearPieceImage();
                }
            }
        }

        private string GetImagePathFromPiece(Piece piece)
        {
            string imgPath = string.Format("CheckersGUI.res.{0}{1}.png", piece.Color.ToString().ToUpper(), piece.IsKing ? "_KING" : "");
            return imgPath;
        }


        /// <summary>
        /// Maps the position to the correct index in the BoardView
        /// </summary>
        /// <param name="pos">Position to map to index</param>
        /// <returns>index int value</returns>
        public static int SquareViewIndexFromPosition(Position pos)
        {
            int col = pos.Column - 'A';
            int row = 8 - pos.Row;
            int index = Math.Abs((8 * row + col));
            return index;
        }

        private void AddClickEvents(Square squareModel, SquareView squareView)
        {
            squareView.DataContext = squareModel;
            squareView.Click += SquareView_Click;
        }

        public void ClearSquares()
        {
            if (StartSquare != null)
            {
                StartSquare.ClearHighlight();
                StartSquare = null;
            }

            if (EndSquare != null)
            {
                EndSquare.ClearHighlight();
                EndSquare = null;
            }
        }

        private void SquareView_Click(object sender, RoutedEventArgs e)
        {
            SquareView squareView = sender as SquareView;

            // haven't clicked the initial starting square yet
            if (StartSquare == null)
            {
                StartSquare = squareView;
                StartSquare.ToggleHighlight();
            }
            // we clicked on the same starting square -- clear out
            else if (StartSquare == squareView)
            {
                StartSquare.ClearHighlight();
                StartSquare = null;
                EndSquare = null;
            } 
            // both start and end are set, clear them out
            else if (StartSquare != null && EndSquare != null)
            {
                StartSquare.ClearHighlight();
                StartSquare = null;

                EndSquare.ClearHighlight();
                EndSquare = null;
            }
            // second click for end square
            else
            {
                EndSquare = squareView;
                GameController.Update();
            }
        }
    }
}
