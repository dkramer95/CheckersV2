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
                    UpdateSquarePiece(square, viewIndex);
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
                    UpdateSquarePiece(square, viewIndex);
                }
                else
                {
                    squareView.ClearPieceImage();
                }
            }
        }

        /// <summary>
        /// Updates a square with a piece view representation
        /// </summary>
        /// <param name="square">Square model</param>
        /// <param name="viewIndex">index in boardsquares view</param>
        private void UpdateSquarePiece(Square square, int viewIndex)
        {
            Piece piece = square.Piece;
            string imgPath = GetImagePathFromPiece(piece);
            PieceView pieceView = PieceView.FromPath(imgPath);
            BoardView.Squares[viewIndex].SetPieceView(pieceView);
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
            int col = pos.Column - Board.MIN_COL;
            int row = Board.MAX_ROW - pos.Row;
            int index = Math.Abs((Board.MAX_ROW * row + col));
            return index;
        }

        private void AddClickEvents(Square squareModel, SquareView squareView)
        {
            squareView.DataContext = squareModel;
            squareView.Click += SquareView_Click;
        }

        public void ClearSquares()
        {
            foreach(SquareView squareView in BoardView.Squares)
            {
                squareView.SetNormalColor();
            }
            StartSquare = null;
            EndSquare = null;
        }

        private void SquareView_Click(object sender, RoutedEventArgs e)
        {
            SquareView clickedSquare = sender as SquareView;

            if (StartSquare == null)
            {
                // Only highlight if it has a piece
                Square square = clickedSquare.DataContext as Square;

                if (square.HasPiece())
                {
                    StartSquare = clickedSquare;
                    StartSquare.SetHighlightColor();
                    ShowMovePreviews();
                }
            }
            else if ((StartSquare == clickedSquare) || (StartSquare != null && EndSquare != null))
            {
                ClearSquares();
            }
            else
            {
                EndSquare = clickedSquare;
                GameController.Update();
            }
        }

        /// <summary>
        /// Returns a square (data model) from a position
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        private Square SquareFromPosition(Position pos)
        {
            Square square = SquareViewFromPosition(pos).DataContext as Square;
            return square;
        }

        /// <summary>
        /// Returns a square view from a position
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        private SquareView SquareViewFromPosition(Position pos)
        {
            int index = SquareViewIndexFromPosition(pos);
            SquareView squareView = BoardView.Squares[index];
            return squareView;
        }

        /// <summary>
        /// Shows a preview of all the squares you can move to
        /// </summary>
        private void ShowMovePreviews()
        {
            if (StartSquare != null)
            {
                List<Move> validMoves = GameController.GetValidMoves();

                foreach (Move m in validMoves)
                {
                    Square moveStartSquare = SquareFromPosition(m.StartPosition);
                    if (moveStartSquare == StartSquare.DataContext as Square)
                    {
                        SquareView moveEndSquare = SquareViewFromPosition(m.EndPosition);
                        moveEndSquare.SetPreviewColor();
                    }
                }
            }
        }
    }
}
